using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentBlog.Models
{
    public class Blog
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string BlogName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime PublishedDate { get; set; }

        [Required]
        public string Author { get; set; }


    }
}
