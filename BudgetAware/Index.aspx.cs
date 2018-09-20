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
            if (Application["LoggedIn"] != null)
            {
                UsersDb usersDb = new UsersDb();
                Users user = usersDb.GetUserById(Convert.ToInt32(Application["LoggedIn"]));
                currentUser = user;
                userName.InnerText = $"{user.FirstName} {user.LastName}";
                birthday.InnerText = $"Birthday:{user.Birthday.ToString("MM/dd/yyyy")}";
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

            string currentDir = "https://i.postimg.cc/hv8BvBj6/baseline_face_black_48dp.png";
            iconImg.Src = currentDir;
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
            List<Purchases> userPurchases = purchaseDb.GetPurchasesByAccountId(currentAccount.AccountNumber);
            currentPurchases = userPurchases;
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
            accountInfo.InnerText = $"Account Number : {currentAccount.AccountNumber}";
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            Purchases purchase = new Purchases();
            purchase.Fk_AccountNumber = currentAccount.AccountNumber;
            purchase.Fk_CategoryId = Convert.ToInt32(this.category.Value);
            purchase.PurchaseDate = DateTime.Now.Date;
            purchase.Cost = Convert.ToDecimal(cost.Value);
            purchase.Company = this.company.Value;
            bool purchaseAdded = AddPurchase(purchase);
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

    }
}