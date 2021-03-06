﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


    public partial class HomePage : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Btn_Login_Click(object sender, EventArgs e)
    {
   
        string connection ="server=psychotestdb.database.windows.net;database=quizdb;user=brenesji;pwd=DesarrolloApp123";
        string insertSQL = "SELECT * FROM usuarios where ID = '" + Txt_Usuario.Text.Trim() + "' and contrasena='" + Txt_password.Text.Trim() + "'";
        string tipoSQL = "SELECT tipo FROM usuarios where ID = '" + Txt_Usuario.Text.Trim() + "' and contrasena='" + Txt_password.Text.Trim() + "'";


        try
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand(insertSQL, con);
            SqlCommand cmd1 = new SqlCommand(tipoSQL, con);
            string output = cmd.ExecuteScalar().ToString();
            string tipo = cmd1.ExecuteScalar().ToString();

            if (output == Txt_Usuario.Text.Trim() & tipo == "U")
            {
                //Aqui creo una variable session
                //Si el tipo es U, nos llevara al perfil del estudiante
                Session["user"] = Txt_Usuario.Text;
                Response.Redirect("~/Admin/Profile_Student.aspx");
            }
            else if (output == Txt_Usuario.Text.Trim() & tipo == "A")
            {
                //Aqui creo una variable session
                //Si el tipo es A, nos llevara al perfil del Administrador
                Session["user"] = Txt_Usuario.Text;
                Response.Redirect("~/Admin/Profile_Administrator.aspx");
            }
            else if (output == Txt_Usuario.Text.Trim() & tipo == "P")
            {
                //Aqui creo una variable session
                //Si el tipo es P, nos llevara al perfil del Psicologo
                Session["user"] = Txt_Usuario.Text;
                Response.Redirect("~/Admin/Profile_Psychologist.aspx");
            }
            else
            {
                Lbl_Error.Visible = true;
                Lbl_Error.Text = "Error: Nombre de Usuario o Contrasena incorrecta";
            }

            con.Close();
            con.Dispose();

        }

        catch (Exception)
        {
            Lbl_Error.Visible = true;
            Lbl_Error.Text = "Error: Nombre de Usuario o Contrasena incorrecta";
        }

    }
}
