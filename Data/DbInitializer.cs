using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentApp.Models;
namespace StudentApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(StudentContext context)
        {
            context.Database.EnsureCreated();
            if (context.Studenti.Any())
            {
                return; // BD a fost creata anterior
            }
            var studenti = new Student[]
            {
        new Student{CodStud=11, Nume="Pop",Prenume="Ana",DataNasterii=DateTime.Parse("1999-09-01"),CNP=1323456789,Email="popana@gmail.com" },
        new Student{CodStud=12, Nume="Muresan",Prenume="Ion",DataNasterii=DateTime.Parse("1989-07-01"),CNP=1258446789,Email="muresanion@gmail.com" },
        new Student{CodStud=13, Nume="Teodorescu",Prenume="Andrei",DataNasterii=DateTime.Parse("1997-06-12"),CNP=2113456789,Email="tandrei@gmail.com" },
            };
            foreach (Student s in studenti)
            {
                context.Studenti.Add(s);
            }
            context.SaveChanges();
            var profesori = new Profesor[]
            {

        new Profesor{CodProf=51,Nume="Moldovan",Prenume="Catalin",DataNasterii=DateTime.Parse("1979-09-01"),CNP=1323196789,Email="moldovan.catalin@gmail.com"},
        new Profesor{CodProf=52,Nume="Mora",Prenume="Iulia",DataNasterii=DateTime.Parse("1971-11-06"),CNP=1423192189,Email="morai@gmail.com"},
        new Profesor{CodProf=53,Nume="Iakab",Prenume="Marius",DataNasterii=DateTime.Parse("1981-09-01"),CNP=1321296789,Email="imarius@gmail.com"},
            };
            foreach (Profesor c in profesori)
            {
                context.Profesori.Add(c);
            }
            context.SaveChanges();
            var orders = new Curs[]
            {
            new Curs{ProfesorID=51,StudentID=12,CodCurs=91,Denumire="Matematica"},
            new Curs{ProfesorID=52,StudentID=11,CodCurs=92,Denumire="Statistica"},
 };
            foreach (Curs e in orders)
            {
                context.Cursuri.Add(e);
            }
            context.SaveChanges();
            var specializare = new Specializare[]
 {

             new Specializare{DenumireSpecializare="Informatica",Domeniu="Cibernetica"},
             new Specializare{DenumireSpecializare="Contabilitate",Domeniu="Contabilitate"},
             new Specializare{DenumireSpecializare="Finante",Domeniu="Economie"},

             };
            foreach (Specializare s in specializare)
            {
                context.Specializari.Add(s);
            }
            context.SaveChanges();
            var specilizarestudenti = new SpecializareStudenti[]
 {
             new SpecializareStudenti {
             StudentID = studenti.Single(c => c.Nume == "Pop" ).ID,
             SpecializareID = specializare.Single(i => i.DenumireSpecializare == "Informatica").ID
             },
             new SpecializareStudenti {
             StudentID = studenti.Single(c => c.Nume == "Muresan" ).ID,
             SpecializareID = specializare.Single(i => i.DenumireSpecializare == "Finante").ID
             },
             };
            foreach (SpecializareStudenti ss in specilizarestudenti)
            {
                context.SpecilizariStudenti.Add(ss);
            }
            context.SaveChanges();

        }


    }
}
