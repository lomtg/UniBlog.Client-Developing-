using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UniBlog.Data.Models
{
    public class Article
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public String AuthorUsername { get; set; }
        [Required]
        [MaxLength(50)]
        public String Title { get; set; }

        [Required]
        [MaxLength(500)]
        public String Description { get; set; }

    }
}
