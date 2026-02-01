using Dong.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Dong.Application.Crud
{
     public interface ICrud
    {
        public void AddUser(string name, string mobile, string pass);
        public bool AddGetTogethers(string name,int userId, out string error);
        public bool AddParticipations(int getTogetherId, int userId, out string error); 
        public List<Participation> GetParticipationsByGetTogether(int getTogetherId);
        public void AddExpense(int userId, string description, decimal cost, int getTogetherId);
        public List<GetTogether> GetTogethersForOwner(int userId);
        public int? FindUserByMobile(string mobile);
        public List<Settlement> GetUserFinancialReport(string mobile);
        public List<Share> GetShare(int getTogetherId);
    }
}
