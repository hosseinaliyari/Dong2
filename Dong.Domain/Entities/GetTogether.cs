using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dong.Domain.Entities
{
    public class GetTogether : BaseEntity
    {
        public required string NameGetTogether { get; set; }
        //Owner
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Participation> Participations { get; set; } = new List<Participation>();
        public List<Expense> Expenses { get; set; } = new List<Expense>();
        public List<Share> Shares { get; set; } = new List<Share>();


    }
}

