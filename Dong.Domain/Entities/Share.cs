using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dong.Domain.Entities
{
    public class Share : BaseEntity
    {
        public int UserId { get; set; }
        public  User User { get; set; }
        public int GetTogetherId { get; set; }
        public GetTogether GetTogether { get; set; }
        public decimal Cost { get; set; }
        public decimal SumCost { get; set; }
        public decimal PerShare { get; set; }
        public decimal DebitCredit { get; set; } 
    }
}
