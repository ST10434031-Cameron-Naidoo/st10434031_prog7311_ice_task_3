using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primary_And_High_School.Domain
{
    public class Subject
    {

            public int SubjectId { get; set; }
            public string SubjectName { get; set; } = string.Empty;
            public int NumCredits { get; set; }

            // Foreign key to Student
            public string StudentNumber { get; set; } = string.Empty;
            public Student? Student { get; set; }

            // Navigation
            public List<Book> Books { get; set; } = new List<Book>();
        }
}
