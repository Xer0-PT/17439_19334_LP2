/*
 * **
 * <copyright file = "Symptoms"   Developer: Joel Martins / José Matos</copyright>
 * <author>Joel Martins / José Matos</author>
 * <email>a17439@alunos.ipca.pt</email>
 * <email>a19334@alunos.ipca.pt</email>
 * <date>6/6/2020 4:39:25 PM</date>
 * <description></description>
 * **
 */

using System.Collections.Generic;

namespace Pandemic
{
    public class Symptoms : Symptom
    {
        #region Member Variables
        /// <summary>
        /// Declaração de uma lista de sintomas
        /// </summary>
        private static List<Symptom> symptomsList = new List<Symptom>();
        #endregion

        #region Properties
        /// <summary>
        /// Propriedade para obter a lista de doenças
        /// </summary>
        public List<Symptom> SymptomsList { get => symptomsList; set => symptomsList = value; }
        #endregion

        #region Functions
        /// <summary>
        /// Função para adicionar novo sintoma à lista de sintomas
        /// 
        /// Retorna falso se essa doença já existir.
        /// Retorna verdadeiro se adicionar.
        /// </summary>
        /// <param name="newDisease"></param>
        /// <returns></returns>
        public bool AddSymptomToList(Symptom newSymptom)
        {
            if (SymptomsList.Contains(newSymptom))
                return false;
            else
            {
                SymptomsList.Add(newSymptom);
                return true;
            }
        }

        /// <summary>
        /// Função para remover um sintoma da lista de sintomas
        /// Retorna verdadeiro se conseguir
        /// Retorna falso se não conseguir
        /// </summary>
        /// <param name="symptom"></param>
        /// <returns></returns>
        public bool RemoveSymptomFromList(Symptom symptom)
        {
            return SymptomsList.Remove(symptom);
        }

        /// <summary>
        /// Função para verificar através do ID se o sintoma existe
        /// Retorna falso se não existir
        /// Retorna verdadeiro se existir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckIfSymptomExists(Symptom symptom)
        {
            return SymptomsList.Contains(symptom);
        }
        #endregion
    }
}
