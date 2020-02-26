using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premium.Models
{
    public class PremiumRequest
    {
        public DateTime dateOfBirth { get; set; }
        public string state { get; set; }
        public int age { get; set; }
    }
}
