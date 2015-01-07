<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewContent.aspx.cs" Inherits="ZeroToProgrammer.AddNewContent" MasterPageFile="Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="form-horizontal" style="width: 75%">
        <div class="form-group">
            <div class="col-sm-2 control-label"></div>
            <div class="col-sm-10">
                <div class="page-header">
                    <h1>Add New Content</h1>
                </div>
            </div>
        </div>

        <div id="divTitle" runat="server" class="form-group">
            <asp:Label ID="lblTitle" AssociatedControlID="txtTitle" CssClass="col-sm-2 control-label" runat="server">Title</asp:Label>
            <asp:TextBox ID="txtTitle" CssClass="form-control input-width-long" runat="server"></asp:TextBox>


        </div>
        <div id="divContent" runat="server" class="form-group">
            <asp:Label ID="lblContent" AssociatedControlID="txtContent" CssClass="col-sm-2 control-label" runat="server">Content</asp:Label>
            <asp:TextBox ID="txtContent" CssClass="form-control input-width-long" TextMode="MultiLine" Height="300px" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <div class="col-sm-2"></div>
            <button id="btnSubmit" runat="server" class="btn btn-primary" onserverclick="btnSubmit_Click">
                Submit
                    <span class="glyphicon glyphicon-floppy-disk" aria-hidden="true"></span>
            </button>
        </div>
    </div>
</asp:Content>
