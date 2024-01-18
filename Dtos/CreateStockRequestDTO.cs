using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class CreateStockRequestDTO
    {
        [Required]
        [MinLength(2, ErrorMessage = "Minimum length of stock symbol is 3.")]
        [MaxLength(5, ErrorMessage = "Maximum length of stock symbol is 5.")]
        public string Symbol { get; set; } = string.Empty;

        [Required]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [Range(1,100000000000)]
        public decimal Purchase { get; set; }

        [Required]
        public decimal LastDiv { get; set; }

        public string Industry { get; set; } = string.Empty;

        [Required]
        [Range(1,1000000000000)]
        public long MarketCap { get; set; }
    }
}