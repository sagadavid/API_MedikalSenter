using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using Newtonsoft.Json;

namespace API_MedikalSenter.Models
{
    public class Doctor
    {
        public int ID { get; set; }
        
        [JsonIgnore]
        public string FullName
        {

            get
            {
                return FirstName
                    + (string.IsNullOrEmpty(MiddleName) ? " " :
                    (" " + (char?)MiddleName[0] + ". ").ToUpper())
                    + LastName;
            }

        }
        
        [JsonIgnore]
        public string FormalName { 
        
        get {
                return LastName + "," + FirstName
                    + (string.IsNullOrEmpty(MiddleName) ? "" :
                    ("" + (char?)MiddleName[0] + ".").ToUpper());
                    }
        
        }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "dont leave first name blank")]
        [StringLength(50, ErrorMessage = "first name, not more than 50 char")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(50, ErrorMessage = "middle name no more than 50 char")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "dont leave last name blank")]
        [StringLength(100, ErrorMessage = "last name, not more than 100 char")]
        public string LastName { get; set; }

        [Timestamp]
        public Byte[] RowVersion { get; set; }

        //to hinder a circular reference in api which is not wanted, decorate it with ignore
        //we cut cycle from doctor to patient side,
        //'cause it aint necessary to have doctor to patient
        //but is necessary reach from patient to doctor
       
        [JsonIgnore]
        public ICollection<Patient> Patients { get; set; } = new HashSet<Patient>();

    }
}
