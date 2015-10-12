<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CPE04.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="container body-content">


        <div class="container">
            <div class="col-xs-12">
                <div class="row">
                    <div class="col-xs-12">
                        <h4 class="text-center">แบบประเมินข้อเสนอโครงงานวิศวกรรมคอมพิวเตอร์ ปีการศึกษา 2557 </h4>
                        <h4 class="text-center">ภาควิชาวิศวกรรมไฟฟ้าและคอมพิวเตอร์ คณะวิศวกรรมศาสตร์ มหาวิทยาลัยนเรศวร</h4>
                        <p class="text-center"></p>
                    </div>
                </div>
            </div>
        </div>
        <table class="table table-striped">
            <span class="glyphicon glyphicon-font"></span>
            <label>รหัสโครงาน</label>

            <br />
            <span class="glyphicon glyphicon glyphicon-file" aria-hidden="true"></span>
            <label>ชื่อโครงการ(ไทย)</label>
            <br />
            <span class="glyphicon glyphicon glyphicon-file" aria-hidden="true"></span>
            <label>ชื่อโครงการ(อังกฤษ)</label>
            <hr />


            <div class="col-xs-12">
                <span class="glyphicon glyphicon-user" aria-hidden="true"></span>
                <label>รายชื่อนิสิตผู้ทำโครงงาน </label>
            </div>
            <hr />
            <div class="row ">
                <div class="col-lg-2">
                    <label>ลับดับที่</label>

                </div>
                <div class="col-lg-4">
                    <label>ชื่อ-นามสกุล</label>

                </div>
                <div class="col-lg-3">
                    <label>รหัสนิสิต</label>

                </div>

            </div>
            <br />
        </table>

        <span class="glyphicon glyphicon-tasks"></span>
        <label>ผลการประเมิน</label>
        <table class="table table-striped">
            <thead>
                <tr>
                    <th>#</th>
                    <th>หัวข้อการประเมิน</th>
                    <th>เหมาะสม</th>
                    <th>ไม่เหมาะสม</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>1</td>
                    <td>จํานวนนิสิตที่ทําโครงงาน</td>
                    <td>
                        <div class="radio">
                            <label>
                                <input type="radio" name="optionsRadios" id="optionsRadios1" value="option1">
                                เหมาะสม
                            </label>
                        </div>
                    </td>
                    <td>
                        <div class="radio">
                            <label>
                                <input type="radio" name="optionsRadios" id="optionsRadios2" value="option2">
                                ไม่เหมาะสม
                            </label>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td>2</td>
                    <td>ที่มาและความสําคัญของปัญหา</td>
                    <td>
                        <div class="radio">
                            <label>
                                <input type="radio" name="optionsRadios1" id="optionsRadios1" value="option1">
                                เหมาะสม
                            </label>
                        </div>
                    </td>
                    <td>
                        <div class="radio">
                            <label>
                                <input type="radio" name="optionsRadios1" id="optionsRadios2" value="option2">
                                ไม่เหมาะสม
                            </label>
                        </div>

                    </td>
                </tr>
                </tr >
    <%--  หัวข้อที่3--%>
                <td>3</td>

                <td>วัตถุประสงค์ของโครงงาน</td>
                <td>
                    <div class="radio">
                        <label>
                            <input type="radio" name="optionsRadios2" id="optionsRadios1" value="option1">
                            เหมาะสม
                        </label>
                    </div>
                </td>
                <td>
                    <div class="radio">
                        <label>
                            <input type="radio" name="optionsRadios2" id="optionsRadios2" value="option2">
                            ไม่เหมาะสม
                        </label>
                    </div>
                    </tr>
    </tr >
      <td>4</td>
                <td>การศึกษาเกี่ยวกับหลักการและทฤษฎีที่เกี่ยวข้อง</td>
                <td>
                    <div class="radio">
                        <label>
                            <input type="radio" name="optionsRadios3" id="optionsRadios1" value="option1">
                            เหมาะสม
                        </label>
                    </div>
                </td>
                <td>
                    <div class="radio">
                        <label>
                            <input type="radio" name="optionsRadios3" id="optionsRadios2" value="option2">
                            ไม่เหมาะสม
                        </label>
                    </div>
                    </tr>
    </tr >
      <td>5</td>
                <td>ความเหมาะสมของวิธีการดําเนินงานที่นําเสนอ</td>
                <td>
                    <div class="radio">
                        <label>
                            <input type="radio" name="optionsRadios4" id="optionsRadios1" value="option1">
                            เหมาะสม
                        </label>
                    </div>
                </td>
                <td>
                    <div class="radio">
                        <label>
                            <input type="radio" name="optionsRadios4" id="optionsRadios2" value="option2">
                            ไม่เหมาะสม
                        </label>
                    </div>
                    <tr>
                    </tr>
                <td>6</td>
                <td>ขอบเขตของโครงงาน</td>
                <td>
                    <div class="radio">
                        <label>
                            <input type="radio" name="optionsRadios5" id="optionsRadios1" value="option1">
                            เหมาะสม
                        </label>
                    </div>
                </td>
                <td>
                    <div class="radio">
                        <label>
                            <input type="radio" name="optionsRadios5" id="optionsRadios2" value="option2">
                            ไม่เหมาะสม
                        </label>
                    </div>
                    <tr>
            </tbody>
        </table>

        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
        <label>ข้อเสนอแนะ</label>
        <input type="text" class="form-control" id="exampleInputName3" placeholder="Type">
        <br />
    </div>

</asp:Content>

