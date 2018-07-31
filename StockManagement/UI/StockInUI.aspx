<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockInUI.aspx.cs" Inherits="StockManagement.UI.StockInUI" MasterPageFile="../Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="body">
    <form id="form1" runat="server">
    <div class="login-form text-center">
         <h2 class="text-center">Stock In</h2>
        <hr/>
        <div class="row">
            <div class="col-md-4">
                Company :
            </div>

            <div class="col-md-8">
                <asp:DropDownList ID="companyDropDownList" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged">
                   
                </asp:DropDownList>
            </div>
           
        </div>
         <br/>
        <div class="row">
            <div class="col-md-4">
                Item :
            </div>

            <div class="col-md-8">
                <asp:DropDownList ID="itemDropDownList" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="itemDropDownList_SelectedIndexChanged"></asp:DropDownList>
            </div>
           
        </div>
         <br/>
        <div class="row">
            <div class="col-md-4">
                Reorder Level :
            </div>

            <div class="col-md-8">
                <asp:TextBox ID="reorderLevelTextBox" runat="server" Height="25px" ReadOnly="True" CssClass="form-control"></asp:TextBox>
            </div>
           
        </div>
         <br/>
        <div class="row">
            <div class="col-md-4">
                Available Quantity :
            </div>

            <div class="col-md-8">
                <asp:TextBox ID="quantityTextBox" runat="server" Height="25px" ReadOnly="True" CssClass="form-control"></asp:TextBox>
            </div>
           
        </div>
         <br/>
        <div class="row">
            <div class="col-md-4">
                Stock In Quantity :
            </div>

            <div class="col-md-8">
                 <asp:TextBox ID="stockQuantityTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
           
        </div>
         <br/>
        <div class="row">
             <div class="col-md-12 text-right">
                 <asp:HiddenField ID="IDHiddenField" runat="server" />
                 <asp:Button ID="stockInSaveButton" runat="server" Text="Save" CssClass="btn btn-primary " OnClick="stockInSaveButton_Click" />
            </div>
        </div>
    </div>
    </form>
</asp:Content>
