<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CPE03.aspx.cs" Inherits="Default2" %>

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
        .z-depth-1, nav, .card-panel, .card, .toast, .btn-large, .btn-floating, .dropdown-content, .collapsible, ul.side-nav {
            -webkit-box-shadow: 0 2px 5px 0 rgba(0, 0, 0, 0.16), 0 2px 10px 0 rgba(0, 0, 0, 0.12);
            -moz-box-shadow: 0 2px 5px 0 rgba(0, 0, 0, 0.16), 0 2px 10px 0 rgba(0, 0, 0, 0.12);
            box-shadow: 0 2px 5px 0 rgba(0, 0, 0, 0.16), 0 2px 10px 0 rgba(0, 0, 0, 0.12);
        }
    </style>

    <div class="container body-content">

        <div class="container">
            <div class="col-xs-12">
                <div class="row">
                    <div class="col-xs-12">
                        <h4 class="text-center">แบบขอสอบข้อเสนอโครงงานวิศวกรรมคอมพิวเตอร์ ปีการศึกษา 2557 </h4>
                        <h4 class="text-center">ภาควิชาวิศวกรรมไฟฟ้าและคอมพิวเตอร์ คณะวิศวกรรมศาสตร์ มหาวิทยาลัยนเรศวร</h4>
                        <p class="text-center"></p>
                    </div>
                </div>
            </div>
        </div>
        <%--///////////////////// รหัสโครงการ //////////////////////--%>

        <%--        <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <span class="glyphicon glyphicon-font" aria-hidden="true"></span>
                    <label>รหัสโครงการ</label>
                </div>
                <div class="panel-body">
                    <div class="col-lg-6">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                </div>
            </div>
        </div>--%>
        <%--//////////////////////  STOP  /////////////////////--%>

        <%--///////////////////// ชื่อโครงการ //////////////////////--%>

        <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <span class="glyphicon glyphicon glyphicon-file" aria-hidden="true"></span>
                    <label>โครงการ</label>
                </div>
                <div class="panel-body">
                    <div class="col-lg-2">
                        <label>รหัสโครงงาน</label>
                        <asp:TextBox ID="text_ProjID" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                    </div>
                    <div class="col-lg-5">
                        <label>ชื่อภาษาไทย</label>
                        <asp:TextBox ID="text_th" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>

                    </div>
                    <div class="col-lg-5">
                        <label>ชื่อภาษาอังกฤษ</label>
                        <asp:TextBox ID="text_en" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                    </div>

                </div>
            </div>
        </div>
        <%--//////////////////////  STOP  /////////////////////--%>

        <%--////////////////////////// รายชื่อนิสิคผู้ทำโครงงาน ////////////////////////////--%>

        <div class="col-lg-12">
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

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>


        <%--///////////////////////////////////////  STOP  ////////////////////////////////////////////--%>


        <%--//////////////////////////// ประเด็นปัญหาและขอบเขตของโครงงานโดยย่อ //////////////////////////////--%>

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

        <%--/////////////////////////////////////////  STOP  /////////////////////////////////////////////////--%>


        <%--//////////////////////////// กรรมการสอบโครงงาน //////////////////////////////--%>
        <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <span class="glyphicon glyphicon-saved"></span>
                    <label>กรรมการสอบโครงงาน</label>
                </div>
                <div class="panel-body">
                    <div class="col-lg-12">
                        <div class="col-lg-6">
                            <div class="col-lg-5">
                            </div>
                            <label>ชื่อ-นามสกุล</label>
                            <asp:TextBox ID="TextBoxcommittee1" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-lg-6">
                            <div class="col-lg-5">
                            </div>
                            <label>สถานะ</label>
                            <br />
                            <div class="col-lg-5">
                            </div>
                            <asp:Button ID="BTN_success1" runat="server" class="btn btn-default disabled" Text="กรุณากดส่งแบบฟอร์มก่อน" />

                        </div>
                    </div>

                    <div class="col-lg-12">
                        <div class="col-lg-6">
                            <asp:TextBox ID="TextBoxcommittee2" runat="server" CssClass="form-control" Rows="5" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-lg-6">
                            <div class="col-lg-5">
                            </div>
                            <asp:Button ID="BTN_success2" runat="server" class="btn btn-default disabled" Text="กรุณากดส่งแบบฟอร์มก่อน" />
                        </div>
                    </div>

                    <div class="col-lg-12">
                        <div class="col-lg-6">
                            <asp:TextBox ID="TextBoxcommittee3" runat="server" CssClass="form-control" Rows="5" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-lg-6">
                            <div class="col-lg-5">
                            </div>
                            <asp:Button ID="BTN_success3" runat="server" class="btn btn-default disabled" Text="กรุณากดส่งแบบฟอร์มก่อน" />
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <%--/////////////////////////////////////////  STOP  /////////////////////////////////////////////////--%>
    </div>
    <br />

    <div class="row ">
        <div class="col-md-6"></div>


        <br />
        <div class="buttonHolder">

            <asp:Button ID="ButtonSave" runat="server" Text="บันทึก" OnClick="ButtonSave_Click" />
            <asp:Button ID="ButtonSend" runat="server" Text="ส่งแบบฟอร์ม" OnClick="ButtonSend_Click" />
        </div>
    </div>
    <style>
        .buttonHolder {
            text-align: center;
        }
    </style>
</asp:Content>



