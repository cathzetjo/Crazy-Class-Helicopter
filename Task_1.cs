using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Zadanie2
{
    class Task_1
    {

        public static void Run()

        {           
            Console.Write("Enter your Surname:"); 
            string str = Console.ReadLine();        //ZHADKO
            Console.WriteLine();
            
            var res = str.Select(c => new { Symbol = c, Code = (int)c, Count = str.Where(ch => ch == c).Count() }).Distinct();

            foreach (var element in res)
            {
                Console.WriteLine($"Letter: {element.Symbol}, code: {element.Code}, number of repits: {element.Count}");
            }
            Console.WriteLine();

            var result = str.Select(c => new { Symbol = c, Code = (int)c, Count = str.Where(ch => ch == c).Count() }).
            Distinct().Sum(s => Math.Pow(s.Code, s.Count)) % 8;


            Console.Write("Formula:");
        
            foreach (var element in res)
            {
                Console.Write($" {element.Code}^{element.Count} +");
            }
            Console.WriteLine();


            Console.WriteLine($"Congratulation, the number of your variant is {result} !");

        }
    }
}
