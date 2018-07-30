<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchItemUI.aspx.cs" Inherits="StockManagement.UI.SearchItemUI" MasterPageFile="../Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="body">
    <form id="form1" runat="server">
    <div class="login-form text-center">
        <h2 class="text-center">Search and Viev Item's Summary</h2>
        <hr/>
    <div class="row">
            <div class="col-md-4">
                Company :
            </div>

            <div class="col-md-8">
                <asp:DropDownList ID="companySearchDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
           
        </div>
        <br/>
        <div class="row">
            <div class="col-md-4">
                Item :
            </div>

            <div class="col-md-8">
                <asp:DropDownList ID="itemSearchDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
           
        </div>
        <br/> 
        <div class="row">
             <div class="col-md-12 text-right">
                 <asp:Button runat="server" Text="Search" ID="searchItemButton" CssClass="btn btn-primary " />
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
                <asp:GridView ID="searchItemGridView" runat="server" ></asp:GridView>
            </div>
        </div>
    </div>
    </form>
</asp:Content>