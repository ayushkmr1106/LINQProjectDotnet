using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQProgram
{
    internal class Student
    {
        public string? Name { get; set; }
        public int Marks { get; set; }
        public List<Subject>? Subject {  get; set; }
    }

    internal class Subject()
    {
        public string? SubjectName { get; set; }
        public int SubjectMarks { get; set; }
    }
}
