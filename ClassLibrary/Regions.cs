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
using System.Threading;

namespace Pandemic
{
    [Serializable]
    public class Regions
    {
        #region Member Variables

        private static int currentRegionID;
        private int regionID;
        private string region;

        private const string FILEPATH = @".\Regions.csv";

        static List<Regions> regionsList = new List<Regions>();

        #endregion


        #region Constructors
        public Regions()
        {
            this.regionID = 0;
            this.region = "";
        }

        public Regions(string region)
        {
            //this.RegionID = GetNextRegionID();
            this.regionID = Interlocked.Increment(ref currentRegionID);
            this.Region = region;
        }
        #endregion


        #region Properties

        public int CurrentRegionID { get => currentRegionID; }

        public int RegionID { get; set; }

        public string Region { get => region; set => region = value; }

        #endregion

        #region Functions

        public void LoadRegionsFromFile()
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

        public bool SaveRegionsToFile()
        {
            try
            {
                List<string> output = new List<string>();

                foreach (var obj in regionsList)
                {
                    output.Add(obj.RegionID + ";" + obj.Region);
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
        /// Função que adiciona uma Região à lista de Regiões
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
    }
}
