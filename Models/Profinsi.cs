using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KlinikAPI.Models
{
    public class Profinsi
    {
        public int id { get; set; }
        public string name { get; set; }
        
        public DateTime updated_date { get; set; }
        [Required]
        public string Pulau { get; set; }

        public int updated_by { get; set; }

    }
}
