<%@ Page Title="ลงชื่อเข้าใช้" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <style>
        body {
            background-color: #fff;
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
    </style>
   <br />
    <div class="container-fluid">
        <div class="col-lg-3">
            <br />
        </div>
        <div class="col-lg-8">
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-3 control-label">รหัสประจำตัว</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="TextUser" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="inputPassword3" class="col-sm-3 control-label">รหัสผ่าน</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="TextPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <br />

                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-5">
                    <button id="test" onserverclick="btnChk_Click" runat="server" class="btn btn-primary" style="width: auto;">เข้าสู่ระบบ</button>
                </div>
            </div>
        </div>
    </div>

    <br />
</asp:Content>

