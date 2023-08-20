using ElectroTrading.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Models.ViewModels
{
    public class PhotoViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel? Product { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(5)).DateTime;
    }
}
