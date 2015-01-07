<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewUser.aspx.cs" Inherits="ZeroToProgrammer.AddNewUser" MasterPageFile="Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="form-horizontal" style="width: 75%">
        <div class="form-group">
            <div class="col-sm-2 control-label"></div>
            <div class="col-sm-10">
                <div class="page-header">
                    <h1>Create New Account</h1>
                </div>
            </div>
        </div>

        <div id="divUsername" runat="server" class="form-group">
            <asp:Label ID="lblUsername" AssociatedControlID="txtUsername" CssClass="col-sm-2 control-label" runat="server">Username</asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtUsername" CssClass="form-control input-width-long" runat="server"></asp:TextBox>
            </div>

        </div>
        <div id="divPassword" runat="server" class="form-group">
            <asp:Label ID="lblPassword" AssociatedControlID="txtPassword" CssClass="col-sm-2 control-label" runat="server">Password</asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtPassword" CssClass="form-control input-width-long" TextMode="Password" runat="server"></asp:TextBox>
            </div>
        </div>
        <div id="divFirstName" runat="server" class="form-group">
            <asp:Label ID="lblFirstName" AssociatedControlID="txtFirstName" CssClass="col-sm-2 control-label" runat="server">First Name</asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtFirstName" CssClass="form-control input-width-long" runat="server"></asp:TextBox>
            </div>
        </div>
        <div id="divLastName" runat="server" class="form-group">
            <asp:Label ID="lblLastName" AssociatedControlID="txtLastName" CssClass="col-sm-2 control-label" runat="server">Last Name</asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtLastName" CssClass="form-control input-width-long" runat="server"></asp:TextBox>
            </div>
        </div>
        <div id="divEmail" runat="server" class="form-group">
            <asp:Label ID="lblEmail" AssociatedControlID="txtEmail" CssClass="col-sm-2 control-label" runat="server">Email</asp:Label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtEmail" CssClass="form-control input-width-long" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <button id="btnSubmit" runat="server" class="btn btn-primary" onserverclick="btnSubmit_Click">
                    Submit
                    <span class="glyphicon glyphicon-floppy-disk" aria-hidden="true"></span>
                </button>
            </div>
        </div>
    </div>
</asp:Content>
