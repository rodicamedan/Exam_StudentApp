using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Models
{
    public class Curs
    {
        public int ID { get; set; }
        public int ProfesorID { get; set; }
        public int StudentID { get; set; }
        public int CodCurs { get; set; }
        public string Denumire { get; set; }

        public Profesor Profesor { get; set; }
        public Student Student { get; set; }
    }
}
