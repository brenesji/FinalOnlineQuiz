using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Profile_Psychologist : System.Web.UI.Page
{
    string quizdetailstable = "quizdetails";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            //txt_Nombre.Text = "Welcome: " + Session["user"].ToString();
            txt_Nombre.Text = Session["user"].ToString();
        }

   
    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {

    }
}