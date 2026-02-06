using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.WebSockets;

namespace LINQProgram
{
    class Program
    {
        static void Main(string[] args)
        {

            // Partitioning operations
            // Partitioning operations are used to divide data source into two parts and return one of them as output without changing element positions.
            // Take (Take operator is used to get first n number of records from a data source.)
            // TakeWhile
            // (TakeWhile operator is used to get all records from a data source until a specified condition is true.)
            // (Once the condition is failed TAkeWhile will not alidate rest elements even if the condition is true for remaining elements.
            // Skip (Skip operator is used to skip first n number of records from a data source and select remaining elements as an output.)
            // SkipWhile (SkipWhile operator is used to skip all reocurds from a data source until a condition is true and select remaining elements as an output.)

            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 4, 3, 8, 9, 10 };

            List<string> names = new List<string>() { "Kim", "John", "Mark", "Adam", "Sam" };

            // Take
            var msTake = numbers.Take(5).ToArray();
            var msTakeWhere = numbers.Where(num => num > 3).Take(5).ToArray();

            // TakeWhile
            var msTakeWhile = numbers.TakeWhile(num => num < 5).ToArray();
            var msTakeWhile1 = names.TakeWhile((name, index) => index < 3).ToArray();

            // Skip
            var msSkip = numbers.Skip(5).ToArray();
            var msSkipWhere = numbers.Where(x => x > 5).Skip(2).ToArray();

            // SkipWhile
            var msSkipWhile = numbers.SkipWhile(x => x < 6).ToArray();
            var msSKipWhile1 = names.SkipWhile((name, index) => index < 3).ToArray();

            Console.ReadLine();
        }
    }
}