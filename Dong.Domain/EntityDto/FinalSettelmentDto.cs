using Dong.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dong.Domain.EntityDto
{
    public class FinalSettelmentDto 
    {
        public int GetTogetherId { get; set; }
        public GetTogether getTogether { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public User Users { get; set; }
        public decimal Amount { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
    }
}
