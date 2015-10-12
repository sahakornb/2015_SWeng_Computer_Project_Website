<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="form_.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <style>
        body {
            background-color: #ffffff;
        }
    </style>
    <style>
        .block {
            background: white;
            padding: 8px;
            border-radius: 8px;
            border: 1px solid #E1E1E1;
            margin-bottom: 10px;
            width: 50%;
        }

        .list-group-item {
        padding: 7px;

        }

        .btn-goo:hover {
            -webkit-background-size: 100% 100%;
            background-size: 100%;
            border-color: #fff;
        }
    </style>
    <div class="container body-content">

        <div class="col-lg-6">
            <br />
            <div class="list-group">
                <%--  --%>
                <a href="./docs/cpe01.doc" class="list-group-item">
                    <h4 class="list-group-item-heading">CPE01</h4>
                    <p class="list-group-item-text">
                        แบบเสนอหัวข้อโครงงานวิศวกรรมคอมพิวเตอร์
                    </p>
                </a>
                <%--  --%>
                <a href="./docs/cpe02.doc" class="list-group-item">
                    <h4 class="list-group-item-heading">CPE02</h4>
                    <p class="list-group-item-text">
                        แบบบันทึกการดำเนินงานโครงงานวิศวกรรมคอมพิวเตอร์
                    </p>
                </a>
                <%--  --%>
                <a href="./docs/cpe03.doc" class="list-group-item">
                    <h4 class="list-group-item-heading">CPE03</h4>
                    <p class="list-group-item-text">
                        แบบขอสอบข้อเสนอโครงงานวิศวกรรมคอมพิวเตอร์
                    </p>
                </a>
                <%--  --%>
                <a href="./docs/cpe04.doc" class="list-group-item">
                    <h4 class="list-group-item-heading">CPE04</h4>
                    <p class="list-group-item-text">
                        แบบประเมินข้อเสนอโครงงานวิศวกรรมคอมพิวเตอร์
                    </p>
                </a>
                <%--  --%>
                 <a href="./docs/cpe05.doc" class="list-group-item">
                    <h4 class="list-group-item-heading">CPE05</h4>
                    <p class="list-group-item-text">
                        แบบประเมินความก้าวหน้าโครงงานวิศวกรรมคอมพิวเตอร์
                    </p>
                </a>
                <%--  --%>
                 <a href="./docs/cpe06.doc" class="list-group-item">
                    <h4 class="list-group-item-heading">CPE06</h4>
                    <p class="list-group-item-text">
                        แบบขอสอบโครงงานวิศวกรรมคอมพิวเตอร์
                    </p>
                </a>
                <%--  --%>
                 <a href="./docs/cpe07.doc" class="list-group-item">
                    <h4 class="list-group-item-heading">CPE07</h4>
                    <p class="list-group-item-text">
                        แบบขอสอบโครงงานวิศวกรรมคอมพิวเตอร์ 
                    </p>
                </a>
                <%--  --%>
            </div>

        </div>
        <div class="col-lg-6">
            <br />
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-3 control-label">รหัสประจำตัว</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextUser" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="inputPassword3" class="col-sm-3 control-label">รหัสผ่าน</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="TextPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <br />

                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-3 col-sm-9">
                    <button id="test" onserverclick="ButtonLogin_Click" runat="server" class="btn btn-primary" style="width: auto;">เข้าสู่ระบบ</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

