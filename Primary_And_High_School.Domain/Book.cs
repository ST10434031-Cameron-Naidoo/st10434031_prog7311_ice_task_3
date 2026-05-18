using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primary_And_High_School.Domain
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;

        // Foreign key to Subject
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
    }
}
