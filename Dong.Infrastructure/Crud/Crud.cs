using Dong.Application.Crud;
using Dong.Domain.Entities;
using Dong.Infrastructure.Calculator;
using Dong.Infrastructure.dbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Reflection;

namespace Dong.Infrastructure.Crud
{
    public class Crud : ICrud
    {
        private readonly AppDbContext _context;
        public Crud(AppDbContext context)
        {
            _context = context;
        }

        public void AddExpense(int userId, string description, decimal cost, int getTogetherId)
        {
            Expense expense = new Expense()
            {
                UserId = userId,
                Description = description,
                Cost = cost,
                GetTogetherId = getTogetherId
            };
            _context.Expenses.Add(expense);
            _context.SaveChanges();
        }

        public bool AddGetTogethers(string name, int userId, out string error)
        {
            error = "";
            bool exists = _context.GetTogethers.Any(g=> g.UserId == userId && g.NameGetTogether== name);
            if (exists)
            {
                error = "❌ این دورهمی قبلاً برای این کاربر ثبت شده است";
                return false;
            }
            GetTogether getTogether = new GetTogether()
            {
                NameGetTogether = name,
                UserId = userId
            };
            _context.GetTogethers.Add(getTogether);
            _context.SaveChanges();
            return true;
        }

        public bool AddParticipations(int getTogetherId, int userId, out string error)
        {
            error = string.Empty;

            // بررسی اینکه کاربر قبلاً اضافه نشده باشد
            bool exists = _context.Participations
                .Any(p => p.GetTogetherId == getTogetherId && p.UserId == userId);

            if (exists)
            {
                error = "❌ این کاربر قبلاً به این دورهمی اضافه شده است";
                return false;
            }

            // اضافه کردن Participation
            var participation = new Participation
            {
                GetTogetherId = getTogetherId,
                UserId = userId
            };

            _context.Participations.Add(participation);
            _context.SaveChanges();

            return true;
        }

        public void AddPayment(int fromUserId, int toUserId, decimal amount, int getTogetherId)
        {
            var payment = new Payment
            {
                FromUserId = fromUserId,
                ToUserId = toUserId,
                Amount = amount,
                DateTime = DateTime.UtcNow,
                GetTogetherId = getTogetherId
            };
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }

        public void AddUser(string name, string mobile, string pass)
        {
            var exists = _context.Users.Any(u => u.Mobile == mobile);
            if (exists)
                throw new Exception("این شماره موبایل قبلاً ثبت شده است");
            User user = new User()
            {
                Name = name,
                Mobile = mobile,
                PasswordHash = pass
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public int? FindUserByMobile(string mobile)
        {
            return _context.Users.Where(u => u.Mobile == mobile).Select(u => (int?)u.Id).FirstOrDefault();
        }

        public List<Participation> GetParticipationsByGetTogether(int getTogetherId)
        {
            return _context.Participations.Include(p => p.User).Where(p => p.GetTogetherId == getTogetherId).ToList();
        }

        public List<Share> GetShare(int getTogetherId)
        {
            return _context.Shares.Include(s=> s.User).Where(p => p.GetTogetherId == getTogetherId).ToList();
        }

        public List<GetTogether> GetTogethersForOwner(int userId)
        {
            return _context.GetTogethers.Where(g => g.UserId == userId).ToList();
            
        }

        public List<FinancialLedger> GetUserFinalReport(string mobile)
        {
            var userfull = _context.Users;
            var userId = userfull.Where(u => u.Mobile.ToString() == mobile).Select(u => (int)u.Id).FirstOrDefault();


            var settlements = _context.Settlements
                .Include(s => s.Users)
                .Where(s => s.FromUserId == userId || s.ToUserId == userId)
                .Select(s => new FinancialLedger
                {
                    FromUserId = s.FromUserId,
                    ToUserId = s.ToUserId,
                    Balance = s.Amount
                });

            var payments = _context.Payments
                .Include(s => s.Users)
                .Where(p => p.FromUserId == userId || p.ToUserId == userId)
                .Select(p => new FinancialLedger
                {
                    FromUserId = p.FromUserId,
                    ToUserId = p.ToUserId,
                    Balance = -p.Amount
                });

            var ledger = settlements.Concat(payments);

            var finalReport = ledger
                .GroupBy(x => new { x.FromUserId, x.ToUserId })
                .Select(g => new FinancialLedger
                {
                    FromUserId = g.Key.FromUserId,                    
                    ToUserId = g.Key.ToUserId, 
                    FromName = userfull.Where(x=> x.Id== g.Key.FromUserId).FirstOrDefault().Name.ToString(), 
                    ToName = userfull.Where(x => x.Id == g.Key.ToUserId).FirstOrDefault().Name.ToString(),
                    Balance = g.Sum(x => x.Balance)
                })
                .Where(x => x.Balance != 0)
                .ToList();

            return finalReport;
        }

        public List<Settlement> GetUserFinancialReport(string mobile)
        {
            var user = _context.Users.FirstOrDefault(u => u.Mobile.ToString() == mobile);

            var settlements = _context.Settlements
                .Include(s => s.Users)
                .Include(s => s.getTogether)
                .Where(s => s.FromUserId == user.Id || s.ToUserId == user.Id)
                .ToList();
            return settlements;
        }
    }
}
