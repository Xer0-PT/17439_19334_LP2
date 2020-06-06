/*
 * **
 * <copyright file = "SickPersons"   Developer: Joel Martins / José Matos</copyright>
 * <author>Joel Martins / José Matos</author>
 * <email>a17439@alunos.ipca.pt</email>
 * <email>a19334@alunos.ipca.pt</email>
 * <date>6/6/2020 5:16:51 PM</date>
 * <description></description>
 * **
 */

using System.Collections.Generic;

namespace Pandemic
{
    public class SickPersons : SickPerson
    {
        #region Member Variables
        /// <summary>
        /// Declarar uma lista de pessoas doentes
        /// </summary>
        List<SickPerson> sickPersonsList = new List<SickPerson>();
        #endregion

        #region Properties
        /// <summary>
        /// Propriedade para obter a lista de pessoas doentes
        /// </summary>
        List<SickPerson> SickPersonsList { get => sickPersonsList; set => sickPersonsList = value; }
        #endregion

        #region Functions
        /// <summary>
        /// Função para adicionar pessoa doente à lista de pessoas doentes
        /// </summary>
        /// <param name="sickPerson"></param>
        /// <returns></returns>
        public bool AddSickPersonToList(SickPerson sickPerson)
        {
            if (SickPersonsList.Contains(sickPerson))
                return false;
            else
            {
                SickPersonsList.Add(sickPerson);
                return true;
            }
        }

        /// <summary>
        /// Função para remover pessoa doente da lista de pessoas doentes
        /// Retorna verdadeiro se conseguir
        /// Retorna falso se não conseguir
        /// </summary>
        /// <param name="sickPerson"></param>
        /// <returns></returns>
        public bool RemoveSickPersonFromList(SickPerson sickPerson)
        {
            return SickPersonsList.Remove(sickPerson);
        }
        #endregion
    }
}
