using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualGym.Models
{
    public class Gym
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "GYM Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "GYM Address")]
        public string Address { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required]
        [Display(Name = "GYM Policy")]
        public string Policy { get; set; }

        public Gym()
        {

        }
        public Gym(Gym newGym)
        {
            Id = newGym.Id;
            Name = newGym.Name;
            Address = newGym.Address;
            Phone = newGym.Phone;
            Policy = newGym.Policy;
        }
    }
}