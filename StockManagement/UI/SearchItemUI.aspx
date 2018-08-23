<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchItemUI.aspx.cs" Inherits="StockManagement.UI.SearchItemUI" MasterPageFile="../Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="body">
    <form id="form1" runat="server">
    <div class="login-form text-center">
        <h2 class="text-center">Search and View Item's Summary</h2>
        <hr/>
    <div class="row">
            <div class="col-md-4">
                Company :
            </div>

            <div class="col-md-8">
                <asp:DropDownList ID="companyDropDownList" AutoPostBack="True" runat="server" CssClass="form-control" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged" ></asp:DropDownList>
            </div>
           
        </div>
        <br/>
        <div class="row">
            <div class="col-md-4">
                Category : </div>

            <div class="col-md-8">
                <asp:DropDownList ID="categoryDropDownList"  AutoPostBack="True" runat="server" CssClass="form-control" ></asp:DropDownList>
            </div>
           
        </div>
        <br/> 
        <div class="row">
             <div class="col-md-12 text-right">
                 <asp:Button runat="server" Text="Search"  ID="searchItemButton" CssClass="btn btn-primary " OnClick="searchItemButton_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
                <asp:GridView ID="searchItemGridView" runat="server" AutoGenerateColumns="False" Width="667px" >
                    <Columns>
                        <asp:TemplateField HeaderText="SL">
                             <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item">
                            <ItemTemplate>
                                 <%#Eval("ItemName") %>
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Company">
                            <ItemTemplate>
                                 <%#Eval("CompanyName") %>
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category">
                            <ItemTemplate>
                                 <%#Eval("CategoryName") %>
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Available Quantity">
                            <ItemTemplate>
                                 <%#Eval("AvilableQuantity") %>
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reorder Level">
                            <ItemTemplate>
                                 <%#Eval("Reorder") %>
                             </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:HiddenField ID="CompanyHiddenField" runat="server" />
            </div>
        </div>
         <div class="row">
             <div class="col-md-12 text-right">
                 <asp:Button runat="server" Text="Download"  ID="DownLoad" CssClass="btn btn-primary " OnClick="DownLoad_Click"  />
            </div>
        </div>
    </div>
    </form>
</asp:Content>