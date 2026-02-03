using Dong.Application.Calculator;
using Dong.Domain.Entities;
using Dong.Infrastructure.dbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dong.Infrastructure.Calculator
{
    public class DebitCreditCalculator : IDebitCreditCalculator
    {
        private readonly AppDbContext _context;
        public DebitCreditCalculator(AppDbContext context)
        {
            _context = context;
        }
        public List<Settlement> CalculateAndSaveSettlements(int getTogetherId)
        {
            // Shareهای همین دورهمی
            var shares = _context.Shares
                .Where(s => s.GetTogetherId == getTogetherId)
                .ToList();

            // حذف Settlementهای قبلی
            var oldSettlements = _context.Settlements.Where(s => s.GetTogetherId == getTogetherId);
            _context.Settlements.RemoveRange(oldSettlements);
            _context.SaveChanges();

            _context.Settlements.RemoveRange(oldSettlements);

            var settlements = new List<Settlement>();

            var creditors = shares
                .Where(s => s.DebitCredit > 0)
                .Select(s => new TempBalance
                {
                    UserId = s.UserId,
                    Amount = s.DebitCredit
                })
                .ToList();

            var debtors = shares
                .Where(s => s.DebitCredit < 0)
                .Select(s => new TempBalance
                {
                    UserId = s.UserId,
                    Amount = Math.Abs(s.DebitCredit)
                })
                .ToList();

            int c = 0, d = 0;

            while (c < creditors.Count && d < debtors.Count)
            {
                decimal pay = Math.Min(creditors[c].Amount, debtors[d].Amount);

                settlements.Add(new Settlement
                {
                    FromUserId = debtors[d].UserId,
                    ToUserId = creditors[c].UserId,
                    Amount = pay,
                    GetTogetherId = getTogetherId
                });

                creditors[c].Amount -= pay;
                debtors[d].Amount -= pay;

                if (creditors[c].Amount == 0) c++;
                if (debtors[d].Amount == 0) d++;
            }

            _context.Settlements.AddRange(settlements);
            _context.SaveChanges();

            return _context.Settlements
                .Include(s => s.Users)
                .Where(s => s.GetTogetherId == getTogetherId)
                .ToList();

        }

    }
}
