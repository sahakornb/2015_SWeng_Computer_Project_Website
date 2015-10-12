<%@ Page Title="CPE01 แบบเสนอหัวข้อโครงงานวิศวกรรมคอมพิวเตอร์" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="Default2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <style>
        .panel-heading {
            padding: 5px 15px;
            border-bottom: 1px solid transparent;
            border-top-right-radius: 2px;
            border-top-left-radius: 2px;
        }

        .card-panel {
            padding: 20px;
            margin: 0.5rem 0 1rem 0;
            -webkit-border-radius: 2px;
            -moz-border-radius: 2px;
            border-radius: 2px;
            background-clip: padding-box;
            background-color: #fff;
        }

        label {
            display: inline-block;
            max-width: 100%;
            margin-bottom: 2px;
            font-weight: bold;
        }
    </style>

    <style>
        .teal.lighten-2 {
            background-color: #fff !important;
        }
    </style>
    <style>
        .z-depth-1, nav, .card-panel, .card, .toast, .btn-large, .btn-floating, .dropdown-content, .collapsible, ul.side-nav {
            -webkit-box-shadow: 0 2px 5px 0 rgba(0, 0, 0, 0.16), 0 2px 10px 0 rgba(0, 0, 0, 0.12);
            -moz-box-shadow: 0 2px 5px 0 rgba(0, 0, 0, 0.16), 0 2px 10px 0 rgba(0, 0, 0, 0.12);
            box-shadow: 0 2px 5px 0 rgba(0, 0, 0, 0.16), 0 2px 10px 0 rgba(0, 0, 0, 0.12);
        }
    </style>
    <style>
        .btn {
            padding: 6px 9px;
        }
    </style>
    <script>$("body").css("overflow", "auto");
    </script>
    <div class="container body-content">
        <div class="container-fluid">
            <br />
            <div class="panel2">
                <div class="panel-heading">
                    <h5 class="text-center">แบบเสนอหัวข้อโครงงานวิศวกรรมคอมพิวเตอร์</h5>
                </div>
            </div>
        </div>
        <br />
        <div class="container-fluid">
            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <span class="glyphicon glyphicon glyphicon-file" aria-hidden="true"></span>
                        <label>ชื่อโครงการ</label>
                    </div>
                    <div class="panel-body">
                        <div class="col-lg-6">
                            <label>ภาษาไทย</label>
                            <asp:TextBox ID="text_th" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-lg-6">
                            <label>ภาษาอังกฤษ</label>
                            <asp:TextBox ID="text_en" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>


            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <span class="glyphicon glyphicon-user" aria-hidden="true"></span>
                        <label>รายชื่อนิสิตผู้ทำโครงงาน</label>
                    </div>
                    <div class="panel-body">
                        <%--                        <div class="row">
                            <div class="col-lg-2">
                                <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control" Height="32px" Width="112px" AutoPostBack="True">
                                    <asp:ListItem Selected="True" Value="1">สมาชิก 1 คน</asp:ListItem>
                                    <asp:ListItem Value="2">สมาชิก 2 คน</asp:ListItem>
                                    <asp:ListItem Value="3">สมาชิก 3 คน</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>--%>
                        <div id="divAddMember" style="display: block;" runat="server">
                            <div class="row">

                                <div class="col-lg-12">
                                    <label>เพิ่มสมาชิก</label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-2">
                                    <div class="input-group">
                                        <asp:TextBox ID="shBox" runat="server" CssClass="form-control"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:Button ID="BtnSearch" runat="server" Text="ค้นหา" class="btn btn-primary" Width="67px" OnClick="BtnSearch_Click" />
                                        </span>
                                    </div>
                                </div>
                                <div class="col-lg-8">
                                    <asp:TextBox ID="shshowBox" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">
                                    <div class="btn-group btn-group-justified">
                                        <asp:Button ID="btnAdd" runat="server" Text="เพิ่ม" class="btn btn-default" Width="67px" Visible="False" OnClick="btnAdd_Click" />
                                        <asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" class="btn btn-default" Width="67px" Visible="False" OnClick="btnCancel_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <hr />
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
                                        <span class="input-group-btn">
                                            <asp:Button ID="btnRemove" runat="server" Text="ลบ" class="btn btn-danger" OnClick="remove" />
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="my_own_textbox2" style="display: none;" class="card-panel teal lighten-2" runat="server">

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
                                        <span class="input-group-btn">
                                            <asp:Button ID="btnRemove2" runat="server" Text="ลบ" class="btn btn-danger" OnClick="remove2" />
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <span class="glyphicon glyphicon-user" aria-hidden="true"></span>
                        <label>อาจารย์ที่ปรึกษาและกรรมการ</label>
                    </div>
                    <div class="panel-body">
                        <div class="col-lg-4">
                            <label>อาจารย์ที่ปรึกษา</label>
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True">
                                <asp:ListItem Selected="True">โปรดเลือก</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-4">
                            <label>อาจารย์ที่ปรึกษาร่วม (ถ้ามี) </label>
                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" AutoPostBack="True">
                                <asp:ListItem Selected="True">โปรดเลือก</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-4">
                            <label>เสนอรายชื่อกรรมการ 1 ท่าน</label>
                            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control" AutoPostBack="True">
                                <asp:ListItem Selected="True">โปรดเลือก</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <style>
                .buttonHolder {
                    text-align: center;
                }
            </style>
            <div class="form-group">
                <div class="row">
                    <div class="buttonHolder">
                        <%--<button id="test" runat="server" class="btn btn-primary" style="width: auto;">ส่งแบบฟอร์ม</button>--%>
                        <asp:Button ID="btn_saveForm" runat="server" class="btn btn-primary" Text="บันทึก" OnClick="btn_saveForm_Click" />
                        <%--                     <asp:Button ID="btn_sentForm" runat="server" class="btn btn-primary disabled" Text="ส่งแบบฟอร์ม" />--%>
                        <%--                     <asp:Button ID="Button3" runat="server" Text="Button" />--%>
                        <asp:Button ID="btn_sentForm" runat="server" class="btn btn-primary disabled" Text="บันทึกและส่งแบบฟอร์ม" OnClick="btn_sentForm_Click" OnClientClick="ConfirmSent()" />
                        <asp:Button ID="btn_cancelForm" runat="server" class="btn btn-danger" Text="ออกจากโครงงาน" OnClick="exitProject" OnClientClick="Confirm()" />
                        <asp:Button ID="btn_cancelSentForm" runat="server" class="btn btn-danger" Text="ยกเลิการส่งโครงงาน" OnClick="btn_cancelSentForm_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("ต้องการออกจากโครงงานนี้หรือไม่?")) {
                confirm_value.value = "ใช่";
            } else {
                confirm_value.value = "ไม่";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <script type="text/javascript">
        function ConfirmSent() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value2";
            if (confirm("ต้องการบันทึกและส่งโครงงาน?")) {
                confirm_value.value = "ใช่";
            } else {
                confirm_value.value = "ไม่";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>


