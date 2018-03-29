using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;

public partial class Admin_New_User : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //string DropDownList_Canton1 = (string)(Session["DropDownList_Canton1"]);

        if (!Page.IsPostBack)
        {
            Add_Provincia();
            Add_Pais();
            Add_Institucion();
        }
    }

    public void Add_Provincia()
    {
        string connection = "server=psychotestdb.database.windows.net;database=quizdb;user=brenesji;pwd=DesarrolloApp123";

        string selectSQL = "SELECT * FROM Provincias";
        SqlConnection con = new SqlConnection(connection);
        SqlCommand cmd = new SqlCommand(selectSQL, con);
        SqlDataReader reader;
        try
        {
            ListItem newItem = new ListItem();
            newItem.Text = "Provincia";
            newItem.Value = "0";
            DropDownList_Provincia.Items.Add(newItem);
            con.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListItem newItem1 = new ListItem();
                newItem1.Text = reader["nombre"].ToString();
                newItem1.Value = reader["ID_Provincia"].ToString();
                DropDownList_Provincia.Items.Add(newItem1);
            }

            reader.Close();
            reader.Dispose();
            con.Close();
            con.Dispose();
            cmd.Dispose();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void DropDownList_Provincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectSQL = "SELECT nombre from cantones where ID_Provincia = ";
        for (int i = 1; i < 7; i++)
        {
            if (DropDownList_Provincia.SelectedItem.Value.Equals(i.ToString()))
            {
                selectSQL = selectSQL + i.ToString() + ";"; Add_Canton(selectSQL);
            }
        }
    }

    public void Add_Canton(string selectSQL)
    {
        try
        {
            string connection = "server=psychotestdb.database.windows.net;database=quizdb;user=brenesji;pwd=DesarrolloApp123";
            int CONT = 0;

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader reader;

            ListItem newItem = new ListItem();
            newItem.Text = "Canton";
            newItem.Value = CONT.ToString();
            DropDownList_Canton.Items.Add(newItem);
            con.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListItem newItem1 = new ListItem();
                newItem1.Text = reader["nombre"].ToString();
                newItem1.Value = (CONT + 1).ToString();
                DropDownList_Canton.Items.Add(newItem1);
            }
            reader.Close();
            reader.Dispose();
            con.Close();
            con.Dispose();
            cmd.Dispose();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void DropDownList_Canton_SelectedIndexChanged1(object sender, EventArgs e)
    {

        //DropDownList_Canton.SelectedIndex = 0; //Reset Dropdownlist
        string selectSQL = "SELECT nombre FROM Distritos Where ID_Canton =";
        for (int i = 1; i < 82; i++)
        {
            if (DropDownList_Canton.SelectedItem.Value.Equals(i.ToString()))
            {
                selectSQL = selectSQL + i.ToString() + ";"; Add_Distrito(selectSQL);
            }
        }
    }


    public void Add_Distrito(string selectSQL)
    {
        try
        {
            string connection = "server=psychotestdb.database.windows.net;database=quizdb;user=brenesji;pwd=DesarrolloApp123";
            int CONT = 0;

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader reader;

            ListItem newItem = new ListItem();
            newItem.Text = "Distrito";
            newItem.Value = CONT.ToString();
            DropDownList_Distrito.Items.Add(newItem);
            con.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListItem newItem1 = new ListItem();
                newItem1.Text = reader["nombre"].ToString();
                newItem1.Value = (CONT + 1).ToString();
                DropDownList_Distrito.Items.Add(newItem1);
            }
            reader.Close();
            reader.Dispose();
            con.Close();
            con.Dispose();
            cmd.Dispose();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    public void Add_Institucion()
    {
        string connection = "server=psychotestdb.database.windows.net;database=quizdb;user=brenesji;pwd=DesarrolloApp123";

        string selectSQL = "SELECT Id_Colegio, Nombre from colegios";
        SqlConnection con = new SqlConnection(connection);
        SqlCommand cmd = new SqlCommand(selectSQL, con);
        SqlDataReader reader;
        try
        {
            ListItem newItem = new ListItem();
            newItem.Text = "Colegio";
            newItem.Value = "0";
            DropDownList_HighSchool.Items.Add(newItem);
            con.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListItem newItem1 = new ListItem();
                newItem1.Text = reader["Nombre"].ToString();
                newItem1.Value = reader["ID_Colegio"].ToString();
                DropDownList_HighSchool.Items.Add(newItem1);
            }

            reader.Close();
            reader.Dispose();
            con.Close();
            con.Dispose();
            cmd.Dispose();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }



    public void Add_Pais()
    {
        string connection = "server=psychotestdb.database.windows.net;database=quizdb;user=brenesji;pwd=DesarrolloApp123";

        string selectSQL = "SELECT * FROM Paises";
        SqlConnection con = new SqlConnection(connection);
        SqlCommand cmd = new SqlCommand(selectSQL, con);
        SqlDataReader reader;
        try
        {
            ListItem newItem = new ListItem();
            newItem.Text = "Pais";
            newItem.Value = "0";
            DropDownList_Country.Items.Add(newItem);
            con.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListItem newItem1 = new ListItem();
                newItem1.Text = reader["nombre"].ToString();
                newItem1.Value = reader["ID_Pais"].ToString();
                DropDownList_Country.Items.Add(newItem1);
            }

            reader.Close();
            reader.Dispose();
            con.Close();
            con.Dispose();
            cmd.Dispose();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }


    protected void Submit_Click(object sender, EventArgs e)
    {


        Insert_Student(txt_IDusuario.Text, txt_Name.Text, txt_FirstName.Text, txt_LastName.Text,
        DropDownList_Provincia.Text, DropDownList_Canton.Text, DropDownList_Distrito.Text, DropDownList_HighSchool.Text,
        DropDownList_Gender.Text, txt_Telefono.Text, Txt_Date.Text, DropDownList_Country.Text,
        txt_Password.Text, txt_Cedula.Text);
        btn_Return.Visible = true;
        Submit.Enabled = false;

    }

    public void Insert_Student(string iID_Usuario, string iNombre, string iPrimer_Apellido, string iSegundo_Apellido, string iProvincia, string iCanton, string iDistrito, string iInstitucion, string isexo, string itelefono, string iFecha, string iNacionalidad, string iPassword1, string iCedula)
    {
        try
        {
            string insertSQL = "INSERT INTO usuarios VALUES ('" + iID_Usuario + "','" + iNombre + "','" + iPrimer_Apellido + "','" + iSegundo_Apellido + "','" + iProvincia + "','" + iCanton + "','" + iDistrito + "','" + iInstitucion + "','" + isexo + "','" + itelefono + "','" + iFecha + "','" + iNacionalidad + "','" + iPassword1 + "','" + iCedula + "','Admin' );";
            string connection = "server=psychotestdb.database.windows.net;database=quizdb;user=brenesji;pwd=DesarrolloApp123";
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(insertSQL, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write(ex.Message);

        }
    }

    protected void btn_Return_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Homepage.aspx");
    }




}