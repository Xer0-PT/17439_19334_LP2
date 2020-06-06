/*
 * **
 * <copyright file = "Case"   Developer: Joel Martins / José Matos</copyright>
 * <author>Joel Martins / José Matos</author>
 * <email>a17439@alunos.ipca.pt</email>
 * <email>a19334@alunos.ipca.pt</email>
 * <date>4/24/2020 1:14:43 PM</date>
 * <description></description>
 * **
 */

using System.Threading;

namespace Pandemic
{
    public class Case : SickPerson
    {
        #region Member Variables

        /// <summary>
        /// Declaração de variáveis que definem um caso
        /// </summary>
        private static int currentCaseID;
        private int caseID;
        private int caseSickPersonID;
        private bool infected;

        #endregion


        #region Constructors
        /// <summary>
        /// construtor por defeito para caso
        /// </summary>
        public Case()
        {
            this.CaseID = 0;
            this.Infected = false;
        }
        /// <summary>
        /// construtor que recebe por parâmetro id de pessoa
        /// </summary>
        /// <param name="sickPersonId"></param>
        /// <param name="infected"></param>
        public Case(int sickPersonId, bool infected)
        {
            this.CaseID = Interlocked.Increment(ref currentCaseID);
            this.CaseSickPersonID = sickPersonId;
            this.Infected = infected;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Propriedade para o ID actual
        /// </summary>
        public int CurrentCaseID { get => currentCaseID; set => currentCaseID = value; }

        /// <summary>
        /// Propriedade para o ID de caso
        /// </summary>
        public int CaseID { get => this.caseID; set => this.caseID = value; }

        /// <summary>
        /// Propriedade para o ID de pessoa doente que pertence ao caso
        /// </summary>
        public int CaseSickPersonID { get => this.CaseSickPersonID; set => this.CaseSickPersonID = value; }

        /// <summary>
        /// Propriedade para Infected
        /// </summary>
        public bool Infected { get => this.infected; set => this.infected = value; }

        #endregion
    }
}
