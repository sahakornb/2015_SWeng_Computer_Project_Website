<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CPE02.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="container body-content">


        <div class="container-fluid">
            <div class="row">
                <div class="row">
                    <div class="col-lg-12">
                        <h4 class="text-center">แบบบันทึกการดําเนินงานโครงงานวิศวกรรมคอมพิวเตอร์ </h4>
                        <h4 class="text-center">ภาควิชาวิศวกรรมไฟฟ้าและคอมพิวเตอร์ คณะวิศวกรรมศาสตร์ มหาวิทยาลัยนเรศวร </h4>
                        <p class="text-center"></p>
                    </div>
                </div>
            </div>
        </div>

        <div class="container-fluid">
            <div class="row">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <span class="glyphicon glyphicon glyphicon-file" aria-hidden="true"></span>
                        <label>โครงการ</label>
                    </div>
                    <div class="panel-body">
                        <div class="col-lg-2">
                            <label>รหัสโครงงาน</label>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
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


            <div class="row">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                        <label>ประเด็น/หัวข้อ/งานที่มอบหมาย</label>
                    </div>
                    <div class="panel-body">
                        <div class="col-lg-12">
                            <div class="panel panel-primary">
                                <div class="panel-body">
                                    <asp:TextBox ID="TextBox6" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="5"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                        <label>ข้อสรุป/ความคืบหน้าของงาน</label>
                    </div>
                    <div class="panel-body">
                        <div class="col-lg-12">
                            <div class="panel panel-primary">
                                <div class="panel-body">
                                    <asp:TextBox ID="TextBox7" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="5"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                        <label>หมายเหตุ</label>
                    </div>
                    <div class="panel-body">
                        <div class="col-lg-12">
                            <div class="panel panel-primary">
                                <div class="panel-body">
                                    <asp:TextBox ID="TextBox8" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="5"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <br />
        <div class="row">
            <div class="buttonHolder">
                <asp:Button ID="Button3" runat="server" Text="ดูรายละเอียดทั้งหมด" class="btn btn-default" Width="150px" OnClick="Button3_Click" />
                <asp:Button ID="Button1" runat="server" Text="บันทึก" class="btn btn-default" Width="67px" OnClick="Button1_Click" />
<%--                <asp:Button ID="Button2" runat="server" Text="ส่งแบบฟอร์ม" class="btn btn-default" Width="100px" OnClick="Button2_Click" />--%>
            </div>

            <style>
                .buttonHolder {
                    text-align: center;
                }
            </style>
        </div>
    </div>
</asp:Content>




