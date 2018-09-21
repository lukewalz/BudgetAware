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
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <div class="card">
                    <div class="card-header" runat="server" id="userName"></div>
                    <div class="card-body" runat="server" id="userCard">
                        <div class="card-text" runat="server">
                            <div id="birthday" runat="server"></div>
                            <div id="accountInfo" runat="server"></div>
                            <div id="accountBalance" runat="server"></div>

                        </div>
                    </div>

                </div>
            </div>

        </div>
        <div class="row">
            <div id="app" class="col">
                <div class="card">
                    <div class='card-header'>
                        Your Spending
                    </div>
                    <div class="card-body">

                        <div class='card-text' id="pie">
                        </div>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card">
                    <div id="app2">
                    </div>
                </div>

            </div>
            <div id="addPurchases" class="col">
                <div class="card">
                    <div class="card-header">
                        Add a Purchase
                    </div>
                    <div class="card-body">
                        <div class="container-fluid">
                            <div class="row">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="submit" EventName="Click" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <div class="col">
                                            <div class="form-group">
                                                <label for="company">Company:</label>
                                                <input type="text" class="form-control" id="company" runat="server">
                                            </div>
                                            <div class="form-group">
                                                <label for="cost">Cost:</label>
                                                <input type="text" class="form-control" id="cost" runat="server">
                                            </div>
                                            <div class="form-group">
                                                <label for="category">Category:</label>
                                                <select runat="server" id="category" class="dropdown">
                                                    <option value="1">Clothing</option>
                                                    <option value="2">Food</option>
                                                    <option value="6">Auto</option>
                                                    <option value="9">Entertainment</option>
                                                    <option value="8">Rent</option>
                                                    <option value="7">Misc</option>
                                                </select>
                                            </div>
                                            <asp:Button runat="server" ID="submit" OnClick="Unnamed_Click1" class="btn btn-primary" Text="Submit"></asp:Button>
                                        </div>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>


                </div>
            </div>
        </div>
        <div class="row">
            <div id="app3" class="col">
                <div class="card">
                    <div class='card-header'>
                        Your Budget
                    </div>
                    <div class="card-body">
                        <div class='card-text' id="bar">
                        </div>
                    </div>
                </div>
            </div>
            <div id="addBudget" class="col">
                <div class="card">
                    <div class="card-header">
                        Add a Budget Item
                    </div>
                    <div class="card-body">
                        <div class="container-fluid">
                            <div class="row">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="submitBudget" EventName="Click" />
                                    </Triggers>
                                    <ContentTemplate>
                                        <div class="col">
                                            <div class="form-group">
                                                <label for="company">Amount:</label>
                                                <input type="number" class="form-control" id="budgetAmount" runat="server">
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
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
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
    <div id="hiddenJsonBudget" runat="server" hidden="hidden">
    </div>
    </div>
</asp:Content>
