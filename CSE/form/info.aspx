<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="info.aspx.cs" Inherits="Default2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="container body-content">
        <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <span class="glyphicon glyphicon glyphicon-file" aria-hidden="true"></span>
                    <label>โครงการ</label>
                </div>
                <div class="panel-body">
                    <%--<label>รหัสโครงงาน</label>--%>
                    <div class="col-lg-4">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                    </div>
                    <div class="col-lg-4">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                    </div>
                    <div class="col-lg-4">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>

                <%--//////////////////////////////////////////////////////////////////////////--%>

                <%--<div class="col-lg-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <span class="glyphicon glyphicon-user" aria-hidden="true"></span>
                            <label>รายชื่อนิสิตผู้ทำโครงงาน</label>
                        </div>
                        <div class="panel-body">

                            <div id="my_own_textbox" style="display: block;" class="card-panel teal lighten-2" runat="server">
                                <div class="row">
                                    <div class="col-lg-1">
                                        <label>ลำดับที่</label>
                                        <h5 class="text-center">1</h5>
                                    </div>
                                    <div class="col-lg-2">
                                        <label>รหัสนิสิต</label>
                                        <asp:TextBox ID="text_id" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3">
                                        <label>ชื่อ-นามสกุล</label>
                                        <asp:TextBox ID="text_name" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        <label>เบอร์โทร</label>
                                        <asp:TextBox ID="text_tel" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-4">
                                        <label>อีเมล์</label>
                                        <asp:TextBox ID="text_email" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div id="my_own_textbox1" style="display: none;" class="card-panel teal lighten-2" runat="server">

                                <div class="row">
                                    <div class="col-lg-1">
                                        <label>ลำดับที่</label>
                                        <h5 class="text-center">2</h5>
                                    </div>
                                    <div class="col-lg-2">
                                        <label>รหัสนิสิต</label>
                                        <asp:TextBox ID="text_id2" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3">
                                        <label>ชื่อ-นามสกุล</label>
                                        <asp:TextBox ID="text_name2" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        <label>เบอร์โทร</label>
                                        <asp:TextBox ID="text_tel2" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-4">
                                        <label>อีเมล์</label>
                                        <div class="input-group">
                                            <asp:TextBox ID="text_email2" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="my_own_textbox2" style="display: block;" class="card-panel teal lighten-2" runat="server">

                                <div class="row">
                                    <div class="col-lg-1">
                                        <label>ลำดับที่</label>
                                        <h5 class="text-center">3</h5>
                                    </div>
                                    <div class="col-lg-2">
                                        <label>รหัสนิสิต</label>
                                        <asp:TextBox ID="text_id3" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3">
                                        <label>ชื่อ-นามสกุล</label>
                                        <asp:TextBox ID="text_name3" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-2">
                                        <label>เบอร์โทร</label>
                                        <asp:TextBox ID="text_tel3" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-4">
                                        <label>อีเมล์</label>
                                        <div class="input-group">
                                            <asp:TextBox ID="text_email3" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>--%>
                <div class="col-lg-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                            <label>ประเด็นปัญหาและขอบเขตของโครงงานโดยย่อ</label>
                        </div>
                        <div class="panel-body">
                            <div class="col-lg-12">
                                <div class="panel panel-primary">
                                    <div class="panel-body">
                                        <%--<label>ภาษาไทย</label>--%>
                                        <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="5"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                


                <%--///////////////////////////////////////////////////////////////////////////////--%>
                <div class="card-panel" style="padding: 15px;">
                    <asp:Table CssClass="table table-condensed" ID="Table1" runat="server" Width="100%" HorizontalAlign="Center">
                    </asp:Table>
                </div>
            </div>
        </div>
        <div class="buttonHolder">
            <button type="button" class="btn btn-default" onclick="goBack()">กลับ</button>
        </div>


    </div>
    <style>
        .buttonHolder {
            text-align: center;
        }
    </style>
    <script>
        function goBack() {
            window.history.back();
        }
    </script>
</asp:Content>

