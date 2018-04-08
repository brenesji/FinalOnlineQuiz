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

public partial class Admin_Reports : System.Web.UI.Page
{
    string reporttype = "";



    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Report_Changed(object sender, EventArgs e)
    {
        reporttype = ddlReport.SelectedItem.Text.ToLower();

        if (reporttype == "por nombre")
        {
            namereportdiv.Visible = true;
            emailreportdiv.Visible = false;
            studentsreportdiv.Visible = false;
            addressreportdiv.Visible = false;
            schoolreportdiv.Visible = false;
            genderreportdiv.Visible = false;

        }
        else if (reporttype == "por correo electronico")
        {
            namereportdiv.Visible = false;
            emailreportdiv.Visible = true;
            studentsreportdiv.Visible = false;
            addressreportdiv.Visible = false;
            schoolreportdiv.Visible = false;
            genderreportdiv.Visible = false;
        }
        else if (reporttype == "por estudiantes por fecha")
        {
            namereportdiv.Visible = false;
            emailreportdiv.Visible = false;
            studentsreportdiv.Visible = true;
            addressreportdiv.Visible = false;
            schoolreportdiv.Visible = false;
            genderreportdiv.Visible = false;
            FechaStudents1.Visible = true;
            FechaStudents2.Visible = true;
        }
        else if (reporttype == "por direccion por fecha")
        {
            namereportdiv.Visible = false;
            emailreportdiv.Visible = false;
            studentsreportdiv.Visible = false;
            addressreportdiv.Visible = true;
            schoolreportdiv.Visible = false;
            genderreportdiv.Visible = false;
            FechaStudents1.Visible = false;
            FechaStudents2.Visible = false;
            FechaAddress1.Visible = true;
            FechaAddress2.Visible = true;
            Add_Provincia();
        }
        else if (reporttype == "por colegio por fecha")
        {
            namereportdiv.Visible = false;
            emailreportdiv.Visible = false;
            studentsreportdiv.Visible = false;
            addressreportdiv.Visible = false;
            schoolreportdiv.Visible = true;
            genderreportdiv.Visible = false;
            FechaStudents1.Visible = false;
            FechaStudents2.Visible = false;
            FechaAddress1.Visible = false;
            FechaAddress2.Visible = false;
            FechaSchool1.Visible = true;
            FechaSchool2.Visible = true;
            Add_Institucion();
        }
        else if (reporttype == "por sexo por fecha")
        {
            namereportdiv.Visible = false;
            emailreportdiv.Visible = false;
            studentsreportdiv.Visible = false;
            addressreportdiv.Visible = false;
            schoolreportdiv.Visible = false;
            genderreportdiv.Visible = true;
            FechaStudents1.Visible = false;
            FechaStudents2.Visible = false;
            FechaAddress1.Visible = false;
            FechaAddress2.Visible = false;
            FechaSchool1.Visible = false;
            FechaSchool2.Visible = false;
            FechaGender1.Visible = true;
            FechaGender2.Visible = true;

        }




    }


