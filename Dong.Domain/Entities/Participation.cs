using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dong.Domain.Entities
{
    public class Participation 
    {
        
        public int GetTogetherId { get; set; }
        public  GetTogether GetTogether { get; set; }
        public int UserId { get; set; }
        public  User User { get; set; }

    }
}
