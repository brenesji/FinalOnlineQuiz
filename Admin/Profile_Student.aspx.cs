using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Profile_Student : System.Web.UI.Page
{
    string quizdetailstable = "quizdetails";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            //txt_Nombre.Text = "Welcome: " + Session["user"].ToString();
            txt_Nombre.Text = Session["user"].ToString();
        }

        bindexams();
    }

    protected void bindexams()
    {
        DataTable dTable = new DataTable();
        SqlCommand getquestions = new SqlCommand("select id, name, description from " + quizdetailstable + " order by id ASC");

        db getquestionslist = new db();
        dTable = getquestionslist.returnDataTable(getquestions);

        if (dTable.Rows.Count > 0)
        {
            examdiv.Visible = true;

            examrepeater.DataSource = dTable;
            examrepeater.DataBind();
        }
        else
        {
            examdiv.Visible = true;
            examdiv.InnerHtml = "<span style='color:#FF0000; font-size:15px;'>Nothing available at the moment</span>";
        }
    }


    protected void examrepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string allKeys = Convert.ToString(e.CommandArgument);

        string[] arrKeys = new string[1];
        char[] splitter = { '|' };
        arrKeys = allKeys.Split(splitter);

        if (e.CommandName == "Iniciar")
        {
            Session["user"] = txt_Nombre.Text;
            Session["examid"] = arrKeys[0];
            Response.Redirect("~/Admin/startnewquiz.aspx", true);

        }
    }
}