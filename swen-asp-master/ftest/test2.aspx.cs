using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string test = DropDownList1.SelectedItem.Value;
        if (test == "2")
        {
            my_own_textbox1.Style.Add("display", "block");
            my_own_textbox2.Style.Add("display", "none");
            ShID2(sender, e);
        }
        else if (test == "3")
        {
            my_own_textbox1.Style.Add("display", "block");
            my_own_textbox2.Style.Add("display", "block");
            ShID2(sender, e);
        }
        else
        {
            my_own_textbox1.Style.Add("display", "none");
            my_own_textbox2.Style.Add("display", "none");
            ShID2(sender, e);
        }
        
    }

    protected void ShID2(object sender, EventArgs e)
    {

    }

}