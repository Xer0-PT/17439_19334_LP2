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
using System.Runtime.Serialization.Formatters.Binary;

namespace Pandemic
{
    [Serializable]
    public class Regions
    {
        #region Member Variables

        private static int currentRegionID;
        private int regionID;
        private string region;

        private const string CSVFILEPATH = @"..\..\Regions.csv";
        private const string BINARYFILEPATH = @"..\..\Regions.dat";

        private static List<Regions> regionsList = new List<Regions>();

        #endregion

        #region Constructors
        public Regions()
        {
            this.regionID = 0;
            this.region = "";
        }

        public Regions(string region)
        {
            this.regionID = Interlocked.Increment(ref currentRegionID);
            this.Region = region;
        }
        #endregion


        #region Properties

        public int CurrentRegionID { get => currentRegionID; }

        public int RegionID { get; set; }

        public string Region { get => region; set => region = value; }

        public List<Regions> RegionList { get => regionsList; }

        #endregion

        #region Functions

        /// <summary>
        /// Função para ler o ficheiro binário de Regiões e guardar na Lista de Regiões
        /// 
        /// Retorna verdadeiro se não houve problema
        /// Retorna falso se houve algum problema
        /// </summary>
        public bool LoadRegionsFromBinaryFile()
        {
            try
            {
                FileStream fs = new FileStream(BINARYFILEPATH, FileMode.Open, FileAccess.Read);
                BinaryFormatter bin = new BinaryFormatter();

                if (File.Exists(BINARYFILEPATH))
                {
                    regionsList = (List<Regions>)bin.Deserialize(fs);
                }
                else
                {
                    fs = File.Create(BINARYFILEPATH);
                    bin.Serialize(fs, regionsList);
                }

                fs.Close();

                Regions aux = regionsList.Last();
                currentRegionID = aux.regionID;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            
            return false;
        }

        /// <summary>
        /// Função para guardar a Lista de Regiões em Ficheiro Binário
        /// 
        /// Retorna verdadeiro se não houve problema
        /// Retorna falso se houve algum problema
        /// </summary>
        public bool SaveRegionsToBinaryFile()
        {
            try
            {
                FileStream fs = new FileStream(BINARYFILEPATH, FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(fs, regionsList);
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
        /// Função para ler o ficheiro CSV de Regiões e guardá-los em Lista
        /// 
        /// Retorna verdadeiro se não houve problema
        /// Retorna falso se houve algum problema
        /// </summary>
        public bool LoadRegionsFromCSVFile()
        {
            try
            {
                List<string> lines = File.ReadAllLines(CSVFILEPATH).ToList();

                foreach (var line in lines)
                {
                    string[] entrie = line.Split(';');

                    Regions newRegion = new Regions();

                    newRegion.RegionID = Convert.ToInt32(entrie[0]);
                    newRegion.region = entrie[1];

                    regionsList.Add(newRegion);
                }

                Regions aux = regionsList.Last();
                currentRegionID = aux.regionID;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            return false;
        }

        /// <summary>
        /// Função para guardar a lista de Regiões em ficheiro CSV
        /// 
        /// Retorna verdadeiro se não houve problema
        /// Retorna falso se houve algum problema
        /// </summary>
        public bool SaveRegionsToCSVFile()
        {
            try
            {
                List<string> output = new List<string>();

                foreach (var obj in regionsList)
                {
                    output.Add(obj.RegionID + ";" + obj.Region);
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
