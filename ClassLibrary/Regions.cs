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
using System.IO;
using System.Linq;

namespace Pandemic
{
    [Serializable]
    class Regions
    {
        #region Member Variables

        private static int currentRegionID;
        private int regionID;
        private string region;

        private const string FILEPATH = @"E:\Escola\2_Semestre\LP_2\TP1_V1.1\Saude_Publica\Files\Regions.csv";

        static List<Regions> regionsList;

        #endregion



        #region Constructors

        public Regions()
        {
            regionsList = new List<Regions>();
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

        public void LoadRegionsList()
        {
            List<string> lines = File.ReadAllLines(FILEPATH).ToList();

            foreach (var line in lines)
            {
                string[] entrie = line.Split(';');

                Regions newRegion = new Regions();

                newRegion.RegionID = Convert.ToInt32(entrie[0]);
                newRegion.region = entrie[1];

                regionsList.Add(newRegion);
            }
        }


        /// <summary>
        /// Função que percorre o array à procura de um espaço livre
        /// Retorna true se houver espaço livre e guarda lá os dados
        /// Retorna false se não houver espaço livre
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public bool AddRegion(Regions region)
        {
            try
            {
                regionsList.Add(region);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
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
        /// Função para imprimir todas as regiões
        /// </summary>
        public void ShowRegion()
        {
            foreach (var item in regionsList)
            {
                Console.WriteLine("Codigo: {0}\tRegião: {1}", item.RegionID, item.Region);
            }
        }

        #endregion

        #region Enums
        #endregion
    }
}
