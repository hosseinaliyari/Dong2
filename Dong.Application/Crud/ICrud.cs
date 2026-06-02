using Dong.Domain.Entities;
using Dong.Domain.EntityDto;


namespace Dong.Application.Crud
{
    public interface ICrud
    {
        public void AddUser(string name, string mobile, string pass);
        public List<User> GetUsers();
        public bool AddGetTogethers(string name, int userId, out string error);
        public bool AddParticipations(int getTogetherId, int userId, out string error);
        public List<Participation> GetParticipationsByGetTogether(int getTogetherId);
        public void AddExpense(int userId, string description, decimal cost, int getTogetherId);
        public List<GetTogether> GetTogethersForOwner(int userId);
        public int? FindUserByMobile(string mobile);
        public List<FinalSettelmentDto> GetUserFinancialReport(string mobile);
        public List<Share> GetShare(int getTogetherId);
        public void AddPayment(int fromUserId, int toUserId, decimal amount, int getTogetherId);

        public List<FinancialLedger> GetUserFinalReport(string moblie);


    }
}
