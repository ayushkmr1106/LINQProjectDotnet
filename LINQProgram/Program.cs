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

            // Join Operations
            // A Join of two data sourrces is the association of objects in one data source with objects that share a common attribute in another data source.

            List<Student> students = new()
            {
                new Student() {Id = 1, Name = "A", AddressId = 1 },
                new Student() {Id = 2, Name = "B", AddressId = 0 },
                new Student() {Id = 3, Name = "C", AddressId = 2 },
                new Student() {Id = 4, Name = "D", AddressId = 0 },
                new Student() {Id = 5, Name = "E", AddressId = 3 }
            };

            List<Address> addresses = new()
            {
                new Address() { Id = 1, AddressLine = "Line 1" },
                new Address() { Id = 2, AddressLine = "Line 2" },
                new Address() { Id = 3, AddressLine = "Line 3" },
                new Address() { Id = 4, AddressLine = "Line 4" },
                new Address() { Id = 5, AddressLine = "Line 5" }
            };

            List<Marks> marks = new()
            {
                new Marks() {Id = 1, StudentId=1, TMarks=80 },
                new Marks() {Id = 2, StudentId=2, TMarks=90 },
                new Marks() {Id = 3, StudentId=3, TMarks=95 }
            };

            // Inner Join
            var msInnerJoin = students.Join(addresses, std => std.AddressId, adr => adr.Id, (std, adr) => new
            {
                StudentName = std.Name,
                Line = adr.AddressLine
            }).ToList();


            // Inner Join in Multiple tables in LINQ
            var msInnerJoinMultipleTable = students.Join(addresses, 
                std => std.AddressId,
                adr => adr.Id,
                (std, adr) => new { std, adr })
                .Join(marks,
                student => student.std.Id,
                marks => marks.StudentId, 
                (student, marks) => new { student, marks })
                .Select(x => new
                {
                    StudentName = x.student.std.Name,
                    Line = x.student.adr.AddressLine,
                    TotalMarks = x.marks.TMarks
                })
                .ToList();

            var qsInnerJoinMultipleTable = (from student in students
                    join address in addresses
                    on student.AddressId equals address.Id
                    join mark in marks
                    on student.Id equals mark.StudentId
                    select new
                    {
                        StudentName = student.Name,
                        Line = address.AddressLine,
                        TotalMarks = mark.TMarks
                    }).ToList();

            Console.ReadLine();
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