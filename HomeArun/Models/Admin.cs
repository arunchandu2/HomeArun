using System.ComponentModel.DataAnnotations;

namespace HomeArun.Models
{
    public class Admin
    {
        

        [Display(Name = "Admin ID")]
        public int AdminId { get; set; }
        [Display(Name = "Password")]
        public string AdminPassword { get; set; }

    }
}
