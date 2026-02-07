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

            // Implement Paging using skip and take opeartors
            // Paging is the process of dividing n number of records into multiple pages.
            // Paging can be implemented using LINQ Skip and Take operator.
            // How -
            // Suppose total page - t
            // Number of records per page - n
            // Formula -
            // For Index --> Skip(index * n) Take(n)
            // For Pages --> Skip((pageNumber - 1) * n) Take(n)

            int totalPagePerView = 10;
            int pageNumber;
            do
            {
                Console.WriteLine("Enter your page number");
                if (int.TryParse(Console.ReadLine(), out pageNumber))
                {
                    if (pageNumber == -1) break;
                    var ms = GetEmployee().Skip((pageNumber - 1) * totalPagePerView).Take(totalPagePerView).ToList();
                    foreach (var record in ms)
                    {
                        Console.WriteLine($"Id: {record.Id}, Name: {record.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Enter a valid page number");
                }
            }
            while (pageNumber != -1);

        }
        public static List<Student> GetEmployee()
        {

            List<Student> students = Enumerable
                .Range(1, 100)
                .Select(i => new Student
                {
                    Id = i,
                    Name = $"Student {i}"
                })
                .ToList();
            return students;
        }
    }
}