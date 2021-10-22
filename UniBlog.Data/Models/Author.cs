using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UniBlog.Data.Models
{
    public class Author
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public String FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public String LastName { get; set; }
        [Required]
        [MaxLength(30)]
        public String UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public String Password { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
