using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Dong.Domain.Entities
{
    [Index(nameof(Mobile), IsUnique = true)]
    public class User : BaseEntity
    {
        public required string Name { get; set; }
        public required string Mobile { get; set; }
        public string? PasswordHash { get; set; }

        public List<GetTogether> getTogether { get; set; } = new List<GetTogether>();
        public List<Participation> participations { get; set; } = new List<Participation>();
    }
}


