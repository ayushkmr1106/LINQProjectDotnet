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

            var methodSyntax = dataSource.OrderBy(emp => emp.FirstName).ThenByDescending(emp => emp.LastName).ToList();

            var querySyntax = (from emp in dataSource
                              orderby emp.FirstName descending, emp.LastName descending
                              select emp).ToList();

            foreach (var item in querySyntax)
            {
                Console.WriteLine($"Id: {item.Id}, Full Name: {item.FirstName} {item.LastName}, Email: {item.Email}");
            }


            Console.ReadLine();
        }
    }
}