    protected void namereportsubmit_Click(object sender, EventArgs e)
    {


        DataTable dTable = new DataTable();
        SqlCommand cmd = new SqlCommand("select u.ID , u.nombres, u.primer_apellido, u.segundo_apellido , p.Nombre Provincia, c.Nombre Canton, d.Nombre Distrito, co.Nombre Colegio, u.sexo, FORMAT(u.fecha_nacimiento, 'dd-MM-yyyy') Fecha_Nacimiento, pa.Nombre Nacionalidad, u.cedula , FLOOR(DATEDIFF(DAY, u.fecha_nacimiento, GETDATE()) / 365.25) AS Edad from usuarios as u inner join provincias as p on u.provincia=p.ID_Provincia inner join cantones as c on u.canton=c.ID_Canton inner join distritos as d on u.distrito=d.ID_Distrito inner join colegios as co on u.colegio=co.ID_Colegio inner join paises as pa on u.nacionalidad=pa.ID_Pais where LOWER(u.nombres)=@nombre ");
        cmd.Parameters.AddWithValue("nombre", txtname.Text.Trim().ToLower());

        db getquestionslist = new db();
        dTable = getquestionslist.returnDataTable(cmd);

        if (dTable.Rows.Count > 0)
        {
            GridViewName1.DataSource = dTable;
            GridViewName1.DataBind();
        }


        DataTable dTable1 = new DataTable();
        SqlCommand cmd1 = new SqlCommand("select q.quiz_name , q.question ,qq.category ,q.correct_answer , q.user_answer, q.accurate_answer ,FORMAT(q.lastupdated, 'dd-MM-yyyy') Fecha  from usuarios as u inner join quiz_responses as q on u.ID=q.userid inner join quiz_questions as qq on q.quizid=qq.quizid where LOWER(u.nombres)=@nombre and q.question=qq.title group by u.nombres, q.quiz_name, q.question , q.correct_answer, q.user_answer ,q.accurate_answer, q.lastupdated, qq. category order by q.lastupdated DESC");
        cmd1.Parameters.AddWithValue("nombre", txtname.Text.Trim().ToLower());

        db getquestionslist1 = new db();
        dTable1 = getquestionslist1.returnDataTable(cmd1);

       

        if (dTable1.Rows.Count > 0)
        {
            GridViewName2.DataSource = dTable1;
            GridViewName2.DataBind();
        }

        SqlDataReader dReader;
        SqlCommand cmd2 = new SqlCommand("select u.nombres, q.quiz_name, q.question, q.correct_answer, q.user_answer,q.accurate_answer, q.lastupdated from usuarios as u inner join quiz_responses as q on u.ID=q.userid where LOWER(u.nombres)=@nombre group by u.nombres, q.quiz_name, q.question , q.correct_answer, q.user_answer,q.accurate_answer ,q.lastupdated order by q.lastupdated DESC");
        cmd2.Parameters.AddWithValue("nombre", txtname.Text.Trim().ToLower());

        db count = new db();
        dReader = count.returnDataReader(cmd2);

        int correct_counter = 0;
        int bad_counter = 0;

        if (dReader.HasRows)
        {


            while (dReader.Read())
            {

                if (dReader["accurate_answer"].ToString() == "Y")
                {
                    correct_counter++;
                }
                else if (dReader["accurate_answer"].ToString() == "N")
                {
                    bad_counter++;
                }

            }
        }

        txtcorrectname.Visible = true;
        txtwrongname.Visible = true;
        txtcorrectheadername.Visible = true;
        txtwrongheadername.Visible = true;
        txtcorrectheadername.Text = "Total Correctas";
        txtwrongheadername.Text = "Total Incorrectas";
        txtcorrectname.Text = correct_counter.ToString();
        txtwrongname.Text = bad_counter.ToString();
        txtcorrectheadername.Enabled = false;
        txtwrongheadername.Enabled = false;
        txtcorrectname.Enabled = false;
        txtwrongname.Enabled = false;
    }


