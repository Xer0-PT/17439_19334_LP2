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

        private const string FILEPATH = @".\Person.csv";

        static List<Person> PersonList = new List<Person>();

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
            this.personID = GetNextPersonID();
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.age = age;
            this.RegionID = regionID;
        }

        #endregion


        #region Properties

        public int CurrentPersonID { get => currentPersonID; }

        public int PersonID { get ; set ; }

        public string FirstName { get => firstName; set => firstName = value; }

        public string LastName { get => lastName; set => lastName = value; }

        public Genders Gender { get => gender; set => gender = value; }

        public int Age { get => age; set => age = value; }

        #endregion


        #region Functions

        public bool SavePersonsToFile()
        {
            try
            {
                List<string> output = new List<string>();

                foreach (var obj in PersonList)
                {
                    output.Add(obj.PersonID + ";" + obj.FirstName + ";" + obj.LastName + ";" + obj.Gender + ";" + obj.Age + ";" + obj.RegionID);
                }

                File.WriteAllLines(FILEPATH, output);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            return false;
        }

        public void LoadPersonsFromFile()
        {
            List<string> lines = File.ReadAllLines(FILEPATH).ToList();

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

                PersonList.Add(newPerson);
            }

            Person aux = PersonList.Last();
            currentPersonID = aux.PersonID;
        }


        public bool ValidatePersonID(int id)
        {
            foreach (var item in PersonList)
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
                PersonList.Add(person);
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
        protected int GetNextPersonID()
        {
            return ++currentPersonID;
        }

        /// <summary>
        /// Função para retornar o array de Pessoas, caso seja necessário em outra classe
        /// </summary>
        /// <returns></returns>
        public static List<Person> GetPersonList()
        {
            return PersonList;
        }

        /// <summary>
        /// Função simplesmente para imprimir a informação do array enquanto houver dados
        /// </summary>
        public void ShowPerson()
        {
            foreach (var obj in PersonList)
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