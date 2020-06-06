/*
 * **
 * <copyright file = "Disease"   Developer: Joel Martins / José Matos</copyright>
 * <author>Joel Martins / José Matos</author>
 * <email>a17439@alunos.ipca.pt</email>
 * <email>a19334@alunos.ipca.pt</email>
 * <date>6/6/2020 3:49:14 PM</date>
 * <description></description>
 * **
 */

using System.Collections.Generic;
using System.Threading;

namespace Pandemic
{
    public class Disease : Symptoms
    {
        #region Member Variables
        /// <summary>
        /// Declaração de variáveis. Cada doença terá um id, um nome e uma lista de sintomas
        /// </summary>
        private int currentDiseaseID;
        private int diseaseID;
        private string diseaseName;

        List<Symptom> diseaseSymptoms = new List<Symptom>();

        #endregion

        #region Constructors
        /// <summary>
        /// Construtor por defeito para doença
        /// </summary>
        public Disease()
        {
            this.DiseaseID = 0;
            this.DiseaseName = "";
        }

        /// <summary>
        /// Construtor que recebe por parâmetro o nome da doença
        /// </summary>
        /// <param name="name"></param>
        public Disease(string name)
        {
            this.DiseaseID = Interlocked.Increment(ref currentDiseaseID);
            this.DiseaseName = name;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Propriedade para o actual ID de doença
        /// </summary>
        public int CurrentDiseaseID { get => currentDiseaseID;}

        /// <summary>
        /// Propriedade para o ID de doença
        /// </summary>
        public int DiseaseID { get => this.diseaseID; set => this.diseaseID = value; }

        /// <summary>
        /// Propriedade para o nome da doença
        /// </summary>
        public string DiseaseName { get => this.diseaseName; set => this.diseaseName = value; }

        public List<Symptom> DiseaseSymptoms { get => diseaseSymptoms; set => diseaseSymptoms = value; }
        #endregion

        #region Functions
        /// <summary>
        /// Função para adicionar novos sintomas a uma doença
        /// Primeiro faz a verificação se esse sintoma existe
        /// Se existir, adiciona à lista de sintomas dessa doença
        /// Se não existir retorna falso
        /// </summary>
        /// <param name="symptom"></param>
        /// <returns></returns>
        public bool AddSymptomToDisease(Symptom symptom)
        {
            if (CheckIfSymptomExists(symptom) == true)
            {
                DiseaseSymptoms.Add(symptom);
                return true;
            }
            return false;
        }
        #endregion
    }
}
