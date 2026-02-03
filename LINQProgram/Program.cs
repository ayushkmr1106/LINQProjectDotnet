using System.ComponentModel.DataAnnotations;

namespace LINQProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // OfType Operator | Filtering Operator
            // OfType is used to filter specific data based on their type.
            // OfType is used as a generic method to filter data based on any type.
            var dataSource = new List<object>() { "Adam", "Harry", "Kim", "John", 1, 2, 3, 4, 5 };

            var methodSyntax = dataSource.OfType<string>().Where(x => x.Length > 3).ToList();
            var querySyntax = (from x in dataSource
                              where x is string
                              select Convert.ToString(x)).ToList();

            Console.ReadLine();
        }
    }

    class Employees
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        // public List<string>? Programming { get; set; }
        public List<Techs>? Programming { get; set; }
    }

    class Techs
    {
        public string? Technology { get; set; }
    }
}