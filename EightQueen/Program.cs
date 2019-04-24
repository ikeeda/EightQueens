using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EightQueens
{
    class Program
    {
        static void Main(string[] args)
        {

            var board = new Board(8);

            var start = DateTime.Now;
            var rslt = board.Analyze();
            var end = DateTime.Now - start;

            for(int i = 0; i < rslt.Count(); i++)
            {
                Console.WriteLine($"{i+1};{rslt.ElementAt(i)}");
            }

            Console.WriteLine(end);
            Console.ReadLine();
        }
    }
}
