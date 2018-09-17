<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Main.Master"
    AutoEventWireup="true"
    CodeBehind="Index.aspx.cs"
    Inherits="BudgetAware.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="card">

            <div class="card-body" runat="server" id="userCard">
                    <img class="card-img-top" id="iconImg" runat="server" alt="User Icon" />
                <div class="card-header" runat="server" id="userName"></div>
                <div class="card-text" runat="server" id="userInfo"></div>
            </div>
        </div>
    </div>
    <div class="row">
        <div id="app" class="card box">
            <div class="card-body">
                <div class='card-header'>
                    Your Spending
                </div>
                <div class='card-text' id="pie">
                </div>
            </div>
        </div>
        <div id="app2" class="box">
        </div>

    </div>
    <div class="row">
        <div id="app3" class="card box">
            <div class="card-body">
                <div class='card-header'>
                    Your Budget
                </div>
                <div class='card-text' id="bar">
                </div>
            </div>
        </div>
    </div>


    <div id="hiddenJsonUser" runat="server" hidden="hidden">
    </div>
    <div id="hiddenJsonAccount" runat="server" hidden="hidden">
    </div>
    <div id="hiddenJsonPurchases" runat="server" hidden="hidden">
    </div>

</asp:Content>
