/*
 * **
 * <copyright file = "SickPerson"   Developer: Joel Martins / José Matos</copyright>
 * <author>Joel Martins / José Matos</author>
 * <email>a17439@alunos.ipca.pt</email>
 * <email>a19334@alunos.ipca.pt</email>
 * <date>6/6/2020 3:24:46 PM</date>
 * <description></description>
 * **
 */

using System.Collections.Generic;
using System.Threading;

namespace Pandemic
{
    /// <summary>
    /// Classe Sick Person que herda de Person
    /// </summary>
    public class SickPerson : Person
    {
        #region Member Variables

        /// <summary>
        /// Conjunto de variáveis para a classe SickPerson
        /// </summary>
        private int currentSickPersonID;
        private int sickPersonID;

        private static List<Disease> sickPersonDiseases = new List<Disease>();

        #endregion

        #region Constructors
        /// <summary>
        /// Construtor por defeito para Sick Person
        /// </summary>
        public SickPerson()
        {
            this.SickPersonID = 0;
            this.SickPersonDiseases = null;
        }

        /// <summary>
        /// Construtor que recebe por parâmetro o nome da doença e se a pessoa está ou não morta
        /// </summary>
        public SickPerson(string disease, bool infected)
        {
            this.SickPersonID = Interlocked.Increment(ref currentSickPersonID);
        }

        #endregion

        #region Properties
        /// <summary>
        /// Propriedade para o actual ID de pessoa doente
        /// </summary>
        public int CurrentSickPersonID { get => currentSickPersonID; set => currentSickPersonID = value; }

        /// <summary>
        /// Propriedade para o ID de pessoa doente
        /// </summary>
        public int SickPersonID { get => this.sickPersonID; set => this.sickPersonID = value; }

        /// <summary>
        /// Propriedade para obter a lista de doenças da pessoa
        /// </summary>
        public List<Disease> SickPersonDiseases { get => sickPersonDiseases; set => sickPersonDiseases = value; }
        #endregion

        #region Functions
        /// <summary>
        /// Função para adicionar uma doença a uma pessoa doente
        /// </summary>
        /// <param name="disease"></param>
        /// <returns></returns>
        public bool AddDiseaseToSickPerson(Disease disease)
        {
            if (SickPersonDiseases.Contains(disease))
                return false;
            else
            {
                SickPersonDiseases.Add(disease);
                return true;
            }
        }

        /// <summary>
        /// Função para remover doença de uma pessoa doente
        /// Retorna verdadeiro se conseguir
        /// Retorna falso se não conseguir
        /// </summary>
        /// <param name="disease"></param>
        /// <returns></returns>
        public bool RemoveDiseaseFromSickPerson(Disease disease)
        {
            return SickPersonDiseases.Remove(disease);
        }
        #endregion
    }
}
