using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Models
{
    public class SpecializareStudenti
    {
        public int SpecializareID { get; set; }
        public int StudentID { get; set; }
        public Specializare Specializare { get; set; }
        public Student Student { get; set; }
    }
}
