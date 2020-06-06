/*
 * **
 * <copyright file = "Person"   Developer: Joel Martins / José Matos</copyright>
 * <author>Joel Martins / José Matos</author>
 * <email>a17439@alunos.ipca.pt</email>
 * <email>a19334@alunos.ipca.pt</email>
 * <date>4/24/2020 11:01:55 AM</date>
 * <description></description>
 * **
 */

using System.Threading;

namespace Pandemic
{
    public class Person
    {
        #region Member Variables

        /// <summary>
        /// Declaração de variáveis que definem uma Pessoa
        /// </summary>
        private int currentPersonID;
        private int personID;
        private string firstName;
        private string lastName;
        private Genders gender;
        private int age;
        private int regionID;
        private bool dead;
        #endregion


        #region Constructors
        /// <summary>
        /// Construtor por defeito para pessoa
        /// </summary>
        public Person()
        {
            this.PersonID = 0;
            this.FirstName = "";
            this.LastName = "";
            this.Age = 0;
            this.Gender = 0;
            this.Dead = false;
        }

        /// <summary>
        /// Construtor que recebe por parâmetro o nome, género, idade, id de região, e se a pessoa está morta ou não
        /// </summary>
        public Person(string firstName, string lastName, Genders gender, int age, int regionID, bool dead)
        {
            this.PersonID =  Interlocked.Increment(ref currentPersonID);
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.Age = age;
            this.RegionID = regionID;
            this.Dead = dead;
        }
        #endregion


        #region Properties
        /// <summary>
        /// Propriedade para o ID actual de Pessoa
        /// </summary>
        public int CurrentPersonID { get => this.currentPersonID; set => this.currentPersonID = value; }

        /// <summary>
        /// Propriedade para o ID de pessoa
        /// </summary>
        public int PersonID { get => this.personID ; set => this.personID = value; }

        /// <summary>
        /// Propriedade para o primeiro nome de pessoa
        /// </summary>
        public string FirstName { get => this.firstName; set => this.firstName = value; }

        /// <summary>
        /// Propriedade para o último nome de pessoa
        /// </summary>
        public string LastName { get => this.lastName; set => this.lastName = value; }

        /// <summary>
        /// Propriedade para o género de pessoa
        /// </summary>
        public Genders Gender { get => this.gender; set => this.gender = value; }

        /// <summary>
        /// Propriedade para a idade de pessoa
        /// </summary>
        public int Age { get => this.age; set => this.age = value; }

        /// <summary>
        /// Propriedade para o id de região de pessoa
        /// </summary>
        public int RegionID { get => this.regionID; set => this.regionID = value; }

        /// <summary>
        /// Propriedade para definir se a pessoa está morta ou não
        /// </summary>
        public bool Dead { get => this.dead; set => this.dead = value; }

        #endregion


        #region Enums
        /// <summary>
        /// Enumerador para os Géneros
        /// </summary>
        public enum Genders
        {
            M,
            F
        }
        #endregion
    }
}