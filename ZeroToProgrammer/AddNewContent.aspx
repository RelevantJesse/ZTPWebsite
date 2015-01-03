<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewContent.aspx.cs" Inherits="ZeroToProgrammer.AddNewContent" MasterPageFile="Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <h1>Add New Content</h1>

    <table>
        <tr>
            <td colspan="2">
                
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label1" runat="server" Text="Title: "></asp:Label></td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="500px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: right" class="auto-style1">
                <asp:Label ID="Label3" runat="server" Text="Content: "></asp:Label></td>
            <td class="auto-style1">
                <asp:TextBox ID="txtContent" runat="server" Width="500px" Height="158px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
        </tr>
    </table>
</asp:Content>
