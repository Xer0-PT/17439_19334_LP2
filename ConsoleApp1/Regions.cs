/*
 * **
 * <copyright file = "Regions"   Developer: Joel Martins / José Matos</copyright>
 * <author>Joel Martins / José Matos</author>
 * <email>a17439@alunos.ipca.pt</email>
 * <email>a19334@alunos.ipca.pt</email>
 * <date>4/24/2020 12:37:26 PM</date>
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
    class Regions
    {
        #region Member Variables

        private static int currentRegionID;
        private int regionID;
        private string region;

        static Regions[] regionsArray;

        #endregion



        #region Constructors

        public Regions()
        {
            regionsArray = new Regions[100];
        }

        public Regions(string region)
        {
            this.regionID = GetNextRegionID();
            this.region = region;
        }
        
        #endregion



        #region Properties

        public int RegionID
        {
            get
            {
                return this.regionID;
            }
            set
            {
                this.regionID = value;
            }
        }

        public string Region
        {
            get
            {
                return this.region;
            }
            set
            {
                this.region = value;
            }
        }


        #endregion

        #region Functions
        /// <summary>
        /// Função que percorre o array à procura de um espaço livre
        /// Retorna true se houver espaço livre e guarda lá os dados
        /// Retorna false se não houver espaço livre
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public bool AddRegion(Regions region)
        {
            for (int i = 0; i < regionsArray.Length; i++)
            {
                if (regionsArray[i] == null)
                {
                    regionsArray[i] = region;

                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Retorna o próximo ID de Região válido
        /// </summary>
        /// <returns></returns>
        protected private int GetNextRegionID()
        {
            return ++currentRegionID;
        }

        /// <summary>
        /// Função simplesmente para imprimir a informação do array enquanto houver dados
        /// </summary>
        public void ShowRegion()
        {
            Console.WriteLine("");
            for (int i = 0; regionsArray[i] != null; i++)
            {
                Console.WriteLine("Codigo: {0} Região: {1}", regionsArray[i].regionID, regionsArray[i].region);
            }
        }

        #endregion

        #region Enums
        #endregion
    }
}
