using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KlinikAPI.Models
{
    public class User
    {
        public int id { get; set; }
        [Required]
        public String Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
