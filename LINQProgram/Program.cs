using System.ComponentModel.DataAnnotations;

namespace LINQProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sorting Operators 
            // There are five methods in Sorting:
            // 1. OrderBy: Sort data in ascending order.
            // 2. OrderByDescending: Sort data in descending order.
            // 3. ThenBy
            // 4. ThenByDescending
            // 5. Reverse

            // OrderBy
            var dataSourceInt = new List<int>() { 5, 12, 13, 1, 8, 33, 20 };

            var dataSourceString = new List<string>()
            {
                "Smith",
                "Anderson",
                "Wright",
                "Mitchell",
                "Thomas",
                "Allen",
                "Evans",
                "Collins"
            };

            //var querySyntax = (from num in dataSourceInt
            //                   where num > 15
            //                  orderby num
            //                  select num).ToList();
            //var methodSyntax = dataSourceInt.Where(num => num > 15).OrderBy(num => num).ToList();

            //var querySyntax = (from name in dataSourceString
            //                  orderby name
            //                  select name).ToList();

            //var methodSyntax = dataSourceString.OrderBy(name => name).ToList();

            //foreach (var name in querySyntax)
            //{
            //    Console.WriteLine(name);
            //}

            // OrderByDescending
            var methodSyntax = dataSourceInt.OrderByDescending(num => num).ToList();

            var querySyntax = (from num in dataSourceInt
                              orderby num descending
                              select num).ToList();

            Console.ReadLine();
        }
    }
}