using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
public partial class Default2 : System.Web.UI.Page
{
    //Default of form

    protected int checkType(string id, SqlConnection conn)
    {
        conn.Open();
        string FindType = "select typeOfPers  from person where PersID = '" + id + "'";
        SqlCommand FindTypeComm = new SqlCommand(FindType, conn);
        SqlDataReader myType = FindTypeComm.ExecuteReader();
        myType.Read();
        int Type = myType.GetInt32(0);
        myType.Close();
        conn.Close();
        return Type;
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
    protected void showRequest(string id, SqlConnection conn)
    {

        conn.Open();
        string mycommand = "select " +
                            "project.ProjName_TH ," +
                            "project.ProjID, " +
                            "person.Fname, " +
                            "person.Lname, " +
                            "Request.Request, " +
                            "Request_Title.Date " +
                            "From Request_Title " +
                            "INNER JOIN project ON Request_Title.ProjID = project.ProjID " +
                            "INNER JOIN person ON Request_Title.ApplicantID = person.PersID " +
                            "INNER JOIN Request ON Request_Title.ReqID = Request.ReqID " +
                            "where Request_Title.AcceptanceID ='" + id + "'";
        SqlDataAdapter sda = new SqlDataAdapter(mycommand, conn);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
        conn.Close();
    }
    protected void showProj(string id, SqlConnection conn)
    {
        conn.Open();
        string mycommand = "select " +
                            "project.ProjID ," +
                            "project.ProjName_TH ," +
                            "Relation.ProjiD " +
                            "From Relation " +
                            "INNER JOIN project ON Relation.ProjID = project.ProjID where project.Status_ID = '" + "2" + "'AND Relation.PersID = '" + id + "'AND Relation.Status_ID = '" + "4" + "'";
        //"where Relation.PersID='" + id + "'AND Relation.Status_ID = '" + x + "'";

        SqlDataAdapter sda = new SqlDataAdapter(mycommand, conn);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        Repeater2.DataSource = dt;
        Repeater2.DataBind();
        conn.Close();

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string constr = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(constr);
        if (Session["New"] == null) // ยังบ่ได้ล็อกอิน
        {
            Response.Redirect("~/Account/Login");
        }
        else
        {
            string id = Session["ID"].ToString();
            if (youAreStudent(id, conn))
            {
                Div_student.Style.Add("display", "block");
            }
            else
            {
                Div_Teacher.Style.Add("display", "block");
                if (checkType(id, conn) == 2)
                    Div1.Style.Add("display", "none");

            }

            if (!IsPostBack)
            {
                showRequest(id, conn);
                showProj(id, conn);
            }
        }

    }
    protected void btn_approve_Click(object sender, EventArgs e)
    {

    }
    protected void deleteReq(string ProjID, SqlConnection conn)
    {
        conn.Open();
        string delReq = "DELETE FROM Request_Title where ProjID= @ProjID";
        SqlCommand comDel = new SqlCommand(delReq, conn);
        comDel.Parameters.AddWithValue("@ProjID", ProjID);
        comDel.CommandType = CommandType.Text;
        comDel.ExecuteNonQuery();
        conn.Close();
    }
    protected void updateStatusOfProject(string ProjID, string status, SqlConnection conn)
    {
        conn.Open();
        string updateProjStatus = "UPDATE project SET Status_ID = '" + status + "' " + " WHERE ProjID = '" + ProjID + "'";
        SqlCommand comUpdate = new SqlCommand(updateProjStatus, conn);
        comUpdate.ExecuteScalar();
        conn.Close();
    }
    protected void updateStatusOfPerson(string ProjID, string PersID, string old_status, string new_status, SqlConnection conn) // จาก "4" เป็น new 23/4/58 5:51
    {
        conn.Open();
        string updatePersStatus = "UPDATE Relation SET Status_ID = '" + new_status + "' " + " WHERE ProjID = '" + ProjID + "'AND PersID = '" + PersID + "'AND Status_ID = '" + old_status + "'";
        SqlCommand comUpdate = new SqlCommand(updatePersStatus, conn);
        comUpdate.ExecuteScalar();
        conn.Close();
    }
    protected bool isCommittee(string PersID, SqlConnection conn)
    {
        string chk = "select typeOfPers from person where PersID ='" + PersID + "'";
        conn.Open();
        SqlCommand chkAdivser = new SqlCommand(chk, conn);
        SqlDataReader myAdivser = chkAdivser.ExecuteReader();
        myAdivser.Read();
        int temp = myAdivser.GetInt32(0);
        myAdivser.Close();
        conn.Close();
        if (temp == 2)
            return true;
        else
            return false;
    }
    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string constr = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        string PersID = Session["ID"].ToString();
        SqlConnection conn = new SqlConnection(constr);

        if (e.CommandName == "enter")
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Literal __ProjID = (Literal)e.Item.FindControl("_ProjID");
                string ProjID = __ProjID.Text;

                Session["id_form"] = ProjID;
                Response.Redirect("~/form/info");
            }
        }
    }
    protected void AcceptCPE03(string ProjID, string PersID, SqlConnection conn)
    {
        ;
    }

    protected string checkStatusIDinProject(string ProjID, string PersID, SqlConnection conn)
    {
        conn.Open();
        string FindType = "select Status_ID  from Relation where PersID = '" + PersID + "'AND ProjID = '" + ProjID +"'";
        SqlCommand FindTypeComm = new SqlCommand(FindType, conn);
        SqlDataReader myType = FindTypeComm.ExecuteReader();
        myType.Read();
        string Type = myType.GetInt32(0).ToString();
        myType.Close();
        conn.Close();
        return Type;
    }
    protected void deleReqForCommittee(string AcceptanceID, string ProjID, SqlConnection conn)
    {
        conn.Open();
        string delReq = "DELETE FROM Request_Title where ProjID= @ProjID AND AcceptanceID = @AcceptanceID";
        SqlCommand comDel = new SqlCommand(delReq, conn);
        comDel.Parameters.AddWithValue("@ProjID", ProjID);
        comDel.Parameters.AddWithValue("@AcceptanceID", AcceptanceID);
        comDel.CommandType = CommandType.Text;
        comDel.ExecuteNonQuery();
        conn.Close();
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string constr = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        string PersID = Session["ID"].ToString();
        SqlConnection conn = new SqlConnection(constr);
        int type = checkType(PersID, conn);
        if (e.CommandName == "approve")
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal __ProjID = (Literal)e.Item.FindControl("_ProjID");
                string ProjID = __ProjID.Text;

                if (type == 1)
                {
                    updateStatusOfProject(ProjID, "2", conn);//2 is ผ่าน 
                    updateStatusOfPerson(ProjID, PersID, "1", "4", conn); // 4 ยอมรับเป็นที่ปรึกษาแล้ว
                    deleteReq(ProjID, conn);
                }
                else
                {
                    if (checkStatusIDinProject(ProjID, PersID, conn) == "9")
                    {
                        updateStatusOfPerson(ProjID, PersID, "9", "12", conn);
                    }
                    else if (checkStatusIDinProject(ProjID, PersID, conn) == "10")
                    {
                        updateStatusOfPerson(ProjID, PersID, "10", "13", conn);
                    }
                    else
                    {
                        updateStatusOfPerson(ProjID, PersID, "11", "14", conn);
                    }

                    deleReqForCommittee(PersID, ProjID, conn);
                }
            }
        }
        else if (e.CommandName == "reject")
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal __ProjID = (Literal)e.Item.FindControl("_ProjID");
                string ProjID = __ProjID.Text;
                if (type == 1)
                {
                    updateStatusOfProject(ProjID, "0", conn);//0 is ไม่ผ่าน 
                    deleteReq(ProjID, conn);
                }
                else
                {
                    // do nothing
                }
            }
        }
        else if (e.CommandName == "viewDetail")
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal __ProjID = (Literal)e.Item.FindControl("_ProjID");
                string ProjID = __ProjID.Text;

                Session["id_form"] = ProjID;
                if (type == 1)
                {
                    Response.Redirect("~/form/CPE01");
                }
                else
                {
                    Response.Redirect("~/form/info");
                }
            }
        }
        Response.Redirect(Request.Url.AbsoluteUri);
    }

}