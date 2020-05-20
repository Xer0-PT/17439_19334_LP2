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
            int id;
            
            bool aux;

            string answer;

            Regions regionsArray = new Regions();

            Case caseList = new Case();

            Person defaultPerson = new Person();

            defaultPerson.LoadPersonsFromFile();
            defaultPerson.ShowPerson();

            do
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Inserir Caso");
                    Console.Write("Qual o id da pessoa com suspeitas de virus: ");

                    id = Convert.ToInt32(Console.ReadLine());

                    if (defaultPerson.ValidatePersonID(id) == false)
                    {
                        Console.WriteLine("Id de pessoa não existe!");
                        aux = false;
                    }
                    else
                    {
                        try
                        {
                            Console.WriteLine("Esta pessoa está infectada? [Sim] ou [Não]");
                            answer = Console.ReadLine();

                            if (answer == "sim")
                            {
                                Case case1 = new Case(id, true);

                                caseList.AddCase(case1);
                            }
                            else if (answer == "nao")
                            {
                                Case case1 = new Case(id, false);

                                caseList.AddCase(case1);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Erro: " + e.Message);
                        }

                        aux = true;
                    }                    
                }
                catch (FormatException e)
                {
                    aux = false;
                    Console.WriteLine("Erro: " + e.Message);
                }

            } while (aux != true);


            




            //Importar Regiões
            Regions region1 = new Regions("Minho");
            Regions region2 = new Regions("Algarve");
            Regions region3 = new Regions("Alto Alentejo");
            Regions region4 = new Regions("Estremadura");
            Regions region5 = new Regions("Trás - os - Montes e Alto Douro");
            Regions region6 = new Regions("Douro Litoral");
            Regions region7 = new Regions("Beira Litoral");
            Regions region8 = new Regions("Beira Alta");
            Regions region9 = new Regions("Beira Baixa");
            Regions region10 = new Regions("Ribatejo");
            Regions region11 = new Regions("Baixo Alentejo");

            //Adicionar Pessoas
            Person person1 = new Person("Joel", "Martins", Person.Genders.M, 30, region1.RegionID);
            Person person2 = new Person("José", "Matos", Person.Genders.M, 30, region2.RegionID);
            Person person3 = new Person("Alexandra", "Silva", Person.Genders.F, 40, region3.RegionID);
            Person person4 = new Person("Joaquina", "Santos", Person.Genders.F, 22, region4.RegionID);
            Person person5 = new Person("Andreia", "Barrete", Person.Genders.F, 33, region7.RegionID);
            Person person6 = new Person("asdasd", "asdasdasd", Person.Genders.F, 33, region7.RegionID);

            //Adicionar Casos
/*            Case case2 = new Case(person3.PersonID, false);
            Case case3 = new Case(person1.PersonID, false);
            Case case4 = new Case(person2.PersonID, true);
            Case case5 = new Case(person4.PersonID, true);*/

            #region Valida Inserir Regiões
            if (regionsArray.AddRegion(region1))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (regionsArray.AddRegion(region2))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (regionsArray.AddRegion(region3))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (regionsArray.AddRegion(region4))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (regionsArray.AddRegion(region5))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (regionsArray.AddRegion(region6))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (regionsArray.AddRegion(region7))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (regionsArray.AddRegion(region8))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (regionsArray.AddRegion(region9))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (regionsArray.AddRegion(region10))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (regionsArray.AddRegion(region11))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            #endregion

            #region Valida Inserir Pessoas
/*
            if (defaultPerson.AddPerson(person1))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (defaultPerson.AddPerson(person2))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (defaultPerson.AddPerson(person3))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (defaultPerson.AddPerson(person4))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (defaultPerson.AddPerson(person5))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }*/
            #endregion

            #region Valida Inserir Casos
            /*if (caseList.AddCase(case1))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (caseList.AddCase(case2))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (caseList.AddCase(case3))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (caseList.AddCase(case4))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (caseList.AddCase(case5))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }*/
            #endregion

            //Mostrar Regiões
            regionsArray.ShowRegion();
            Console.WriteLine();

            //Mostrar Casos
            caseList.ShowAllCases();
            Console.WriteLine();


            //Mostrar Total de Casos
            caseCount = caseList.CountTotalCases();
            Console.WriteLine("Total de casos: {0}", caseCount);

            //Mostrar Total de Casos defaultCase
            caseCount = caseList.CountInfected();
            Console.WriteLine("Total de casos positivos: {0}", caseCount);

            Console.WriteLine();

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

            caseCount = caseList.CountByAge(age);

            if (caseCount > 0)
            {
                Console.WriteLine("Numero de casos com a idade inserida: {0}", caseCount);
            }
            else
            {
                Console.WriteLine("Não há casos com idade igual a {0}", age);
            }
            
            //Mostrar casos por género
            caseCount = caseList.CountByGender(Person.Genders.F);
            if (caseCount > 0)
            {
                Console.WriteLine("Numero de casos com o género Feminino: {0}", caseCount);
            }
            else
            {
                Console.WriteLine("Não há casos com o género {0}", Person.Genders.M);
            }

            caseCount = caseList.CountByGender(Person.Genders.M);
            if (caseCount > 0)
            {
                Console.WriteLine("Numero de casos com o género Masculino: {0}", caseCount);
            }
            else
            {
                Console.WriteLine("Não há casos com o género {0}", Person.Genders.M);
            }



            defaultPerson.SavePersonsToFile();
            
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Ultimo ID: " + defaultPerson.CurrentPersonID);
            Console.ReadKey();
        }
    }
}
