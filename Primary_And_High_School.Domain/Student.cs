using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primary_And_High_School.Domain
{
    public class Student
    {

        public string StudentNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
