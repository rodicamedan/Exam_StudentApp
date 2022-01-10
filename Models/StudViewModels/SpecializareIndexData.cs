using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Models.StudViewModels
{
    public class SpecializareIndexData
    {
        public IEnumerable<Specializare> Specilizari { get; set; }
        public IEnumerable<Student> Studenti { get; set; }
        public IEnumerable<Curs> Cursuri { get; set; }
    }
}
