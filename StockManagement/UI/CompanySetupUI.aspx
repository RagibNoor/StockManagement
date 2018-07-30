<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanySetupUI.aspx.cs" Inherits="StockManagement.UI.CompanySetupUI" MasterPageFile="../Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="body">
    <form id="form1" runat="server">
     <div class="login-form text-center">
         <h2 class="text-center">Company Setup</h2>
        <hr/>
        <div class="row">
            <div class="col-md-4">
                Name :
            </div>

            <div class="col-md-8">
                <asp:TextBox ID="addCompanyTextBox"  runat="server" CssClass="form-control"></asp:TextBox>
            </div>
           
        </div>
         <br/> 
        <div class="row">
             <div class="col-md-12 text-right">
                
                 
                 <asp:Button runat="server" Text="Update" ID="UpdateCompanyBtn" CssClass="btn btn-primary " OnClick="UpdateCompanyBtn_Click"   />
                 <asp:Button runat="server" Text="Save" ID="saveCompanyBtn" CssClass="btn btn-primary " OnClick="saveCompanyBtn_Click"   />
            </div>
        </div>
        <asp:HiddenField ID="CompanyIdHiddenField" runat="server" />
        <asp:GridView ID="CompanyGridView" runat="server" AutoGenerateColumns="False" Width="454px" OnSelectedIndexChanged="CompanyGridView_SelectedIndexChanged"   >
            <Columns>
                <asp:TemplateField>
                     <ItemTemplate>
                        
                          <asp:Label runat="server" ID="companyIdLabel" Text='<%#Eval("CompanyId") %>' ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Category Name">
                    <ItemTemplate>
                       <asp:Label runat="server" ID="companyNameLabel" Text='<%#Eval("CompanyName") %>' ></asp:Label>
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