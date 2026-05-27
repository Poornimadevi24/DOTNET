<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"AutoEventWireup="true"CodeBehind="MenuList.aspx.cs"Inherits="FoodOrderManagement.MenuList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Food Menu List</h2>

    <asp:Button ID="btnAddNew" runat="server" Text="Add New Food Item" PostBackUrl="~/AddEditMenu.aspx" BackColor="Orange" ForeColor="White" Height="35px" />

    <br /><br />

    <asp:GridView ID="gvMenu" runat="server" AutoGenerateColumns="False" Width="100%" BorderWidth="1" CellPadding="8" OnRowCommand="gvMenu_RowCommand">

       <Columns>

            <asp:BoundField DataField="MenuId" HeaderText="Menu ID" />
            <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
            <asp:BoundField DataField="Category" HeaderText="Category" />
            <asp:BoundField DataField="FoodType" HeaderText="Food Type" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
            <asp:BoundField DataField="AvailableQuantity" HeaderText="Quantity" />

            <asp:TemplateField HeaderText="Available">
                <ItemTemplate>
                    <%# Convert.ToBoolean(Eval("IsAvailable")) ? "Yes" : "No" %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Actions">

                <ItemTemplate>

                    <asp:LinkButton ID="lnkView" runat="server" Text="View" CommandName="ViewMenu" CommandArgument='<%# Eval("MenuId") %>'></asp:LinkButton>
                    <asp:LinkButton ID="lnkEdit"  runat="server" Text="Edit" CommandName="EditMenu" CommandArgument='<%# Eval("MenuId") %>'></asp:LinkButton>
                    <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="DeleteMenu" CommandArgument='<%# Eval("MenuId") %>'
                    OnClientClick="return confirm('Are you sure to delete?');"></asp:LinkButton>
                </ItemTemplate>

            </asp:TemplateField>

        </Columns>

    </asp:GridView>

</asp:Content>