<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Main.Master"
    AutoEventWireup="true"
    CodeBehind="Login.aspx.cs"
    Inherits="BudgetAware.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <form id="form1" runat="server">
            <div class="form-group">
                <label for="email">Email address:</label>
                <input type="email" class="form-control" id="email" runat="server" required="required">
            </div>
            <div class="form-group">
                <label for="pwd">Password:</label>
                <input type="password" class="form-control" id="pwd" runat="server" required="required">
            </div>
            <asp:Button Text="Submit" ID="submit" runat="server" type="submit" class="btn btn-primary" OnClick="submit_Click"/>
        </form>
    </div>
</asp:Content>
