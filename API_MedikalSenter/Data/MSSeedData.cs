using API_MedikalSenter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace API_MedikalSenter.Data
{
    public static class MSSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Api_MedikalSenterContext(
                serviceProvider.GetRequiredService<DbContextOptions<Api_MedikalSenterContext>>()))
            {
                //doctors first.. since we cant have patients without doctors.
                if (!context.Doctors.Any())
                {
                    context.Doctors.AddRange(
                        new Doctor
                        {
                            FirstName = "Geir",
                            MiddleName = "A",
                            LastName = "Frukteter"
                        },

                        new Doctor
                        {
                            FirstName = "Henrik",
                            MiddleName = "B",
                            LastName = "Walsmer"
                        },

                          new Doctor
                          {
                              FirstName = "Maria",
                              MiddleName = "C",
                              LastName = "Knokker"
                          },
                              new Doctor
                              {
                                  FirstName = "Charles",
                                  LastName = "Xavier"
                              });
                    context.SaveChanges();//forgotten.. couldnt save any into databae
                }

                //any patient registeres to a doctor is oblig
                if (!context.Patients.Any())
                { 
                    context.Patients.AddRange(
                 new Patient
                 {
                     FirstName = "Wilma",
                     MiddleName = "AA",
                     LastName = "Flintstone",
                     OHIP = "1231231234",
                     DOB = DateTime.Parse("1986-05-11"),
                     ExpYrVisits = 2,
                     DoctorID = context.Doctors.FirstOrDefault
                     (d => d.FirstName == "Geir" && d.LastName == "Frukteter").ID
                 },

                      new Patient
                      {
                          FirstName = "Barney",
                          LastName = "Moloztash",
                          OHIP = "2312312341",
                          DOB = DateTime.Parse("1985-04-29"),
                          ExpYrVisits = 1,
                          DoctorID = context.Doctors.FirstOrDefault
                     (d => d.FirstName == "Henrik" && d.LastName == "Walsmer").ID
                      },

                         new Patient
                         {
                             FirstName = "Fred",
                             LastName = "Chakmaktash",
                             OHIP = "3123123412",
                             DOB = DateTime.Parse("1982-08-17"),
                             ExpYrVisits = 4,
                             DoctorID = context.Doctors.FirstOrDefault
                     (d => d.FirstName == "Maria" && d.LastName == "Knokker").ID
                         });
                    context.SaveChanges();
                }

            }
        }

    }
}
