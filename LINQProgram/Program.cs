namespace LINQProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //var querySyntax = from obj in list
            //                  where obj > 2
            //                  select obj;

            var methodSyntax = list.Where(num => num > 2);

            //foreach (var item in methodSyntax)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.ReadLine();

            List<Employees> employees = new List<Employees>()
            {
                new Employees { Id = 1, Name = "Emp1", Email = "Emp1@abc.co" },
                new Employees { Id = 2, Name = "Emp2", Email = "Emp2@abc.co" },
                new Employees { Id = 3, Name = "Emp3", Email = "Emp3@abc.co" },
                new Employees { Id = 4, Name = "Emp4", Email = "Emp4@abc.co" },
                new Employees { Id = 5, Name = "Emp5", Email = "Emp5@abc.co" },
            };

            /*
            IEnumerable<Employees> query = from emp in employees
                                           where emp.Id == 1
                                           select emp;

            IQueryable<Employees> query1 = employees.AsQueryable().Where(emp => emp.Id == 1);

            foreach (Employees emp in query)
            {
                Console.WriteLine(emp.Id + " " + emp.Name);
            }      */


            // Projection Operator (SELECT)
            /*var basicQuery = (from emp in employees
                             select emp.Id + 1).ToList();
            var basicMethod = employees.Select(emp => emp.Id + 1).ToList();*/

            /*var selectQuery = (from emp in employees
                               select new Employees()
                               {
                                   Id = emp.Id,
                                   Email = emp.Email
                               }).ToList();

            var selectMethod = employees.Select(emp => new Employees()
            {
                Id = emp.Id,
                Email = emp.Email
            }).ToList();*/

            var query = employees.Select((emp, index) => new { Index = index, FullName = emp.Name }).ToList();

            foreach (var emp in query)
            {
                Console.WriteLine(emp.Index + ", " + emp.FullName);
            }

            Console.ReadLine();
        }
    }

    class Employees
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}