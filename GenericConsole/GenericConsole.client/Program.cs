using System;
using glm=GenericConsole.Library.Models;

namespace GenericConsole.Client
{
  public class Program
  {
    static void Main(string[] args)
    {
            //PlayWithGeneric();
            PlayWithGenericEmployee();
    }

    static void PlayWithGeneric()
    {
            var g1 = new glm.Client();
            var g2 = new glm.Client();

            foreach (var item in glm.Client.Clients.Peoples)
            {
                Console.WriteLine("{0}\n{1}",item.Name,item.Title);
            }
             
    }

    static void PlayWithGenericEmployee()
        {
            var a1 = new glm.Employee<glm.Associate>();
            var t1 = new glm.Employee<glm.Trainer>();
            var a2 = new glm.Employee<glm.Associate>();
            var t2 = new glm.Employee<glm.Trainer>();

            foreach (var item in glm.Employee<glm.Associate>.Employees.Peoples)
            {
                Console.WriteLine("{0}\n{1}", item.Name, item.Title);
            }

            foreach (var item in glm.Employee<glm.Trainer>.Employees.Peoples)
            {
                Console.WriteLine("{0}\n{1}", item.Name, item.Title);
            }
        }
  }
}