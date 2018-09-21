using BudgetAware.Dal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BudgetAware
{
    public partial class Home : System.Web.UI.Page
    {
        private Users currentUser;
        private Accounts currentAccount;
        private List<Purchases> currentPurchases;
        private List<Budget> currentBudget;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {
                UsersDb usersDb = new UsersDb();
                Users user = usersDb.GetUserById(Convert.ToInt32(Session["LoggedIn"]));
                currentUser = user;
                userName.InnerText = $"{user.FirstName} {user.LastName}";
                birthday.InnerText = $"Birthday:{user.Birthday.ToString("MM/dd/yyyy")}";
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

            GetAccount();
            GetPurchases();
            GetBudget();
            ConvertToJson();
        }

        private void GetBudget()
        {
            BudgetDb budgetDb = new BudgetDb();
            List<Budget> budget = budgetDb.GetBudgetByUserId(currentUser.Id);
            currentBudget = budget;
        }

        private void GetPurchases()
        {
            PurchaseDb purchaseDb = new PurchaseDb();
            List<Purchases> userPurchases = purchaseDb.GetPurchasesByAccountNumber(currentAccount.AccountNumber);
            currentPurchases = userPurchases;
        }

        private void AddBudgetToTable()
        {
            Budget budget = new Budget();
            budget.Fk_UserId = currentUser.Id;
            budget.Amount = Convert.ToDecimal(budgetAmount.Value);
            budget.Fk_CategoriesId = Convert.ToInt32(budgetCategory.Value);

            BudgetDb budgetDb = new BudgetDb();
            budgetDb.AddBudget(budget);
        }

        public void ConvertToJson()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer(new SimpleTypeResolver());
            string serialUser = serializer.Serialize(currentUser);
            string serialAccount = serializer.Serialize(currentAccount);
            string serialPurchases = serializer.Serialize(currentPurchases);
            string serialBudget = serializer.Serialize(currentBudget);


            hiddenJsonUser.InnerText = serialUser;
            hiddenJsonAccount.InnerText = serialAccount;
            hiddenJsonPurchases.InnerText = serialPurchases;
            hiddenJsonBudget.InnerText = serialBudget;
        }

        private void GetAccount()
        {
            AccountDb accountDb = new AccountDb();
            Accounts userAccount = accountDb.GetAccountsByUserId(currentUser.Id);
            currentAccount = userAccount;
            accountInfo.InnerHtml = $"<div>Account Number <p>{currentAccount.AccountNumber} </p></div>";
            accountBalance.InnerHtml = $"<div>Account Balance <p>{ currentAccount.Balance}</p></div>";
        }

        private bool AddPurchase(Purchases purchase)
        {
            PurchaseDb purchaseDb = new PurchaseDb();
            var t = purchaseDb.AddPurchase(purchase);
            if (t > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void Unnamed_Click1(object sender, EventArgs e)
        {
            Purchases purchase = new Purchases();
            purchase.Fk_AccountNumber = currentAccount.AccountNumber;
            purchase.Fk_CategoryId = Convert.ToInt32(this.category.Value);
            purchase.PurchaseDate = DateTime.Now.Date;
            purchase.Cost = Convert.ToDecimal(cost.Value);
            purchase.Company = this.company.Value;
            bool purchaseAdded = AddPurchase(purchase);

            Response.Redirect("/Index.aspx");
        }

        protected void submitBudget_Click(object sender, EventArgs e)
        {
            AddBudgetToTable();
            Response.Redirect("/Index.aspx");
        }
    }
}