using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualGym.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="First Name")]
        [MaxLength(20,ErrorMessage = "First Name Is too long.")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(20, ErrorMessage = "Last Name Is too long.")]
        public string LastName { get; set; }
        [Required]
        public int Phone { get; set; }

        public byte Role { get; set; }

        [Required]
        [Display(Name = "Personal Picture")]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}