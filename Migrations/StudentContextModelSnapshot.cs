// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentApp.Data;

namespace StudentApp.Migrations
{
    [DbContext(typeof(StudentContext))]
    partial class StudentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentApp.Models.Curs", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodCurs")
                        .HasColumnType("int");

                    b.Property<string>("Denumire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfesorID")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProfesorID");

                    b.HasIndex("StudentID");

                    b.ToTable("Curs");
                });

            modelBuilder.Entity("StudentApp.Models.Profesor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CNP")
                        .HasColumnType("int");

                    b.Property<int>("CodProf")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNasterii")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Profesor");
                });

            modelBuilder.Entity("StudentApp.Models.Specializare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DenumireSpecializare")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Domeniu")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("ID");

                    b.ToTable("Specializare");
                });

            modelBuilder.Entity("StudentApp.Models.SpecializareStudenti", b =>
                {
                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("SpecializareID")
                        .HasColumnType("int");

                    b.HasKey("StudentID", "SpecializareID");

                    b.HasIndex("SpecializareID");

                    b.ToTable("SpecializareStudenti");
                });

            modelBuilder.Entity("StudentApp.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CNP")
                        .HasColumnType("int");

                    b.Property<int>("CodStud")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNasterii")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("StudentApp.Models.Curs", b =>
                {
                    b.HasOne("StudentApp.Models.Profesor", "Profesor")
                        .WithMany("Cursuri")
                        .HasForeignKey("ProfesorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentApp.Models.Student", "Student")
                        .WithMany("Cursuri")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profesor");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentApp.Models.SpecializareStudenti", b =>
                {
                    b.HasOne("StudentApp.Models.Specializare", "Specializare")
                        .WithMany("SpecializareStudenti")
                        .HasForeignKey("SpecializareID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentApp.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specializare");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentApp.Models.Profesor", b =>
                {
                    b.Navigation("Cursuri");
                });

            modelBuilder.Entity("StudentApp.Models.Specializare", b =>
                {
                    b.Navigation("SpecializareStudenti");
                });

            modelBuilder.Entity("StudentApp.Models.Student", b =>
                {
                    b.Navigation("Cursuri");
                });
#pragma warning restore 612, 618
        }
    }
}
