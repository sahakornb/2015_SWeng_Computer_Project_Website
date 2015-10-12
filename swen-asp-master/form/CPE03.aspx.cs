using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Default2 : System.Web.UI.Page
{
    string constr = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
    string[] ProjDetail = new string[3];
    string[] PersID = new string[3]; // ไม่แน่ใจว่า3 จะพังไหม
    string[] CommitteeName = new string[3]; // Faith
    string[] CommitteeID = new string[3]; //Faith


    protected void Page_Load(object sender, EventArgs e)
    {
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
                        text_ProjID.Text = ProjID;
                        GetProjDetail(ProjID, conn);
                        FindPersID(ProjID, conn);
                        ShowProjInfo();
                        ShowPersInfo(ProjDetail[2], conn);
                        checkDisplay(ProjDetail[2]);

                        /////////////////////////////////////

                        // Faith
                        FindShowStatusCommittee(conn);
                        //GetCommitteeID(conn);
                        CheckWaitCommittee(conn);
                        CheckApproveCommittee(conn);
                        // End Faith

                        setScop(ProjID, conn);

                        ////////////////////////////////////
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
                Response.Redirect("~/Form");
            }
        }
        else
        {
            Response.Redirect("~/Account/Login");
        }
    }
    protected void setScop(string ProjID, SqlConnection conn)
    {
        string Scope = "select Scope from project where ProjID = '" + ProjID + "'";
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


    protected void GetProjDetail(string ProjiD, SqlConnection conn)
    {
        conn.Open();
        string findProjectInfo = "select ProjName_TH,ProjName_ENG,Member from project where ProjID ='" + ProjiD + "'";
        SqlCommand ProjectInfoComm = new SqlCommand(findProjectInfo, conn);
        SqlDataReader myProjectInfo = ProjectInfoComm.ExecuteReader();
        myProjectInfo.Read();
        ProjDetail[0] = myProjectInfo.GetString(0);
        ProjDetail[1] = myProjectInfo.GetString(1);
        ProjDetail[2] = myProjectInfo.GetInt32(2).ToString();
        myProjectInfo.Close();
        conn.Close();
    }

    protected void FindPersID(string ProjID, SqlConnection conn)
    {
        conn.Open();
        string findPersID = "select PersID from Relation where ProjID = '" + ProjID + "'AND Status_ID = '" + 0 + "'";
        SqlCommand findPersIDComm = new SqlCommand(findPersID, conn);
        SqlDataReader myPersID = findPersIDComm.ExecuteReader();
        int i = 0;
        while (myPersID.Read())
        {
            PersID[i] = myPersID.GetString(0);
            i++;
        }
        myPersID.Close();
        conn.Close();
    }

    protected void ShowPersInfo(string member, SqlConnection conn)
    {
        int Member = Convert.ToInt16(member);
        Swap();
        if (Member == 1)
        {
            MemberIsOne(conn);
        }
        else if (Member == 2)
        {
            MemberIsOne(conn);
            MemberIsTwo(conn);
        }
        else
        {
            MemberIsOne(conn);
            MemberIsTwo(conn);
            MemberIsThree(conn);
        }
    }

    protected void Swap()
    {
        string temp;
        if (PersID[1] == Session["ID"].ToString())
        {
            //อยู่ลำดับที่2
            temp = PersID[1];
            PersID[1] = PersID[0];
            PersID[0] = temp;
        }
        else if (PersID[2] == Session["ID"].ToString())
        {
            // อยู่ดับดับที่3
            temp = PersID[2];
            PersID[2] = PersID[0];
            PersID[0] = temp;
        }
    }

    protected void MemberIsOne(SqlConnection conn)
    {
        conn.Open();
        string Pers1 = "select title ,fname , lname , phone , email from person where PersID = '" + PersID[0] + "'";
        SqlCommand Pers1Comm = new SqlCommand(Pers1, conn);
        SqlDataReader myPers1 = Pers1Comm.ExecuteReader();
        myPers1.Read();
        text_id.Text = PersID[0];
        text_name.Text = myPers1.GetString(0) + myPers1.GetString(1) + " " + myPers1.GetString(2);
        text_tel.Text = myPers1.GetString(3);
        text_email.Text = myPers1.GetString(4);
        myPers1.Close();
        conn.Close();
    }
    protected void MemberIsTwo(SqlConnection conn)
    {
        conn.Open();
        string Pers2 = "select title ,fname , lname , phone , email from person where PersID = '" + PersID[1] + "'";
        SqlCommand Pers2Comm = new SqlCommand(Pers2, conn);
        SqlDataReader myPers2 = Pers2Comm.ExecuteReader();
        myPers2.Read();
        text_id2.Text = PersID[1];
        text_name2.Text = myPers2.GetString(0) + myPers2.GetString(1) + " " + myPers2.GetString(2); //order title fname lname
        text_tel2.Text = myPers2.GetString(3); // tel
        text_email2.Text = myPers2.GetString(4); // email
        myPers2.Close();
        conn.Close();
    }
    protected void MemberIsThree(SqlConnection conn)
    {
        conn.Open();
        string Pers3 = "select title ,fname , lname , phone , email from person where PersID = '" + PersID[2] + "'";
        SqlCommand Pers3Comm = new SqlCommand(Pers3, conn);
        SqlDataReader myPers3 = Pers3Comm.ExecuteReader();
        myPers3.Read();
        text_id3.Text = PersID[2];
        text_name3.Text = myPers3.GetString(0) + myPers3.GetString(1) + " " + myPers3.GetString(2); //order title fname lname
        text_tel3.Text = myPers3.GetString(3); // tel
        text_email3.Text = myPers3.GetString(4); // email
        myPers3.Close();
        conn.Close();
    }
    protected void checkDisplay(string member)
    {
        if (member == "2")
        {
            my_own_textbox1.Style.Add("display", "block");
            my_own_textbox2.Style.Add("display", "none");

        }
        else if (member == "3")
        {
            my_own_textbox1.Style.Add("display", "block");
            my_own_textbox2.Style.Add("display", "block");
        }
        else //1 
        {

            my_own_textbox1.Style.Add("display", "none");
            my_own_textbox2.Style.Add("display", "none");
        }

    }
    protected void ShowProjInfo()
    {
        if (!IsPostBack)
        {
            text_th.Text = ProjDetail[0];
            text_en.Text = ProjDetail[1];
        }
    }

    protected void ButtonSave_Click(object sender, EventArgs e)
    {

        if (TextBox4.Text != "")
        {
            string id = Session["ID"].ToString();
            DateTime time = DateTime.Now;
            string time_finished = String.Format("{0:dd-MM-yyyy HH:mm:ss}", time);
            string constr = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            string findProjID = "select ProjID from Relation where PersID = '" + id + "'";

            SqlCommand findProjIDComm = new SqlCommand(findProjID, conn);
            SqlDataReader myProjID = findProjIDComm.ExecuteReader();
            myProjID.Read();
            string ProjID = myProjID.GetInt32(0).ToString();
            myProjID.Close();

            //string sql = "INSERT INTO project (Scope,Date) VALUES ('" + TextBox4.Text + "','" + TextBox1.Text + "')";
            string sql = "UPDATE project SET Scope='" + TextBox4.Text + "', Date='" + time_finished + "' WHERE ProjID='" + ProjID + "'";

            SqlCommand com = new SqlCommand(sql, conn);
            com.ExecuteNonQuery();
            conn.Close();
        }
        else
        {
            MessageBox.Show("กรุณากรอก \"ประเด็นปัญหาและขอบเขตของโครงงานโดยย่อ\" ครับ");
        }
    }
    protected void request(string ProjID, string ApplicantID, string AcceptanceID, string requestID, SqlConnection conn)
    {
        DateTime time = DateTime.Now;
        string time_forsave = String.Format("{0:dd-MM-yyyy HH:mm:ss}", time);
        conn.Open();
        string Request = "INSERT INTO Request_Title(ReqID,ProjID,ApplicantID,AcceptanceID,Date) VALUES('" + requestID + "','" + ProjID + "','" + ApplicantID + "','" + AcceptanceID + "','" + time_forsave + "')";
        SqlCommand com = new SqlCommand(Request, conn);
        com.ExecuteScalar();
        conn.Close();
    }
    protected void ButtonSend_Click(object sender, EventArgs e)
    {
        string id = Session["ID"].ToString();
        string constr = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(constr);
        if (TextBox4.Text != "")
        {
            BTN_success1.CssClass = "btn btn-warning disabled";
            BTN_success1.Text = "รอคณะกรรมการเซ็น";
            BTN_success1.Visible = true;
            BTN_success2.CssClass = "btn btn-warning disabled";
            BTN_success2.Text = "รอคณะกรรมการเซ็น";
            BTN_success2.Visible = true;
            BTN_success3.CssClass = "btn btn-warning disabled";
            BTN_success3.Text = "รอคณะกรรมการเซ็น";
            BTN_success3.Visible = true;
            ButtonSave.Visible = false;
            ButtonSend.Visible = false;

            request(GetProjID(id, conn), id, CommitteeID[0], "2", conn);
            request(GetProjID(id, conn), id, CommitteeID[1], "2", conn);
            request(GetProjID(id, conn), id, CommitteeID[2], "2", conn);
            pushStatusInDB();
        }
        else
        {
            MessageBox.Show("กรุณากรอก \"ประเด็นปัญหาและขอบเขตของโครงงานโดยย่อ\" ครับ");
        }

    }

    protected void pushStatusInDB()
    {
        string sql;
        string constr = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(constr);
        conn.Open();

        // กรรมการคนที่1 รอเซ็นลายเซ็น
        //Test MessageBox.Show("project ID="+ text_ProjID.Text+" "+"Commitee ="+CommitteeID[0]); //Test
        sql = "UPDATE Relation SET Status_ID='" + 9 + "' WHERE ProjID='" + text_ProjID.Text + "' AND PersID='" + CommitteeID[0] + "'";
        SqlCommand com = new SqlCommand(sql, conn);
        com.ExecuteNonQuery();

        // กรรมการคนที่2 รอเซ็นลายเซ็น
        sql = "UPDATE Relation SET Status_ID='" + 10 + "' WHERE ProjID='" + text_ProjID.Text + "' AND PersID='" + CommitteeID[1] + "'";
        SqlCommand com2 = new SqlCommand(sql, conn);
        com2.ExecuteNonQuery();

        // กรรมการคนที่3 รอเซ็นลายเซ็น
        sql = "UPDATE Relation SET Status_ID='" + 11 + "' WHERE ProjID='" + text_ProjID.Text + "' AND PersID='" + CommitteeID[2] + "'";
        SqlCommand com3 = new SqlCommand(sql, conn);
        com3.ExecuteNonQuery();
        conn.Close();
    }

    protected void FindShowStatusCommittee(SqlConnection conn)
    {
        conn.Open();
        string findPersID = "select Title,Fname,Lname,PersID from Person where typeOfPers = '" + 2 + "'";
        SqlCommand findPersIDComm = new SqlCommand(findPersID, conn);
        SqlDataReader myPersID = findPersIDComm.ExecuteReader();
        int i = 0;
        while (myPersID.Read())
        {
            CommitteeName[i] = myPersID.GetString(0) + myPersID.GetString(1) + " " + myPersID.GetString(2);
            CommitteeID[i] = myPersID.GetString(3);
            i++;
        }
        myPersID.Close();
        conn.Close();

        TextBoxcommittee1.Text = CommitteeName[0];
        TextBoxcommittee2.Text = CommitteeName[1];
        TextBoxcommittee3.Text = CommitteeName[2];
    }

    protected string Get_StatusIDCommittee(string PersID, string ProjID, SqlConnection conn)
    {
        conn.Open();
        //string findPersID = "select PersID from Relation WHERE Status_ID='" + "9" + "' OR Status_ID='" + "10" + "' OR Status_ID='" + "11" + "'";
        string findStaID = "select Status_ID from Relation WHERE PersID='" + PersID + "'AND ProjID = '" + ProjID + "'";
        SqlCommand findStaIDComm = new SqlCommand(findStaID, conn);
        SqlDataReader myStaID = findStaIDComm.ExecuteReader();
        myStaID.Read();
        string temp = myStaID.GetInt32(0).ToString();
        myStaID.Close();
        conn.Close();
        return temp;
    }

    protected void CheckWaitCommittee(SqlConnection conn)
    {
        string[] temp = new string[3];
        string id = Session["ID"].ToString();
        string ProjID = GetProjID(id, conn);

        temp[0] = Get_StatusIDCommittee(CommitteeID[0], ProjID, conn);
        temp[1] = Get_StatusIDCommittee(CommitteeID[1], ProjID, conn);
        temp[2] = Get_StatusIDCommittee(CommitteeID[2], ProjID, conn);

        // กรรมการคนที่1 รอ
        if (temp[0] == "9")
        {
            BTN_success1.CssClass = "btn btn-warning disabled";
            BTN_success1.Text = "รอการตอบรับจากคณะกรรมการ";
            ButtonSend.Visible = false;
            ButtonSave.Visible = false;
        }

        // กรรมการคนที่2 รอ
        if (temp[1] == "10")
        {
            BTN_success2.CssClass = "btn btn-warning disabled";
            BTN_success2.Text = "รอการตอบรับจากคณะกรรมการ";
            ButtonSend.Visible = false;
            ButtonSave.Visible = false;
        }

        // กรรมการคนที่3 รอ
        if (temp[2] == "11")
        {
            BTN_success3.CssClass = "btn btn-warning disabled";
            BTN_success3.Text = "รอการตอบรับจากคณะกรรมการ";
            ButtonSend.Visible = false;
            ButtonSave.Visible = false;
        }

    }

    protected void CheckApproveCommittee(SqlConnection conn)
    {
        string[] temp = new string[3];
        string id = Session["ID"].ToString();
        string ProjID = GetProjID(id, conn);

        temp[0] = Get_StatusIDCommittee(CommitteeID[0], ProjID, conn);
        temp[1] = Get_StatusIDCommittee(CommitteeID[1], ProjID, conn);
        temp[2] = Get_StatusIDCommittee(CommitteeID[2], ProjID, conn);

        // กรรมการคนที่1 เซ็นลายเซ็น
        if (temp[0] == "12")
        {
            BTN_success1.CssClass = "btn btn-success disabled";
            BTN_success1.Text = "คณะกรรมการเซ็นแล้ว";
            ButtonSend.Visible = false;
            ButtonSave.Visible = false;
        }

        // กรรมการคนที่2 เซ็นลายเซ็น
        if (temp[1] == "13")
        {
            BTN_success2.CssClass = "btn btn-success disabled";
            BTN_success2.Text = "คณะกรรมการเซ็นแล้ว";
            ButtonSend.Visible = false;
            ButtonSave.Visible = false;
        }

        // กรรมการคนที่3 เซ็นลายเซ็น
        if (temp[2] == "14")
        {
            BTN_success3.CssClass = "btn btn-success disabled";
            BTN_success3.Text = "คณะกรรมการเซ็นแล้ว";
            ButtonSend.Visible = false;
            ButtonSave.Visible = false;
        }

    }

}