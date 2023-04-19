using System.ComponentModel.DataAnnotations;

namespace Zaren.Web.Models
{
    public class LoginUser
    {
        [Required]
        public string Agency { get; set; }
        [Required]
        public string User { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
