<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /*body {
            background: #EAEAEA url(http://www.iphone-droid.net/wp-content/themes/2557/images/bg.png) repeat;
            background-attachment: fixed;
            margin: 0 auto;
            padding: 0;
        }*/

        .body {
            background-color: #ff0000;
        }

        #footer{
            background-color: #ffffff;
            bottom:0;
            height:100px;
            position:relative;
            width:100%;
        }
        /*.container-fluid .jumbotron {
            padding-left: 30px;
            padding-right: 30px;
        }*/
    </style>

    <%--///////////////////////////////////////////// START //////////////////////////////////////////////////////--%>
    <div class="container">
        <div class="row clearfix">
            <div class="col-md-12 column">
                <img alt="" src="/img/1.png" width="1100" height="200" />
            </div>
        </div>
        <h3 class="text-primary">ข่าวสารใหม่
        </h3>

        <%--///////////////////////////////////////////////////////////////////////////////////////////--%>

        <div class="col-md-12 column">
			<div class="row">
				<div class="col-md-4">
					<div class="thumbnail">
                        <a href="./News1"><img alt="300x200" src="http://www.nstda.or.th/ystp/images/YSTP58.gif" /></a>
						<div class="caption">
							<a href="./News1">เปิดสมัครเพื่อขอรับทุนสนับสนุนการวิจัยปริญญานิพนธ์ (Senior Project) ปีการศึกษา 2558</a>
                            <h6 class="text-warning text-right">
				                (April 1,2015)
			                </h6>
						</div>
					</div>
				</div>
				<div class="col-md-4">
					<div class="thumbnail">
						<a href="./News1"><img alt="300x200" src="http://www.nstda.or.th/ystp/images/YSTP58.gif" /></a>
						<div class="caption">
							<a href="./News1">เปิดสมัครเพื่อขอรับทุนสนับสนุนการวิจัยปริญญานิพนธ์ (Senior Project) ปีการศึกษา 2558</a>
                            <h6 class="text-warning text-right">
				                (April 1,2015)
			                </h6>
						</div>
					</div>
				</div>
				<div class="col-md-4">
					<div class="thumbnail">
						<a href="./News1"><img alt="300x200" src="http://www.nstda.or.th/ystp/images/YSTP58.gif" /></a>
						<div class="caption">
							<a href="./News1">เปิดสมัครเพื่อขอรับทุนสนับสนุนการวิจัยปริญญานิพนธ์ (Senior Project) ปีการศึกษา 2558</a>
                            <h6 class="text-warning text-right">
				                (April 1,2015)
			                </h6>
						</div>
					</div>
				</div>
			</div>
            <a class="btn btn-primary" href="/DetailTotal">ดูรายละเอียดทั้งหมด >></a>
		</div>
        <%--///////////////////////////////////////////////////////////////////////////////////////////--%>

        <%--<a class="btn btn-link" href="#">ดูรายละเอียดทั้งหมด >></a>--%>

    </div>
    </br></br>
            <div id="footer" class="navbar-default">
                 <div class="container"><br>
                     <h6><p class="text-center"> Copyright © 2015 Tuxedo พัฒนาเว็บไซต์ขึ้นในรายวิชา  305351 วิศวกรรมระบบคอมพิวเตอร์ Computer System Engineering </p></h6>
                  <h6><p class="text-center"> Copyright © 2015 IRON พัฒนาเว็บไซต์ต่อในรายวิชา         305471 วิศวกรรมซอร์ฟแวร์ Software Engineering  </p></h6>
                 </div>
            </div>
    <%--///////////////////////////////////////////// STOP //////////////////////////////////////////////////////--%>

</asp:Content>
