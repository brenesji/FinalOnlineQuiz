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
using System.Globalization;

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

        DropDownList_Canton.Items.Clear();
        Add_Canton(Convert.ToInt32(DropDownList_Provincia.SelectedItem.Value));
        
    }

    public void Add_Canton(int idprovincia)
    {

        try
        {
            string connection = "server=psychotestdb.database.windows.net;database=quizdb;user=brenesji;pwd=DesarrolloApp123";

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("SELECT ID_Canton, nombre from cantones where ID_Provincia=@ID_Provincia", con);
            cmd.Parameters.AddWithValue("ID_Provincia", idprovincia);
            SqlDataReader reader;

            ListItem newItem = new ListItem();
            newItem.Text = "Canton";
            newItem.Value = "0";
            DropDownList_Canton.Items.Add(newItem);
            con.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListItem newItem1 = new ListItem();
                newItem1.Text = reader["nombre"].ToString();
                newItem1.Value = reader["ID_Canton"].ToString();
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
        DropDownList_Distrito.Items.Clear();
        Add_Distrito(Convert.ToInt32(DropDownList_Canton.SelectedItem.Value));

    }


    public void Add_Distrito(int idcanton)
    {
        try
        {
            string connection = "server=psychotestdb.database.windows.net;database=quizdb;user=brenesji;pwd=DesarrolloApp123";

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("SELECT ID_Distrito, nombre FROM Distritos Where ID_Canton=@ID_Canton", con);
            cmd.Parameters.AddWithValue("ID_Canton", idcanton);
            SqlDataReader reader;

            ListItem newItem = new ListItem();
            newItem.Text = "Distrito";
            newItem.Value = "0";
            DropDownList_Distrito.Items.Add(newItem);
            con.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListItem newItem1 = new ListItem();
                newItem1.Text = reader["nombre"].ToString();
                newItem1.Value = reader["ID_Distrito"].ToString();
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
        register.Visible = false;
        lbMessage.Visible = true;
        lbMessage.Text = "Registro completado exitosamente, por favor presione Salir para continuar";
        btnExit.Visible = true;

    }

    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Homepage.aspx", true);
    }


    public void Insert_Student(string iID_Usuario, string iNombre, string iPrimer_Apellido, string iSegundo_Apellido, string iProvincia, string iCanton, string iDistrito, string iInstitucion, string isexo, string itelefono, string iFecha, string iNacionalidad, string iPassword1, string iCedula)
    {
        try
        {
            string insertSQL = "INSERT INTO usuarios VALUES ('" + iID_Usuario + "','" + iNombre + "','" + iPrimer_Apellido + "','" + iSegundo_Apellido + "','" + iProvincia + "','" + iCanton + "','" + iDistrito + "','" + iInstitucion + "','" + isexo + "','" + itelefono + "','" + iFecha + "','" + iNacionalidad + "','" + iPassword1 + "','" + iCedula + "','U' );";
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