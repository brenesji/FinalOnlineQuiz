using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Diagnostics;

public partial class _Default : Page
{
    string quizdetailstable = "quizdetails";
    string quizquestionstable = "quiz_questions";
    string quizresponsestable = "quiz_responses";
    string quizquestionoptionstable = "question_options";
    string quizquestionanswertable = "question_answer";
    string quizuserreponsetable = "question_responses";
    string quizname = "";
    string description = "";
    DateTime updatedate = new DateTime();
    DateTime start = new DateTime();
    DateTime end = new DateTime();
    string terms = "";
    string lbr = "<br /><br />";
    int quizId = 0;
    int tempval = 0;
    int amountquest = 0;
    int[] questionID; // Contains questions IDs
    int questcounter = 0;
    string question = "";
    string answer = "";
    string selectedanswer = "";
    string type = "";
    int numques = 0;
    public static Stopwatch sw;


    protected void Page_Load(object sender, EventArgs e)
    {
        updatedate = DateTime.Now;

        if (!Page.IsPostBack)
        {
            Image.Visible = false;
            txtanswer.Visible = false;
            lberror.Visible = false;
            lbMessage.Visible = false;
            btnExit.Visible = false;

            sw = new Stopwatch();
            sw.Start();

            //show quiz details
            Bindquizes();

            //show questions
            LoadQuestion();
 
        }
        else
        {
            if (int.TryParse(quizfield.Value, out tempval) == true)
            {
                quizId = tempval;
            }
        }

        //add javascript event
        //this.Form.DefaultButton = this.btnNext.UniqueID;
       //btnNext.Attributes.Add("onclick", "javascript: if ( Page_ClientValidate() ){" + btnNext.ClientID + ".disabled=true; " + btnNext.ClientID + ".value='Wait...';}" + ClientScript.GetPostBackEventReference(btnNext, ""));
    }

    //get the recent quizes
    protected void Bindquizes()
    {
        SqlDataReader dReader;
        SqlCommand getquizescmd = new SqlCommand("select id, name, description, startdate, enddate, termsandconditions from " + quizdetailstable);

        db getquizeslist = new db();
        dReader = getquizeslist.returnDataReader(getquizescmd);

       if (!dReader.HasRows)
      {
            lblmessage.Visible = true;
            lblmessage.Text = "Nothing available at the moment" + "<br /><br />";
        }
        else
        {
            while (dReader.Read())
            {
                //get and store quizid
                quizfield.Value = dReader["id"].ToString();
                quizId = Convert.ToInt32(quizfield.Value);

                Page.Session["quizid"] = quizId;

                //quiz details
                quizname = dReader["name"].ToString();
                Page.Session["quizname"] = quizname;

                description = dReader["description"].ToString();
                start = Convert.ToDateTime(dReader["startdate"].ToString());
                end = Convert.ToDateTime(dReader["enddate"].ToString());
                terms = dReader["termsandconditions"].ToString();

                //show quiz if start/end date is valid
                if ((updatedate < start) && (updatedate > end))
                {
                    lblmessage.Visible = true;
                    lblmessage.Text = "Sorry! We could not process your request. please try later.";
                }
                else
                {
                    lblquizname.Text = quizname;
                    lbldescription.Text = description;
                }
           }
        }
    }


