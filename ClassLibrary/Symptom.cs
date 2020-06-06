/*
 * **
 * <copyright file = "Symptoms"   Developer: Joel Martins / José Matos</copyright>
 * <author>Joel Martins / José Matos</author>
 * <email>a17439@alunos.ipca.pt</email>
 * <email>a19334@alunos.ipca.pt</email>
 * <date>6/6/2020 4:19:15 PM</date>
 * <description></description>
 * **
 */

using System.Threading;

namespace Pandemic
{
    public class Symptom
    {
        #region Member Variables
        /// <summary>
        /// Variáveis para a criação de um sintoma
        /// </summary>
        private static int currentSymptomID;
        private int symptomID;
        private string symptomName;
        #endregion

        #region Constructors
        /// <summary>
        /// Construtor por defeito de um sintoma
        /// </summary>
        public Symptom()
        {
            this.SymptomID = 0;
            this.SymptomName = "";
        }

        /// <summary>
        /// Construtor de um sintoma que recebe por parâmetro o nome do sintoma
        /// O ID é incrementado automaticamente
        /// </summary>
        /// <param name="name"></param>
        public Symptom(string name)
        {
            this.SymptomID = Interlocked.Increment(ref currentSymptomID);
            this.SymptomName = name;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Propriedade para o actual ID de sintoma
        /// </summary>
        public int CurrentSymptomID { get => currentSymptomID; }

        /// <summary>
        /// Propriedade para o ID de um sintoma
        /// </summary>
        public int SymptomID { get => this.symptomID; set => this.symptomID = value; }

        /// <summary>
        /// Propriedade para o nome de um sintoma
        /// </summary>
        public string SymptomName{ get => this.symptomName; set => this.symptomName = value; }
        #endregion

    }
}
