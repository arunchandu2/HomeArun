using System.ComponentModel.DataAnnotations;

namespace HomeArun.Models
{
    public class LoanTracker
    {
        [Key]
        public int ApplicationId { get; set; }

        public string MobileNumber { get; set; }
    }
}
