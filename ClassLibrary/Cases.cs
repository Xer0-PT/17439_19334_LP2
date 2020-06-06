/*
 * **
 * <copyright file = "Cases"   Developer: Joel Martins / José Matos</copyright>
 * <author>Joel Martins / José Matos</author>
 * <email>a17439@alunos.ipca.pt</email>
 * <email>a19334@alunos.ipca.pt</email>
 * <date>6/6/2020 6:27:09 PM</date>
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
    class Cases : Case
    {
        #region Member Variables
        /// <summary>
        /// Declaração de variáveis para Classe Cases
        /// </summary>
        private List<Case> caseList = new List<Case>();

        private const string CSVFILEPATH = @"..\..\Case.csv";
        private const string BINARYFILEPATH = @"..\..\Case.dat";
        #endregion

        #region Properties
        /// <summary>
        /// Propriedade para Lista de Casos
        /// </summary>
        public List<Case> CaseList { get => caseList; set => caseList = value; }
        #endregion

        #region Functions
        /// <summary>
        /// Função para ler o ficheiro binário de Casos e guardar na Lista de Casos
        /// 
        /// Retorna verdadeiro se não houve problema
        /// Retorna falso se houve algum problema
        /// </summary>
        public bool LoadCasesFromBinaryFile()
        {
            FileStream fs = new FileStream(BINARYFILEPATH, FileMode.Open, FileAccess.Read);
            BinaryFormatter bin = new BinaryFormatter();

            try
            {
                if (File.Exists(BINARYFILEPATH))
                {
                    CaseList = (List<Case>)bin.Deserialize(fs);
                }
                else
                {
                    fs = File.Create(BINARYFILEPATH);
                    bin.Serialize(fs, CaseList);
                }

                fs.Close();

                Case aux = CaseList.Last();
                CurrentCaseID = aux.CaseID;
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        /// <summary>
        /// Função para guardar a Lista de Casos em Ficheiro Binário
        /// 
        /// Retorna verdadeiro se não houve problema
        /// Retorna falso se houve algum problema
        /// </summary>
        public bool SaveCasesToBinaryFile()
        {
            try
            {
                FileStream fs = new FileStream(BINARYFILEPATH, FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(fs, CaseList);
                fs.Close();

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        /// <summary>
        /// Função para ler o ficheiro CSV de Casos e guardá-los em Lista
        /// 
        /// Retorna verdadeiro se não houve problema
        /// Retorna falso se houve algum problema
        /// </summary>
        public bool LoadCasesFromCSVFile()
        {
            List<string> lines = File.ReadAllLines(CSVFILEPATH).ToList();

            try
            {
                foreach (var line in lines)
                {
                    string[] entrie = line.Split(';');

                    Case newCase = new Case();

                    newCase.CaseID = Convert.ToInt32(entrie[0]);
                    newCase.PersonID = Convert.ToInt32(entrie[1]);
                    newCase.Infected = bool.Parse(entrie[2]);

                    CaseList.Add(newCase);
                }

                Case aux = CaseList.Last();
                CurrentCaseID = aux.CaseID;

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Função para guardar a lista de Casos em ficheiro CSV
        /// 
        /// Retorna verdadeiro se não houve problema
        /// Retorna falso se houve algum problema
        /// </summary>
        public bool SaveCasesToCSVFile()
        {
            try
            {
                List<string> output = new List<string>();

                foreach (var caso in CaseList)
                {
                    output.Add(caso.CaseID + ";" + caso.PersonID + ";" + caso.Infected);
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
        /// Função para imprimir todos os Casos
        /// </summary>
        public void ShowAllCases()
        {
            foreach (var caso in CaseList)
            {
                Console.WriteLine("Cdigo: {0}\tID Pessoa: {1}\tInfectado: {2}", caso.CaseID, caso.PersonID, caso.Infected);
            }
        }

        /// <summary>
        /// Percorre cada Caso e compara o ID de Pessoa com cada ID na lista de Pessoas.
        /// Assim vai apenas contabilizar as Pessoas que representam um caso.
        /// Se o ID de Pessoa existir na lista de Casos, verifica se a idade da Pessoa
        /// é igual à idade inserida pelo utilizador, se for igual incrementa o contador.
        /// Dando assim a contagem de Pessoas, com idade igual à inserida pelo utilizador,
        /// que realmente representa um Caso.
        /// </summary>
        /// <param name="age"></param>
        public int CountByAge(int age, List<SickPersons> sickPersonList)
        {
            int count = 0;

            if (age < 0)
                age = -age;

            foreach (var caso in CaseList)
            {
                foreach (var person in sickPersonList)
                {
                    if (caso.PersonID == person.PersonID)
                    {
                        if (person.Age == age)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// Percorre cada Caso e compara o ID de Pessoa com cada ID na lista de Pessoas.
        /// Assim vai apenas contabilizar as Pessoas que representam um caso.
        /// Se o ID de Pessoa existir na lista de Casos, verifica se o género da Pessoa
        /// é igual ao género inserido pelo utilizador, se for igual incrementa o contador.
        /// Dando assim a contagem de Pessoas, com género igual ao inserido pelo utilizador,
        /// que realmente representa um Caso.
        /// </summary>
        /// <param name="gender"></param>
        public int CountByGender(string gender, List<SickPerson> sickPersonList)
        {
            int count = 0;

            Genders auxGender = (Genders)Enum.Parse(typeof(Genders), gender);

            foreach (var caso in CaseList)
            {
                foreach (var person in sickPersonList)
                {
                    if (caso.PersonID == person.PersonID)
                    {
                        if (person.Gender == auxGender)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// Percorre cada Caso, se se tratar de um infectado incrementa o contador.
        /// Devolvendo o número de infectados.
        /// </summary>
        public int CountInfected()
        {
            int count = 0;

            foreach (var caso in CaseList)
            {
                if (caso.Infected == true)
                    count++;
            }
            return count;
        }

        /// <summary>
        /// Função que adiciona o novo Caso à lista de Casos
        /// Se por acaso já existir o ID retorna falso
        /// Se não houver problema adiciona o caso e retorna verdadeiro
        /// </summary>
        /// <param name="newCase"></param>
        public bool AddCase(Case newCase)
        {
            foreach (var caso in CaseList)
            {
                if (newCase.CaseID == caso.CaseID)
                {
                    return false;
                }
            }
            CaseList.Add(newCase);
            return true;
        }

        /// <summary>
        /// Função para remover caso da lista de casos
        /// </summary>
        /// <param name="auxCase"></param>
        /// <returns></returns>
        public bool RemoveCase(Case auxCase)
        {
            return CaseList.Remove(auxCase);
        }

        /// <summary>
        /// Função com método alternativo ao foreach
        /// que recebe por parâmetro o id de Pessoa
        /// Se existir um caso com essa Pessoa retorna o caso
        /// Senão retorna nulo
        /// </summary>
        /// <param name="personId"></param>
        public Case ReturnCase(int personId)
        {
            var caso = CaseList.Find(x => x.PersonID == personId);

            return caso;
        }

        /// <summary>
        /// Função para verificar se a pessoa inserida pelo utilizador
        /// já está registada em algum caso.
        /// Retorna verdadeiro se sim
        /// Retorna falso se não
        /// </summary>
        /// <param name="id"></param>
        public bool CheckIfPersonHasCase(int id)
        {
            foreach (var caso in CaseList)
            {
                if (caso.PersonID == id)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Função que recebe por parâmetro o id de Pessoa e o novo estado de Infectado
        /// faz o update da variável infectado para o recebido por parâmetro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="update"></param>
        public void UpdateCase(int id, bool update)
        {
            foreach (var caso in CaseList)
            {
                if (caso.PersonID == id)
                {
                    caso.Infected = update;
                }
            }
        }
        #endregion
    }
}
