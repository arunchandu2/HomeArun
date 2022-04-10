using System.ComponentModel.DataAnnotations;

namespace HomeArun.Models
{
    public class LoanDetails
    {
        [Key]
        public int? LoanId { get; set; }

        public double? MaxAmountGrantable { get; set; }

        public double? InterestRate { get; set; }
        public int? tenure { get; set; }

        public double? TotalLoanAmount { get; set; }

    }
}
