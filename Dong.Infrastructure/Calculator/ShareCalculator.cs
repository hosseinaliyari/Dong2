using Dong.Application.Calculator;
using Dong.Domain.Entities;
using Dong.Infrastructure.dbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dong.Infrastructure.Calculator
{
    public class ShareCalculator : IShareCalculator
    {
        private readonly AppDbContext _context;
        public ShareCalculator(AppDbContext context)
        {
            _context = context;
        }
        public List<Share> CalculateAndSave(int getTogetherId)
        {
            var expenses = _context.Expenses
                .Where(e => e.GetTogetherId == getTogetherId)
                .ToList();

            var participations = _context.Participations
                .Where(p => p.GetTogetherId == getTogetherId)
                .ToList();
            if (!participations.Any())
                throw new Exception("هیچ شرکت‌کننده‌ای برای این دورهمی وجود ندارد");
            var participationsCount =_context.Participations.Where(p=> p.GetTogetherId==getTogetherId).Select(p=> p.UserId).Distinct().Count();
            decimal sumCost = expenses.Sum(e => e.Cost);
            decimal perShare = sumCost / participationsCount;
            // حذف Shareهای قبلی
            var oldShares = _context.Shares.Where(s => s.GetTogetherId == getTogetherId);
            _context.Shares.RemoveRange(oldShares);
            _context.SaveChanges();

            var result = participations.Select(p =>
            {
                decimal paid = expenses
                    .Where(e => e.UserId == p.UserId)
                    .Sum(e => e.Cost);
                return new Share
                {
                    UserId = p.UserId,
                    GetTogetherId = getTogetherId,
                    Cost = paid,
                    SumCost = sumCost,
                    PerShare = perShare,
                    DebitCredit = paid - perShare
                };
            }).ToList();

            _context.Shares.AddRange(result);
            _context.SaveChanges();

            return result;
        }
            
    }
}
