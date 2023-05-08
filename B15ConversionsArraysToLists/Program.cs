using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B15ConversionsArraysToLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = { "a",  "b", "c" };

            List<string> list = array.ToList();

            string[] array2 = list.ToArray();

            Console.WriteLine(array);
            Console.WriteLine(array2);

            Console.ReadKey();
        }
    }
}
