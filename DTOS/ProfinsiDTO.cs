using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KlinikAPI.DTOS
{
    public class ProfinsiDTO
    {
        public int id { get; set; }
        [Required (ErrorMessage = "Profinsi Name is madatory field")]
        [StringLength(50, MinimumLength = 2)] //error msg should be "The field name must be a string with a minimum length of 2 and a maximum length of 50."
        [RegularExpression(".*[a-zA-Z]+.*",ErrorMessage = "Only Numerics are not allowed")]
        public string name { get; set; }
        [Required]
        public string Pulau { get; set; }
    }
}
