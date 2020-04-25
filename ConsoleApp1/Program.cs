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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Program
    {
        static void Main(string[] args)
        {
            int caseCount = 0;

            Regions regionsArray = new Regions();
            Case caseArray = new Case();
            Person personArray = new Person();

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


            Person person1 = new Person("Joel Martins", Person.Genders.M, 30, region1.RegionID);
            Person person2 = new Person("José Matos", Person.Genders.M, 30, region2.RegionID);
            Person person3 = new Person("Alexandrina", Person.Genders.F, 40, region3.RegionID);
            Person person4 = new Person("Joaquina", Person.Genders.F, 22, region4.RegionID);
            Person person5 = new Person("Andreia", Person.Genders.F, 33, region7.RegionID);

            Case case1 = new Case(person5.PersonID);
            Case case2 = new Case(person3.PersonID);
            Case case3 = new Case(person1.PersonID);
            Case case4 = new Case(person2.PersonID);
            Case case5 = new Case(person4.PersonID);

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

            if (personArray.AddPerson(person1))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (personArray.AddPerson(person2))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (personArray.AddPerson(person3))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (personArray.AddPerson(person4))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (personArray.AddPerson(person5))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            #endregion

            #region Valida Inserir Casos
            if (caseArray.AddCase(case1))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (caseArray.AddCase(case2))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (caseArray.AddCase(case3))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (caseArray.AddCase(case4))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            if (caseArray.AddCase(case5))
            {
                Console.WriteLine("Inserido com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta sem espaco!!!");
            }
            #endregion

            regionsArray.ShowRegion();
            personArray.ShowPerson();
            caseArray.ShowAllCases();



            caseCount = caseArray.CountTotalCases();

            Console.WriteLine("Total de casos: {0}", caseCount);

            


            Console.Write("Insira Idade: ");
            int age = Convert.ToInt32(Console.ReadLine());

            caseCount = caseArray.CountByAge(age);
            if (caseCount > 0)
            {
                Console.WriteLine("Numero de casos com a idade inserida: {0}", caseCount);
            }
            else
            {
                Console.WriteLine("Não há casos com idade igual a {0}", age);
            }


            caseCount = caseArray.CountByGender(Person.Genders.F);
            if (caseCount > 0)
            {
                Console.WriteLine("Numero de casos com o género Feminino: {0}", caseCount);
            }
            else
            {
                Console.WriteLine("Não há casos com o género {0}", Person.Genders.M);
            }

            caseCount = caseArray.CountByGender(Person.Genders.M);
            if (caseCount > 0)
            {
                Console.WriteLine("Numero de casos com o género Masculino: {0}", caseCount);
            }
            else
            {
                Console.WriteLine("Não há casos com o género {0}", Person.Genders.M);
            }

            Console.ReadKey();
        }
    }
}
