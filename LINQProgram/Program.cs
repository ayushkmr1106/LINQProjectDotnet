namespace LINQProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //var querySyntax = from obj in list
            //                  where obj > 2
            //                  select obj;

            // var methodSyntax = list.Where(num => num > 2);

            //foreach (var item in methodSyntax)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.ReadLine();

            /*List<Employees> employees = new List<Employees>()
            {
                new Employees { Id = 1, Name = "Emp1", Email = "Emp1@abc.co", Programming = new List<string>() {"C#", "PHP", "JAVA" } },
                new Employees { Id = 2, Name = "Emp2", Email = "Emp2@abc.co", Programming = new List<string>() {"C#", "Python", "Scala" } },
                new Employees { Id = 3, Name = "Emp3", Email = "Emp3@abc.co", Programming = new List<string>() {"C++", "PHP", "Ruby" } },
                new Employees { Id = 4, Name = "Emp4", Email = "Emp4@abc.co", Programming = new List<string>() {"C", "Python", "JAVA" } },
                new Employees { Id = 5, Name = "Emp5", Email = "Emp5@abc.co", Programming = new List<string>() {"Ruby", "JavaScript", "JAVA" } },
            };*/

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

            // var query = employees.Select((emp, index) => new { Index = index, FullName = emp.Name }).ToList();

            //foreach (var emp in query)
            //{
            //    Console.WriteLine(emp.Index + ", " + emp.FullName);
            //}

            // SelectMany
            // SelectMany is used to project each element of a sequence to an IEnumerable<T> and flattens the resulting sequence into one sequence.
            // SelectMany combines records from a sequence of result and converto it into one result.

            /*List<string> strList = new List<string>() { "Michell", "Ava" };
            var methodResult = strList.SelectMany(x => x).ToList();
            var queryResult = (from rec in strList
                              from ch in rec
                              select ch).ToList();*/

            /*var methodSyntax = employees.SelectMany(emp => emp.Programming).ToList();

            var querySyntax = (from emp in employees
                              from skill in emp.Programming
                              select skill).ToList();*/

            List<Employees> employees = new List<Employees>()
            {
                new Employees { Id = 1, Name = "Emp1", Email = "Emp1@abc.co",
                    Programming = new List<Techs> {
                    new Techs() {Technology = "C#" },
                    new Techs() {Technology = "PHP" },
                    new Techs() {Technology = "JAVA" }
                } },
                new Employees { Id = 2, Name = "Emp2", Email = "Emp2@abc.co",Programming = new List<Techs> {
                    new Techs() {Technology = "C" },
                    new Techs() {Technology = "Python" },
                    new Techs() {Technology = "JAVA" }
                } },
                new Employees { Id = 3, Name = "Emp3", Email = "Emp3@abc.co", Programming = new List<Techs> {
                    new Techs() {Technology = "Ruby" },
                    new Techs() {Technology = "Scala" },
                    new Techs() {Technology = "JAVA" }
                } },
                new Employees { Id = 4, Name = "Emp4", Email = "Emp4@abc.co", Programming = new List<Techs>() },
                new Employees { Id = 5, Name = "Emp5", Email = "Emp5@abc.co", Programming = new List<Techs>() }
            };

            //var methodSyntax = employees.SelectMany(emp => emp.Programming).ToList();

            //var querySyntax = (from emp in employees
            //                  from program in emp.Programming
            //                  select program).ToList();

            // Filtering Operators - Where Operator
            // Filtering is the porcess to get only those elements form a data souce who satisfy a specified condition.
            // Where is used to filter specific data from a data source based on a condition.
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //var querySyntax = (from number in list
            //                   where number % 2 == 0
            //                   select number).ToList();
            //var methodSyntax = list.Where(x => x % 2 == 0).ToList();

            var querySyntax = employees.Where(emp => emp.Programming.Count == 0).ToList(); ;

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