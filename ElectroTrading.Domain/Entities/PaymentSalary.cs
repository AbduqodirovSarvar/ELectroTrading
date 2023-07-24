﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Domain.Entities
{
    public class PaymentSalary
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public decimal Summs { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int ByWhomId { get; set; }
        public User? Master { get; set; }
    }
}