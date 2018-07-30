<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategorySetupUI.aspx.cs" Inherits="StockManagement.UI.CategorySetupUI" MasterPageFile="../Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="body">
    <form id="form1" runat="server">
    <div class="login-form text-center">
         <h2 class="text-center">Category Setup</h2>
        <hr/>
        <div class="row">
            <div class="col-md-4">
                Name :
            </div>

            <div class="col-md-8">
                <asp:TextBox ID="addCategoryTextBox"  runat="server" CssClass="form-control"></asp:TextBox>
            </div>
           
        </div>
         <br/> 
        <div class="row">
             <div class="col-md-12 text-right">
                
                 
                 <asp:Button runat="server" Text="Update" ID="UpdateBtn" CssClass="btn btn-primary " OnClick="UpdateBtn_Click"  />
                 <asp:Button runat="server" Text="Save" ID="saveBtn" CssClass="btn btn-primary " OnClick="saveBtn_Click"  />
            </div>
        </div>
        <asp:HiddenField ID="idHiddenField" runat="server" />
        <asp:GridView ID="categoryGridView" runat="server" AutoGenerateColumns="False" Width="455px" OnSelectedIndexChanged="categoryGridView_SelectedIndexChanged"    >
            <Columns>
                <asp:TemplateField>
                     <ItemTemplate>
                        
                          <asp:Label runat="server" ID="categoryIdLabel" Text='<%#Eval("CategoryId") %>' ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Category Name">
                    <ItemTemplate>
                       <asp:Label runat="server" ID="categoryNameLabel" Text='<%#Eval("CategoryName") %>' ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Update" ID="lnkSelect" runat="server" CommandName="Select" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
         </asp:GridView>
        <br/>
        <asp:Button runat="server" Text="Home" ID="homeBtn" CssClass="btn btn-primary btn-block " OnClick="homeBtn_Click"   />
         
    </div>
    </form>
</asp:Content>
