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
    protected void Page_Load(object sender, EventArgs e)
    {
   
    }
    protected void btnChk_Click(object sender, EventArgs e)
    {
        string constr = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        SqlConnection conn = new SqlConnection(constr);
        conn.Open();
        String Checkuser = "select count(*) from person where Username ='" + TextUser.Text + "'";
        SqlCommand com = new SqlCommand(Checkuser, conn);
        int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
        conn.Close();
        if (temp == 1)
        {
            conn.Open();
            string checkPasswordQuery = "select passWord from person where Username ='" + TextUser.Text + "'";
            string test = "select Fname from person where Username ='" + TextUser.Text + "'";
            string id = "select PersID from person where Username ='" + TextUser.Text + "'";
            SqlCommand passComm = new SqlCommand(checkPasswordQuery, conn);
            SqlCommand testComm = new SqlCommand(test, conn);
            SqlCommand idComm = new SqlCommand(id,conn);
            string password = passComm.ExecuteScalar().ToString().Replace(" ", "");
            string testtest = testComm.ExecuteScalar().ToString().Replace(" ", "");
            string persid = idComm.ExecuteScalar().ToString().Replace(" ", "");
            if (password == TextPass.Text)
            {
                Session["New"] = testtest;
                Session["status"] = true;
                Session["ID"] = persid;
                Response.Redirect("~/form");
            }
        }
    }
}