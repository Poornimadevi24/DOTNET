<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuDetails.aspx.cs" Inherits="FoodOrderManagement.MenuDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Menu Details</h2>

    <table border="1" cellpadding="8">

        <tr>
            <td>Menu ID</td>
            <td><asp:Label ID="lblMenuId" runat="server"></asp:Label></td>
        </tr>

        <tr>
            <td>Item Name</td>
            <td><asp:Label ID="lblItemName" runat="server"></asp:Label></td>
        </tr>

        <tr>
            <td>Category</td>
            <td><asp:Label ID="lblCategory" runat="server"></asp:Label></td>
        </tr>

        <tr>
            <td>Food Type</td>
            <td><asp:Label ID="lblFoodType" runat="server"></asp:Label></td>
        </tr>

        <tr>
            <td>Price</td>
            <td><asp:Label ID="lblPrice" runat="server"></asp:Label></td>
        </tr>

        <tr>
            <td>Quantity</td>
            <td><asp:Label ID="lblQuantity" runat="server"></asp:Label></td>
        </tr>

        <tr>
            <td>Available</td>
            <td><asp:Label ID="lblAvailable" runat="server"></asp:Label></td>
        </tr>

        <tr>
            <td>Created Date</td>
            <td><asp:Label ID="lblDate" runat="server"></asp:Label></td>
        </tr>

    </table>

    <br />

    <asp:Button ID="btnBack" runat="server" Text="Back to List" PostBackUrl="~/MenuList.aspx"  />

</asp:Content>
