using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace WebAppMVCCORE.Models
{
    public class ValidateModelClass
    {
        [Required(ErrorMessage = "FirstName Required")]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*")]
        [EmailAddress]
        public string MailAddress { get; set; }

        [Range(0.00,999.99)]
        public float Cost { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNumber { get; set; }
    }
}
