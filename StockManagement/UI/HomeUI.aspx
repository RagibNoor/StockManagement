<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeUI.aspx.cs" Title="Home" Inherits="StockManagement.UI.HomeUI" MasterPageFile="../Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="body">
    <form id="form1" runat="server">
    <div class="login-form">
       
         <asp:Button runat="server" Text="Category Setup" ID="CategorySetupBtn" CssClass="btn btn-primary btn-block" OnClick="CategorySetupBtn_Click"/>
        <asp:Button runat="server" Text="Company Setup" ID="companySetupBtn" CssClass="btn btn-primary btn-block" OnClick="companySetupBtn_Click"/>
        <asp:Button runat="server" Text="Item Setup" ID="itemSetupBtn" CssClass="btn btn-primary btn-block"/>
        <asp:Button runat="server" Text="Stock In" ID="StockInBtn" CssClass="btn btn-primary btn-block"/>
        <asp:Button runat="server" Text="Stock Out" ID="StockOutBtn" CssClass="btn btn-primary btn-block"/>
        <asp:Button runat="server" Text="Search & View Item" ID="ViewItemBtn" CssClass="btn btn-primary btn-block"/>
        <asp:Button runat="server" Text="View Sales" ID="viewSalesBtn" CssClass="btn btn-primary btn-block"/>
    
    </div>
    </form>
</asp:Content>