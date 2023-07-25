using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Models.DTOs
{
    public class UpdateAttendanceDto
    {
        [Required]
        public int Id { get; set; }
        public bool? IsMainWork { get; set; } = null;
        public double? LateHours { get; set; } = null;
        public double? ExtraWorkHours { get; set; } = null;
    }
}
