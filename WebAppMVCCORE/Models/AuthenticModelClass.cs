using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WebAppMVCCORE.Models
{
    public class AuthenticModelClass
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
