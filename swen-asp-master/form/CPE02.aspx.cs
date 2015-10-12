using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Default2 : System.Web.UI.Page
{
   

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
    protected int checkPersIDInRelation(string PersID,SqlConnection conn)
    {
        conn.Open();
        String Checkuser = "select count(*) from Relation where PersID ='" + PersID + "'";
        SqlCommand com = new SqlCommand(Checkuser, conn);
        int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
        conn.Close();
        return temp;
    }
    protected void Startshow(string ProjID, SqlConnection conn)
    {
        //DateTime time = DateTime.Now;
        //string time_finished = String.Format("{0:dd-MM-yyyy HH:mm:ss}", time);
        //TextBox5.Text = time_finished;

        string info = "select ProjID ,ProjName_TH , ProjName_ENG from project where ProjID = '" + ProjID + "'";
        SqlCommand infoComm = new SqlCommand(info, conn);
        conn.Open();
        SqlDataReader myInfo2 = infoComm.ExecuteReader();
        myInfo2.Read();
        TextBox1.Text = myInfo2.GetInt32(0).ToString(); // รหัสโครงงาน
        text_th.Text = myInfo2.GetString(1); // ชื่อโครงงานภาษาไทย
        text_en.Text = myInfo2.GetString(2); // ชื่อโครงงานภาษาอังกฤษ
        myInfo2.Close();
        conn.Close();

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        DateTime time = DateTime.Now;
        string time_finished = String.Format("{0:dd-MM-yyyy HH:mm:ss}", time);
        string id = Session["ID"].ToString();
        string constr = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(constr);
        conn.Open();
        string sql = "INSERT INTO ProjectOperations (ProjID,Date,Subject,Progress,Note) VALUES ('" + TextBox1.Text + "','" + time_finished + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "')";
        SqlCommand com = new SqlCommand(sql, conn);
        com.ExecuteNonQuery();
        conn.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "fuck";
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Form/info");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.MaintainScrollPositionOnPostBack = true;
        
        string constr = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(constr);

        if (Session["ID"] == null)
        {
            Response.Redirect("~/Account/Login");
        }
        else
        {
            string id = Session["ID"].ToString();
            if (checkPersIDInRelation(id,conn) == 1)//มีข้อมูลในดาต้าเบสแล้ว 
            {
                string ProjID = GetProjID(id, conn);
                if (ApprovedCPE01(ProjID, conn)) //TOP -> ผ่าน 01 
                {
                    Startshow(ProjID, conn);
                }
                else // TOP -> ไม่ผ่าน01 
                {
                    Response.Redirect("~/Form/CPE01");
                }
            }
            else //มียังไม่มีข้อมูล
            {
                Response.Redirect("~/Form/CPE01");
            }
        }
    }

}