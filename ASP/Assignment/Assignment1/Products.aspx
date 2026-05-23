<!--2. Create a web application that hosts a series of products (any product) as a dropdown list.

Have an image control that can display the image of the selected item in the dropdown

have a button control that gets the price of the selected product and displays it in a Label control-->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="ASP_Assignemt.Products" %>


<!DOCTYPE html>
<html>
<head runat="server">
    <title>Product Details</title>
    <style>
        body {
            font-family: Arial;
            margin: 40px;
        }
        .container {
            width: 400px;
        }
        img {
            width: 200px;
            height: 200px;
            border: 1px solid #ccc;
            margin-top: 20px;
        }
        .btn {
            margin-top: 15px;
        }
        .label {
            margin-top: 15px;
            font-weight: bold;
            display: block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="container">

            <h2>Product Dropdown</h2>
<asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged"></asp:DropDownList>

            <br />

           
            <asp:Image ID="imgProduct" runat="server" />

            <br />

            <asp:Button ID="btnGetPrice" runat="server"
                Text="Get Price"
                CssClass="btn"
                OnClick="btnGetPrice_Click" />

           
            <asp:Label ID="lblPrice" runat="server" CssClass="label" Text="Price: " />

        </div>

    </form>
</body>
</html>
