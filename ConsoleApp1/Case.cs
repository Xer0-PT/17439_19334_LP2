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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Case : Person
    {
        #region Member Variables

        private static int currentCaseID;
        private int caseID;

        static Case[] caseArray;
        
        #endregion


        #region Constructors
        public Case()
        {
            caseArray = new Case[100];
        }

        public Case(int personId)
        {
            this.caseID = GetNextCaseID();
            this.PersonID = personId;
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
            Console.WriteLine("");
            for (int i = 0; caseArray[i] != null; i++)
            {
                Console.WriteLine("Codigo Caso: {0} ID Pessoa: {1}", caseArray[i].CaseID, caseArray[i].PersonID);
            }
        }
        /// <summary>
        /// Percorre o array de Casos e contabiliza todos os campos com dados
        /// </summary>
        /// <returns></returns>
        public int CountTotalCases()
        {
            int count = 0;
            foreach(Case x in caseArray)
            {
                if(x != null)
                    count++;
            }
            return count;
        }

        /// <summary>
        /// Percorre o array de Pessoas à procura de pessoas com idade igual à inserida pelo utilizador
        /// Não soubemos como implementar a procura a partir do ID de pessoa que está guardado no array de Casos
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public int CountByAge(int age)
        {
            int count = 0;

            Person[] personArray = GetPersonArray();

            foreach (Person x in personArray)
            {
                if (x != null)
                {
                    if (x.Age == age)
                        count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Percorre o array de Pessoas à procura de pessoas com género igual ao inserifo pelo utilizador
        /// Mais uma vez, não soubemos como implementar a procura a partir do ID de pessoa que está guardado no array de Casos
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public int CountByGender(Genders gender)
        {
            int count = 0;

            Person[] personArray = GetPersonArray();

            foreach (Person x in personArray)
            {
                if (x != null)
                {
                    if (x.Gender == gender)
                        count++;
                }
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
            for (int i = 0; i < caseArray.Length; i++)
            {
                if (caseArray[i] == null)
                {
                    caseArray[i] = newCase;

                    return true;
                }
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
        public static Case[] GetCaseArray()
        {
            return caseArray;
        }
        #endregion


        #region Enums
        #endregion
    }
}
