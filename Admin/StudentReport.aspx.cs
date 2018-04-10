using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

public partial class Admin_StudentReport : System.Web.UI.Page
{

    string ID = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["ID"] != null)
        {
            //txt_Nombre.Text = "Welcome: " + Session["user"].ToString();
            ID = Session["ID"].ToString();
            StudentReport(ID);
            emailreportdiv.Visible = true;
        }

    }


    public void StudentReport(string email)
    {
        DataTable dTable = new DataTable();
        SqlCommand cmd = new SqlCommand("select u.ID , u.nombres, u.primer_apellido, u.segundo_apellido , p.Nombre Provincia, c.Nombre Canton, d.Nombre Distrito, co.Nombre Colegio, u.sexo, FORMAT(u.fecha_nacimiento, 'dd-MM-yyyy') Fecha_Nacimiento, pa.Nombre Nacionalidad, u.cedula , FLOOR(DATEDIFF(DAY, u.fecha_nacimiento, GETDATE()) / 365.25) AS Edad from usuarios as u inner join provincias as p on u.provincia=p.ID_Provincia inner join cantones as c on u.canton=c.ID_Canton inner join distritos as d on u.distrito=d.ID_Distrito inner join colegios as co on u.colegio=co.ID_Colegio inner join paises as pa on u.nacionalidad=pa.ID_Pais where LOWER(u.ID)=@email ");
        cmd.Parameters.AddWithValue("email", email);

        db getquestionslist = new db();
        dTable = getquestionslist.returnDataTable(cmd);

        if (dTable.Rows.Count > 0)
        {
            GridViewEmail1.DataSource = dTable;
            GridViewEmail1.DataBind();
        }


        DataTable dTable1 = new DataTable();
        SqlCommand cmd1 = new SqlCommand("select q.quiz_name , q.question ,qq.category ,q.correct_answer , q.user_answer, q.accurate_answer ,FORMAT(q.lastupdated, 'dd-MM-yyyy') Fecha  from usuarios as u inner join quiz_responses as q on u.ID=q.userid inner join quiz_questions as qq on q.quizid=qq.quizid where LOWER(u.ID)=@email and q.question=qq.title group by u.nombres, q.quiz_name, q.question , q.correct_answer, q.user_answer ,q.accurate_answer, q.lastupdated, qq. category order by q.lastupdated DESC");
        cmd1.Parameters.AddWithValue("email", email);

        db getquestionslist1 = new db();
        dTable1 = getquestionslist1.returnDataTable(cmd1);



        if (dTable1.Rows.Count > 0)
        {
            GridViewEmail2.DataSource = dTable1;
            GridViewEmail2.DataBind();
        }

        SqlDataReader dReader;
        SqlCommand cmd2 = new SqlCommand("select u.nombres, q.quiz_name, q.question, q.correct_answer, q.user_answer,q.accurate_answer, q.lastupdated from usuarios as u inner join quiz_responses as q on u.ID=q.userid where LOWER(u.ID)=@email group by u.nombres, q.quiz_name, q.question , q.correct_answer, q.user_answer,q.accurate_answer ,q.lastupdated order by q.lastupdated DESC");
        cmd2.Parameters.AddWithValue("email", email);

        db count = new db();
        dReader = count.returnDataReader(cmd2);

        int correct_counter = 0;
        int bad_counter = 0;

        if (dReader.HasRows)
        {


            while (dReader.Read())
            {

                if (dReader["accurate_answer"].ToString() == "1")
                {
                    correct_counter++;
                }
                else if (dReader["accurate_answer"].ToString() == "0")
                {
                    bad_counter++;
                }

            }
        }

        txtcorrectemail.Visible = true;
        txtwrongemail.Visible = true;
        txtcorrectheaderemail.Visible = true;
        txtwrongheaderemail.Visible = true;
        txtcorrectheaderemail.Text = "Total Correctas";
        txtwrongheaderemail.Text = "Total Incorrectas";
        txtcorrectemail.Text = correct_counter.ToString();
        txtwrongemail.Text = bad_counter.ToString();
        txtcorrectheaderemail.Enabled = false;
        txtwrongheaderemail.Enabled = false;
        txtcorrectemail.Enabled = false;
        txtwrongemail.Enabled = false;

    }


}