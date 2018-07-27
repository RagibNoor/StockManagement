<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogInUI.aspx.cs" Inherits="StockManagement.UI.LogInUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="../Assets/css/bootstrap.css"/>
    <link rel="stylesheet" href="../Assets/css/myStyle.css"/>
</head>
<body>
    <form id="form1" runat="server">

        <div class="login-form">

            <h2 class="text-center">Log in</h2>
            <div class="form-group">
                <asp:TextBox ID="userNameTextBox" placeholder="User Name" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:TextBox ID="PasswordTextBox" placeholder="Password" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Button runat="server" Text="Login" ID="loginBtn" CssClass="btn btn-primary btn-block" OnClick="loginBtn_Click" />
            </div>

            <div class="clearfix">
                <label class="pull-left checkbox-inline">
                    <input type="checkbox" />
                    Remember me</label>
                <a href="#" class="pull-right">Forgot Password?</a>
            </div>

            <p class="text-center"><a href="#">Create an Account</a></p>
        </div>

    </form>
</body>

</html>
