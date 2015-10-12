using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Default2 : System.Web.UI.Page
{
    string[] PersID = new string[3]; // ไม่แน่ใจว่า3 จะพังไหม
    string[] CommitteeName = new string[3]; // Faith
    string[] CommitteeID = new string[3]; //Faith
    string[] ProjDetail = new string[3];
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    Page.MaintainScrollPositionOnPostBack = true;
    //    if (Session["ID"] == null)
    //    {
    //        Response.Redirect("~/Account/Login");
    //    }
    //    else
    //    {
    //        /////////////// ฟังก์ชั่นที่ต้องทำหลังจาก login 
    //        string id = Session["ID"].ToString();
    //        string constr = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
    //        SqlConnection conn = new SqlConnection(constr);
    //        conn.Open();
    //        string chkProjID = "select ProjID from Relation where PersID = '" + id + "'";
    //        SqlCommand chkProjIDd = new SqlCommand(chkProjID, conn);
    //        SqlDataReader myInfo1 = chkProjIDd.ExecuteReader();
    //        myInfo1.Read();
    //        string tob = myInfo1.GetInt32(0).ToString();
    //        //TextBox1.Text = tob;
    //        myInfo1.Close();
    //        conn.Close();
    //        string info = "select Date ,Subject , Progress , Note from ProjectOperations where ProjID = '" + tob + "'";
    //        SqlCommand infoComm = new SqlCommand(info, conn);
    //        conn.Open();
    //        SqlDataReader myInfo2 = infoComm.ExecuteReader();
    //        TableHeaderRow headerRow1 = new TableHeaderRow();
    //        headerRow1.BackColor = Color.LightBlue;

    //        // Create TableCell objects to contain 
    //        // the text for the header.
    //        TableHeaderCell headerTableCell5 = new TableHeaderCell();
    //        TableHeaderCell headerTableCell6 = new TableHeaderCell();
    //        TableHeaderCell headerTableCell7 = new TableHeaderCell();
    //        TableHeaderCell headerTableCell8 = new TableHeaderCell();
    //        headerTableCell5.Text = "วันที่";
    //        headerTableCell5.Scope = TableHeaderScope.Column;
    //        headerTableCell5.AbbreviatedText = "Column 1 Header";
    //        headerTableCell6.Text = "ประเด็น/หัวข้อ/งานที่มอบหมาย";
    //        headerTableCell6.Scope = TableHeaderScope.Column;
    //        headerTableCell6.AbbreviatedText = "Column 2 Header";
    //        headerTableCell7.Text = "ข้อสรุป/ความคืบหน้าของงาน";
    //        headerTableCell7.Scope = TableHeaderScope.Column;
    //        headerTableCell7.AbbreviatedText = "Column 3 Header";
    //        headerTableCell8.Text = "หมายเหตุ";
    //        headerTableCell8.Scope = TableHeaderScope.Column;
    //        headerTableCell8.AbbreviatedText = "Column 4 Header";

    //        // Add the TableHeaderCell objects to the Cells
    //        // collection of the TableHeaderRow.
    //        headerRow1.Cells.Add(headerTableCell5);
    //        headerRow1.Cells.Add(headerTableCell6);
    //        headerRow1.Cells.Add(headerTableCell7);
    //        headerRow1.Cells.Add(headerTableCell8);

    //        Table1.Rows.AddAt(0, headerRow1);
    //        while(myInfo2.Read())
    //        {
    //            string Qdate = myInfo2.GetString(0);
    //            string Qsubject = myInfo2.GetString(1);
    //            string Qprogress = myInfo2.GetString(2);
    //            string Qnote = myInfo2.GetString(3);
    //            TextBox1.Text = "   รหัสโครงงาน" + tob;
               
           
    //            //menubar.Style.Add("display", "none");
    //            TableHeaderRow headerRow = new TableHeaderRow();
    //            //headerRow.BackColor = Color.LightBlue;

    //            // Create TableCell objects to contain 
    //            // the text for the header.
    //            TableHeaderCell headerTableCell1 = new TableHeaderCell();
    //            TableHeaderCell headerTableCell2 = new TableHeaderCell();
    //            TableHeaderCell headerTableCell3 = new TableHeaderCell();
    //            TableHeaderCell headerTableCell4 = new TableHeaderCell();
    //            headerTableCell1.Text = Qdate;
    //            headerTableCell1.Scope = TableHeaderScope.Column;
    //            headerTableCell1.AbbreviatedText = Qsubject;
    //            headerTableCell2.Text = Qsubject;
    //            headerTableCell2.Scope = TableHeaderScope.Column;
    //            headerTableCell2.AbbreviatedText = "Column 2 Header";
    //            headerTableCell3.Text = Qprogress;
    //            headerTableCell3.Scope = TableHeaderScope.Column;
    //            headerTableCell3.AbbreviatedText = "Column 3 Header";
    //            headerTableCell4.Text = Qnote;
    //            headerTableCell4.Scope = TableHeaderScope.Column;
    //            headerTableCell4.AbbreviatedText = "Column 4 Header";

    //            // Add the TableHeaderCell objects to the Cells
    //            // collection of the TableHeaderRow.
    //            headerRow.Cells.Add(headerTableCell1);
    //            headerRow.Cells.Add(headerTableCell2);
    //            headerRow.Cells.Add(headerTableCell3);
    //            headerRow.Cells.Add(headerTableCell4);

    //            Table1.Rows.AddAt(1, headerRow);


    //        }


    //        //myInfo2.Read();
    //        //string Qdate = myInfo2.GetDateTime(0).ToString();
    //        //string Qsubject = myInfo2.GetString(1);
    //        //string Qprogress = myInfo2.GetString(2);
    //        //string Qnote = myInfo2.GetString(3);
    //        myInfo2.Close();
    //        conn.Close();
    //        //Startshow();



            
            
    //    }

    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        string constr = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        Page.MaintainScrollPositionOnPostBack = true;
        SqlConnection conn = new SqlConnection(constr);
        if (Session["ID"] != null)
        {
            string id = Session["ID"].ToString();
            if (youAreStudent(id, conn)) // นิสิต
            {
                if (haveProject(id, conn)) // มีโปรเจคแล้ว
                {
                    string ProjID = GetProjID(id, conn);

                    if (ApprovedCPE01(ProjID, conn)) //TOP -> ผ่าน 01?
                    {
                        /////////////// ฟังก์ชั่นที่ต้องทำหลังจาก login 
                        //string id = Session["ID"].ToString();
                        //string constr = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                        //SqlConnection conn = new SqlConnection(constr);
                        conn.Open();
                        string chkProjID = "select ProjID from Relation where PersID = '" + id + "'";
                        SqlCommand chkProjIDd = new SqlCommand(chkProjID, conn);
                        SqlDataReader myInfo1 = chkProjIDd.ExecuteReader();
                        myInfo1.Read();
                        string tob = myInfo1.GetInt32(0).ToString();
                        //TextBox1.Text = tob;
                        myInfo1.Close();
                        conn.Close();
                        string info = "select Date ,Subject , Progress , Note from ProjectOperations where ProjID = '" + tob + "'";
                        SqlCommand infoComm = new SqlCommand(info, conn);
                        conn.Open();
                        SqlDataReader myInfo2 = infoComm.ExecuteReader();
                        TableHeaderRow headerRow1 = new TableHeaderRow();
                        headerRow1.BackColor = Color.LightBlue;

                        // Create TableCell objects to contain 
                        // the text for the header.
                        TableHeaderCell headerTableCell5 = new TableHeaderCell();
                        TableHeaderCell headerTableCell6 = new TableHeaderCell();
                        TableHeaderCell headerTableCell7 = new TableHeaderCell();
                        TableHeaderCell headerTableCell8 = new TableHeaderCell();
                        headerTableCell5.Text = "วันที่";
                        headerTableCell5.Scope = TableHeaderScope.Column;
                        headerTableCell5.AbbreviatedText = "Column 1 Header";
                        headerTableCell6.Text = "ประเด็น/หัวข้อ/งานที่มอบหมาย";
                        headerTableCell6.Scope = TableHeaderScope.Column;
                        headerTableCell6.AbbreviatedText = "Column 2 Header";
                        headerTableCell7.Text = "ข้อสรุป/ความคืบหน้าของงาน";
                        headerTableCell7.Scope = TableHeaderScope.Column;
                        headerTableCell7.AbbreviatedText = "Column 3 Header";
                        headerTableCell8.Text = "หมายเหตุ";
                        headerTableCell8.Scope = TableHeaderScope.Column;
                        headerTableCell8.AbbreviatedText = "Column 4 Header";

                        // Add the TableHeaderCell objects to the Cells
                        // collection of the TableHeaderRow.
                        headerRow1.Cells.Add(headerTableCell5);
                        headerRow1.Cells.Add(headerTableCell6);
                        headerRow1.Cells.Add(headerTableCell7);
                        headerRow1.Cells.Add(headerTableCell8);

                        Table1.Rows.AddAt(0, headerRow1);
                        TextBox1.Text = "   รหัสโครงงาน" + tob;
                        while (myInfo2.Read())
                        {
                            string Qdate = myInfo2.GetString(0);
                            string Qsubject = myInfo2.GetString(1);
                            string Qprogress = myInfo2.GetString(2);
                            string Qnote = myInfo2.GetString(3);
                            


                            //menubar.Style.Add("display", "none");
                            TableHeaderRow headerRow = new TableHeaderRow();
                            //headerRow.BackColor = Color.LightBlue;

                            // Create TableCell objects to contain 
                            // the text for the header.
                            TableHeaderCell headerTableCell1 = new TableHeaderCell();
                            TableHeaderCell headerTableCell2 = new TableHeaderCell();
                            TableHeaderCell headerTableCell3 = new TableHeaderCell();
                            TableHeaderCell headerTableCell4 = new TableHeaderCell();
                            headerTableCell1.Text = Qdate;
                            headerTableCell1.Scope = TableHeaderScope.Column;
                            headerTableCell1.AbbreviatedText = Qsubject;
                            headerTableCell2.Text = Qsubject;
                            headerTableCell2.Scope = TableHeaderScope.Column;
                            headerTableCell2.AbbreviatedText = "Column 2 Header";
                            headerTableCell3.Text = Qprogress;
                            headerTableCell3.Scope = TableHeaderScope.Column;
                            headerTableCell3.AbbreviatedText = "Column 3 Header";
                            headerTableCell4.Text = Qnote;
                            headerTableCell4.Scope = TableHeaderScope.Column;
                            headerTableCell4.AbbreviatedText = "Column 4 Header";

                            // Add the TableHeaderCell objects to the Cells
                            // collection of the TableHeaderRow.
                            headerRow.Cells.Add(headerTableCell1);
                            headerRow.Cells.Add(headerTableCell2);
                            headerRow.Cells.Add(headerTableCell3);
                            headerRow.Cells.Add(headerTableCell4);

                            Table1.Rows.AddAt(1, headerRow);

                        }


                        //myInfo2.Read();
                        //string Qdate = myInfo2.GetDateTime(0).ToString();
                        //string Qsubject = myInfo2.GetString(1);
                        //string Qprogress = myInfo2.GetString(2);
                        //string Qnote = myInfo2.GetString(3);
                        myInfo2.Close();
                        conn.Close();
                        //Startshow();
                    }

                    else
                    {
                        Response.Redirect("~/Form/CPE01");
                    }
                }
                else
                {
                    //MessageBox.Show("ยังไม่มีโครงงาน")
                    Response.Redirect("~/Form/CPE01");

                }
            }
            else//อาจารย์
            {
                string JectID = Session["id_form"].ToString();
                
                string info = "select Date ,Subject , Progress , Note from ProjectOperations where ProjID = '" + JectID + "'";
                SqlCommand infoComm = new SqlCommand(info, conn);
                conn.Open();
                SqlDataReader myInfo2 = infoComm.ExecuteReader();
                TableHeaderRow headerRow1 = new TableHeaderRow();
                headerRow1.BackColor = Color.LightBlue;

                // Create TableCell objects to contain 
                // the text for the header.
                TableHeaderCell headerTableCell5 = new TableHeaderCell();
                TableHeaderCell headerTableCell6 = new TableHeaderCell();
                TableHeaderCell headerTableCell7 = new TableHeaderCell();
                TableHeaderCell headerTableCell8 = new TableHeaderCell();
                headerTableCell5.Text = "วันที่";
                headerTableCell5.Scope = TableHeaderScope.Column;
                headerTableCell5.AbbreviatedText = "Column 1 Header";
                headerTableCell6.Text = "ประเด็น/หัวข้อ/งานที่มอบหมาย";
                headerTableCell6.Scope = TableHeaderScope.Column;
                headerTableCell6.AbbreviatedText = "Column 2 Header";
                headerTableCell7.Text = "ข้อสรุป/ความคืบหน้าของงาน";
                headerTableCell7.Scope = TableHeaderScope.Column;
                headerTableCell7.AbbreviatedText = "Column 3 Header";
                headerTableCell8.Text = "หมายเหตุ";
                headerTableCell8.Scope = TableHeaderScope.Column;
                headerTableCell8.AbbreviatedText = "Column 4 Header";

                // Add the TableHeaderCell objects to the Cells
                // collection of the TableHeaderRow.
                headerRow1.Cells.Add(headerTableCell5);
                headerRow1.Cells.Add(headerTableCell6);
                headerRow1.Cells.Add(headerTableCell7);
                headerRow1.Cells.Add(headerTableCell8);

                Table1.Rows.AddAt(0, headerRow1);
                TextBox1.Text = "   รหัสโครงงาน" + JectID;
                while (myInfo2.Read())
                {
                    string Qdate = myInfo2.GetString(0);
                    string Qsubject = myInfo2.GetString(1);
                    string Qprogress = myInfo2.GetString(2);
                    string Qnote = myInfo2.GetString(3);
                    


                    //menubar.Style.Add("display", "none");
                    TableHeaderRow headerRow = new TableHeaderRow();
                    //headerRow.BackColor = Color.LightBlue;

                    // Create TableCell objects to contain 
                    // the text for the header.
                    TableHeaderCell headerTableCell1 = new TableHeaderCell();
                    TableHeaderCell headerTableCell2 = new TableHeaderCell();
                    TableHeaderCell headerTableCell3 = new TableHeaderCell();
                    TableHeaderCell headerTableCell4 = new TableHeaderCell();
                    headerTableCell1.Text = Qdate;
                    headerTableCell1.Scope = TableHeaderScope.Column;
                    headerTableCell1.AbbreviatedText = Qsubject;
                    headerTableCell2.Text = Qsubject;
                    headerTableCell2.Scope = TableHeaderScope.Column;
                    headerTableCell2.AbbreviatedText = "Column 2 Header";
                    headerTableCell3.Text = Qprogress;
                    headerTableCell3.Scope = TableHeaderScope.Column;
                    headerTableCell3.AbbreviatedText = "Column 3 Header";
                    headerTableCell4.Text = Qnote;
                    headerTableCell4.Scope = TableHeaderScope.Column;
                    headerTableCell4.AbbreviatedText = "Column 4 Header";

                    // Add the TableHeaderCell objects to the Cells
                    // collection of the TableHeaderRow.
                    headerRow.Cells.Add(headerTableCell1);
                    headerRow.Cells.Add(headerTableCell2);
                    headerRow.Cells.Add(headerTableCell3);
                    headerRow.Cells.Add(headerTableCell4);

                    Table1.Rows.AddAt(1, headerRow);


                }


                //myInfo2.Read();
                //string Qdate = myInfo2.GetDateTime(0).ToString();
                //string Qsubject = myInfo2.GetString(1);
                //string Qprogress = myInfo2.GetString(2);
                //string Qnote = myInfo2.GetString(3);
                myInfo2.Close();
                conn.Close();
                Startshow(JectID,conn);

                
                //GetProjDetail(ProjID, conn);
                //FindPersID(JectID, conn);
                //ShowProjInfo();
                //ShowPersInfo(id,ProjDetail[2], conn);
               // checkDisplay(ProjDetail[2]);

                /////////////////////////////////////

                // Faith
                //FindShowStatusCommittee(conn);
                //GetCommitteeID(conn);
                //CheckWaitCommittee(conn);
               // CheckApproveCommittee(conn);
                // End Faith

                setScop(JectID, conn);
            }
        }
        else
        {
            Response.Redirect("~/Account/Login");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Form");
    }

    protected bool youAreStudent(string id, SqlConnection conn)
    {
        conn.Open();
        String Checkuser = "select count(*) from Person where PersID ='" + id + "'AND TypeOfPers = '" + 0 + "'";
        SqlCommand com = new SqlCommand(Checkuser, conn);
        int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
        conn.Close();
        if (temp == 1)//มีข้อมูลในดาต้าเบสแล้ว 
            return true;
        else
            return false;
    }

    protected bool haveProject(string id, SqlConnection conn)
    {
        conn.Open();
        String Checkuser = "select count(*) from Relation where PersID ='" + id + "'";
        SqlCommand com = new SqlCommand(Checkuser, conn);
        int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
        conn.Close();
        if (temp == 1)//มีข้อมูลในดาต้าเบสแล้ว 
            return true;
        else
            return false;
    }
    protected string GetProjID(string id, SqlConnection conn)
    {
        string findProjID = "select ProjID from Relation where PersID = '" + id + "'";
        conn.Open();
        SqlCommand findProjIDComm = new SqlCommand(findProjID, conn);
        SqlDataReader myProjID = findProjIDComm.ExecuteReader();
        myProjID.Read();
        string ProjID = myProjID.GetInt32(0).ToString();
        myProjID.Close();
        conn.Close();
        return ProjID;
    }
    protected bool ApprovedCPE01(string ProjID, SqlConnection conn)
    {
        string Checkuser = "select count(*) from project where ProjID ='" + ProjID + "'AND Status_ID = '" + "2" + "'";
        conn.Open();
        SqlCommand com = new SqlCommand(Checkuser, conn);
        int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
        conn.Close();

        if (temp == 1)
            return true;
        else
            return false;
    }
    protected void Startshow(string JectID, SqlConnection conn)
    {
        //DateTime time = DateTime.Now;
        //string time_finished = String.Format("{0:dd-MM-yyyy HH:mm:ss}", time);
        //TextBox5.Text = time_finished;

        string info = "select ProjID ,ProjName_TH , ProjName_ENG from project where ProjID = '" + JectID + "'";
        SqlCommand infoComm = new SqlCommand(info, conn);
        conn.Open();
        SqlDataReader myInfo3 = infoComm.ExecuteReader();
        myInfo3.Read();
        //TextBox1.Text = myInfo3.GetInt32(0).ToString(); // รหัสโครงงาน
        TextBox2.Text = "ชื่อภาษาไทย " + myInfo3.GetString(1); // ชื่อโครงงานภาษาไทย
        TextBox3.Text = "ชื่อภาษาอังกฤษ " + myInfo3.GetString(2); // ชื่อโครงงานภาษาอังกฤษ
        myInfo3.Close();
        conn.Close();

    }
   

    protected void setScop(string JectID, SqlConnection conn)
    {
        string Scope = "select Scope from project where ProjID = '" + JectID + "'";
        conn.Open();
        SqlCommand findScope = new SqlCommand(Scope, conn);
        SqlDataReader Scope_ = findScope.ExecuteReader();
        Scope_.Read();
        try
        {
            string myScope = Scope_.GetString(0);
            Scope_.Close();
            TextBox4.Text = myScope;
        }
        catch
        {

        }
        conn.Close();
    }

    

}