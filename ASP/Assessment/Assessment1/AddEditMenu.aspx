<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="AddEditMenu.aspx.cs"
    Inherits="FoodOrderManagement.AddEditMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Add / Edit Menu Item</h2>

    <table>

        <tr>
            <td>Item Name</td>
            <td>
                <asp:TextBox ID="txtItemName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtItemName" ErrorMessage="Name required" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>Category</td>
            <td>
                <asp:DropDownList ID="ddlCategory" runat="server">
                    <asp:ListItem>Veg</asp:ListItem>
                    <asp:ListItem>Non-Veg</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>Food Type</td>
            <td>
                <asp:DropDownList ID="ddlFoodType" runat="server">
                    <asp:ListItem>Breakfast</asp:ListItem>
                    <asp:ListItem>Lunch</asp:ListItem>
                    <asp:ListItem>Dinner</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>Price</td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>

                <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice" ErrorMessage="Price required" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvPrice" runat="server" ControlToValidate="txtPrice" MinimumValue="50" MaximumValue="5000" Type="Double" ErrorMessage="Invalid price" ForeColor="Red">*</asp:RangeValidator>
            </td>
        </tr>

        <tr>
            <td>Quantity</td>
            <td>
                <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Available</td>
            <td>
                <asp:CheckBox ID="chkAvailable" runat="server" Text="Is Available" />
            </td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </td>
        </tr>

        <tr>
            <td colspan="2">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>

    </table>

</asp:Content>
