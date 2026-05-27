<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FoodOrderManagement.Login" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Admin Login</title>

    <style>
        body {
            font-family: Arial;
            background-color: #f4f4f4;
        }

        .login-box {
            width: 350px;
            margin: 100px auto;
            background-color: white;
            padding: 25px;
            border-radius: 10px;
            box-shadow: 0px 0px 10px gray;
        }

        .btn {
            width: 100%;
            padding: 10px;
            background-color: #ff6600;
            color: white;
            border: none;
        }

        .error {
            color: red;
        }
    </style>
</head>

<body>

    <form id="form1" runat="server">

        <div class="login-box">

            <h2>Admin Login</h2>

            <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
            <br />

            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>

            <br /><br />

            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            <br />

            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>

            <br /><br />

            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click" />

            <br /><br />

            <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>

        </div>

    </form>

</body>
</html>
