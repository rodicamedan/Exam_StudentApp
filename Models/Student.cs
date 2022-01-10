using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Models
{
    public class Student
    {

        public int ID { get; set; }
        public int CodStud { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public DateTime DataNasterii { get; set; }
        public int CNP { get; set; }
        public string Email { get; set; }
        public ICollection<Curs> Cursuri { get; set; }
    }
}
