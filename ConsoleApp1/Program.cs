/*
 * **
 * <copyright file = "Program"   Developer: Joel Martins / José Matos</copyright>
 * <author>Joel Martins / José Matos</author>
 * <email>a17439@alunos.ipca.pt</email>
 * <email>a19334@alunos.ipca.pt</email>
 * <date>4/24/2020 10:59:10 AM</date>
 * <description></description>
 * **
 */

using System;
using Pandemic;

namespace TP1
{
    class Program
    {
        static void Main(string[] args)
        {
            int caseCount;
            int age = 0;
            int personId;
            int answer;

            bool loadFiles = true;
            bool saveFiles = true;
            bool aux;
            bool addCase;

            string gender;

            Regions defaultRegion = new Regions();
            Case defaultCase = new Case();
            Person defaultPerson = new Person();

            /*
             * Ler os ficheiros CSV de cada classe 
             * Se houver alguma falha a variável loadFiles toma o valor falso
             */
            /*if (defaultRegion.LoadRegionsFromCSVFile() != true)     loadFiles = false;
            if (defaultCase.LoadCasesFromCSVFile() != true)         loadFiles = false;
            if (defaultPerson.LoadPersonsFromCSVFile() != true)     loadFiles = false;*/


            /*
             * Ler os ficheiros Binários de cada classe 
             * Se houver alguma falha a variável loadFiles toma o valor falso
             */
            if (defaultPerson.LoadPersonsFromBinaryFile() != true)      loadFiles = false;
            if (defaultCase.LoadCasesFromBinaryFile() != true)          loadFiles = false;
            if (defaultRegion.LoadRegionsFromBinaryFile() != true)      loadFiles = false;


            /*
             * Se a variável loadFiles tiver como valor falso
             * Fechamos a aplicação
             */
            if (loadFiles != true)
            {
                Console.WriteLine("Programa vai encerrar. Prima qualquer tecla para continuar.");
                Console.ReadKey();
                Environment.Exit(1);
            }

            Console.WriteLine("---\t\tListagem de Regiões Existentes\t\t---");
            Console.WriteLine();
            defaultRegion.ShowRegion();
            Console.WriteLine("_______________________________________________________________\n\n");

            Console.WriteLine("---\t\tListagem de Casos Existentes\t\t---");
            Console.WriteLine();
            defaultCase.ShowAllCases();
            Console.WriteLine("_______________________________________________________________\n\n");

            Console.WriteLine("---\t\tListagem de Pessoas Existentes\t\t---");
            Console.WriteLine();
            defaultPerson.ShowPerson();
            Console.WriteLine("_______________________________________________________________\n\n");


            /*
             * Como não há a utilização de menus
             * Forçamos a inserção de um novo caso
             */
            do
            {
                Console.WriteLine();
                Console.WriteLine("---\t\tInserir Caso Suspeito\t\t---");
                try
                {
                    /* 
                     * Pedimos o id da Pessoa
                     */
                    Console.Write("Qual o ID da pessoa com suspeitas de virus: ");
                    personId = Convert.ToInt32(Console.ReadLine());

                    /*
                     * Verificamos se essa pessoa existe com a função CheckIfPersonExists
                     */
                    if (defaultPerson.CheckIfPersonExists(personId) == false)
                    {
                        Console.WriteLine("ID de pessoa não existe!");
                        aux = false;
                    }
                    /*
                     * Verificamos se essa pessoa já está registada num caso
                     * Se já estiver a variável defaultCase recebe esse caso.
                     * A variável defaultPerson recebe a pessoa com o id inserido
                     * e perguntamos se quer alterar o estado de Infectado.
                     */
                    else if (defaultCase.CheckIfPersonHasCase(personId) == true)
                    {
                        defaultPerson = defaultPerson.ReturnPerson(personId);
                        defaultCase = defaultCase.ReturnCase(personId);

                        Console.WriteLine("A pessoa {0} {1} já está registada num caso com Infectado = {2}.", defaultPerson.FirstName, defaultPerson.LastName, defaultCase.Infected);
                        do
                        {
                            try
                            {
                                Console.WriteLine("Quer alterar o estado de Infectado? [1 - Sim] ou [0 - Não]");
                                answer = Convert.ToInt32(Console.ReadLine());
                                
                                if (answer == 1)
                                {
                                    do
                                    {
                                        try
                                        {
                                            Console.WriteLine("[1] Se infectado");
                                            Console.WriteLine("[0] Se não infectado");
                                            answer = Convert.ToInt32(Console.ReadLine());

                                            if (answer == 1)
                                            {
                                                defaultCase.UpdateCase(personId, true);
                                                aux = true;
                                            }
                                            else if (answer == 0)
                                            {
                                                defaultCase.UpdateCase(personId, false);
                                                aux = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Opção Inválida!");
                                                aux = false;
                                            }
                                        }
                                        catch (FormatException e)
                                        {
                                            aux = false;
                                            Console.WriteLine("Erro: " + e.Message);
                                        }
                                    } while (aux != true);
                                }
                                aux = true;
                            }
                            catch (FormatException e)
                            {
                                aux = false;
                                Console.WriteLine("Erro: " + e.Message);
                            }
                        } while (aux != true);
                    }
                    /*
                     * Se a pessoa não estiver registada num caso, é porque se trata de um caso suspeito novo,
                     * então perguntamos se esta pessoa deu teste positivo ou não.
                     */
                    else
                    {
                        do
                        {
                            try
                            {
                                Console.WriteLine("O teste desta pessoa deu positivo? [1 - Sim] ou [0 - Não]");
                                answer = Convert.ToInt32(Console.ReadLine());

                                if (answer == 1)
                                {
                                    Case case1 = new Case(personId, true);

                                    addCase = defaultCase.AddCase(case1);

                                    if (addCase == false)
                                    {
                                        Console.WriteLine("Ocorreu um erro. Programa vai encerrar. Prima qualquer tecla para continuar.");
                                        Console.ReadKey();
                                        Environment.Exit(1);
                                    }

                                    aux = true;
                                }
                                else if (answer == 0)
                                {
                                    Case case1 = new Case(personId, false);

                                    addCase = defaultCase.AddCase(case1);

                                    if (addCase == false)
                                    {
                                        Console.WriteLine("Ocorreu um erro. Programa vai encerrar. Prima qualquer tecla para continuar.");
                                        Console.ReadKey();
                                        Environment.Exit(1);
                                    }

                                    aux = true;
                                }
                                else
                                {
                                    Console.WriteLine("Opção Inválida");
                                    aux = false;
                                }
                            }
                            catch (FormatException e)
                            {
                                aux = false;
                                Console.WriteLine("Erro: " + e.Message);
                            }
                        } while (aux != true);
                    }
                }
                catch (FormatException e)
                {
                    aux = false;
                    Console.WriteLine("Erro: " + e.Message);
                }
            } while (aux != true);


            //Mostrar Total de Casos
            Console.WriteLine("---\t\tTotal de casos: {0}\t\t---", defaultCase.CaseList.Count);

            //Mostrar Total de Casos 
            caseCount = defaultCase.CountInfected();
            Console.WriteLine("---\t\tTotal de casos positivos: {0}\t\t---", caseCount);

            Console.WriteLine("\n\n");
            //Contar por idade inserida pelo utilizador
            do
            {
                try
                {
                    Console.Write("Insira Idade a pesquisar: ");
                    age = Convert.ToInt32(Console.ReadLine());

                    aux = true;
                }
                catch (FormatException e)
                {
                    aux = false;
                    Console.WriteLine("Erro: " + e.Message);
                }
            } while (aux != true);

            caseCount = defaultCase.CountByAge(age);

            if (caseCount > 0)
            {
                Console.WriteLine("Numero de casos com a idade inserida: {0}", caseCount);
            }
            else
            {
                Console.WriteLine("Não há casos com idade igual a {0}", age);
            }

            Console.WriteLine("\n\n");

            //Mostrar casos por género inserido pelo utilizador
            do
            {
                try
                {
                    Console.WriteLine("Insira o género a procurar. [F] ou [M]");
                    gender = Console.ReadLine();

                    if ((gender != "M") && (gender != "F"))
                    {
                        aux = false;
                        Console.WriteLine("Género Inválido!");
                    }
                    else
                    {
                        aux = true;

                        caseCount = defaultCase.CountByGender(gender);

                        Console.WriteLine("Número de casos com o género inserido: " + caseCount);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro: " + e.Message);
                }
            } while (aux != true);

            Console.WriteLine("\n\n");
            Console.WriteLine("Prima qualquer tecla para continuar.");
            Console.ReadKey();
            Console.WriteLine("\n\n");
            Console.WriteLine("A inserir duas novas pessoas.");
            Console.WriteLine("A inserir dois novos casos.");
            Console.WriteLine("Prima qualquer tecla para continuar.");
            Console.ReadKey();

            Person personExtra1 = new Person("Extra_1", "Extra_1", Person.Genders.F, 33, 7);
            Person personExtra2 = new Person("Extra_2", "Extra_2", Person.Genders.M, 38, 4);
            defaultPerson.AddPerson(personExtra1);
            defaultPerson.AddPerson(personExtra2);

            Case caseExtra1 = new Case(-1, false);
            Case caseExtra2 = new Case(-2, true);
            defaultCase.AddCase(caseExtra1);
            defaultCase.AddCase(caseExtra2);

            Console.WriteLine("---\t\tListagem de Casos Existentes\t\t---");
            Console.WriteLine();
            defaultCase.ShowAllCases();
            Console.WriteLine("_______________________________________________________________\n\n");

            Console.WriteLine("---\t\tListagem de Pessoas Existentes\t\t---");
            Console.WriteLine();
            defaultPerson.ShowPerson();
            Console.WriteLine("_______________________________________________________________\n\n");

            //Save Lists to CSV File
            /*if (defaultPerson.SavePersonsToCSVFile() != true)       saveFiles = false;
            if (defaultCase.SaveCasesToCSVFile() != true)           saveFiles = false;
            if (defaultRegion.SaveRegionsToCSVFile() != true)       saveFiles = false;*/

            //Save Lists to BINARY File
            if (defaultPerson.SavePersonsToBinaryFile() != true)        saveFiles = false;
            if (defaultCase.SaveCasesToBinaryFile() != true)            saveFiles = false;
            if (defaultRegion.SaveRegionsToBinaryFile() != true)        saveFiles = false;

            if (saveFiles != true)
            {
                Console.WriteLine("Programa vai encerrar. Prima qualquer tecla para continuar.");
                Console.ReadKey();
                Environment.Exit(1);
            }


            Console.WriteLine("Prima qualquer tecla para sair.");
            Console.ReadKey();
        }
    }
}