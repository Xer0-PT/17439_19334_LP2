/*
 * **
 * <copyright file = "Regions"   Developer: Joel Martins / José Matos</copyright>
 * <author>Joel Martins / José Matos</author>
 * <email>a17439@alunos.ipca.pt</email>
 * <email>a19334@alunos.ipca.pt</email>
 * <date>6/6/2020 6:16:03 PM</date>
 * <description></description>
 * **
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Pandemic
{
    [Serializable]
    class Regions : Region
    {
        #region Member Variables
        /// <summary>
        /// Declaração de variáveis para classe Regiões
        /// </summary>
        private const string CSVFILEPATH = @"..\..\Regions.csv";
        private const string BINARYFILEPATH = @"..\..\Regions.dat";

        private static List<Region> regionsList = new List<Region>();
        #endregion

        #region Properties

        /// <summary>
        /// Propriedade para a Lista de Regiões
        /// </summary>
        public List<Region> RegionsList { get => regionsList; set => regionsList = value; }
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
                    RegionsList = (List<Region>)bin.Deserialize(fs);
                }
                else
                {
                    fs = File.Create(BINARYFILEPATH);
                    bin.Serialize(fs, RegionsList);
                    CurrentRegionID = 0;
                }

                fs.Close();

                Region aux = regionsList.Last();
                CurrentRegionID = aux.RegionID;

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

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
                bin.Serialize(fs, RegionsList);
                fs.Close();

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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

                    Region newRegion = new Region();

                    newRegion.RegionID = Convert.ToInt32(entrie[0]);
                    newRegion.RegionName = entrie[1];

                    RegionsList.Add(newRegion);
                }

                Region aux = regionsList.Last();
                CurrentRegionID = aux.RegionID;

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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
                    output.Add(obj.RegionID + ";" + obj.RegionName);
                }

                File.WriteAllLines(CSVFILEPATH, output);

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        /// <summary>
        /// Função que adiciona uma Região à lista de Regiões
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public bool AddRegion(Region region)
        {
            /* Código foi alterado de acordo com a sugestão do Professor, para a seguinte forma: */
            if (RegionsList.Contains(region))
                return false;
            else
            {
                RegionsList.Add(region);
                return true;
            }


            /* De seguida fica o código tal como estava antes da defesa com o Professor */

            /*
             * 
            
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
            
             */
        }

        /// <summary>
        /// Função para verificar se uma Região existe na lista de Regiões
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckIfRegionExists(int id)
        {
            var region = RegionsList.Find(x => x.RegionID == id);

            if (region != null)
                return true;

            return false;
        }

        /// <summary>
        /// Função para imprimir todas as regiões
        /// </summary>
        public void ShowRegion()
        {
            foreach (var item in RegionsList)
            {
                Console.WriteLine("Codigo: {0}\tRegião: {1}", item.RegionID, item.RegionName);
            }
        }
        #endregion
    }
}
