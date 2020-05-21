/*
 * **
 * <copyright file = "Case"   Developer: Joel Martins / José Matos</copyright>
 * <author>Joel Martins / José Matos</author>
 * <email>a17439@alunos.ipca.pt</email>
 * <email>a19334@alunos.ipca.pt</email>
 * <date>4/24/2020 1:14:43 PM</date>
 * <description></description>
 * **
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Pandemic
{
    [Serializable]
    public class Case : Person
    {
        #region Member Variables

        private static int currentCaseID;
        private int caseID;
        private bool infected;

        static List<Case> CaseList = new List<Case>();

        private const string FILEPATH = @".\Case.csv";

        #endregion


        #region Constructors
        public Case()
        {
            this.caseID = 0;
            this.infected = false;
        }

        public Case(int personId, bool infected)
        {
            //this.CaseID = GetNextCaseID();
            this.caseID = Interlocked.Increment(ref currentCaseID);
            this.PersonID = personId;
            this.infected = infected;
        }
        #endregion


        #region Properties

        public int CurrentCaseID { get => currentCaseID; }

        public int CaseID { get => this.caseID; set => this.caseID = value; }

        public bool Infected { get => this.infected; set => this.infected = value; }

        #endregion


        #region Functions
        public void LoadCasesFromFile()
        {
            List<string> lines = File.ReadAllLines(FILEPATH).ToList();

            foreach (var line in lines)
            {
                string[] entrie = line.Split(';');

                Case newCase = new Case();

                newCase.CaseID = Convert.ToInt32(entrie[0]);
                newCase.PersonID = Convert.ToInt32(entrie[1]);
                newCase.Infected = bool.Parse(entrie[2]);

                CaseList.Add(newCase);
            }

            Case aux = CaseList.Last();
            currentCaseID = aux.CaseID;
        }

        public bool SaveCasesToFile()
        {
            try
            {
                List<string> output = new List<string>();

                foreach (var obj in CaseList)
                {
                    output.Add(obj.CaseID + ";" + obj.PersonID + ";" + obj.Infected);
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


        /// <summary>
        /// Função simplesmente para imprimir a informação do array enquanto houver dados
        /// </summary>
        public void ShowAllCases()
        {
            foreach (var obj in CaseList)
            {
                Console.WriteLine("Cdigo: {0}\tID Pessoa: {1}\tInfectado: {2}", obj.CaseID, obj.PersonID, obj.Infected);
            }
        }
        /// <summary>
        /// Retorna o número de Casos existentes
        /// </summary>
        /// <returns></returns>
        public int CountTotalCases()
        {
            return CaseList.Count;
        }

        /// <summary>
        /// Percorre cada Caso e compara o ID de Pessoa com cada ID na lista de Pessoas.
        /// Se o ID de Pessoa existir na lista de Casos, verifica se a idade da Pessoa
        /// é igual à idade inserida pelo utilizador, se for igual incrementa o contador.
        /// Dando assim a contagem de Pessoas, com idade igual à inserida pelo utilizador,
        /// que realmente representa um Caso.
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public int CountByAge(int age)
        {
            int count = 0;

            List<Person> personList = GetPersonList();

            if (age < 0)
                age = -age;

            foreach (var caso in CaseList)
            {
                foreach (var person in personList)
                {
                    if (caso.PersonID == person.PersonID)
                    {
                        if (person.Age == age)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// Percorre cada Caso e compara o ID de Pessoa com cada ID na lista de Pessoas.
        /// Se o ID de Pessoa existir na lista de Casos, verifica se o género da Pessoa
        /// é igual ao género inserido pelo utilizador, se for igual incrementa o contador.
        /// Dando assim a contagem de Pessoas, com género igual ao inserido pelo utilizador,
        /// que realmente representa um Caso.
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public int CountByGender(string gender)
        {
            int count = 0;

            Genders auxGender = (Genders)Enum.Parse(typeof(Genders), gender);

            List<Person> personList = GetPersonList();

            foreach (var caso in CaseList)
            {
                foreach (var person in personList)
                {
                    if (caso.PersonID == person.PersonID)
                    {
                        if (person.Gender == auxGender)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// Percorre cada Caso, se se tratar de um infectado incrementa o contador.
        /// Devolvendo o número de infectados.
        /// </summary>
        /// <returns></returns>
        public int CountInfected()
        {
            int count = 0;

            foreach (var item in CaseList)
            {
                if (item.infected == true)
                    count++;
            }
            return count;
        }

        /// <summary>
        /// Função que adiciona o novo Caso à lista de Casos
        /// </summary>
        /// <param name="newCase"></param>
        /// <returns></returns>
        public bool AddCase(Case newCase)
        {
            try
            {
                CaseList.Add(newCase);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            return false;
        }

        public bool CheckIfPersonHasCase(int id)
        {
            foreach (var caso in CaseList)
            {
                if (caso.PersonID == id)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Retorna o próximo ID de Caso válido
        /// </summary>
        /// <returns></returns>
        protected private int GetNextCaseID()
        {
            return ++currentCaseID;
        }

        /// <summary>
        /// Função para retornar a lista de Casos, caso seja necessário noutra classe
        /// </summary>
        /// <returns></returns>
        public static List<Case> GetCaseList()
        {
            return CaseList;
        }
        #endregion
    }
}
