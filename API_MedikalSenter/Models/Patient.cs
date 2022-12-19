using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using System.Text.Json.Serialization;

namespace API_MedikalSenter.Models
{
    public class Patient
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

        [Required(ErrorMessage = "dont leave OHIP blank")]
        [RegularExpression("^\\d{10}$", ErrorMessage = "OHIP is exact 10 digits")]
        [StringLength(10)]//we include this to limit the size of database field to 10 digits
        public string OHIP { get; set; }

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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        [Display(Name = "Visits/Yr")]
        [Required(ErrorMessage = "You cannot leave the number of expected vists per year blank.")]
        [Range(1, 12, ErrorMessage = "The number of expected vists per year must be between 1 and 12.")]
        public byte ExpYrVisits { get; set; }

        [Timestamp]
        public Byte[] RowVersion { get; set; }

        [Required(ErrorMessage = "You must select a Primary Care Physician.")]
        [Display(Name = "Doctor")]
        [Range(1, int.MaxValue, ErrorMessage = "must select a doctor as primary care physician")]
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }

    }
}
