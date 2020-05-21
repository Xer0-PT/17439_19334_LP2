/*
 * **
 * <copyright file = "Person"   Developer: Joel Martins / José Matos</copyright>
 * <author>Joel Martins / José Matos</author>
 * <email>a17439@alunos.ipca.pt</email>
 * <email>a19334@alunos.ipca.pt</email>
 * <date>4/24/2020 11:01:55 AM</date>
 * <description></description>
 * **
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Pandemic
{
    [CLSCompliant(true)]
    [Serializable]
    public class Person : Regions
    {
        #region Member Variables

        private static int currentPersonID;
        private int personID;
        private string firstName;
        private string lastName;
        private Genders gender;
        private int age;

        private const string CSVFILEPATH = @".\Person.csv";
        private const string BINARYFILEPATH = @".\Person.dat";

        static List<Person> personList = new List<Person>();

        #endregion


        #region Constructors
        public Person()
        {
            this.personID = 0;
            this.firstName = "";
            this.lastName = "";
            this.age = 0;
            this.gender = 0;
        }

        public Person(string firstName, string lastName, Genders gender, int age, int regionID)
        {
            //this.PersonID = GetNextPersonID();
            this.personID =  Interlocked.Increment(ref currentPersonID);
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.age = age;
            this.RegionID = regionID;
        }

        #endregion


        #region Properties

        public int CurrentPersonID { get => currentPersonID; }

        public int PersonID { get => this.personID ; set => this.personID = value; }

        public string FirstName { get => firstName; set => firstName = value; }

        public string LastName { get => lastName; set => lastName = value; }

        public Genders Gender { get => gender; set => gender = value; }

        public int Age { get => age; set => age = value; }

        #endregion


        #region Functions

        public bool SavePersonsToBinaryFile()
        {
            try
            {
                FileStream fs = new FileStream(BINARYFILEPATH, FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(fs, personList);
                fs.Close();

                return true;
            }
            catch (Exception e)
            {

                Console.WriteLine("Erro: " + e.Message);
            }
            return false;
        }

        public void LoadPersonsFromBinaryFile()
        {
            FileStream fs = new FileStream(BINARYFILEPATH, FileMode.Open, FileAccess.Read);
            BinaryFormatter bin = new BinaryFormatter();

            try
            {
                if (File.Exists(BINARYFILEPATH))
                {
                    personList = (List<Person>)bin.Deserialize(fs);
                }
                else
                {
                    fs = File.Create(BINARYFILEPATH);
                    bin.Serialize(fs, personList);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }

            fs.Close();

            Person aux = personList.Last();
            currentPersonID = aux.personID;
        }

        public bool SavePersonsToCSVFile()
        {
            try
            {
                List<string> output = new List<string>();

                foreach (var obj in personList)
                {
                    output.Add(obj.PersonID + ";" + obj.FirstName + ";" + obj.LastName + ";" + obj.Gender + ";" + obj.Age + ";" + obj.RegionID);
                }

                File.WriteAllLines(CSVFILEPATH, output);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            return false;
        }

        public void LoadPersonsFromCSVFile()
        {
            List<string> lines = File.ReadAllLines(CSVFILEPATH).ToList();

            foreach (var line in lines)
            {
                string[] entrie = line.Split(';');

                Person newPerson = new Person();

                newPerson.PersonID = Convert.ToInt32(entrie[0]);
                newPerson.FirstName = entrie[1];
                newPerson.LastName = entrie[2];
                newPerson.Gender = (Genders)Enum.Parse(typeof(Genders), entrie[3]);
                newPerson.Age = Convert.ToInt32(entrie[4]);
                newPerson.RegionID = Convert.ToInt32(entrie[5]);

                personList.Add(newPerson);
            }

            Person aux = personList.Last();
            currentPersonID = aux.PersonID;
        }

        public bool ValidatePersonID(int id)
        {
            foreach (var item in personList)
            {
                if (item.PersonID == id)
                    return true;
            }
            return false;
        }


        /// <summary>
        /// Função que percorre o array à procura de um espaço livre
        /// Retorna true se houver espaço livre e guarda lá os dados
        /// Retorna false se não houver espaço livre
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool AddPerson(Person person)
        {
            try
            {
                personList.Add(person);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            return false;
        }
        /// <summary>
        /// Retorna o próximo id de Pessoa válido
        /// </summary>
        /// <returns></returns>
        /*protected int GetNextPersonID()
        {
            return ++currentPersonID;
        }*/

        /// <summary>
        /// Função para retornar o array de Pessoas, caso seja necessário em outra classe
        /// </summary>
        /// <returns></returns>
        public static List<Person> GetPersonList()
        {
            return personList;
        }

        /// <summary>
        /// Função simplesmente para imprimir a informação do array enquanto houver dados
        /// </summary>
        public void ShowPerson()
        {
            foreach (var obj in personList)
            {
                Console.WriteLine("Codigo: {0}\tNome: {1} {2}\tGénero: {3}\tIdade: {4}\tRegiao: {5}", obj.PersonID, obj.FirstName, obj.LastName,
                    obj.Gender, obj.Age, obj.RegionID);
            }
        }
        #endregion


        #region Enums
        /// <summary>
        /// Enumerador para os Géneros
        /// </summary>
        public enum Genders
        {
            M,
            F
        }
        #endregion
    }
}