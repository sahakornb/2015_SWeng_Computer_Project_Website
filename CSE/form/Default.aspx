<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <style>
        h6 {
            font-size: 17px;
        }
    </style>
    <%--    <div class="container body-content">--%>
    <div id="Div_student" style="display: none;" runat="server">
        <br />
        <div class="col-lg-6">

            <div class="col-md-12">
                <div class="list-group">
                    <a class="list-group-item active">
                        <h5>เลือกแบบฟอร์ม</h5>
                    </a>
                    <a href="./CPE01" class="list-group-item">
                        <h6>CPE01-แบบเสนอหัวข้อโครงงาน</h6>
                    </a>
                    <a href="./CPE02" class="list-group-item">
                        <h6>CPE02-แบบบันทึกการดำเนินงานโครงงาน</h6>
                    </a>
                    <a href="./CPE03" class="list-group-item">
                        <h6>CPE03-แบบขอสอบข้อเสนอโครงงาน</h6>
                    </a>
                    <a href="./CPE04" class="list-group-item">
                        <h6>CPE04-แบบประเมินข้อเสนอโครงงาน</h6>
                    </a>
                    <a href="./CPE05" class="list-group-item">
                        <h6>CPE05-แบบประเมินความก้าวหน้าโครงงาน</h6>
                    </a>
                    <a href="./CPE06" class="list-group-item">
                        <h6>CPE06-แบบขอสอบโครงงาน</h6>
                    </a>
                    <a href="./CPE07" class="list-group-item">
                        <h6>CPE07-แบบประเมินโครงงาน</h6>
                    </a>
                </div>
            </div>
        </div>

        <div class="col-lg-6">
<%--            <div class="col-md-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">สถานะโครงงาน</h3>
                    </div>
                    <div class="panel-body">
                        <p>
                            CPE01
                            <span class="label label-default">Default</span>
                        </p>
                        <p>
                            CPE02                              
                            <span class="label label-default">Default</span>
                        </p>
                        <p>
                            CPE03                            
                            <span class="label label-default">Default</span>
                        </p>
                        <p>
                            CPE04                            
                            <span class="label label-default">Default</span>
                        </p>
                        <p>
                            CPE05                            
                            <span class="label label-default">Default</span>
                        </p>
                        <p>
                            CPE06                            
                            <span class="label label-default">Default</span>
                        </p>
                        <p>
                            CPE07
                            <span class="label label-default">Default</span>
                        </p>
                    </div>
                </div>
            </div>--%>
        </div>
    </div>


    <%-------------------------------------------------------------------------------------------------------------------------------------------%>

    <div id="Div_Teacher" style="display: none;" runat="server">
        <div class="col-lg-9">
            <div class="panel panel-primary">
                <%--<div class="panel-body">--%>
                <div class="col-lg-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <span class="glyphicon glyphicon-user" aria-hidden="true"></span>
                            <label>คำขอทั้งหมด</label>
                        </div>
                        <div class="panel-body">
                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" ClientIDMode="Static">
                                <HeaderTemplate>
                                    <table class="table table-striped table-hover ">
                                        <tr>
                                            <th>
                                                <div class="buttonHolder">รหัสโครงงาน</div>
                                            </th>
                                            <th>
                                                <div class="buttonHolder">ชื่อโครงงาน</div>
                                            </th>
                                            <th>
                                                <div class="buttonHolder">ผู้ขอ</div>
                                            </th>
                                            <th>
                                                <div class="buttonHolder">ประเภทที่ขอ</div>
                                            </th>
                                            <th>
                                                <div class="buttonHolder">วันที่ขอ</div>
                                            </th>
                                            <th>
                                                <div class="buttonHolder">ดูรายละเอียด</div>
                                            </th>
                                            <th>
                                                <div class="buttonHolder">การดำเนินการ</div>
                                            </th>

                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <div class="buttonHolder">
                                                <asp:Literal ID="_ProjID" Text='<%#Eval("ProjID") %>' runat="server"></asp:Literal>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="buttonHolder">
                                                <asp:Literal ID="_ProjName_TH" Text='<%#Eval("ProjName_TH") %>' runat="server"></asp:Literal>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="buttonHolder">
                                                <asp:Literal ID="_Fname" Text='<%#Eval("Fname") %>' runat="server"></asp:Literal>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="buttonHolder">
                                                <asp:Literal ID="_Request" Text='<%#Eval("Request") %>' runat="server"></asp:Literal>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="buttonHolder">
                                                <asp:Literal ID="_Date" Text='<%#Eval("Date") %>' runat="server"></asp:Literal>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="buttonHolder">
                                                <asp:Button ID="btn_viewDetail" class="btn btn-primary btn-xs" runat="server" Text="คลิก" CommandName="viewDetail" /><%--data-toggle="modal"--%>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="buttonHolder">
                                                <asp:Button ID="btn_Approve" runat="server" class="btn btn-success btn-xs" Text="ตอบรับ" CommandName="approve" />
                                                <asp:Button ID="btn_reject" runat="server" class="btn btn-danger btn-xs" Text="ปฎิเสธ" CommandName="reject" />
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="Div1" style="display: block;" runat="server">
            <div class="col-lg-3">
                <div class="panel panel-primary">
                    <%--<div class="panel-body">--%>
                    <div class="col-lg-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <span class="glyphicon glyphicon-user" aria-hidden="true"></span>
                                <label>โครงงานที่ดูแล</label>
                            </div>
                            <div class="panel-body">
                                <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand" ClientIDMode="Static">
                                    <HeaderTemplate>
                                        <table class="table table-striped table-hover ">
                                            <tr>
                                                <th>
                                                    <div class="buttonHolder">รหัสโครงงาน</div>
                                                </th>
                                                <th>
                                                    <div class="buttonHolder">ชื่อโครงงาน</div>
                                                </th>
                                                <th>
                                                    <div class="buttonHolder">การดำเนินการ</div>
                                                </th>
                                            </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <div class="buttonHolder">
                                                    <asp:Literal ID="_ProjID" Text='<%#Eval("ProjID") %>' runat="server"></asp:Literal>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="buttonHolder">
                                                    <asp:Literal ID="_ProjName_TH" Text='<%#Eval("ProjName_TH") %>' runat="server"></asp:Literal>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="buttonHolder">
                                                    <asp:Button ID="btn_enter" runat="server" class="btn btn-success btn-xs" Text="ดูโครงงาน" CommandName="enter" />
                                                </div>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--</div>--%>

    <%-------------------------------------------------------------------------------------------------------------------------------------------%>

    <style>
        .buttonHolder {
            text-align: center;
        }
    </style>




    <%--    </div>--%>
</asp:Content>

