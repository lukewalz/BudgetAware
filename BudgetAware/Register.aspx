<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BudgetAware.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col-lg-6">
                        <div id="error" class="alert alert-danger" runat="server" visible="false"></div>
                        <div class="form-group">
                            <label for="fName">First Name:</label>
                            <input type="text" class="form-control" id="fName" runat="server" required="required">
                        </div>
                        <div class="form-group">
                            <label for="lName">Last Name:</label>
                            <input type="text" class="form-control" id="lName" runat="server" required="required">
                        </div>
                        <div class="form-group">
                            <label for="email">Email address:</label>
                            <input type="email" class="form-control" id="email" runat="server" required="required" >
                        </div>
                        <div class="form-group">
                            <label for="pwd">Password:</label>
                            <input type="password" class="form-control" id="pwd" runat="server" pattern=".{7,20}" required title="Enter a password between 7 and 20 characters long.">
                        </div>
                        <div class="form-group">
                            <label for="cpwd">Confirm Password:</label>
                            <input type="password" class="form-control" id="cpwd" runat="server" required="required">
                        </div>
                        <div class="form-group">
                            <label for="dob">Date of Birth:</label>
                            <input type="date" class="form-control" id="dob" runat="server" required="required">
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label for="accounttype">Account Type:</label>
                            <select type="datetime-local" class="form-control" id="accounttype" runat="server" required="required">
                                <option runat="server">Checking</option>
                                <option runat="server">Savings</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="accountNum">Account Number:</label>
                            <input type="text" class="form-control" id="accountNum" runat="server" required="required">
                        </div>
                        <asp:Button Text="Submit" ID="submit" runat="server" type="submit" class="btn btn-primary" OnClick="submit_Click" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>

</asp:Content>
