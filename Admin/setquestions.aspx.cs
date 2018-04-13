using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_setquestions : System.Web.UI.Page
{
    string quizdetailstable = "quizdetails";
    string quiztotalquestionstable = "total_questions";
    string quizquestionstable = "quiz_questions";
    string quizquestionoptionstable = "question_options";
    string quizquestionanswertable = "question_answer";
    string qstring = "0";
    string qtype = "";
    int quizId = 0;
    int tempval = 0;
    int qorder = 0;
    int questid = 0;
    DateTime updatedate = new DateTime();

    protected void Page_Load(object sender, EventArgs e)
    {
        updatedate = DateTime.Now;
        HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
        HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
        HttpContext.Current.Response.AddHeader("Expires", "0");

        if (!Page.IsPostBack)
        {
                bindquestions();
            }
        }
        

    protected void bindquestions()
    {
        DataTable dTable = new DataTable();
        SqlCommand getquestions = new SqlCommand("select id, title, type from " + quiztotalquestionstable + " order by questionorder ASC");
        getquestions.Parameters.AddWithValue("quizid", quizId);

        db getquestionslist = new db();
        dTable = getquestionslist.returnDataTable(getquestions);

        if (dTable.Rows.Count > 0)
        {
            questionsdiv.Visible = true;

            currrepeater.DataSource = dTable;
            currrepeater.DataBind();
        }
        else
        {
            questionsdiv.Visible = true;
            questionsdiv.InnerHtml = "<span style='color:#FF0000; font-size:15px;'>Nothing available at the moment</span>";
        }
    }

    //edit quiz
    protected void currrepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string allKeys = Convert.ToString(e.CommandArgument);

        string[] arrKeys = new string[1];
        char[] splitter = { '|' };
        arrKeys = allKeys.Split(splitter);

        if (e.CommandName == "edit")
        {
            Response.Redirect("editquestion?q=" + arrKeys[0], false);

        }
        else if (e.CommandName == "delete")
        {
            SqlCommand deletequestion = new SqlCommand("delete from " + quizquestionstable + " where id=@questionid");
            deletequestion.Parameters.AddWithValue("questionid", arrKeys[0]);

            db deleterequest = new db();
            deleterequest.ExecuteQuery(deletequestion);

            SqlCommand deletequestion1 = new SqlCommand("delete from " + quiztotalquestionstable + " where id=@questionid");
            deletequestion1.Parameters.AddWithValue("questionid", arrKeys[0]);

            db deleterequest1 = new db();
            deleterequest.ExecuteQuery(deletequestion1);

            bindquestions();
        }
    }
}