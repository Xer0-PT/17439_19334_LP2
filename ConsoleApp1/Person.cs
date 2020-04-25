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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Person : Regions
    {
        #region Member Variables

        private static int currentPersonID;
        private int personID;
        private string name;
        private Genders gender;
        private int age;

        static Person[] personArray;

        #endregion


        #region Constructors
        public Person()
        {
            personArray = new Person[100];
        }

        public Person(string name, Genders gender, int age, int regionID)
        {
            this.personID = GetNextPersonID();
            this.name = name;
            this.gender = gender;
            this.age = age;
            this.RegionID = regionID;
        }

        #endregion


        #region Properties

        public int PersonID
        {
            get
            {
                return this.personID;
            }
            set
            {
                this.personID = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public Genders Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if(value < 0)
                {
                    this.age = -value;
                }
                else
                {
                    this.age = value;
                }
            }
        }
        #endregion


        #region Functions
        /// <summary>
        /// Função que percorre o array à procura de um espaço livre
        /// Retorna true se houver espaço livre e guarda lá os dados
        /// Retorna false se não houver espaço livre
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool AddPerson(Person person)
        {
            for (int i = 0; i < personArray.Length; i++)
            {
                if (personArray[i] == null)
                {
                    personArray[i] = person;

                    return true;
                }
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
        public static Person[] GetPersonArray()
        {
            return personArray;
        }

        /// <summary>
        /// Função simplesmente para imprimir a informação do array enquanto houver dados
        /// </summary>
        public void ShowPerson()
        {
            for (int i = 0; personArray[i] != null; i++)
            {
                Console.WriteLine("");
                Console.WriteLine("Codigo: {0} Nome: {1} Género: {2} Idade: {3} Regiao: {4}", personArray[i].PersonID,
                    personArray[i].Name, personArray[i].Gender, personArray[i].Age, personArray[i].RegionID);
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