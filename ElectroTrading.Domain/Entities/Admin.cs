using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Domain.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? UserAdmin { get; set; }
        public string Password { get; set; } = "Password";
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
