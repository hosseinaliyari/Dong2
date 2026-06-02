using Dong.Domain.Entities;

namespace Dong.Blazor.Components.Pages
{
    public partial class ReportNew
    {
        private List<FinancialLedger> reports = new();
        private string mobile = string.Empty;
        private string message = string.Empty;

        private List<User> users = new();
        private int selectedGetTogetherId;


        protected override void OnInitialized()
        {
            users = Crud.GetUsers();
        }
        private void OnGetTogetherChanged()
        {
            if (string.IsNullOrEmpty(mobile))
            {
                users.Clear();
                return;
            }

            users = Crud.GetUsers();
        }






        private void Search()
        {
            reports = Crud.GetUserFinalReport(mobile);
            if (reports == null)
            {
                message = "❌ کاربری با این شماره یافت نشد";
            }
        }
    }
}