using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Student_Profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            //txt_Nombre.Text = "Welcome: " + Session["user"].ToString();
            txt_Nombre.Text = Session["user"].ToString();
        }
    }
}