using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

static public class memberControl
{
    static public int member = 1;
    static public ArrayList adviser = new ArrayList();
}
static public class PersInfo
{
    static public string id2;
    static public string title2;
    static public string fname2;
    static public string lname2;
    static public string phone2;
    static public string email2;
    static public string id3;
    static public string title3;
    static public string fname3;
    static public string lname3;
    static public string phone3;
    static public string email3;
    static public string oldID2;
    static public string oldID3;
    static public bool removeispush = false;
}
public partial class Default2 : System.Web.UI.Page
{
    string constr = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
    string[] ProjDetail = new string[3];
    string[] PersID = new string[3]; // ไม่แน่ใจว่า3 จะพังไหม
    string[] PersIDTemp = new string[2];
    int teacher = 0;
    protected void DropdownListadviser(SqlConnection conn)
    {
        if (!IsPostBack)
        {

            conn.Open();
            String Checkuser = "select count(*) from person where typeOfPers ='" + "1" + "'";
            SqlCommand com = new SqlCommand(Checkuser, conn);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            if (temp >= 1)
            {
                string info = "select PersID,title ,fname , lname  from person where typeOfPers = '" + "1" + "'";
                SqlCommand infoComm = new SqlCommand(info, conn);
                SqlDataReader myInfo = infoComm.ExecuteReader();
                while (myInfo.Read())
                {
                    DropDownList1.Items.Add(myInfo[1].ToString() + " " + myInfo[2].ToString() + " " + myInfo[3].ToString());
                    DropDownList2.Items.Add(myInfo[1].ToString() + " " + myInfo[2].ToString() + " " + myInfo[3].ToString());
                    DropDownList3.Items.Add(myInfo[1].ToString() + " " + myInfo[2].ToString() + " " + myInfo[3].ToString());
                    memberControl.adviser.Add(myInfo[0].ToString());
                    teacher++;
                }
            }
        }
        conn.Close();
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
    } //หา Project ID
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
    protected void ShowProjInfo()
    {
        if (!IsPostBack)
        {
            text_th.Text = ProjDetail[0];
            text_en.Text = ProjDetail[1];
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
    protected void checkDisplay()
    {
        if (memberControl.member == 2)
        {
            my_own_textbox1.Style.Add("display", "block");
            my_own_textbox2.Style.Add("display", "none");

        }
        else if (memberControl.member == 3)
        {
            my_own_textbox1.Style.Add("display", "block");
            my_own_textbox2.Style.Add("display", "block");
        }
        else //1 
        {

            my_own_textbox1.Style.Add("display", "none");
            my_own_textbox2.Style.Add("display", "none");
            text_id2.Text = "";
            text_name2.Text = "";
            text_tel2.Text = "";
            text_email2.Text = "";
            text_id3.Text = "";
            text_name3.Text = "";
            text_tel3.Text = "";
            text_email3.Text = "";
        }

    }
    protected void checkSearchBox()
    {
        if (memberControl.member == 3)
        {
            divAddMember.Style.Add("display", "none");
        }
        else
        {
            divAddMember.Style.Add("display", "block");
        }
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
    protected bool HaveAdvser(string ProjID, SqlConnection conn, int type) // ใช่หาตรวจสอบว่า มีอาจารย์ที่ปรึกษา อาจารย์ที่ปรึกษาร่วม หรือกรรมการหรือไม่
    {
        conn.Open();
        String Checkuser = "select count(*) from Relation where Status_ID ='" + type + "' AND ProjID ='" + ProjID + "'";
        SqlCommand com = new SqlCommand(Checkuser, conn);
        int HaveAdviser = Convert.ToInt32(com.ExecuteScalar().ToString());
        conn.Close();
        if (HaveAdviser == 1)
            return true;
        else
            return false;

    }
    protected string WhoAreAdviser(string ProjID, SqlConnection conn, int type)
    {
        conn.Open();
        string FindAdviser = "select PersID  from Relation where ProjID = '" + ProjID + "' AND Status_ID = '" + type + "'";
        SqlCommand FindAdviserComm = new SqlCommand(FindAdviser, conn);
        SqlDataReader myAdviser = FindAdviserComm.ExecuteReader();
        myAdviser.Read();
        string Adviser = myAdviser.GetString(0);
        myAdviser.Close();
        conn.Close();
        return Adviser;
    }
    protected void CheckTeacherAtProj(string ProjID, SqlConnection conn)
    {
        /* มีอาจารย์ในโครงงานหรือไม่
         * ถ้ามี มีใครบ้าง อยู่ตำแหน่งไหน
         * 
         */
        int check;
        if (HaveAdvser(ProjID, conn, 1))
        {
            //ใครละ   รีเทินมา
            string Adviser = WhoAreAdviser(ProjID, conn, 1); // ได้รหัสอาจารย์มาแล้ว
            for (int i = 0; i < teacher; i++)
            {
                check = string.Compare(Adviser, memberControl.adviser[i].ToString());
                if (check == 0) // แสดงว่าเจอ
                    DropDownList1.SelectedIndex = i + 1;
            }
        }
        if (HaveAdvser(ProjID, conn, 2))
        {
            string Adviser = WhoAreAdviser(ProjID, conn, 2); // ได้รหัสอาจารย์มาแล้ว
            for (int i = 0; i < teacher; i++)
            {
                check = string.Compare(Adviser, memberControl.adviser[i].ToString());
                if (check == 0) // แสดงว่าเจอ
                    DropDownList2.SelectedIndex = i + 1;
            }
        }

        if (HaveAdvser(ProjID, conn, 3))
        {
            string Adviser = WhoAreAdviser(ProjID, conn, 3); // ได้รหัสอาจารย์มาแล้ว
            for (int i = 0; i < teacher; i++)
            {
                check = string.Compare(Adviser, memberControl.adviser[i].ToString());
                if (check == 0) // แสดงว่าเจอ
                    DropDownList3.SelectedIndex = i + 1;
            }
        }
    }
    protected bool CanSeatch()
    {
        if (shBox.Text == text_id.Text || shBox.Text == text_id2.Text || shBox.Text == text_id3.Text)
            return false;
        return true;
    }
    protected bool HaveStudent(SqlConnection conn)
    {
        conn.Open();
        String Checkmember = "select count(*) from Person where PersID ='" + shBox.Text + "'AND TypeOfPers = '" + 0 + "'";
        SqlCommand coms = new SqlCommand(Checkmember, conn);
        int havedMember = Convert.ToInt32(coms.ExecuteScalar().ToString());
        conn.Close();
        if (havedMember > 0)
            return true;
        else
            return false;
    }
    protected void WhoAreStudent(SqlConnection conn)
    {
        string info = "select title ,fname , lname , phone , email from person where PersID = '" + shBox.Text + "'";
        conn.Open();
        SqlCommand infoComm = new SqlCommand(info, conn);
        SqlDataReader myInfo = infoComm.ExecuteReader();
        myInfo.Read();
        shshowBox.Text = myInfo.GetString(0) + myInfo.GetString(1) + " " + myInfo.GetString(2);

        if (memberControl.member == 1)
        {
            PersInfo.id2 = shBox.Text;
            PersInfo.title2 = myInfo.GetString(0);
            PersInfo.fname2 = myInfo.GetString(1);
            PersInfo.lname2 = myInfo.GetString(2);
            PersInfo.phone2 = myInfo.GetString(3);
            PersInfo.email2 = myInfo.GetString(4);
            // MessageBox.Show(PersInfo.id2);
        }

        if (memberControl.member == 2)
        {
            PersInfo.id3 = shBox.Text;
            PersInfo.title3 = myInfo.GetString(0);
            PersInfo.fname3 = myInfo.GetString(1);
            PersInfo.lname3 = myInfo.GetString(2);
            PersInfo.phone3 = myInfo.GetString(3);
            PersInfo.email3 = myInfo.GetString(4);
        }
        btnAdd.Visible = true;
        btnCancel.Visible = true;
        myInfo.Close();
        conn.Close();
    }
    protected void clearTextBox() // ช่องค้นหา และ ช่องแสดง และ ปิดปุ่มยกเลิก และ ปุ่มค้นหา
    {
        shBox.Text = "";
        shshowBox.Text = "";
        btnAdd.Visible = false;
        btnCancel.Visible = false;
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(constr);
        if (shBox.Text != "")
        {
            /*ตรวจสอบว่า ข้อความในช่องค้นหา ซ้ำกับคนที่ 1 2 3 หรือไม่
             * ต้องเป็นนิสิต
             * ต้องเป็นนิสิตที่ยังไม่มีโครงงานเท่านั้น
             */
            if (CanSeatch())
            {
                if (HaveStudent(conn))//มีข้อมูลอยู่ใช่ไหม
                {
                    if (!haveProject(shBox.Text, conn))
                    {
                        WhoAreStudent(conn);
                    }
                    else
                    {
                        //มีโครงงานแล้ว
                        MessageBox.Show("นิสิตคนนี้มีโครงงานแล้ว");
                        clearTextBox();
                    }

                    //คนที่ค้นหามีโปรเจคแล้วรึยัง
                    //คือใคร;

                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูล");
                    clearTextBox();
                    /*
                     *ไม่พบข้อมูลเนื่องจาก เป็นอาจารย์ หรือไม่มีรหัสดังกล่าวในระบบ 
                     */
                }
            }
            else
            {
                MessageBox.Show("input ที่เข้ามา ซ้ำกับข้อมูลในฟอร์ม");
                clearTextBox();
            }
        }
        else
        {
            //MessageBox.Show("มันว่าง");
        }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (memberControl.member == 1)
        {

            text_id2.Text = PersInfo.id2;
            text_name2.Text = PersInfo.title2 + PersInfo.fname2 + " " + PersInfo.lname2;
            text_tel2.Text = PersInfo.phone2;
            text_email2.Text = PersInfo.email2;
            memberControl.member = 2;
            //MessageBox.Show(memberControl.member.ToString());

        }

        else if (memberControl.member == 2)
        {
            text_id3.Text = PersInfo.id3;
            text_name3.Text = PersInfo.title3 + PersInfo.fname3 + " " + PersInfo.lname3;
            text_tel3.Text = PersInfo.phone3;
            text_email3.Text = PersInfo.email3;
            memberControl.member = 3;
        }
        checkSearchBox();
        clearTextBox();
        checkDisplay();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clearTextBox();
    }
    protected void remove(object sender, EventArgs e)
    {
        /*กรณีที่1 ลบเมื่อมีสมาชิกอยู่2 คน
         * ให้เครียค่าในแถวที่2ทั้งหมดทิ้ง
         * กรณีที่2 กดลบเมื่อมีสมาชิก 3 คน
         * ต้องย้ายข้อมูลจากแถวที่3 มาไว้แถวที่2แทน
         */
        PersInfo.removeispush = true;
        if (memberControl.member == 2)
        {
            PersInfo.oldID2 = text_id2.Text;
            PersInfo.oldID3 = text_id3.Text;
            text_id2.Text = null;
            text_name2.Text = null;
            text_tel2.Text = null;
            text_email2.Text = null;
            memberControl.member = 1;
        }
        else if (memberControl.member == 3)
        {
            PersInfo.oldID2 = text_id2.Text;
            PersInfo.oldID3 = text_id3.Text;
            PersInfo.id2 = text_id3.Text;
            text_id2.Text = text_id3.Text;
            text_name2.Text = text_name3.Text;
            text_tel2.Text = text_tel3.Text;
            text_email2.Text = text_email3.Text;

            text_id3.Text = null;
            text_name3.Text = null;
            text_tel3.Text = null;
            text_email3.Text = null;
            memberControl.member = 2;

        }
        checkDisplay();
        clearTextBox();
    }
    protected void remove2(object sender, EventArgs e)
    {
        PersInfo.oldID2 = text_id2.Text;
        PersInfo.oldID3 = text_id3.Text;
        text_id3.Text = "";
        text_name3.Text = "";
        text_tel3.Text = "";
        text_email3.Text = "";
        memberControl.member = 2;
        checkDisplay();
        clearTextBox();
    }
    protected void CreatProject(string id, SqlConnection conn)
    {
        string info = "select title ,fname , lname , phone , email  from person where PersID = '" + id + "'";
        conn.Open();
        SqlCommand infoComm = new SqlCommand(info, conn);
        SqlDataReader myInfo = infoComm.ExecuteReader();
        myInfo.Read();

        text_id.Text = id;
        text_name.Text = myInfo.GetString(0) + myInfo.GetString(1) + " " + myInfo.GetString(2);
        text_tel.Text = myInfo.GetString(3);
        text_email.Text = myInfo.GetString(4);

        myInfo.Close();
        conn.Close();
    }

    protected void addTeacherToDB(string ProjID, SqlConnection conn)
    {

        int index1 = DropDownList1.SelectedIndex; //ที่ปรึกษา
        int index2 = DropDownList2.SelectedIndex; //ที่ปรึกษาร่วม
        int index3 = DropDownList3.SelectedIndex; //เสนอกรรมการ
        conn.Open();

        if (index1 > 0)
        {
            string sql = "INSERT INTO Relation (ProjID,PersID,Status_ID) VALUES ('" + ProjID + "','" + memberControl.adviser[index1 - 1].ToString() + "','" + "1" + "')";
            SqlCommand com = new SqlCommand(sql, conn);
            com.ExecuteScalar();
        }
        if (index2 > 0)
        {
            string sql = "INSERT INTO Relation (ProjID,PersID,Status_ID) VALUES ('" + ProjID + "','" + memberControl.adviser[index2 - 1].ToString() + "','" + "2" + "')";
            SqlCommand com = new SqlCommand(sql, conn);
            com.ExecuteScalar();
        }
        if (index3 > 0)
        {
            string sql = "INSERT INTO Relation (ProjID,PersID,Status_ID) VALUES ('" + ProjID + "','" + memberControl.adviser[index3 - 1].ToString() + "','" + "3" + "')";
            SqlCommand com = new SqlCommand(sql, conn);
            com.ExecuteScalar();
        }
        conn.Close();

    }
    protected string addProjName(SqlConnection conn)
    {
        DateTime time = DateTime.Now;
        string time_forsave = String.Format("{0:dd-MM-yyyy HH:mm:ss}", time);
        conn.Open();
        string sql = "INSERT INTO project (ProjName_TH,ProjName_ENG,Member,Date,Status_ID) OUTPUT INSERTED.ProjiD VALUES ('" + text_th.Text + "','" + text_en.Text + "','" + memberControl.member + "','" + time_forsave + "','" + "0" + "')";
        SqlCommand com = new SqlCommand(sql, conn);
        var projectIDCS = com.ExecuteScalar();
        string ProjID = projectIDCS.ToString();
        conn.Close();
        return ProjID;
    }
    protected void updateProjName(string ProjID, SqlConnection conn)
    {
        DateTime time = DateTime.Now;
        string time_forsave = String.Format("{0:dd-MM-yyyy HH:mm:ss}", time);
        conn.Open();
        string sql = "UPDATE project SET ProjName_TH = '" + text_th.Text + "'," + " ProjName_ENG = '" + text_en.Text + "'," + "Date ='" + time_forsave + "' " + " WHERE ProjID = '" + ProjID + "'";


        SqlCommand com = new SqlCommand(sql, conn);
        com.ExecuteScalar();
        conn.Close();
    }

    protected int getMemberinDB(string ProjID, SqlConnection conn) //กรองมาเฉพาะนิสิต
    {
        conn.Open();
        String Checkmember = "select count(*) from Relation where ProjID ='" + ProjID + "'AND Status_ID = '" + 0 + "'";
        SqlCommand coms = new SqlCommand(Checkmember, conn);
        int Member = Convert.ToInt32(coms.ExecuteScalar().ToString());
        conn.Close();
        return Member;
    }
    protected void insertMember(string id, string ProjID, SqlConnection conn)
    {
        conn.Open();
        string insertMember = "INSERT INTO Relation (ProjID,PersID,Status_ID) VALUES ('" + ProjID + "','" + id + "','" + "0" + "')";
        SqlCommand comInser = new SqlCommand(insertMember, conn);
        comInser.ExecuteScalar();
        conn.Close();
    }
    protected void updateMember(int member, string ProjID, SqlConnection conn)
    {
        conn.Open();
        string updateMember = "UPDATE project SET Member = '" + member + "' " + " WHERE ProjID = '" + ProjID + "'";
        SqlCommand comUpdate = new SqlCommand(updateMember, conn);
        comUpdate.ExecuteScalar();
        conn.Close();
    }
    protected void deleteMember(string PersID, SqlConnection conn)
    {
        conn.Open();
        string deleteMember = "DELETE FROM Relation where PersID= @PersID";
        SqlCommand comDel = new SqlCommand(deleteMember, conn);
        comDel.Parameters.AddWithValue("@PersID", PersID);
        comDel.CommandType = CommandType.Text;
        comDel.ExecuteNonQuery();
        conn.Close();
    }
    protected void updateMemberToDB(string PersID, string ProjID, SqlConnection conn)
    {
        // ต้องรู้ สมาชิกปัจจุบันในเว็บ และ สมาชิกใน DB 
        int memberLocal = memberControl.member;
        int memberDB = getMemberinDB(ProjID, conn);
        //MessageBox.Show("DB" + memberDB.ToString() + " " + memberLocal, "ตรวจสอบสมาชิก");
        if (memberDB == 1)
        {
            if (memberLocal == 2)
            {
                updateMember(2, ProjID, conn);
                insertMember(text_id2.Text, ProjID, conn);
            }
            else if (memberLocal == 3)
            {
                updateMember(3, ProjID, conn);
                insertMember(text_id2.Text, ProjID, conn);
                insertMember(text_id3.Text, ProjID, conn);
            }
        }
        else if (memberDB == 2)
        {
            if (memberLocal == 1)
            {
                updateMember(1, ProjID, conn);
                deleteMember(PersID, conn);
            }
            else if (memberLocal == 3)
            {
                updateMember(3, ProjID, conn);
                insertMember(text_id3.Text, ProjID, conn);
            }
        }
        else
        {
            if (memberLocal == 2)
            {
                updateMember(2, ProjID, conn);
                deleteMember(PersID, conn);
            }
        }
    }

    protected void deleteAdviser(string ProjID, string PersID, SqlConnection conn)
    {
        conn.Open();
        string deleteMember = "DELETE FROM Relation where PersID= @PersID AND ProjID = @ProjID";
        SqlCommand comDel = new SqlCommand(deleteMember, conn);
        comDel.Parameters.AddWithValue("@PersID", PersID);
        comDel.Parameters.AddWithValue("@ProjID", ProjID);
        comDel.CommandType = CommandType.Text;
        comDel.ExecuteNonQuery();
        conn.Close();
    }
    protected void updateTeacher(string ProjID, SqlConnection conn)
    {
        if (DropDownList1.SelectedIndex != DropDownList2.SelectedIndex && DropDownList1.SelectedIndex != 0 && DropDownList2.SelectedIndex != 0)
        {
            for (int i = 1; i <= 3; i++)
            {
                if (HaveAdvser(ProjID, conn, i))
                {
                    //deleteMember(WhoAreAdviser(ProjID, conn, i), conn);
                    deleteAdviser(ProjID, WhoAreAdviser(ProjID, conn, i), conn);
                }
            }
            addTeacherToDB(ProjID, conn);
        }
        else
        {
            //MessageBox.Show("ไม่สามารถเลือกอาจารย์ที่ปรึกษาร่วมซ้ำกับอาจารย์ที่ปรึกษาได้", "เตือน");
        }
    }
    protected void AddCommitteeQ(string ProjID, string committee,SqlConnection conn)
    {
        conn.Open();
        string sql = "INSERT INTO Relation (ProjID,PersID,Status_ID) VALUES ('" + ProjID + "','" + committee + "','" + "7" + "')";
        SqlCommand com = new SqlCommand(sql, conn);
        com.ExecuteScalar();
        conn.Close();
    }
    protected void AddCommittee(string ProjID, SqlConnection conn)
    {
        string committeeID1 = "C0000001";
        string committeeID2 = "C0000002";
        string committeeID3 = "C0000003";
        AddCommitteeQ(ProjID, committeeID1,conn);
        AddCommitteeQ(ProjID, committeeID2, conn);
        AddCommitteeQ(ProjID, committeeID3, conn);
    }
    protected void btn_saveForm_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(constr);
        string id = Session["ID"].ToString();
        string[] tempID = new string[3];
        tempID[0] = text_id.Text;
        tempID[1] = text_id2.Text;
        tempID[2] = text_id3.Text;

        if (text_th.Text != "" && text_en.Text != "")
        {
            if (haveProject(id, conn)) // มีโปรเจคแล้ว 
            {
                updateProjName(GetProjID(id, conn), conn);
                updateMemberToDB(id, GetProjID(id, conn), conn);
                updateTeacher(GetProjID(id, conn), conn);
                PersInfo.removeispush = false;
                /*
                 * เกิดการเปลี่ยนแปลงสมาชิกเกิดขึ้น
                 */
            }
            else//สร้างครั้งแรก
            {
                //MessageBox.Show("สร้างครั้งแรก");
                string ProjID = addProjName(conn);
                //MessageBox.Show(memberControl.member.ToString());
                if (memberControl.member == 1)
                {
                    //MessageBox.Show("เข้ากรณี 1");
                    insertMember(tempID[0], ProjID, conn);

                }
                else if (memberControl.member == 2)
                {
                    //MessageBox.Show("เข้ากรณี 2");
                    insertMember(tempID[0], ProjID, conn);
                    insertMember(tempID[1], ProjID, conn);
                }
                else
                {
                    insertMember(tempID[0], ProjID, conn);
                    insertMember(tempID[1], ProjID, conn);
                    insertMember(tempID[2], ProjID, conn);
                }
                addTeacherToDB(ProjID, conn);
                AddCommittee(ProjID, conn);
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            MessageBox.Show("ชื่อโครงงานไม่ถูกต้อง");
        }
    }
    protected void checkRemove(string member)
    {
        if (member == "2")
        {
            btnRemove.Visible = false;
            //btnRemove2.Visible = false;
        }
        else if (member == "3")
        {
            btnRemove.Visible = false;
            btnRemove2.Visible = false;
        }
        else
        {
            btnRemove.Visible = true;
            btnRemove2.Visible = true;
        }
    }
    protected void deleteProject(string ProjID, SqlConnection conn)
    {
        conn.Open();

        string deleteRelation = "DELETE FROM Relation where ProjID = @ProjID";
        string deleteProject = "DELETE FROM project where ProjID = @ProjID";

        SqlCommand comDel = new SqlCommand(deleteRelation, conn);
        comDel.Parameters.AddWithValue("@ProjID", ProjID);
        comDel.CommandType = CommandType.Text;
        comDel.ExecuteNonQuery();

        SqlCommand comDelProj = new SqlCommand(deleteProject, conn);
        comDelProj.Parameters.AddWithValue("@ProjID", ProjID);
        comDelProj.CommandType = CommandType.Text;
        comDelProj.ExecuteNonQuery();
        conn.Close();
    }
    protected void exitProject(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "ใช่")
        {
            SqlConnection conn = new SqlConnection(constr);
            string id = Session["ID"].ToString();
            string ProjID = GetProjID(id, conn);
            int memberDB = getMemberinDB(ProjID, conn);
            //MessageBox.Show("จะทำการลบ " + id + " " + "ออกจาก " + ProjID + " ", "ทดสอบการลบ");
            //deleteMember(id, conn);
            if (memberDB == 1)
            {
                deleteProject(ProjID, conn);
            }
            else if (memberDB == 2)
            {
                updateMember(1, ProjID, conn);
               // MessageBox.Show("จะทำการลดจำนวนสมาชิกเหลือ 1คน");
                deleteMember(id, conn);
            }
            else
            {
                updateMember(2, ProjID, conn);
               // MessageBox.Show("จะทำการลดจำนวนสมาชิกเหลือ 2คน");
                deleteMember(id, conn);
            }

            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('ออกจากโครงการแล้ว')", true);
            //MessageBox.Show("ลบเสร็จแล้วจะกลับไปหน้าฟอม");
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('คำขอถูกยกเลิก')", true);
        }
    }
    protected void updateStatusOfProject(string ProjID, string status, SqlConnection conn)
    {
        conn.Open();
        string updateProjStatus = "UPDATE project SET Status_ID = '" + status + "' " + " WHERE ProjID = '" + ProjID + "'";
        SqlCommand comUpdate = new SqlCommand(updateProjStatus, conn);
        comUpdate.ExecuteScalar();
        conn.Close();
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
    protected void btn_sentForm_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(constr);
        string id = Session["ID"].ToString();
        string ProjID = GetProjID(id, conn);

        //MessageBox.Show(DropDownList3.SelectedIndex.ToString());
        if (DropDownList3.SelectedIndex == 0 || DropDownList1.SelectedIndex == 0)
        {
            MessageBox.Show("โปรดเลือกอาจารย์ที่ปรึกษาและกรรมการให้ครบถ้วน");
        }
        else //ทำการ sent
        {
            /*
             * update ข้อมูลอาจารย์
             * เปลี่ยนแปลง Status_ID ใน ตาราง Project เป็น 1
             * เพิ่มข้อมูลใน ตาราง Request_Title
             * โดย ส่งประเภทที่ขอ
             * รหัสโครงงานที่ขอ
             * ผู้ขอ
             * และ ผู้ที่ถูกขอไป
             */
            string confirmValue = Request.Form["confirm_value2"];
            if (confirmValue == "ใช่")
            {
                updateTeacher(GetProjID(id, conn), conn);
                updateStatusOfProject(ProjID, "1", conn);
                WhoAreAdviser(ProjID, conn, 1);
                request(ProjID, id, WhoAreAdviser(ProjID, conn, 1), "1", conn);
                //MessageBox.Show(WhoAreAdviser(ProjID, conn, 1));
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('คำขอถูกยกเลิก'),df", true);
            }
            Response.Redirect(Request.Url.AbsoluteUri);

        }
    }
    protected void DeleteReq(string ProjID, SqlConnection conn)
    {
        conn.Open();
        string deleteReq = "DELETE FROM Request_Title where ProjID= @ProjID";
        SqlCommand com = new SqlCommand(deleteReq, conn);
        com.Parameters.AddWithValue("@ProjID", ProjID);
        com.CommandType = CommandType.Text;
        com.ExecuteNonQuery();
        conn.Close();
    }
    protected void btn_cancelSentForm_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(constr);
        string id = Session["ID"].ToString();
        string ProjID = GetProjID(id, conn);
        //MessageBox.Show(findStatusProj(ProjID, conn).ToString());
        if (findStatusProj(ProjID, conn) == 1)
        {
            updateStatusOfProject(ProjID, "0", conn);
            DeleteReq(ProjID, conn);

        }
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void checkDropdownList()
    {
        if (DropDownList1.SelectedIndex == DropDownList2.SelectedIndex)
        {
            if (DropDownList1.SelectedIndex != 0)
            {
                //MessageBox.Show("ไม่สามารถเลือกอาจารย์ที่ปรึกษาร่วมซ้ำกับอาจารย์ที่ปรึกษาได้", "เตือน");
                DropDownList2.ClearSelection();
            }
        }
    }
    protected int findStatusProj(string ProjID, SqlConnection conn)
    {
        string findStatus = "select Status_ID from project where ProjID = '" + ProjID + "'";
        conn.Open();
        SqlCommand findStatusComm = new SqlCommand(findStatus, conn);
        SqlDataReader myStatus = findStatusComm.ExecuteReader();
        myStatus.Read();
        int status = myStatus.GetInt32(0);
        myStatus.Close();
        conn.Close();
        return status;
    }
    protected int test(string ProjID,string PersID,SqlConnection conn)
    {
        // ใครใน relation ที่ มี statusid = 4 ได้เป็น index 
        // 
        int check;
        if (HaveAdvser(ProjID, conn, 4))
        {
            string Adviser = WhoAreAdviser(ProjID, conn, 4); // ได้รหัสอาจารย์มาแล้ว
            //MessageBox.Show(Adviser);
            for(int i = 0; i < teacher; i++)
            {
                //MessageBox.Show(i+memberControl.adviser[i].ToString());
                check = string.Compare(Adviser, memberControl.adviser[i].ToString());
                if (check == 0) // แสดงว่าเจอ
                {
                    //MessageBox.Show((i + 1).ToString());
                    //DropDownList1.SelectedIndex = i + 1;
                    return i + 1;
                }
            }
            return 0;
        }
        else
            return 0;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.MaintainScrollPositionOnPostBack = true;
        SqlConnection conn = new SqlConnection(constr);
        if (Session["ID"] != null)
        {
            DropdownListadviser(conn);
            string id = Session["ID"].ToString();
            if (youAreStudent(id, conn)) // นิสิต
            {
                if (haveProject(id, conn)) // มีโปรเจคแล้ว
                {
                    /*
                     * เป็นนิสิต
                     * ต้องการรู้รหัสโครงงาน
                     * ต้องการรู้จำนวนสมาชิก
                     * ต้องการรู้ข้อมูลสมาชิก
                     * ต้องการรู้ข้อมูลโครงงาน
                     * ต้องการรู้อาจารย์ที่ปรึกษา
                     */
                    string ProjID = GetProjID(id, conn);
                    GetProjDetail(ProjID, conn);

                    FindPersID(ProjID, conn);
                    ShowProjInfo();
                    ShowPersInfo(ProjDetail[2], conn);
                    if (!IsPostBack)
                        memberControl.member = Convert.ToInt16(ProjDetail[2]);
                    checkSearchBox();
                    checkDisplay();
                    checkRemove(ProjDetail[2]);
                    CheckTeacherAtProj(ProjID, conn);

                    if (ProjDetail[2] == "1")
                        btn_cancelForm.Text = "ลบโครงงาน";
                    else
                        btn_cancelForm.Text = "ออกจากโครงงาน";
                    btn_cancelForm.Visible = true;
                    btn_sentForm.CssClass = "btn btn-success";
                    checkDropdownList();
                    btn_cancelSentForm.Visible = false;
                    if (findStatusProj(ProjID, conn) == 1)
                    {
                        btn_saveForm.Visible = false;
                        btn_sentForm.Visible = false;
                        btn_cancelForm.Visible = false;
                        divAddMember.Style.Add("display", "none");
                        DropDownList1.Enabled = false;
                        DropDownList2.Enabled = false;
                        DropDownList3.Enabled = false;
                        text_th.Enabled = false;
                        text_en.Enabled = false;
                        btn_cancelSentForm.Visible = true;
                    }
                    else if (findStatusProj(ProjID, conn) == 2)//ผ่านแล้ว
                    {
                        btn_saveForm.Visible = false;
                        btn_sentForm.Visible = false;
                        btn_cancelForm.Visible = false;
                        divAddMember.Style.Add("display", "none");
                        DropDownList1.Enabled = false;
                        DropDownList2.Enabled = false;
                        DropDownList3.Enabled = false;
                        text_th.Enabled = false;
                        text_en.Enabled = false;
                        btn_cancelSentForm.Visible = false;

                        //****
                        //DropDownList1.SelectedIndex = 1;
                        //MessageBox.Show(test(ProjID, id, conn).ToString());
                        //****
                        DropDownList1.SelectedIndex = test(ProjID, id, conn);
                    }
                    else
                    {
                        btn_cancelSentForm.Visible = false;
                    }
                }
                else
                {
                    //MessageBox.Show("ยังไม่มีโครงงาน");
                    btn_cancelForm.Visible = false;
                    CreatProject(id, conn);
                    if (!IsPostBack)
                        memberControl.member = 1;
                    btn_sentForm.CssClass = "btn btn-success disabled";
                    //btn_cancelForm.Visible = false;
                    checkDropdownList();
                    btn_cancelSentForm.Visible = false;
                }
            }
            else//อาจารย์
            {
                //Response.Redirect("~/Account/Form");
                btn_saveForm.Visible = false;
                btn_sentForm.Visible = false;
                btn_cancelForm.Visible = false;
                divAddMember.Style.Add("display", "none");
                DropDownList1.Enabled = false;
                DropDownList2.Enabled = false;
                DropDownList3.Enabled = false;
                text_th.Enabled = false;
                text_en.Enabled = false;
                btn_cancelSentForm.Visible = false;
                if (Session["id_form"] != null)
                {
                    string ProjID = Session["id_form"].ToString();
                    GetProjDetail(ProjID, conn);
                    FindPersID(ProjID, conn);
                    ShowProjInfo();
                    ShowPersInfo(ProjDetail[2], conn);
                    if (!IsPostBack)
                        memberControl.member = Convert.ToInt16(ProjDetail[2]);
                    divAddMember.Style.Add("display", "none");
                    checkDisplay();
                    checkRemove(ProjDetail[2]);
                    CheckTeacherAtProj(ProjID, conn);
                }
            }
        }
        else
        {
            Response.Redirect("~/Account/Login");
        }
    }


}