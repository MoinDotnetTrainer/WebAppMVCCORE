using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WebAppMVCCORE.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Product Name Required")]        
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "Product Description  Required")]
        [StringLength(maximumLength: 25, MinimumLength = 10, ErrorMessage = "Length must be between 10 to 25")]
        public string? ProductDescription { get; set; }

        [Required(ErrorMessage = "Product Cost Required")]
        [Range(0, 999.99)]
        public decimal ProductCost { get; set; }


        [Required(ErrorMessage = "Stock Required")]
        public int Stock { get; set; }
    }
}
