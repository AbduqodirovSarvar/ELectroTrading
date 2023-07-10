using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Infrastructure.Services
{
    public class JWTConfiguration
    {
        public JWTConfiguration() { }
        public string ValidIssuer { get; set; } = string.Empty;
        public string ValidAudience { get; set; } = string.Empty;
        public string Secret { get; set; } = string.Empty;

    }
}
