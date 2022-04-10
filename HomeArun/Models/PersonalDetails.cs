using System.ComponentModel.DataAnnotations;

namespace HomeLoanArun.Models
{
    public class PersonalDetails
    {
        [Key]
        [Display(Name = "Application ID")]
        public int? ApplicationID { get; set; }

        [Required]
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public string? EmailId { get; set; }

        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }
        public DateTime Dob { get; set; }

     
    }
}
