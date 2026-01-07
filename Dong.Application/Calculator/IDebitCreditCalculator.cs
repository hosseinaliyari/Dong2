using Dong.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dong.Application.Calculator
{
    public interface IDebitCreditCalculator
    {
        public List<Settlement> CalculateAndSaveSettlements(int getTogetherId);
    }
}
