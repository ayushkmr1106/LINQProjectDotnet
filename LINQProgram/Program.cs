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

            List<Employee> employees = new()
            {
                new Employee() { Id = 1, FirstName = "Joey"},
                new Employee() {Id = 2, FirstName = "John" , LastName ="Stark", Email = "def@xyz.co"},
                new Employee() {Id = 3, FirstName = "Kim" , LastName ="Stark", Email = "def@xyz.co"},
                new Employee() {Id = 3, FirstName = "Kim" , LastName ="Stark", Email = "def@xyz.co"},

            };


            List<Student> student1 = new()
            {
                new Student() {Id= 1, Name = "John"},
                new Student() {Id= 2, Name = "Kim"},
                new Student() {Id= 3, Name = "Ava"},
                new Student() {Id= 4, Name = "Mark"},
            };

            List<Student> student2 = new()
            {
                new Student() {Id= 1, Name = "John"},
                new Student() {Id= 2, Name = "Kim"},
                new Student() {Id= 5, Name = "Joey"},
                new Student() {Id= 6, Name = "Sam"},
            };

            // Set Operations
            // Distinct (Removes duplicate values from data source)
            // Except (Returns all the elements from one data source that do not exist in second data source)
            // Interset (Returns all the elements which exist in both the data source.)
            // Union (Returns all the elements that appear in either of two data sources.)
            // IEquatable & IEquality operator

            // Distinct Operator
            List<int> numbers = new() { 1, 2, 3, 2, 1, 3, 2, 5, 4, 6 };
            var ms = numbers.Distinct().ToList();

            var distinctEmployee = employees.Select(emp => emp.FirstName).Distinct().ToList();

            var methodSyntax = employees.Distinct().ToList();

            // Except Operator
            List<string> datasource1 = new() { "A", "B", "C", "D" };
            List<string> datasource2 = new() { "C", "D", "E", "F" };

            var result = datasource1.Except(datasource2).ToList();

            var res = student1.Select(stud => stud.Name).Except(student2.Select(std => std.Name)).ToList();

            var msExceptUsingAnoynmous = student1.Select(x => new { x.Id, x.Name }).Except(student2.Select(x => new { x.Id, x.Name })).ToList();

            var msExceptUsingComparer = student1.Except(student2, new StudentComparer()).ToList();

            // Intersect Operator
            var msIntersect = datasource1.Intersect(datasource2).ToList();
            var msIntersect1 = student1.Select(stud => stud.Name).Intersect(student2.Select(stud => stud.Name)).ToList();

            var msIntersectUsingAnoynmous = student1.Select(x => new { x.Id, x.Name}).Intersect(student2.Select( y => new { y.Id, y.Name })).ToList();

            var msIntrsectUsingComparer = student1.Intersect(student2, new StudentComparer()).ToList();

            // Union Operator
            var msUnion = datasource1.Union(datasource2).ToList();
            var msUnion1 = student1.Select(stud => stud.Name).Union(student2.Select(stud => stud.Name)).ToList();

            var msUnionUsingAnoynmous = student1.Select(x => new { x.Id, x.Name }).Union(student2.Select(y => new { y.Id, y.Name })).ToList();

            var msUnionUsingComparer = student1.Union(student2, new StudentComparer()).ToList();

            Console.ReadLine();
        }

        class StudentComparer : IEqualityComparer<Student>
        {
            public bool Equals(Student? x, Student? y)
            {
                if (object.ReferenceEquals(x, y))
                {
                    return true;
                }
                if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
                {
                    return false;
                }
                return x.Id.Equals(y.Id) && x.Name.Equals(y.Name);
            }

            public int GetHashCode([DisallowNull] Student obj)
            {
                int idHashCode = obj.Id.GetHashCode();
                int nameHashCode = obj.Name == null ? 0 : obj.Name.GetHashCode();

                return idHashCode ^ nameHashCode;
            }
        }

        class EmployeeComparer : IEqualityComparer<Employee>
        {
            public bool Equals(Employee? x, Employee? y)
            {
                if (object.ReferenceEquals(x, y))
                {
                    return true;
                }
                if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
                {
                    return false;
                }
                return x.Id.Equals(y.Id) && x.FirstName.Equals(y.FirstName) && x.LastName.Equals(y.LastName) && x.Email.Equals(y.Email);
            }

            public int GetHashCode([DisallowNull] Employee obj)
            {
                int idHashCode = obj.Id.GetHashCode();
                int firstNameHashCode = obj.FirstName == null ? 0 : obj.FirstName.GetHashCode();
                int lastNameHashCode = obj.LastName == null ? 0 : obj.LastName.GetHashCode();
                int emailHashCode = obj.Email == null ? 0 : obj.Email.GetHashCode();

                return idHashCode ^ firstNameHashCode ^ lastNameHashCode ^ emailHashCode;
            }
        }

    }
}