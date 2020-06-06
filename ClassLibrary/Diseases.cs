/*
 * **
 * <copyright file = "Diseases"   Developer: Joel Martins / José Matos</copyright>
 * <author>Joel Martins / José Matos</author>
 * <email>a17439@alunos.ipca.pt</email>
 * <email>a19334@alunos.ipca.pt</email>
 * <date>6/6/2020 3:55:37 PM</date>
 * <description></description>
 * **
 */

using System.Collections.Generic;

namespace Pandemic
{
    class Diseases : Disease
    {
        #region Member Variables
        /// <summary>
        /// Declaração de uma lista de Doenças
        /// </summary>
        private static List<Disease> diseasesList = new List<Disease>();
        #endregion

        #region Properties
        /// <summary>
        /// Propriedade para obter a lista de doenças
        /// </summary>
        public List<Disease> DiseasesList { get => diseasesList; set => diseasesList = value; }
        
        #endregion

        #region Functions

        /// <summary>
        /// Função para adicionar nova doença à lista de doenças
        /// 
        /// Retorna falso se essa doença já existir.
        /// Retorna verdadeiro se adicionar.
        /// </summary>
        /// <param name="newDisease"></param>
        /// <returns></returns>
        public bool AddDiseaseToList(Disease newDisease)
        {
            if (DiseasesList.Contains(newDisease))
                return false;
            else
            {
                DiseasesList.Add(newDisease);
                return true;
            }
        }

        /// <summary>
        /// Função para remover uma doença da lista de doenças
        /// Retorna verdadeiro se conseguir
        /// Retorna falso se não conseguir
        /// </summary>
        /// <param name="disease"></param>
        /// <returns></returns>
        public bool RemoveDiseaseFromList(Disease disease)
        {
            return DiseasesList.Remove(disease);
        }

        /// <summary>
        /// Função para verificar através do ID se a doença existe
        /// Retorna falso se não existir
        /// Retorna verdadeiro se existir
        /// </summary>
        /// <param name="disease"></param>
        /// <returns></returns>
        public bool CheckIfDiseaseExists(Disease disease)
        {
            return DiseasesList.Contains(disease);
        }
        #endregion
    }
}
