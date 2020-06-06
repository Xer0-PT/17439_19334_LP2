/*
 * **
 * <copyright file = "Persons"   Developer: Joel Martins / José Matos</copyright>
 * <author>Joel Martins / José Matos</author>
 * <email>a17439@alunos.ipca.pt</email>
 * <email>a19334@alunos.ipca.pt</email>
 * <date>6/6/2020 5:34:10 PM</date>
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
    class Persons : Person
    {
        #region Member Variables
        /// <summary>
        /// Declaração de variáveis para a classe Persons
        /// </summary>
        private static List<Person> personList = new List<Person>();

        private const string CSVFILEPATH = @"..\..\Person.csv";
        private const string BINARYFILEPATH = @"..\..\Person.dat";
        #endregion
        
        #region Properties
        /// <summary>
        /// Propriedade para obter a lista de Pessoas
        /// </summary>
        public List<Person> PersonList { get => personList; set => personList = value; }
        #endregion

        #region Functions
        /// <summary>
        /// Função para guardar a Lista de Pessoas em Ficheiro Binário
        /// 
        /// Retorna verdadeiro se não houve problema
        /// Retorna falso se houve algum problema
        /// </summary>
        public bool SavePersonsToBinaryFile()
        {
            try
            {
                FileStream fs = new FileStream(BINARYFILEPATH, FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(fs, PersonList);
                fs.Close();

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Função para ler o ficheiro binário de Pessoas e guardar na Lista de Pessoas
        /// 
        /// Retorna verdadeiro se não houve problema
        /// Retorna falso se houve algum problema
        /// </summary>
        public bool LoadPersonsFromBinaryFile()
        {
            try
            {
                FileStream fs = new FileStream(BINARYFILEPATH, FileMode.Open, FileAccess.Read);
                BinaryFormatter bin = new BinaryFormatter();

                if (File.Exists(BINARYFILEPATH))
                {
                    PersonList = (List<Person>)bin.Deserialize(fs);
                }
                else
                {
                    fs = File.Create(BINARYFILEPATH);
                    bin.Serialize(fs, PersonList);
                }
                fs.Close();

                Person aux = PersonList.Last();
                CurrentPersonID = aux.PersonID;

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Função para guardar a lista de Pessoas em ficheiro CSV
        /// 
        /// Retorna verdadeiro se não houve problema
        /// Retorna falso se houve algum problema
        /// </summary>
        public bool SavePersonsToCSVFile()
        {
            try
            {
                List<string> output = new List<string>();

                foreach (var obj in PersonList)
                {
                    output.Add(obj.PersonID + ";" + obj.FirstName + ";" + obj.LastName + ";" + obj.Gender + ";" + obj.Age + ";" + obj.RegionID);
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
        /// Função para ler o ficheiro CSV de Pessoas e guardá-los em Lista
        /// 
        /// Retorna verdadeiro se não houve problema
        /// Retorna falso se houve algum problema
        /// </summary>
        public bool LoadPersonsFromCSVFile()
        {
            try
            {
                List<string> lines = File.ReadAllLines(CSVFILEPATH).ToList();

                foreach (var line in lines)
                {
                    string[] entrie = line.Split(';');

                    Person newPerson = new Person();

                    newPerson.PersonID = Convert.ToInt32(entrie[0]);
                    newPerson.FirstName = entrie[1];
                    newPerson.LastName = entrie[2];
                    newPerson.Gender = (Genders)Enum.Parse(typeof(Genders), entrie[3]);
                    newPerson.Age = Convert.ToInt32(entrie[4]);
                    newPerson.RegionID = Convert.ToInt32(entrie[5]);

                    PersonList.Add(newPerson);
                }

                Person aux = PersonList.Last();
                CurrentPersonID = aux.PersonID;

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Função com método alternativo ao foreach
        /// que recebe por parâmetro o id de Pessoa
        /// Se essa pessoa existir retorna a Pessoa
        /// Senão retorna nulo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Person ReturnPerson(int id)
        {
            var person = PersonList.Find(x => x.PersonID == id);

            if (person != null)
                return person;

            return null;
        }

        /// <summary>
        /// Função que recebe por parâmetro o id de pessoa inserido pelo utilizador
        /// se verifica se essa pessoa existe.
        /// Se existir retorna verdadeiro.
        /// Se não existir retorna falso.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckIfPersonExists(int id)
        {
            foreach (var person in PersonList)
            {
                if (person.PersonID == id)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Função que adiciona nova Pessoa à lista de Pessoas
        /// Se por acaso já existir o ID retorna falso
        /// Se não houver problema adiciona a pessoa e retorna verdadeiro
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool AddPerson(Person newPerson)
        {
            /* Código foi alterado de acordo com a sugestão do Professor, para a seguinte forma: */

            if (PersonList.Contains(newPerson))
                return false;
            else
            {
                PersonList.Add(newPerson);
                return true;
            }

            /* De seguida fica o código tal como estava antes da defesa com o Professor */
            /*
                        foreach (var person in personList)
                        {
                            if (newPerson.personID == person.PersonID)
                            {
                                return false;
                            }
                        }
                        personList.Add(newPerson);
                        return true;
            */
        }

        /// <summary>
        /// Função para remover uma pessoa da lista de pessoas
        /// Retorna verdadeiro se conseguir
        /// Retorna falso se não conseguir
        /// </summary>
        public bool RemovePersonFromList(Person person)
        {
            return PersonList.Remove(person);
        }

        /// <summary>
        /// Função para imprimir todas as Pessoas
        /// </summary>
        public void ShowPerson()
        {
            foreach (var obj in PersonList)
            {
                Console.WriteLine("Codigo: {0}\tNome: {1} {2}\tGénero: {3}\tIdade: {4}\tRegiao: {5}", obj.PersonID, obj.FirstName, obj.LastName,
                    obj.Gender, obj.Age, obj.RegionID);
            }
        }
        #endregion
    }
}
