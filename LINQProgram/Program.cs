using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LINQProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Quantifier Operations
            // Quantifier Operations are used on a data source to check if some or all elements of that data source satisfy a condition or not.
            // All the methods in quantifier ops return a boolean value.
            // Condition may be for some or all the elements.
            // All, Any, Contains
            Student[] students =
            {
                new Student() {Name= "John", Marks=90,
                Subject = new List<Subject>() {
                    new Subject() { SubjectName = "Math", SubjectMarks=89},
                    new Subject() { SubjectName = "Hindi", SubjectMarks=79},
                    new Subject() { SubjectName = "English", SubjectMarks=54},
                } },
                new Student() {Name= "Ava", Marks=80,
                Subject = new List<Subject>() {
                    new Subject() { SubjectName = "Math", SubjectMarks=86},
                    new Subject() { SubjectName = "Hindi", SubjectMarks=93},
                    new Subject() { SubjectName = "English", SubjectMarks=78},
                }   },
                new Student() {Name= "Sid", Marks=75,
                Subject = new List<Subject>() {
                    new Subject() { SubjectName = "Math", SubjectMarks=75},
                    new Subject() { SubjectName = "Hindi", SubjectMarks=84},
                    new Subject() { SubjectName = "English", SubjectMarks=95},
                }   },
            };

            List<Employee> employee = new()
            {
                new Employee() { Id = 1, FirstName = "Kim"},
                new Employee() {Id = 2, FirstName = "John" , LastName ="Stark", Email = "def@xyz.co"},

            };

            var comparer = new EmployeeComparer();

            //All Operator
            //bool methodSyntax = students.All(student => student.Marks > 70);

            //var querySyntax = (from student in students
            //                   select student).All(student => student.Marks > 70);

            var methodAllSyntax = students.Where(student => student.Subject.All(subject => subject.SubjectMarks > 76)).Select(student => student.Name).ToList();

            var queryAllSyntax = (from std in students
                              where std.Subject.All(x => x.SubjectMarks > 76)
                              select std.Name).ToList();

            // Any Operator
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            // Check if any elememnt is present in list
            bool isAvailable = numbers.Any();

            //var methodAnySyntax = students.Where(std => std.Marks >= 80).Select(student => student.Name).ToList();

            var methodAnySyntax = students.Where(std => std.Subject.Any(sub => sub.SubjectMarks > 94)).Select(std => std.Name).ToList();

            // Contains Operator
            List<string> employees = new() { "Kim", "Sam", "Vicky", "Michell" };
            var isExist = employees.AsEnumerable().Contains("Sam");

            var isExist2 = employee.Contains(new Employee() { Id = 1, FirstName = "Kim"}, comparer);


            Console.ReadLine();
        }

        class EmployeeComparer : IEqualityComparer<Employee>
        {
            public bool Equals(Employee? x, Employee? y)
            {
                if (object.ReferenceEquals(x , y))
                {
                    return true;
                }
                if (object.ReferenceEquals(x , null) || object.ReferenceEquals(y , null))
                {
                    return false;
                }

                return x.Id == y.Id && x.FirstName == y.FirstName && x.LastName == y.LastName && x.Email == y.Email;
            }

            public int GetHashCode([DisallowNull] Employee obj)
            {
                if (object.ReferenceEquals(obj, null))
                {
                    return 0;
                }

                int idHashCode = obj.Id.GetHashCode();
                int firstNameHashCode = obj.FirstName == null ? 0: obj.FirstName.GetHashCode();
                int lastNameHashCode = obj.LastName == null ? 0 : obj.LastName.GetHashCode();
                int emailHashCode = obj.Email == null ? 0 : obj.Email.GetHashCode();

                return idHashCode ^ firstNameHashCode ^ lastNameHashCode ^ emailHashCode;
            }
        }

    }
}