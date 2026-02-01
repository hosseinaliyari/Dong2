using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dong.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public int GetTogetherId { get; set; }
        public GetTogether getTogether { get; set; }
        public int FromUserId { get; set; }
        public User FromUser { get; set; }
        public int ToUserId { get; set; }
        public User ToUser { get; set; }
        public decimal Amount { get; set; }
    }
}
