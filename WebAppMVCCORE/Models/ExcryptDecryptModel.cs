using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WebAppMVCCORE.Models
{
    

    public partial class ExcryptDecryptModel
    {
        [Key]
        public int ID { get; set; }


        [MinLength(6, ErrorMessage = "Minimum Username must be 6 in charaters")]
        [Required(ErrorMessage = "Username Required")]
        public string Username { get; set; }

        [MinLength(7, ErrorMessage = "Minimum Password must be 7 in charaters")]
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Enter Valid Password")]
        public string ConfirmPassword { get; set; }

       

    }

    public class CountryValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string Message = string.Empty;
            if (Convert.ToString(value) == "0")
            {
                Message = "Choose Country";
                return new ValidationResult(Message);
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }

    public class StateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string Message = string.Empty;
            if (Convert.ToString(value) == "0")
            {
                Message = "State Required";
                return new ValidationResult(Message);
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }

    public class CityValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string Message = string.Empty;
            if (Convert.ToString(value) == "0")
            {
                Message = "City Required";
                return new ValidationResult(Message);
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
