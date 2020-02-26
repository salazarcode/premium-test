using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premium.Models
{
    public class PremiumCondition
    {
        public string State { get; set; }
        public string Month { get; set; }
        public int Left { get; set; }
        public int? Right { get; set; }
        public double Premium { get; set; }
    }
}
