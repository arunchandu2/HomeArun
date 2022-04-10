using System.ComponentModel.DataAnnotations;

namespace HomeArun.Models
{
    public class Login
    {
        [Key]
         public int? ApplicationId{ get; set; }

           public string? Password{ get; set; }
    }
}
