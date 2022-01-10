using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace StudentApp.Models
{
    public class Specializare
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Specializare Facultate")]
        [StringLength(50)]
        public string DenumireSpecializare { get; set; }

        [StringLength(70)]
        public string Domeniu { get; set; }
        public ICollection<SpecializareStudenti> SpecializareStudenti { get; set; }
    }
}
