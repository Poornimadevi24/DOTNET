<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="OrderStats.aspx.cs"
    Inherits="FoodOrderManagement.OrderStats" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Order Statistics Dashboard</h2>

    <hr />

    <h3>Application State</h3>

    <asp:Label ID="lblTotalVisitors" runat="server" Font-Bold="true"></asp:Label>
    <br />
    <asp:Label ID="lblActiveUsers" runat="server" Font-Bold="true"></asp:Label>

    <hr />

    <h3>Food Category Report (Cached)</h3>

    <asp:GridView ID="gvCategoryStats" runat="server"
        BorderWidth="1"
        CellPadding="6"
        Width="50%">
    </asp:GridView>

</asp:Content>