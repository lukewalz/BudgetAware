<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Main.Master"
    AutoEventWireup="true"
    CodeBehind="Home.aspx.cs"
    Inherits="BudgetAware.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="card">
            <div class="card-body" runat="server" id="userCard">
                <div class="card-header" runat="server" id="userName"></div>
                <div class="card-text" runat="server" id="userInfo"></div>
            </div>
        </div>
    </div>
    <div class="row" id="app">

    </div>

    <div id="hiddenJsonUser" runat="server" hidden="hidden">
    </div>
    <div id="hiddenJsonAccount" runat="server" hidden="hidden">
    </div>
    <div id="hiddenJsonPurchases" runat="server" hidden="hidden">
    </div>

</asp:Content>
