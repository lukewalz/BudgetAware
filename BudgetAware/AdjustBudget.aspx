<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AdjustBudget.aspx.cs" Inherits="BudgetAware.AdjustBudget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="addBudget" class="card col container-fluid" runat="server">
        <div class="container-fluid">
            <div class="row">
                <form id="budgetForm" runat="server">
                    <div class="col">
                        <div class="form-group">
                            <label for="company">Amount:</label>
                            <input type="number" class="form-control" id="budgetAmount" runat="server" required="required">
                        </div>
                        <div class="form-group">
                            <label for="budgetCategory" runat="server">Category:</label>
                            <select runat="server" id="budgetCategory" class="dropdown">
                                <option value="1">Clothing</option>
                                <option value="2">Food</option>
                                <option value="6">Auto</option>
                                <option value="7">Entertainment</option>
                                <option value="8">Rent</option>
                                <option value="9">Misc</option>
                            </select>
                        </div>
                    </div>
                    <asp:Button Text="Submit Budget" CssClass="btn btn-primary" runat="server" ID="submitBudget" OnClick="submitBudget_Click" />
                </form>
            </div>
        </div>
    </div>
</asp:Content>
