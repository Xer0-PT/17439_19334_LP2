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

[assembly: CLSCompliant(true)]

namespace TP1
{
    class Program
    {
        static void Main(string[] args)
        {
            int caseCount;
            int age = 0;
            int id;
            int answer;
            
            bool aux;

            string gender;

            Regions defaultRegion = new Regions();
            Case defaultCase = new Case();
            Person defaultPerson = new Person();

            defaultRegion.LoadRegionsFromFile();
            defaultCase.LoadCasesFromFile();
            defaultPerson.LoadPersonsFromFile();

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

            do
            {
                Console.WriteLine();
                Console.WriteLine("---\t\tInserir Caso\t\t---");
                try
                {
                    Console.Write("Qual o ID da pessoa com suspeitas de virus: ");

                    id = Convert.ToInt32(Console.ReadLine());

                    if (defaultPerson.ValidatePersonID(id) == false)
                    {
                        Console.WriteLine("ID de pessoa não existe!");
                        aux = false;
                    }
                    else if (defaultCase.CheckIfPersonHasCase(id) == true)
                    {
                        Console.WriteLine("Esta pessoa já está registada num caso!.");
                        aux = false;
                    }
                    else
                    {
                        do
                        {
                            try
                            {
                                Console.WriteLine("Esta pessoa está infectada? [1 - Sim] ou [0 - Não]");
                                answer = Convert.ToInt32(Console.ReadLine());

                                if (answer == 1)
                                {
                                    Case case1 = new Case(id, true);

                                    defaultCase.AddCase(case1);

                                    aux = true;
                                }
                                else if (answer == 0)
                                {
                                    Case case1 = new Case(id, false);

                                    defaultCase.AddCase(case1);

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
            caseCount = defaultCase.CountTotalCases();
            Console.WriteLine("---\t\tTotal de casos: {0}\t\t---", caseCount);

            //Mostrar Total de Casos defaultCase
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

            defaultPerson.SavePersonsToFile();
            defaultCase.SaveCasesToFile();
            defaultRegion.SaveRegionsToFile();

            Console.WriteLine("Prima qualquer tecla para sair.");
            Console.ReadKey();
        }
    }
}