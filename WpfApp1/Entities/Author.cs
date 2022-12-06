using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Entities
{
    public class Author
    {
        [Key] // Primary Key
        public int Id { get; set; }

        // [Required] // Not null
        public string FirstName { get; set; }

        // [Required]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public override string ToString()
        {
            return FirstName;
        }


    }
}
