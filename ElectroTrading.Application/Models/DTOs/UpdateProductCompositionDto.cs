using ElectroTrading.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Models.DTOs
{
    public class UpdateProductCompositionDto
    {
        [Required]
        public int CompositionId { get; set; }
        public string? Description { get; set; } = null;
        public decimal? Price { get; set; } = null;
        public CategoryUnity? Category { get; set; } = null;
        public double? Amount { get; set; } = null;
    }
}
