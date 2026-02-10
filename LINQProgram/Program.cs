using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.WebSockets;
using System.Text.RegularExpressions;

namespace LINQProgram
{
    class Program
    {
        static void Main(string[] args)
        {

            // Join Operations
            // A Join of two data sourrces is the association of objects in one data source with objects that share a common attribute in another data source.

            List<Student> students = new()
            {
                new Student() {Id = 1, Name = "A", CategoryId = 1 },
                new Student() {Id = 2, Name = "B", CategoryId = 1 },
                new Student() {Id = 3, Name = "C", CategoryId = 2 },
                new Student() {Id = 4, Name = "D", CategoryId = 2 },
                new Student() {Id = 5, Name = "E", CategoryId = 3 }
            };

            List<Category> categories = new()
            {
                new Category() { Id = 1, Name = "Monitor" },
                new Category() { Id = 2, Name = "Discipline" },
                new Category() { Id = 3, Name = "Nothing" },
            };

            // Group Join
            // Group join is applied on 2 or more data sources based on a key which links both the data sources and produce result in form of groups.
            // In Simple words - Group join is used to group the result based on a common key.

            var ms = categories.GroupJoin(students, cat => cat.Id, std => std.CategoryId, (cat, std) => new { cat, std });

            var qs = from cat in categories
                     join std in students
                     on cat.Id equals std.CategoryId into stdGroups
                     select new { cat, stdGroups };

            Console.WriteLine("-------Method Syntax-------");
            foreach (var item in ms)
            {
                Console.WriteLine(item.cat.Name + "-->");

                foreach (var c in item.std)
                {
                    Console.WriteLine(c.Name);
                }
            }
            Console.WriteLine("-------Query Syntax-------");
            foreach (var item in qs)
            {
                Console.WriteLine(item.cat.Name + "-->");

                foreach (var c in item.stdGroups)
                {
                    Console.WriteLine(c.Name);
                }
            }

            Console.ReadLine();
        }
    }
}