namespace pd10.Data;

using pd10.Models;
using Microsoft.EntityFrameworkCore;


public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

    
     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        

            modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
            {
                new Doctor
                {
                    IdDoctor = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Email = "j@kow"
                },
                new Doctor
                {
                    IdDoctor = 2,
                    FirstName = "Anna",
                    LastName = "Nowak",
                    Email = "a@now"
                },
                new Doctor
                {
                    IdDoctor = 3,
                    FirstName = "Jan",
                    LastName = "Drabina",
                    Email = "j@dr"
                },
                new Doctor
                {
                    IdDoctor = 4,
                    FirstName = "Anna",
                    LastName = "Drabina",
                    Email = "a@dr"
                }
                
            });

            modelBuilder.Entity<Patient>().HasData(new List<Patient>
            {
                new Patient
                {
                    IdPatient = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Birthdate = new DateTime(1990, 1, 1)
                },
                new Patient
                {
                    IdPatient = 2,
                    FirstName = "Anna",
                    LastName = "Nowak",
                    Birthdate = new DateTime(1991, 2, 2)
                },
                new Patient
                {
                    IdPatient = 3,
                    FirstName = "Jan",
                    LastName = "Drabina",
                    Birthdate = new DateTime(1992, 3, 3)
                },
                new Patient
                {
                    IdPatient = 4,
                    FirstName = "Anna",
                    LastName = "Drabina",
                    Birthdate = new DateTime(1993, 4, 4)
                }
            });
            
            modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
            {
                new Medicament
                {
                    IdMedicament = 1,
                    Name = "Apap",
                    Description = "bol glowy",
                    Type = "tabletki"
                },
                new Medicament
                {
                    IdMedicament = 2,
                    Name = "Ibuprofen",
                    Description = "bol",
                    Type = "tabletki"
                },
                new Medicament
                {
                    IdMedicament = 3,
                    Name = "Kwas omega",
                    Description = "suplement",
                    Type = "tabletki"
                },
                new Medicament
                {
                    IdMedicament = 4,
                    Name = "Witamina C",
                    Description = "suplement",
                    Type = "tabletki"
                }
            });
            
            modelBuilder.Entity<Prescription_Medicament>().HasData(new List<Prescription_Medicament>
            {
                new Prescription_Medicament
                {
                    IdMedicament = 1,
                    IdPrescription = 1,
                    Dose = 2,
                    Details = "codziennie"
                },
                new Prescription_Medicament
                {
                    IdMedicament = 2,
                    IdPrescription = 2,
                    Dose = 3,
                    Details = "codziennie"
                },
                new Prescription_Medicament
                {
                    IdMedicament = 3,
                    IdPrescription = 3,
                    Dose = 1,
                    Details = "codziennie"
                },
            });

            modelBuilder.Entity<Prescription>().HasData(new List<Prescription>
            {
                new Prescription
                {
                    IdPrescription = 1,
                    Date = new DateTime(2021, 1, 1),
                    DueDate = new DateTime(2021, 1, 10),
                    IdDoctor = 1,
                    IdPatient = 1
                },
                new Prescription
                {
                    IdPrescription = 2,
                    Date = new DateTime(2021, 2, 2),
                    DueDate = new DateTime(2021, 2, 20),
                    IdDoctor = 2,
                    IdPatient = 2
                },
                new Prescription
                {
                    IdPrescription = 3,
                    Date = new DateTime(2021, 3, 3),
                    DueDate = new DateTime(2021, 3, 30),
                    IdDoctor = 3,
                    IdPatient = 3
                },
              
            });
    }
}
