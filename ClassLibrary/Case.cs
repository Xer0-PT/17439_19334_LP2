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

namespace Pandemic
{
    public class Case : Person
    {
        #region Member Variables

        private static int currentCaseID;
        private int caseID;
        private bool infected;

        static List<Case> CaseList;

        #endregion


        #region Constructors
        public Case()
        {
            CaseList = new List<Case>();
        }

        public Case(int personId, bool infected)
        {
            this.caseID = GetNextCaseID();
            this.PersonID = personId;
            this.infected = infected;
        }
        #endregion


        #region Properties

        public int CaseID
        {
            get
            {
                return this.caseID;
            }
            set
            {
                this.caseID = value;
            }
        }

        #endregion


        #region Functions

        /// <summary>
        /// Função simplesmente para imprimir a informação do array enquanto houver dados
        /// </summary>
        public void ShowAllCases()
        {
            foreach (var obj in CaseList)
            {
                Console.WriteLine("Cdigo: {0}\tID Pessoa: {1}", obj.CaseID, obj.PersonID);
            }
        }
        /// <summary>
        /// Percorre o array de Casos e contabiliza todos os campos com dados
        /// </summary>
        /// <returns></returns>
        public int CountTotalCases()
        {
            return CaseList.Count;
        }

        /// <summary>
        /// Percorre a lista de Pessoas à procura de pessoas com idade igual à inserida pelo utilizador
        /// Não soubemos como implementar a procura a partir do ID de pessoa que está guardado no array de Casos
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public int CountByAge(int age)
        {
            int count = 0;

            List<Person> personList = GetPersonList();

            if (age < 0)
                age = - age;

            foreach (var obj in personList)
            {
                if (obj.Age == age)
                    count++;
            }
            return count;
        }

        /// <summary>
        /// Percorre a lista de Pessoas à procura de pessoas com género igual ao inserifo pelo utilizador
        /// Mais uma vez, não soubemos como implementar a procura a partir do ID de pessoa que está guardado no array de Casos
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public int CountByGender(Genders gender)
        {
            int count = 0;

            List<Person> personList = GetPersonList();

            foreach (var obj in personList)
            {
                if (obj.Gender == gender)
                    count++;
            }
            return count;
        }

        /// <summary>
        /// Conta o número de infectados
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
        /// Função que percorre o array à procura de um espaço livre
        /// Retorna true se houver espaço livre e guarda lá os dados
        /// Retorna false se não houver espaço livre
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

        /// <summary>
        /// Retorna o próximo ID de Caso válido
        /// </summary>
        /// <returns></returns>
        protected private int GetNextCaseID()
        {
            return ++currentCaseID;
        }

        /// <summary>
        /// Função para retornar o array de Casos, caso seja necessário noutra classe
        /// </summary>
        /// <returns></returns>
        public static List<Case> GetCaseList()
        {
            return CaseList;
        }
        #endregion


        #region Enums
        #endregion
    }
}
