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
                 <asp:TextBox ID="StartDate" runat="server" CssClass="form-control datepicker" data-provide="datepicker" data-date-format="yyyy-mm-dd"></asp:TextBox>
            </div>
           
        </div>
         <br/>
        <div class="row">
            <div class="col-md-4">
                To Date
            </div>

            <div class="col-md-8">
                <asp:TextBox ID="EndDate" runat="server" CssClass="form-control datepicker" data-provide="datepicker" data-date-format="yyyy-mm-dd"></asp:TextBox>
            </div>
           
        </div>
         <br/>
        <div class="row">
             <div class="col-md-12 text-right">
                 <asp:Button ID="viewSearchItemButton" runat="server" Text="Search" CssClass="btn btn-primary " OnClick="viewSearchItemButton_Click" />
            </div>
        </div>
        <div class="row">
             <div class="col-md-12 text-right">
                 <asp:GridView ID="viewSearchItemGridView" runat="server" AutoGenerateColumns="False" Width="504px">
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
                         <asp:TemplateField HeaderText="Sale Quantity">
                             <ItemTemplate>
                                  <%#Eval("StockOut") %>
                             </ItemTemplate>
                         </asp:TemplateField>
                     </Columns>
                 </asp:GridView>
            </div>
            <br/>
            <div class="col-md-12 text-right">
                 <asp:Button ID="DownloadBtn" runat="server" Text="Download" CssClass="btn btn-primary " OnClick="DownloadBtn_Click"  />
            </div>

        </div>
    
    </div>
    
    </form>
</asp:Content>
