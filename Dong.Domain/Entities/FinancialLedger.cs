using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dong.Domain.Entities
{
    public class FinancialLedger
    {
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public User User { get; set; }
        public decimal Balance { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
    }
}
