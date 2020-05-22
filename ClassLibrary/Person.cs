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

        private const string CSVFILEPATH = @"..\..\Person.csv";
        private const string BINARYFILEPATH = @"..\..\Person.dat";

        private static List<Person> personList = new List<Person>();

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

        public List<Person> PersonList { get => personList; }

        #endregion


        #region Functions

        /// <summary>
        /// Função para guardar a Lista de Pessoas em Ficheiro Binário
        /// 
        /// Retorna verdadeiro se não houve problema
        /// Retorna falso se houve algum problema
        /// </summary>
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

        /// <summary>
        /// Função para ler o ficheiro binário de Pessoas e guardar na Lista de Pessoas
        /// 
        /// Retorna verdadeiro se não houve problema
        /// Retorna falso se houve algum problema
        /// </summary>
        public bool LoadPersonsFromBinaryFile()
        {
            try
            {
                FileStream fs = new FileStream(BINARYFILEPATH, FileMode.Open, FileAccess.Read);
                BinaryFormatter bin = new BinaryFormatter();

                if (File.Exists(BINARYFILEPATH))
                {
                    personList = (List<Person>)bin.Deserialize(fs);
                }
                else
                {
                    fs = File.Create(BINARYFILEPATH);
                    bin.Serialize(fs, personList);
                }
                fs.Close();

                Person aux = personList.Last();
                currentPersonID = aux.personID;
                
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            return false;
        }

        /// <summary>
        /// Função para guardar a lista de Pessoas em ficheiro CSV
        /// 
        /// Retorna verdadeiro se não houve problema
        /// Retorna falso se houve algum problema
        /// </summary>
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

        /// <summary>
        /// Função para ler o ficheiro CSV de Pessoas e guardá-los em Lista
        /// 
        /// Retorna verdadeiro se não houve problema
        /// Retorna falso se houve algum problema
        /// </summary>
        public bool LoadPersonsFromCSVFile()
        {
            try
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
                
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            return false;
        }

        /// <summary>
        /// Função com método alternativo ao foreach
        /// que recebe por parâmetro o id de Pessoa
        /// Se essa pessoa existir retorna a Pessoa
        /// Senão retorna nulo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Person ReturnPerson(int id)
        {
            var person = personList.Find(x => x.PersonID == id);
            
            if (person != null)
                return person;
            
            return null;
        }

        /// <summary>
        /// Função que recebe por parâmetro o id de pessoa inserido pelo utilizador
        /// se verifica se essa pessoa existe.
        /// Se existir retorna verdadeiro.
        /// Se não existir retorna falso.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckIfPersonExists(int id)
        {
            foreach (var person in personList)
            {
                if (person.PersonID == id)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Função que adiciona nova Pessoa à lista de Pessoas
        /// Se por acaso já existir o ID retorna falso
        /// Se não houver problema adiciona a pessoa e retorna verdadeiro
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool AddPerson(Person newPerson)
        {
            foreach (var person in personList)
            {
                if (newPerson.personID == person.PersonID)
                {
                    return false;
                }
            }
            personList.Add(newPerson);
            return true;
        }

        /// <summary>
        /// Função para retornar a lista de Pessoas
        /// Está a ser usada na função CountByAge e CountByGender da Classe Case
        /// </summary>
        public static List<Person> GetPersonList()
        {
            return personList;
        }

        /// <summary>
        /// Função para imprimir todas as Pessoas
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