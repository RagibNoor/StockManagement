<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemSetupUI.aspx.cs" Inherits="StockManagement.UI.ItemSetupUI" MasterPageFile="../Site.Master" Title="Item Setup" %>


<asp:Content  ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server">
     <div class="login-form text-center">
         <h2 class="text-center">Item Setup</h2>
        <hr/>
        <div class="row">
            <div class="col-md-4">
                Category :
            </div>

            <div class="col-md-8">
                <asp:DropDownList ID="categoryDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
           
        </div>
         <br/>
           <div class="row">
            <div class="col-md-4">
                Company :
            </div>

            <div class="col-md-8">
                <asp:DropDownList ID="companyDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
           
        </div>
         <br/>
         <div class="row">
            <div class="col-md-4">
                Item Name :
            </div>

            <div class="col-md-8">
                <asp:TextBox ID="itemNameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
           
        </div>
         <br/>
         <div class="row">
            <div class="col-md-4">
                Reorder :
            </div>

            <div class="col-md-8">
                <asp:TextBox ID="reorderTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
           
        </div>
         <br/> 
        <div class="row">
             <div class="col-md-12 text-right">
                 <asp:Button runat="server" Text="Save" ID="itemSaveButton" CssClass="btn btn-primary " OnClick="itemSaveButton_Click"  />
            </div>
        </div>
         </div>
    </form>
</asp:Content>
