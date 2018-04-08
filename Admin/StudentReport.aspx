<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentReport.aspx.cs" Inherits="Admin_StudentReport" %>

<!DOCTYPE html>
<html lang="en">

<head runat="server">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Universidad Hispanoamericana</title>



    <!-- Bootstrap core CSS -->
    <link href="~/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom fonts for this template -->
    <link href="~/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Lora:400,700,400italic,700italic" rel="stylesheet" type="text/css">
    <link href='https://fonts.googleapis.com/css?family=Cabin:700' rel='stylesheet' type='text/css'>

    <!-- Custom styles for this template -->
    <link href="~/Styles/grayscale.min.css" rel="stylesheet">
</head>

<body>
    <br />
    <br />
    <form id="form1" runat="server" class="download-section">
    <div id="emailreportdiv" runat="server" class="text-center" visible="false">
            <br />
            <br />
            <asp:Label ID="Label" runat="server" Font-Size="XX-Large" Text="Reporte Estudiante" Font-Bold="true" />
            <br />
            <div style="float: right; padding-right: 15px;">
            <asp:HyperLink ID="homelnk" runat="server" class="fa fa-home" Font-Size="XX-Large" NavigateUrl="~/Admin/Reports.aspx"></asp:HyperLink>
            </div>
            <br />
            <br />
            <asp:GridView ID="GridViewEmail1" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false" Style="background-color: gray; color: white;">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Correo Electronico" />
                    <asp:BoundField DataField="nombres" HeaderText="Nombre" />
                    <asp:BoundField DataField="primer_apellido" HeaderText="Primer Apellido" />
                    <asp:BoundField DataField="segundo_apellido" HeaderText="Segundo Apellido" />
                    <asp:BoundField DataField="Provincia" HeaderText="Provincia" />
                    <asp:BoundField DataField="Canton" HeaderText="Canton" />
                    <asp:BoundField DataField="Distrito" HeaderText="Distrito" />
                    <asp:BoundField DataField="Colegio" HeaderText="Colegio" />
                    <asp:BoundField DataField="sexo" HeaderText="Sexo" />
                    <asp:BoundField DataField="Fecha_Nacimiento" HeaderText="Fecha Nacimiento" />
                    <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad" />
                    <asp:BoundField DataField="cedula" HeaderText="Cedula" />
                    <asp:BoundField DataField="Edad" HeaderText="Edad" />
                </Columns>
                <HeaderStyle BackColor="#666666" />
            </asp:GridView>
            <br />
            <br />
            <asp:TextBox ID="txtcorrectheaderemail" runat="server" Style="background-color: #666666; color: white; text-align: center;" Visible="false" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtwrongheaderemail" runat="server" Style="background-color: #666666; color: white; text-align: center;" Visible="false" />
            <br />
            <asp:TextBox ID="txtcorrectemail" runat="server" Style="background-color: gray; color: white; text-align: center;" Visible="false" />&nbsp;&nbsp &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtwrongemail" runat="server" Style="background-color: gray; color: white; text-align: center;" Visible="false" />
            <br />
            <br />
            <br />
            <asp:GridView ID="GridViewEmail2" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false" Style="background-color: gray; color: white;">
                <Columns>
                    <asp:BoundField DataField="quiz_name" HeaderText="Examen" />
                    <asp:BoundField DataField="question" HeaderText="Pregunta" />
                    <asp:BoundField DataField="category" HeaderText="Categoria" />
                    <asp:BoundField DataField="correct_answer" HeaderText="Respuesta Correcta" />
                    <asp:BoundField DataField="user_answer" HeaderText="Respuesta Estudiante" />
                    <asp:BoundField DataField="accurate_answer" HeaderText="Correcta" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                </Columns>
                <HeaderStyle BackColor="#666666" />
            </asp:GridView>
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
