using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "Lets go. C#. Lesson #2.";
            Console.WriteLine("Enter task number");
            Byte choise = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _\n");
            switch (choise)
            {
                case 1: Task_1.Run(); break;
                case 2: Task_2.Run(); break;

                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("This task is not exist! \n");
                    Console.ForegroundColor = ConsoleColor.Gray; break;


            }

            Console.Read();
        }
    }
}