    protected void emailreportsubmit_Click(object sender, EventArgs e)
    {


        DataTable dTable = new DataTable();
        SqlCommand cmd = new SqlCommand("select u.ID , u.nombres, u.primer_apellido, u.segundo_apellido , p.Nombre Provincia, c.Nombre Canton, d.Nombre Distrito, co.Nombre Colegio, u.sexo, FORMAT(u.fecha_nacimiento, 'dd-MM-yyyy') Fecha_Nacimiento, pa.Nombre Nacionalidad, u.cedula , FLOOR(DATEDIFF(DAY, u.fecha_nacimiento, GETDATE()) / 365.25) AS Edad from usuarios as u inner join provincias as p on u.provincia=p.ID_Provincia inner join cantones as c on u.canton=c.ID_Canton inner join distritos as d on u.distrito=d.ID_Distrito inner join colegios as co on u.colegio=co.ID_Colegio inner join paises as pa on u.nacionalidad=pa.ID_Pais where LOWER(u.ID)=@email ");
        cmd.Parameters.AddWithValue("email", txtemail.Text.Trim().ToLower());

        db getquestionslist = new db();
        dTable = getquestionslist.returnDataTable(cmd);

        if (dTable.Rows.Count > 0)
        {
            GridViewEmail1.DataSource = dTable;
            GridViewEmail1.DataBind();
        }


        DataTable dTable1 = new DataTable();
        SqlCommand cmd1 = new SqlCommand("select q.quiz_name , q.question ,qq.category ,q.correct_answer , q.user_answer, q.accurate_answer ,FORMAT(q.lastupdated, 'dd-MM-yyyy') Fecha  from usuarios as u inner join quiz_responses as q on u.ID=q.userid inner join quiz_questions as qq on q.quizid=qq.quizid where LOWER(u.ID)=@email and q.question=qq.title group by u.nombres, q.quiz_name, q.question , q.correct_answer, q.user_answer ,q.accurate_answer, q.lastupdated, qq. category order by q.lastupdated DESC");
        cmd1.Parameters.AddWithValue("email", txtemail.Text.Trim().ToLower());

        db getquestionslist1 = new db();
        dTable1 = getquestionslist1.returnDataTable(cmd1);



        if (dTable1.Rows.Count > 0)
        {
            GridViewEmail2.DataSource = dTable1;
            GridViewEmail2.DataBind();
        }

        SqlDataReader dReader;
        SqlCommand cmd2 = new SqlCommand("select u.nombres, q.quiz_name, q.question, q.correct_answer, q.user_answer,q.accurate_answer, q.lastupdated from usuarios as u inner join quiz_responses as q on u.ID=q.userid where LOWER(u.ID)=@email group by u.nombres, q.quiz_name, q.question , q.correct_answer, q.user_answer,q.accurate_answer ,q.lastupdated order by q.lastupdated DESC");
        cmd2.Parameters.AddWithValue("email", txtemail.Text.Trim().ToLower());

        db count = new db();
        dReader = count.returnDataReader(cmd2);

        int correct_counter = 0;
        int bad_counter = 0;

        if (dReader.HasRows)
        {


            while (dReader.Read())
            {

                if (dReader["accurate_answer"].ToString() == "Y")
                {
                    correct_counter++;
                }
                else if (dReader["accurate_answer"].ToString() == "N")
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



    protected void studentsreportsubmit_Click(object sender, EventArgs e)
    {


        DataTable dTable = new DataTable();
        SqlCommand cmd = new SqlCommand("select distinct u.ID , u.nombres, u.primer_apellido, u.segundo_apellido , p.Nombre Provincia, c.Nombre Canton, d.Nombre Distrito, co.Nombre Colegio, u.sexo, FORMAT(u.fecha_nacimiento, 'dd-MM-yyyy') Fecha_Nacimiento, pa.Nombre Nacionalidad, u.cedula , FLOOR(DATEDIFF(DAY, u.fecha_nacimiento, GETDATE()) / 365.25) AS Edad from usuarios as u inner join provincias as p on u.provincia=p.ID_Provincia inner join cantones as c on u.canton=c.ID_Canton inner join distritos as d on u.distrito=d.ID_Distrito inner join colegios as co on u.colegio=co.ID_Colegio inner join paises as pa on u.nacionalidad=pa.ID_Pais inner join quiz_responses as q on u.ID=q.userid where q.lastupdated>@datefrom and q.lastupdated<@dateto");
        cmd.Parameters.AddWithValue("datefrom", txtdatefrom.Text.Trim().ToLower());
        cmd.Parameters.AddWithValue("dateto", txtdateto.Text.Trim().ToLower());

        db getquestionslist = new db();
        dTable = getquestionslist.returnDataTable(cmd);

        if (dTable.Rows.Count > 0)
        {
            GridViewStudents1.DataSource = dTable;
            GridViewStudents1.DataBind();
        }


    }

    protected void GridStudents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ver")
        {
            string ID = e.CommandArgument.ToString();

            Session["ID"] = ID;
            Response.Redirect("~/Admin/StudentReport.aspx", true);
            
        }

    }


    protected void GridAddress_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ver")
        {
            string ID = e.CommandArgument.ToString();

            Session["ID"] = ID;
            Response.Redirect("~/Admin/StudentReport.aspx", true);

        }

    }

    protected void GridSchool_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ver")
        {
            string ID = e.CommandArgument.ToString();

            Session["ID"] = ID;
            Response.Redirect("~/Admin/StudentReport.aspx", true);

        }

    }


