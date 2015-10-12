<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="test2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

<%--    <%@ Page MaintainScrollPositionOnPostback="true" %>--%>
    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Height="32px" Width="98px" AutoPostBack="True">
        <asp:ListItem Selected="True">1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
    </asp:DropDownList>

    <button class="btn btn-default" runat="server" type="button" onserverclick="ShID2">ค้นหา</button>

    <div id="my_own_textbox" style="display: block;" class="card-panel teal lighten-2">
        1
    </div>
    <div id="my_own_textbox1" runat="server" style="display: none;" class="card-panel teal lighten-2">
        2
    </div>
    <div id="my_own_textbox2" runat="server" style="display: none;" class="card-panel teal lighten-2">
        3
    </div>


</asp:Content>

