﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["New"] = null;
        Session["ID"] = null;
        Session["status"] = false;
        Response.Redirect("~/Account/Login");
        Session.RemoveAll();
        
    }
}