    // Determines amount of questions of the quiz and get their IDs
    protected void LoadQuestion()
    {


        string databaseString = ConfigurationManager.ConnectionStrings["quizConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(databaseString);

        conn.Open();
        //Obtains amount of questions of the quiz
        SqlCommand numquestions = new SqlCommand("select count(*) from " + quizquestionstable + " where quizid='1'", conn);
        numques = Convert.ToInt32(numquestions.ExecuteScalar());

        conn.Close();


        questionID = new int [numques];
        Page.Session["numques"] = numques;
        DataTable dTable = new DataTable();
        //Get questions IDs
        SqlCommand getquestions = new SqlCommand("select id from " + quizquestionstable + " where quizid='1' order by questionorder ASC");

        db getquestionslist = new db();
        dTable = getquestionslist.returnDataTable(getquestions);

        int cont = 0;

        foreach (DataRow row in dTable.Rows)
        {
            questionID[cont] = row.Field<int>(0); //Pass questions IDs to array 
            cont++;
        }
                

        if (questcounter > numques-1)
        {
            Label1.Visible = false;
            lbldescription.Visible = false;
            Image.Visible = false;
            txtanswer.Visible = false;
            lberror.Visible = false;
            lbQuestion.Visible = false;
            multiplequestionsrpt.Visible = false;
            btnNext.Visible = false;
            lbMessage.Visible = true;
            lbMessage.Text = "Thank you for taking the test, please select exit to continue";
            btnExit.Visible = true;
        }
        else
        {
            StartQuiz();
        }

    }


    protected void StartQuiz()
    {

        SqlDataReader dreader;
            SqlCommand question = new SqlCommand("select title, type, data from " + quizquestionstable + " where id=@qID ");
            question.Parameters.AddWithValue("qID", questionID[questcounter]);

            db getorder = new db();
            dreader = getorder.returnDataReader(question);

            while (dreader.Read())
            {
                lbQuestion.Text = dreader["title"].ToString();
                Page.Session["question"] = dreader["title"].ToString();
                Byte[] tempdata = dreader["data"] as byte[];
                type = dreader["type"].ToString();
                Page.Session["type"] = type;


                if (tempdata != null)
                {
                    string base64String = Convert.ToBase64String(tempdata, 0, tempdata.Length);
                    Image.ImageUrl = "data:image/jpeg;base64," + base64String;
                    Image.Visible = true;
                }

                if (type == "multiple")
                {
                    BindQuestionsMultipleOption();

                }
                else
                {
                    BindQuestionsSingleOption();
                }

                questcounter++;
                Page.Session["questcounter"] = questcounter;

        }

    }






    protected void BindQuestionsMultipleOption()
    {
        DataTable dTable = new DataTable();
        SqlCommand getquestions = new SqlCommand("select id, title from " + quizquestionstable + " where id=@id and type='multiple'");
        getquestions.Parameters.AddWithValue("id", questionID[questcounter]);

        db getquestionslist = new db();
        dTable = getquestionslist.returnDataTable(getquestions);

        SqlDataReader dreaderanswer;
        SqlCommand getanswer = new SqlCommand("select a.questionoption from " + quizquestionoptionstable + " as a inner join " + quizquestionanswertable + " as b on b.optionid=a.id where a.questionid=@questionid");
        getanswer.Parameters.AddWithValue("questionid", questionID[questcounter]);

        db validateanswer = new db();
        dreaderanswer = validateanswer.returnDataReader(getanswer);

        while (dreaderanswer.Read())
        {
            answer = dreaderanswer["questionoption"].ToString();
            Page.Session["answer"] = answer;
        }

        multiplequestionsrpt.DataSource = dTable;
        multiplequestionsrpt.DataBind();

      
    }


    protected void multiplequestionsrpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        int qid = 0;
        txtanswer.Visible = false;
        multiplequestionsrpt.Visible = true;

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //get the questionid
            HiddenField hfl = (HiddenField)e.Item.FindControl("hfID");
            qid = Convert.ToInt32(hfl.Value);

            //get the options for this questionid
            RadioButtonList rbl = (RadioButtonList)e.Item.FindControl("rbloptions");
            DataTable qTable = new DataTable();
            SqlCommand getoptions = new SqlCommand("select id, questionoption from " + quizquestionoptionstable + " where questionid=@questionid");
            getoptions.Parameters.AddWithValue("questionid", qid);

            db getoptionslist = new db();
            qTable = getoptionslist.returnDataTable(getoptions);


            if (qTable.Rows.Count > 0)
            {
                rbl.DataSource = qTable;
                rbl.DataTextField = "questionoption";
                rbl.DataValueField = "id";
                rbl.DataBind();
            }


        }


    }


    //get single option questions
    protected void BindQuestionsSingleOption()
    {

        multiplequestionsrpt.Visible = false;
        txtanswer.Visible = true;

        int questionorder = 0;

        questionorder = questionID[questcounter];

        SqlDataReader dreaderanswer;
        SqlCommand getanswer = new SqlCommand("select a.questionoption from " + quizquestionoptionstable + " as a inner join " + quizquestionanswertable + " as b on a.questionid=b.questionid where a.questionid=@questionid");
        getanswer.Parameters.AddWithValue("questionid", questionorder);

        db validateanswer = new db();
        dreaderanswer = validateanswer.returnDataReader(getanswer);

        while (dreaderanswer.Read())
        {
        answer = dreaderanswer["questionoption"].ToString();
        Page.Session["answer"] = answer;

        }


    }

    


    protected void txtanswer_TextChanged(object sender, EventArgs e)
    {

        string answerstr = "";
        lberror.Visible = false;

        Page.Validate();
        if (Page.IsValid)
        {
            string reqcontrol = getPostBackControlName();

            if (reqcontrol == "txtanswer")
            {
                answer = Page.Session["answer"].ToString();
                answerstr = txtanswer.Text.Trim();
                bool val = System.Text.RegularExpressions.Regex.IsMatch(answer, @"\d");
                bool val1 = System.Text.RegularExpressions.Regex.IsMatch(answerstr, @"\d");

                if (val == true & val1 == false)
                {
                        lberror.Visible = true;
                        lberror.Text = "Response only allow numbers";
                        txtanswer.Text = null;  
                }

                else if (val == false & val1 == true)
                {
                    lberror.Visible = true;
                    lberror.Text = "Response only allow text";
                    txtanswer.Text = null;

                }

            }

            selectedanswer = txtanswer.Text;
            Page.Session["selectedanswer"] = selectedanswer;

        }

    }


    protected void btnNext_Click(object sender, EventArgs e)
    {
        type = Page.Session["type"].ToString();

        if (type == "multiple")
        {
            foreach (RepeaterItem item in multiplequestionsrpt.Items)
            {
                // Checking the item is a data item
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {

                    // get the submitted answer
                    var rdbList = item.FindControl("rbloptions") as RadioButtonList;
                    selectedanswer = rdbList.SelectedItem.ToString();
                    Page.Session["selectedanswer"] = selectedanswer;
                }

           }

        }

        answer = Page.Session["answer"].ToString();
        question = Page.Session["question"].ToString();
        quizId = Convert.ToInt32(Page.Session["quizid"]);
        selectedanswer = Page.Session["selectedanswer"].ToString();
        quizname = Page.Session["quizname"].ToString();


        string accurateanswer = "";

        if (selectedanswer == answer)
        {
            accurateanswer = "Y";
        }
        else
        {
            accurateanswer = "N";
        }


        SqlCommand insertnew = new SqlCommand("insert into " + quizresponsestable + " (quizid, userid, question, user_answer, correct_answer, accurate_answer, quiz_name, lastupdated) values (@quizid, 'mcgusd@hotmail.com', @question, @user_answer, @correct_answer, @accurate_answer, @quiz_name, @lastupdated);SELECT CAST(scope_identity() AS int)");
        insertnew.Parameters.AddWithValue("quizid", quizId);
        //insertnew.Parameters.AddWithValue("userid", qorder);
        insertnew.Parameters.AddWithValue("question", question);
        insertnew.Parameters.AddWithValue("user_answer", selectedanswer);
        insertnew.Parameters.AddWithValue("correct_answer", answer);
        insertnew.Parameters.AddWithValue("accurate_answer", accurateanswer);
        insertnew.Parameters.AddWithValue("quiz_name", quizname);
        insertnew.Parameters.AddWithValue("lastupdated", updatedate);

        db insertnewquestion = new db();
        insertnewquestion.ExecuteQuery(insertnew);

        lberror.Visible = false;
        Image.Visible = false;
        txtanswer.Text = null;
        questcounter = Convert.ToInt32(Page.Session["questcounter"]);
        numques = Convert.ToInt32(Page.Session["numques"]);
        LoadQuestion();

    }


    protected void tm1_Tick(object sender, EventArgs e)
    {
       long sec = sw.Elapsed.Seconds;
       long min = sw.Elapsed.Minutes;

        if (min < 60)
        {
            if (min < 10)
                Label1.Text = "0" + min;
            else
              Label1.Text = min.ToString();

            Label1.Text += " : ";

            if (sec < 10)
                Label1.Text += "0" + sec;
            else
                Label1.Text += sec.ToString();
        }

      
        else
        {
            sw.Stop();
            Response.Redirect("~/Admin/Menu.aspx", true);


        }

    }



    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Menu.aspx", true);
    }


    //quiz answers submitted
    /* protected void btnsubmit_Click(object sender, EventArgs e)
     {
         SqlDataReader dReader;
         string email = "";
         string name = "";
         string selectedanswer = "";
         string correctanswer = "";
         int questionId = 0;
         int questionscount = 0;
         int correctcount = 0;
         int wrongcount = 0;
         int success = 0;
         ArrayList answersList = new ArrayList();

         Page.Validate();
         if (Page.IsValid)
         {
             email = txtemail.Text.Trim();
             name = txtname.Text.Trim();

             //check if this account has already taken the quiz.
             DataTable accounts = new DataTable();
             SqlCommand checkentrycmd = new SqlCommand("select * from " + quizresponsestable + " where quizid=@quizid and email=@email");
             checkentrycmd.Parameters.AddWithValue("quizid", quizId);
             checkentrycmd.Parameters.AddWithValue("email", email);

             db checkentry = new db();
             accounts = checkentry.returnDataTable(checkentrycmd);

             if (accounts.Rows.Count > 0)
             {
                 quizdetails.Visible = false;
                 detailsdiv.Visible = false;
                 questionsdiv.Visible = false;
                 lblmessage.Visible = true;
                 lblmessage.Text = "You have already taken this quiz!";
             }
             else
             {
                 foreach (RepeaterItem item in multiplequestionsrpt.Items)
                 {
                     // Checking the item is a data item
                     if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                     {
                         //get the questionid
                         var hfId = item.FindControl("hfID") as HiddenField;
                         questionId = Convert.ToInt32(hfId.Value);

                         //get the submitted answer
                         var rdbList = item.FindControl("rbloptions") as RadioButtonList;
                         selectedanswer = rdbList.SelectedValue;
                         //disable to prevent submitting again
                         rdbList.Enabled = false;

                         //get the correct answer
                         SqlCommand getanswercmd = new SqlCommand("select optionid from " + quizquestionanswertable + " where questionid=@questionid");
                         getanswercmd.Parameters.AddWithValue("questionid", questionId);

                         db getanswer = new db();
                         dReader = getanswer.returnDataReader(getanswercmd);

                         if (!dReader.HasRows)
                         {
                             //can't find this question/answer
                         }
                         else
                         {
                             while (dReader.Read())
                             {
                                 correctanswer = dReader["optionid"].ToString();
                             }
                         }

                         //compare both answers
                         if (selectedanswer == correctanswer)
                         {
                             correctcount++;
                             rdbList.SelectedItem.Attributes.Add("style", "color: #006400");
                         }
                         else
                         {
                             wrongcount++;
                             rdbList.SelectedItem.Attributes.Add("style", "color: #ff0000");
                             rdbList.Items.FindByValue(correctanswer).Attributes.Add("style", "color: #006400");
                         }

                         //add the submitted answer to list
                         answersList.Add(new string[] { questionId.ToString(), selectedanswer });
                     }
                 }

                 //create entry
                 SqlCommand insertentrycmd = new SqlCommand("insert into " + quizresponsestable + " (quizid, email, name, correctanswers, wronganswers, lastupdated) values (@quizid, @email, @name, @correctanswers, @wronganswers, @lastupdated);SELECT CAST(scope_identity() AS int)");
                 insertentrycmd.Parameters.AddWithValue("quizid", quizId);
                 insertentrycmd.Parameters.AddWithValue("email", email);
                 insertentrycmd.Parameters.AddWithValue("name", name);
                 insertentrycmd.Parameters.AddWithValue("correctanswers", correctcount);
                 insertentrycmd.Parameters.AddWithValue("wronganswers", wrongcount);
                 insertentrycmd.Parameters.AddWithValue("lastupdated", updatedate);

                 db insertentry = new db();
                 success = insertentry.ReturnIDonExecuteQuery(insertentrycmd);

                 //display the result on screen
                 if (success > 0)
                 {
                     foreach (string[] arr in answersList)
                     {
                         SqlCommand insertresponsecmd = new SqlCommand("insert into " + quizuserreponsetable + " (responseid, questionid, optionid, lastupdated) values (@responseid, @questionid, @optionid, @lastupdated)");
                         insertresponsecmd.Parameters.Clear();
                         insertresponsecmd.Parameters.AddWithValue("responseid", success);
                         insertresponsecmd.Parameters.AddWithValue("questionid", arr[0].ToString());
                         insertresponsecmd.Parameters.AddWithValue("optionid", arr[1].ToString());
                         insertresponsecmd.Parameters.AddWithValue("lastupdated", updatedate);

                         db insertresponses = new db();
                         insertresponses.ExecuteQuery(insertresponsecmd);
                     }

                     detailsdiv.Visible = false;
                     questionscount = correctcount + wrongcount;
                     lblalert.Visible = true;

                     //get the completion description from database table
                     SqlDataReader Treader;
                     SqlCommand getcompletiondesc = new SqlCommand("select completiondescription from " + quizdetailstable + " where id=@quizid");
                     getcompletiondesc.Parameters.AddWithValue("quizid", quizId);

                     db getdesc = new db();
                     Treader = getdesc.returnDataReader(getcompletiondesc);

                     if (!Treader.HasRows)
                     {
                         lblalert.Text = "Thanks for taking the Quiz." + "<br />" + "You have answered <span style='color:#006400;'>" + correctcount + "</span> questions correctly out of " + questionscount + "<br />";
                     }
                     else
                     {
                         while (Treader.Read())
                         {
                             string completiondesc = Treader["completiondescription"].ToString();
                             lblalert.Text = completiondesc + "<br />" + "You have answered <span style='color:#006400;'>" + correctcount + "</span> questions correctly out of " + questionscount + "<br />";
                         }
                     }


                     btnsubmit.Visible = false;
                 }
                 else
                 {
                     lblalert.Visible = true;
                     lblalert.Text = "Sorry! we could not process your request. Please try again.";
                 }
             }
         }
         else
         {
             lblalert.Visible = true;
             lblalert.Text = "Please answer all the questions!";
         }
     }

     */


    //populate the options for each question




    /*

        //populate the options for each question
        protected void singlequestionsrpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            TextBox[] MyTextBox = new TextBox[1];

            for (int i = 0; i < 1; i++)
            {
                MyTextBox[i] = new TextBox();
                // MyTextBox.ID = "txtanswer" + i;
                // MyTextBox.Width = 540;
                // MyTextBox.Height = 60;
                // MyTextBox.TextMode = TextBoxMode.MultiLine;
                singlequestionsrpt.Controls.Add(MyTextBox[i]);
            }



            /* int qid = 0;

             if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
             {
                 //get the questionid
                 HiddenField hfl = (HiddenField)e.Item.FindControl("hfID");
                 qid = Convert.ToInt32(hfl.Value);

                 //get the options for this questionid
                 RadioButtonList rbl = (RadioButtonList)e.Item.FindControl("rbloptions");
                 DataTable qTable = new DataTable();
                 SqlCommand getoptions = new SqlCommand("select id, questionoption from " + quizquestionoptionstable + " where questionid=@questionid");
                 getoptions.Parameters.AddWithValue("questionid", qid);

                 db getoptionslist = new db();
                 qTable = getoptionslist.returnDataTable(getoptions);

                 if (qTable.Rows.Count > 0)
                 {
                     rbl.DataSource = qTable;
                     rbl.DataTextField = "questionoption";
                     rbl.DataValueField = "id";
                     rbl.DataBind();
                 }
             }*/



    //get the control that cause postback
    private string getPostBackControlName()
    {
        string controlid = "";
        Control control = null;
        //first we will check the "__EVENTTARGET" because if post back made by the controls
        //which used "_doPostBack" function also available in Request.Form collection.

        string ctrlname = Page.Request.Params["__EVENTTARGET"];
        if (ctrlname != null && ctrlname != String.Empty)
        {
            control = Page.FindControl(ctrlname);
        }

        // if __EVENTTARGET is null, the control is a button type and we need to
        // iterate over the form collection to find it
        else
        {
            string ctrlStr = String.Empty;
            Control c = null;
            foreach (string ctl in Page.Request.Form)
            {
                //handle ImageButton they having an additional "quasi-property" in their Id which identifies
                //mouse x and y coordinates
                if (ctl.EndsWith(".x") || ctl.EndsWith(".y"))
                {
                    ctrlStr = ctl.Substring(0, ctl.Length - 2);
                    c = Page.FindControl(ctrlStr);
                }
                else
                {
                    c = Page.FindControl(ctl);
                }
                if (c is System.Web.UI.WebControls.Button ||
                         c is System.Web.UI.WebControls.ImageButton)
                {
                    control = c;
                    break;
                }
            }
        }
        if (control == null)
        {
            controlid = "pageload";
        }
        else
        {
            controlid = control.ID.ToString();
        }
        return controlid;
    }













   
}