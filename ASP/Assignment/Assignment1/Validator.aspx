<!--1. Write the following application. The initial page is called Validator.aspx and it has 7 text boxes representing (Name, Family Name, Address, City, Zip Code, Phone and e-mail address) and a Check button.-->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="ASP_Assignemt.Validator" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validator Form</title>

    <style>

        body {
            font-family: Arial;
        }

        table {
            margin-top: 20px;
        }

        td {
            padding: 10px;
        }

        .txt {
            width: 180px;
            background-color: white;
        }

        .error {
            color: red;
        }

        .success {
            color: green;
            font-weight: bold;
        }

        .hint {
            margin-left: 10px;
            font-size: 12px;
            color: gray;
        }

        .btn {
            padding: 5px 15px;
        }

    </style>

</head>

<body>

<form id="form1" runat="server">

<div>

    <h3>Insert your details :</h3>

    <table>

      
        <tr>
            <td>Name:</td>
            <td>
                <asp:TextBox ID="txtName" runat="server" CssClass="txt"></asp:TextBox>

                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                 ErrorMessage="Name required" CssClass="error">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>Family Name:</td>
            <td>
                <asp:TextBox ID="txtFamilyName" runat="server" CssClass="txt"></asp:TextBox>

                <asp:RequiredFieldValidator ID="rfvFamily" runat="server" ControlToValidate="txtFamilyName"
                  ErrorMessage="Family Name required" CssClass="error">*</asp:RequiredFieldValidator>

                <asp:CustomValidator ID="cvName" runat="server" ControlToValidate="txtFamilyName"
                ErrorMessage="Name and Family Name must be different" CssClass="error" OnServerValidate="cvName_ServerValidate">*</asp:CustomValidator>
                <span class="hint">must differ from name</span>
            </td>
        </tr>

   
        <tr>
            <td>Address:</td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="txt"></asp:TextBox>

                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                 ErrorMessage="Address required" CssClass="error">*</asp:RequiredFieldValidator>

                <asp:RegularExpressionValidator ID="revAddress" runat="server" ControlToValidate="txtAddress"
                ValidationExpression="^.{2,}$"ErrorMessage="Min 2 characters" CssClass="error">*</asp:RegularExpressionValidator>
                <span class="hint">at least 2 chars</span>
            </td>
        </tr>

        <tr>
            <td>City:</td>
            <td>
                <asp:TextBox ID="txtCity" runat="server" CssClass="txt"></asp:TextBox>

                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity"
                 ErrorMessage="City required" CssClass="error">*</asp:RequiredFieldValidator>

                <asp:RegularExpressionValidator ID="revCity" runat="server" ControlToValidate="txtCity" ValidationExpression="^.{2,}$"
                 ErrorMessage="Min 2 characters" CssClass="error">*</asp:RegularExpressionValidator>

                <span class="hint">at least 2 chars</span>
            </td>
        </tr>

     
        <tr>
            <td>Zip Code:</td>
            <td>
                <asp:TextBox ID="txtZip" runat="server" CssClass="txt"></asp:TextBox>

                <asp:RequiredFieldValidator ID="rfvZip" runat="server" ControlToValidate="txtZip" ErrorMessage="Zip required"
                 CssClass="error">*</asp:RequiredFieldValidator>

                <asp:RegularExpressionValidator ID="revZip" runat="server" ControlToValidate="txtZip" ValidationExpression="^\d{5}$"
                 ErrorMessage="5 digit zip" CssClass="error">*</asp:RegularExpressionValidator>

                <span class="hint">xxxxxx</span>
            </td>
        </tr>

       
        <tr>
            <td>Phone:</td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server" CssClass="txt"></asp:TextBox>

                <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone"
                 ErrorMessage="Phone required" CssClass="error">*</asp:RequiredFieldValidator>

                <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtPhone"
                 ValidationExpression="^\d{10}$" ErrorMessage="Invalid phone format"
                  CssClass="error">*</asp:RegularExpressionValidator>

                <span class="hint">xxxxxxxxxx</span>
            </td>
        </tr>

      
        <tr>
            <td>Email:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="txt"></asp:TextBox>

                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email required"
                 CssClass="error">*</asp:RequiredFieldValidator>

                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                 ValidationExpression="\w+([-.+']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid email"
                  CssClass="error">*</asp:RegularExpressionValidator>

                <span class="hint">example@mail.com</span>
            </td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnCheck" runat="server"
                    Text="Check"
                    CssClass="btn"
                    OnClick="btnCheck_Click" />

                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>

    </table>

    <br />

    <asp:ValidationSummary
        ID="ValidationSummary1"
        runat="server"
        HeaderText="Errors:"
        CssClass="error"
        ShowMessageBox="True"
        ShowSummary="True" />

</div>

</form>

</body>
</html>