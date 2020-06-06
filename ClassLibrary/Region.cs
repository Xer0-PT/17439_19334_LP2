/*
 * **
 * <copyright file = "Region"   Developer: Joel Martins / José Matos</copyright>
 * <author>Joel Martins / José Matos</author>
 * <email>a17439@alunos.ipca.pt</email>
 * <email>a19334@alunos.ipca.pt</email>
 * <date>4/24/2020 12:37:26 PM</date>
 * <description></description>
 * **
 */

using System.Threading;

namespace Pandemic
{
    public class Region
    {
        /// <summary>
        /// Conjunto de variáveis para a classe Região
        /// </summary>
        #region Member Variables

        private static int currentRegionID;
        private int regionID;
        private string regionName;

        #endregion

        #region Constructors

        /// <summary>
        /// Construtor por defeito, regista uma região com ID igual a zero e sem nada no nome da região
        /// </summary>
        public Region()
        {
            this.RegionID = 0;
            this.RegionName = "";
        }

        /// <summary>
        /// Construtor que recebe por parâmetro o nome da Região e incrementa automaticamente o ID, ficando assim com um ID único
        /// </summary>
        /// <param name="region"></param>
        public Region(string region)
        {
            this.RegionID = Interlocked.Increment(ref currentRegionID);
            this.RegionName = region;
        }
        #endregion


        #region Properties

        /// <summary>
        /// Propriedade para o actual ID de região
        /// </summary>
        public int CurrentRegionID { get => currentRegionID; set => currentRegionID = value; }

        /// <summary>
        /// Propiedade para o ID de Região
        /// </summary>
        public int RegionID { get; set; }

        /// <summary>
        /// Propriedade para o Nome da Região
        /// </summary>
        public string RegionName { get => regionName; set => regionName = value; }
        #endregion
    }
}
