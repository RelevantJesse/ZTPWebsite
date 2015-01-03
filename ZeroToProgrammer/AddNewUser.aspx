<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewUser.aspx.cs" Inherits="ZeroToProgrammer.AddNewUser" MasterPageFile="Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    <br/>
    <br/>
    <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
    <br/>
    <br/>
    <asp:Label ID="lblFirstName" runat="server" Text="First Name: "></asp:Label>
    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
    <br/>
    <br/>
    <asp:Label ID="lblLastName" runat="server" Text="Last Name: "></asp:Label>
    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
    <br/>
    <br/>
    <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <br/>
    <br/>
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
</asp:Content>