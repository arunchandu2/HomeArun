using System.ComponentModel.DataAnnotations;

namespace HomeArun.Models
{
    public class IncomeDetails
    {
        [Key]
        public int ApplicationId { get; set; }
        public string PropertyLocation { get; set; }

        public string PropertyType { get; set; }

        public double EstimatedAmount { get; set; }

        public int RetirementAge { get; set; }

        public string OrganizationType { get; set; }

        public string EmployerName { get; set; }
    }
}
