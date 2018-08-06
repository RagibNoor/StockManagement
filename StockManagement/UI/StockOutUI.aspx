<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOutUI.aspx.cs" Inherits="StockManagement.UI.StockOutUI" MasterPageFile="../Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="body">
    <form id="form1" runat="server">
    <div class="login-form text-center">
         <h2 class="text-center">Stock Out</h2>
        <hr/>
        <div class="row">
            <div class="col-md-4">
                Company :
            </div>

            <div class="col-md-8">
                <asp:DropDownList ID="companyDropDownList" AutoPostBack="True" runat="server" CssClass="form-control" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged"></asp:DropDownList>
            </div>
           
        </div>
         <br/>
        <div class="row">
            <div class="col-md-4">
                Item :
            </div>

            <div class="col-md-8">
                <asp:DropDownList ID="itemDropDownList" AutoPostBack="True" runat="server" CssClass="form-control" OnSelectedIndexChanged="itemDropDownList_SelectedIndexChanged"></asp:DropDownList>
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
                Stock Out Quantity :
            </div>

            <div class="col-md-8">
                 <asp:TextBox ID="stockOutQuantityTextBox" AutoPostBack="True" runat="server" CssClass="form-control" OnTextChanged="stockOutQuantityTextBox_TextChanged"></asp:TextBox>
            </div>
           
        </div>
         <br/>
        <div class="row">
             <div class="col-md-12 text-right">
                 <asp:Button ID="stockOutAddButton" runat="server" Text="Add" CssClass="btn btn-primary " OnClick="stockOutAddButton_Click" />
            </div>
        </div>
        <br/>
        <div class="row">
            <div class="col-md-8">
                 <asp:GridView ID="stockOutGridView" runat="server" AutoGenerateColumns="False" Width="455px">
                     <Columns>
                          <asp:TemplateField Visible="False">
                     <ItemTemplate>
                          <asp:Label runat="server" ID="categoryIdLabel" Text='<%#Eval("ItemId") %>' ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
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
                         <asp:TemplateField HeaderText="Quantity">
                              <ItemTemplate>
                                  <%#Eval("StockOut") %>
                             </ItemTemplate>
                         </asp:TemplateField>
                     </Columns>
                 </asp:GridView>
                 <asp:HiddenField ID="IDHiddenField" runat="server" />
                 <asp:HiddenField ID="CompanyHiddenField" runat="server" />
            </div>
        </div>
         <asp:HiddenField ID="HiddenField3" runat="server" />
        <br/>
        <div class="row">
             <div class="col-md-12 text-right">
                 <asp:Button ID="sellButton" runat="server" Text="Sell" CssClass="btn btn-primary " OnClick="sellButton_Click" />
                 <asp:Button ID="damageButton" runat="server" Text="Damage" CssClass="btn btn-primary " OnClick="damageButton_Click" />
                 <asp:Button ID="lostButton" runat="server" Text="Lost" CssClass="btn btn-primary " OnClick="lostButton_Click" />
            </div>
        </div>
    </div>
    </form>
</asp:Content>
