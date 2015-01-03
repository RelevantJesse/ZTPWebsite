<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ZeroToProgrammer.Login" MasterPageFile="Site.Master" %>

<asp:content runat="server" contentplaceholderid="MainContent">
    <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    <br/>
    <br/>
    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    <br/>
    <br/>
    <asp:Button ID="btnSubmit" runat="server" Text="Login" OnClick="btnSubmit_Click" />
</asp:content>