    protected void GridGender_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ver")
        {
            string ID = e.CommandArgument.ToString();

            Session["ID"] = ID;
            Response.Redirect("~/Admin/StudentReport.aspx", true);

        }

    }

    protected void addressreportsubmit_Click(object sender, EventArgs e)
    {


        DataTable dTable = new DataTable();
        SqlCommand cmd = new SqlCommand("select q.userid, u.nombres, u.primer_apellido, u.segundo_apellido, p.Nombre Provincia, c.Nombre Canton, d.Nombre Distrito from usuarios as u inner join provincias as p on u.provincia=p.ID_Provincia inner join cantones as c on u.canton=c.ID_Canton inner join distritos as d on u.distrito=d.ID_Distrito inner join colegios as co on u.colegio=co.ID_Colegio inner join paises as pa on u.nacionalidad=pa.ID_Pais inner join quiz_responses as q on u.ID=q.userid where p.Nombre=@provincia and c.Nombre=@canton and d.Nombre=@distrito and q.lastupdated>@datefrom and q.lastupdated<@dateto group by q.userid, p.Nombre, c.Nombre , d.Nombre, u.nombres, u.primer_apellido, u.segundo_apellido");
        cmd.Parameters.AddWithValue("datefrom", txtdatefromaddress.Text.Trim().ToLower());
        cmd.Parameters.AddWithValue("dateto", txtdatetoaddress.Text.Trim().ToLower());
        cmd.Parameters.AddWithValue("provincia", DropDownList_Provincia.SelectedItem.Text);
        cmd.Parameters.AddWithValue("canton", DropDownList_Canton.SelectedItem.Text);
        cmd.Parameters.AddWithValue("distrito", DropDownList_Distrito.SelectedItem.Text);

        db getquestionslist = new db();
        dTable = getquestionslist.returnDataTable(cmd);

        if (dTable.Rows.Count > 0)
        {
            GridViewAddress1.DataSource = dTable;
            GridViewAddress1.DataBind();
        }


        SqlDataReader dReader;
        SqlCommand cmd1 = new SqlCommand("select q.userid, u.nombres, u.primer_apellido, u.segundo_apellido, p.Nombre Provincia, c.Nombre Canton, d.Nombre Distrito from usuarios as u inner join provincias as p on u.provincia=p.ID_Provincia inner join cantones as c on u.canton=c.ID_Canton inner join distritos as d on u.distrito=d.ID_Distrito inner join colegios as co on u.colegio=co.ID_Colegio inner join paises as pa on u.nacionalidad=pa.ID_Pais inner join quiz_responses as q on u.ID=q.userid where p.Nombre=@provincia and c.Nombre=@canton and d.Nombre=@distrito and q.lastupdated>@datefrom and q.lastupdated<@dateto group by q.userid, p.Nombre, c.Nombre , d.Nombre, u.nombres, u.primer_apellido, u.segundo_apellido");
        cmd1.Parameters.AddWithValue("datefrom", txtdatefromaddress.Text.Trim().ToLower());
        cmd1.Parameters.AddWithValue("dateto", txtdatetoaddress.Text.Trim().ToLower());
        cmd1.Parameters.AddWithValue("provincia", DropDownList_Provincia.SelectedItem.Text);
        cmd1.Parameters.AddWithValue("canton", DropDownList_Canton.SelectedItem.Text);
        cmd1.Parameters.AddWithValue("distrito", DropDownList_Distrito.SelectedItem.Text);

        db count = new db();
        dReader = count.returnDataReader(cmd1);

        int counter = 0;
   

        if (dReader.HasRows)
        {


            while (dReader.Read())
            {

                if (dReader["userid"].ToString() != null)
                {
                    counter++;
                }


            }

        }


        txtcounterheaderaddress.Visible = true;
        txtcounteraddress.Visible = true;
        txtcounterheaderaddress.Text = "Total Estudiantes";
        txtcounteraddress.Text = counter.ToString();
        txtcounterheaderaddress.Enabled = false;
        txtcounteraddress.Enabled = false;


    }



    protected void schoolsreportsubmit_Click(object sender, EventArgs e)
    {


        DataTable dTable = new DataTable();
        SqlCommand cmd = new SqlCommand("select q.userid, u.nombres, u.primer_apellido, u.segundo_apellido, co.Nombre Colegio from usuarios as u inner join provincias as p on u.provincia=p.ID_Provincia inner join cantones as c on u.canton=c.ID_Canton inner join distritos as d on u.distrito=d.ID_Distrito inner join colegios as co on u.colegio=co.ID_Colegio inner join paises as pa on u.nacionalidad=pa.ID_Pais inner join quiz_responses as q on u.ID=q.userid where co.Nombre=@school and q.lastupdated>@datefrom and q.lastupdated<@dateto group by q.userid, co.Nombre , u.nombres, u.primer_apellido, u.segundo_apellido");
        cmd.Parameters.AddWithValue("datefrom", txtdatefromschool.Text.Trim().ToLower());
        cmd.Parameters.AddWithValue("dateto", txtdatetoschool.Text.Trim().ToLower());
        cmd.Parameters.AddWithValue("school", DropDownList_HighSchool.SelectedItem.Text);


        db getquestionslist = new db();
        dTable = getquestionslist.returnDataTable(cmd);

        if (dTable.Rows.Count > 0)
        {
            GridViewSchool1.DataSource = dTable;
            GridViewSchool1.DataBind();
        }


        SqlDataReader dReader;
        SqlCommand cmd1 = new SqlCommand("select q.userid, u.nombres, u.primer_apellido, u.segundo_apellido, co.Nombre Colegio from usuarios as u inner join provincias as p on u.provincia=p.ID_Provincia inner join cantones as c on u.canton=c.ID_Canton inner join distritos as d on u.distrito=d.ID_Distrito inner join colegios as co on u.colegio=co.ID_Colegio inner join paises as pa on u.nacionalidad=pa.ID_Pais inner join quiz_responses as q on u.ID=q.userid where co.Nombre=@school and q.lastupdated>@datefrom and q.lastupdated<@dateto group by q.userid, co.Nombre , u.nombres, u.primer_apellido, u.segundo_apellido");
        cmd1.Parameters.AddWithValue("datefrom", txtdatefromschool.Text.Trim().ToLower());
        cmd1.Parameters.AddWithValue("dateto", txtdatetoschool.Text.Trim().ToLower());
        cmd1.Parameters.AddWithValue("school", DropDownList_HighSchool.SelectedItem.Text);

        db count = new db();
        dReader = count.returnDataReader(cmd1);

        int counter = 0;


        if (dReader.HasRows)
        {


            while (dReader.Read())
            {

                if (dReader["userid"].ToString() != null)
                {
                    counter++;
                }


            }

        }


        txtcounterheaderschool.Visible = true;
        txtcounterschool.Visible = true;
        txtcounterheaderschool.Text = "Total Estudiantes";
        txtcounterschool.Text = counter.ToString();
        txtcounterheaderschool.Enabled = false;
        txtcounterschool.Enabled = false;


    }



    protected void genderreportsubmit_Click(object sender, EventArgs e)
    {


        DataTable dTable = new DataTable();
        SqlCommand cmd = new SqlCommand("select q.userid, u.nombres, u.primer_apellido, u.segundo_apellido, u.sexo from usuarios as u inner join provincias as p on u.provincia=p.ID_Provincia inner join cantones as c on u.canton=c.ID_Canton inner join distritos as d on u.distrito=d.ID_Distrito inner join colegios as co on u.colegio=co.ID_Colegio inner join paises as pa on u.nacionalidad=pa.ID_Pais inner join quiz_responses as q on u.ID=q.userid where u.sexo=@gender and q.lastupdated>@datefrom and q.lastupdated<@dateto group by q.userid, u.sexo , u.nombres, u.primer_apellido, u.segundo_apellido");
        cmd.Parameters.AddWithValue("datefrom", txtdatefromgender.Text.Trim().ToLower());
        cmd.Parameters.AddWithValue("dateto", txtdatetogender.Text.Trim().ToLower());
        cmd.Parameters.AddWithValue("gender", DropDownList_Gender.SelectedValue);


        db getquestionslist = new db();
        dTable = getquestionslist.returnDataTable(cmd);

        if (dTable.Rows.Count > 0)
        {
            GridViewGender1.DataSource = dTable;
            GridViewGender1.DataBind();
        }


        SqlDataReader dReader;
        SqlCommand cmd1 = new SqlCommand("select q.userid, u.nombres, u.primer_apellido, u.segundo_apellido, u.sexo from usuarios as u inner join provincias as p on u.provincia=p.ID_Provincia inner join cantones as c on u.canton=c.ID_Canton inner join distritos as d on u.distrito=d.ID_Distrito inner join colegios as co on u.colegio=co.ID_Colegio inner join paises as pa on u.nacionalidad=pa.ID_Pais inner join quiz_responses as q on u.ID=q.userid where u.sexo=@gender and q.lastupdated>@datefrom and q.lastupdated<@dateto group by q.userid, u.sexo , u.nombres, u.primer_apellido, u.segundo_apellido");
        cmd1.Parameters.AddWithValue("datefrom", txtdatefromgender.Text.Trim().ToLower());
        cmd1.Parameters.AddWithValue("dateto", txtdatetogender.Text.Trim().ToLower());
        cmd1.Parameters.AddWithValue("gender", DropDownList_Gender.SelectedValue);

        db count = new db();
        dReader = count.returnDataReader(cmd1);

        int counter = 0;


        if (dReader.HasRows)
        {


            while (dReader.Read())
            {

                if (dReader["userid"].ToString() != null)
                {
                    counter++;
                }


            }

        }


        txtcounterheadergender.Visible = true;
        txtcountergender.Visible = true;
        txtcounterheadergender.Text = "Total Estudiantes";
        txtcountergender.Text = counter.ToString();
        txtcounterheadergender.Enabled = false;
        txtcountergender.Enabled = false;


    }


    protected void DropDownList_Provincia_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList_Canton.Items.Clear();
        Add_Canton(Convert.ToInt32(DropDownList_Provincia.SelectedItem.Value));

    }


    protected void DropDownList_Canton_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList_Distrito.Items.Clear();
        Add_Distrito(Convert.ToInt32(DropDownList_Canton.SelectedItem.Value));

    }


    public void Add_Provincia()
    {
        

        SqlDataReader dReader;
        SqlCommand cmd = new SqlCommand("SELECT * FROM provincias");

        db list = new db();
        dReader = list.returnDataReader(cmd);

        try
        {
            ListItem newItem = new ListItem();
            newItem.Text = "Provincia";
            newItem.Value = "0";
            DropDownList_Provincia.Items.Add(newItem);
           

            while (dReader.Read())
            {
                ListItem newItem1 = new ListItem();
                newItem1.Text = dReader["nombre"].ToString();
                newItem1.Value = dReader["ID_Provincia"].ToString();
                DropDownList_Provincia.Items.Add(newItem1);
            }

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }


    public void Add_Canton(int idprovincia)
    {


        SqlDataReader dReader;
        SqlCommand cmd = new SqlCommand("SELECT ID_Canton, nombre from cantones where ID_Provincia=@ID_Provincia");
        cmd.Parameters.AddWithValue("ID_Provincia", idprovincia);

        db list = new db();
        dReader = list.returnDataReader(cmd);

            ListItem newItem = new ListItem();
            newItem.Text = "Canton";
            newItem.Value = "0";
            DropDownList_Canton.Items.Add(newItem);

            while (dReader.Read())
            {
                ListItem newItem1 = new ListItem();
                newItem1.Text = dReader["nombre"].ToString();
                newItem1.Value = dReader["ID_Canton"].ToString();
                DropDownList_Canton.Items.Add(newItem1);
            }

      
    }


    public void Add_Distrito(int idcanton)
    {


        SqlDataReader dReader;
        SqlCommand cmd = new SqlCommand("SELECT ID_Distrito, nombre FROM Distritos Where ID_Canton=@ID_Canton");
        cmd.Parameters.AddWithValue("ID_Canton", idcanton);

        db list = new db();
        dReader = list.returnDataReader(cmd);

            ListItem newItem = new ListItem();
            newItem.Text = "Distrito";
            newItem.Value = "0";
            DropDownList_Distrito.Items.Add(newItem);

            while (dReader.Read())
            {
                ListItem newItem1 = new ListItem();
                newItem1.Text = dReader["nombre"].ToString();
                newItem1.Value = dReader["ID_Distrito"].ToString();
                DropDownList_Distrito.Items.Add(newItem1);
            }

     
    }


    public void Add_Institucion()
    {

        SqlDataReader dReader;
        SqlCommand cmd = new SqlCommand("SELECT Id_Colegio, Nombre from colegios");

        db list = new db();
        dReader = list.returnDataReader(cmd);

        ListItem newItem = new ListItem();
            newItem.Text = "Colegio";
            newItem.Value = "0";
            DropDownList_HighSchool.Items.Add(newItem);


            while (dReader.Read())
            {
                ListItem newItem1 = new ListItem();
                newItem1.Text = dReader["Nombre"].ToString();
                newItem1.Value = dReader["ID_Colegio"].ToString();
                DropDownList_HighSchool.Items.Add(newItem1);
            }

     
    }






}