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
        private User currentUser;
        private Account currentAccount;
        private List<Purchase> currentPurchases;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["LoggedIn"] != null)
            {
                User _user = (User)Application["LoggedIn"];
                currentUser = _user;
                userName.InnerText = $"{_user.FirstName} {_user.LastName}";
                userInfo.InnerText = $"{_user.Birthday.ToString("MM/dd/yyyy")}";
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

            string currentDir = System.Web.HttpContext.Current.Server.MapPath("\\Content\\baseline-face-24px.svg");
            iconImg.Src = currentDir;
            GetAccount();
            GetPurchases();
            ConvertToJson();
        }

        private void GetPurchases()
        {
            string currentDir = System.Web.HttpContext.Current.Server.MapPath("DataObjects\\Purchases.json");
            RootPurchaseObject rootObject;

            using (StreamReader r = new StreamReader(currentDir))
            {
                string json = r.ReadToEnd();
                rootObject = new JavaScriptSerializer().Deserialize<RootPurchaseObject>(json);
            }

            List<Purchase> userPurchases = rootObject.purchases.Where(i => i.AccountNumber == currentAccount.AccountNumber).ToList<Purchase>();
            currentPurchases = userPurchases;
        }

        public void ConvertToJson()
        {          
            JavaScriptSerializer serializer = new JavaScriptSerializer(new SimpleTypeResolver());
            string serialUser = serializer.Serialize(currentUser);
            string serialAccount = serializer.Serialize(currentAccount);
            string serialPurchases = serializer.Serialize(currentPurchases);

            hiddenJsonUser.InnerText = serialUser;
            hiddenJsonAccount.InnerText = serialAccount;
            hiddenJsonPurchases.InnerText = serialPurchases;
        }

        private void GetAccount()
        {
            string currentDir = System.Web.HttpContext.Current.Server.MapPath("DataObjects\\Accounts.json");
            RootAccountObject rootObject;
            using (StreamReader r = new StreamReader(currentDir))
            {
                string json = r.ReadToEnd();
                rootObject = new JavaScriptSerializer().Deserialize<RootAccountObject>(json);
            }

            Account userAccount = rootObject.accounts.Where(i => i.UserId == currentUser.Id).First();
            currentAccount = userAccount;          
        }
    }
}