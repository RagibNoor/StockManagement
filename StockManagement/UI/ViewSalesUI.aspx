<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSalesUI.aspx.cs" Inherits="StockManagement.UI.ViewSalesUI" MasterPageFile="../Site.Master" %>
<asp:Content runat="server" ContentPlaceHolderID="body">
    <form id="form1" runat="server">
    <div class="login-form text-center">
         <h2 class="text-center">View Sales Between Two Dates</h2>
        <hr/>
        <div class="row">
            <div class="col-md-4">
                From Date :
            </div>

            <div class="col-md-8">
                <asp:DropDownList ID="fromDateDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
           
        </div>
         <br/>
        <div class="row">
            <div class="col-md-4">
                To Date :
            </div>

            <div class="col-md-8">
                <asp:DropDownList ID="toDateDownList" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
           
        </div>
         <br/>
        <div class="row">
             <div class="col-md-12 text-right">
                 <asp:Button ID="viewSearchItemButton" runat="server" Text="Search" CssClass="btn btn-primary " />
            </div>
        </div>
        <div class="row">
             <div class="col-md-12 text-right">
                 <asp:GridView ID="viewSearchItemGridView" runat="server"></asp:GridView>
            </div>
        </div>
    
    </div>
    </form>
</asp:Content>
