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

            var dataSource = new List<Employee>()
            {
                new Employee()
                {
                    Id = 3,
                    Email = "Smith@abc.co",
                    LastName = "Smith",
                    FirstName = "Foo"
                },
                new Employee()
                {
                    Id = 2,
                    Email = "Thomas@abc.co",
                    LastName = "Thomas",
                    FirstName = "Mark"
                },
                new Employee()
                {
                    Id = 1,
                    Email = "Allen@email.com",
                    LastName = "Allen",
                    FirstName = "Mark"
                },
                new Employee()
                {
                    Id = 4,
                    Email = "Anderson@email.com",
                    LastName = "Anderson",
                    FirstName = "Foo"
                }
            };

            // Reverse Operator
            int[] rollNums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var methodSyntax = rollNums.Reverse();

            // Mixed Syntax
            var querySyntax = (from number in rollNums
                               select number).Reverse();
            
            // System.Collections.Generic namespace - In-Place Sorting
            // dataSourceString.Reverse();
            
            // System.Linq namespace - Out-Of-Place Sorting
            var qs = dataSourceString.AsEnumerable().Reverse();
            
            foreach (var item in qs)
            {
                Console.WriteLine(item);
            }


            Console.ReadLine();
        }
    }
}