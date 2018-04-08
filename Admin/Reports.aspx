<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Admin_Reports" %>

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

        <div id="reportsdiv" runat="server" class="text-center">
            <asp:Label ID="Label" runat="server" Font-Size="XX-Large" Text="Reportes" Font-Bold="true" />
        </div>
        <br />
        <br />
        <div id="selectreportdiv" runat="server" class="text-center">
            <b>Seleccione el tipo de reporte</b>&nbsp;&nbsp;
            <asp:DropDownList ID="ddlReport" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Report_Changed" class="btn btn-default btn-lg">
                <asp:ListItem Text="Seleccione un reporte" Value="0" Selected="True" />
                <asp:ListItem Text="Por Nombre" Value="1" />
                <asp:ListItem Text="Por Correo Electronico" Value="2" />
                <asp:ListItem Text="Por Estudiantes por fecha" Value="3" />
                <asp:ListItem Text="Por Direccion por fecha" Value="4" />
                <asp:ListItem Text="Por Colegio por fecha" Value="5" />
                <asp:ListItem Text="Por Sexo por fecha" Value="6" />
            </asp:DropDownList><br />
            <br />
        </div>

        <div id="namereportdiv" runat="server" class="text-center" visible="false">
            <br />
            <br />
            <b>Nombre</b><br />
            <asp:TextBox ID="txtname" runat="server" class="btn btn-default btn-lg" Height="50px" Width="400px" /><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname" Display="Dynamic" ErrorMessage="Por favor ingrese un nombre" SetFocusOnError="true" ForeColor="Red" ValidationGroup="namereportvalidation" />
            <br />
            <br />
            <br />
            <asp:GridView ID="GridViewName1" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false" Style="background-color: gray; color: white;">
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
            <asp:TextBox ID="txtcorrectheadername" runat="server" Style="background-color: #666666; color: white; text-align: center;" Visible="false" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtwrongheadername" runat="server" Style="background-color: #666666; color: white; text-align: center;" Visible="false" />
            <br />
            <asp:TextBox ID="txtcorrectname" runat="server" Style="background-color: gray; color: white; text-align: center;" Visible="false" />&nbsp;&nbsp &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtwrongname" runat="server" Style="background-color: gray; color: white; text-align: center;" Visible="false" />
            <br />
            <br />
            <br />
            <asp:GridView ID="GridViewName2" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false" Style="background-color: gray; color: white;">
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
            <asp:Button ID="namereportbtn" runat="server" OnClick="namereportsubmit_Click" Text="Consultar" class="btn btn-default btn-lg" ValidationGroup="namereportvalidation" />
        </div>


        <div id="emailreportdiv" runat="server" class="text-center" visible="false">
            <br />
            <br />
            <b>Correo Electronico</b><br />
            <asp:TextBox ID="txtemail" runat="server" class="btn btn-default btn-lg" Height="50px" Width="400px" /><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtemail" Display="Dynamic" ErrorMessage="Por favor ingrese un correo electronico" SetFocusOnError="true" ForeColor="Red" ValidationGroup="emailreportvalidation" />
            <br />
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
            <asp:Button ID="emailreportbtn" runat="server" OnClick="emailreportsubmit_Click" Text="Consultar" class="btn btn-default btn-lg" ValidationGroup="emailreportvalidation" />
        </div>



        <script type="text/javascript">
            $(function () {
                $("#<%= txtdatefrom.ClientID  %>").datepicker({ dateFormat: 'yy-mm-dd', changeMonth: true, changeYear: true });
            });
        </script>

        <script type="text/javascript" src="../Scripts/ckeditor/ckeditor.js"></script>
        <style type="text/css">
            #ui-datepicker-div {
                display: none;
            }
        </style>

        <script type="text/javascript">
            $(function () {
                $("#<%= txtdateto.ClientID  %>").datepicker({ dateFormat: 'yy-mm-dd', changeMonth: true, changeYear: true });
            });
        </script>

        <script type="text/javascript" src="../Scripts/ckeditor/ckeditor.js"></script>
        <style type="text/css">
            #ui-datepicker-div {
                display: none;
            }
        </style>


        <div id="studentsreportdiv" runat="server" class="text-center" visible="false">
            <br />
            <br />
            <asp:Label ID="FechaStudents1" runat="server" ForeColor="White" Visible="false" Style="float: left; text-align: center;" Text="Fecha Desde" /><asp:Label ID="FechaStudents2" runat="server" ForeColor="White" Visible="false" Style="float: right; text-align: center;" Text="Fecha Hasta" /><br />
            <asp:TextBox ID="txtdatefrom" runat="server" class="btn btn-default btn-lg" Type="Date" Operator="DataTypeCheck" Height="50px" Width="400px" Style="float: left;" /><asp:TextBox ID="txtdateto" runat="server" class="btn btn-default btn-lg" Type="Date" Operator="DataTypeCheck" Height="50px" Width="400px" Style="float: right;" /><br />
            <br />
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdatefrom" Display="Dynamic" ErrorMessage="Por favor ingrese una fecha" SetFocusOnError="true" ForeColor="Red" Style="float: left;" ValidationGroup="studentsreportvalidation" /><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtdateto" Display="Dynamic" ErrorMessage="Por favor ingrese una fecha" SetFocusOnError="true" ForeColor="Red" Style="float: right;" ValidationGroup="studentsreportvalidation" />
            <br />
            <br />
            <br />
            <asp:GridView ID="GridViewStudents1" runat="server" HorizontalAlign="Center" OnRowCommand="GridStudents_RowCommand" AutoGenerateColumns="false" Style="background-color: gray; color: white;">
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
                    <asp:TemplateField HeaderText="Detalles">
                    <ItemTemplate>
                    <asp:LinkButton ID="lnkVer" runat="server" CommandName="Ver" Font-Bold="true" CommandArgument='<%#Bind("ID") %>' CausesValidation="false">Ver</asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                <HeaderStyle BackColor="#666666" />
            </asp:GridView>
            <br />
            <br />
            <br />
            <asp:Button ID="studentsreportbtn" runat="server" OnClick="studentsreportsubmit_Click" Text="Consultar" class="btn btn-default btn-lg" ValidationGroup="studentsreportvalidation" />
        </div>


        <div id="addressreportdiv" runat="server" class="text-center" visible="false">
            <br />
            <br />
            <asp:Label ID="FechaAddress1" runat="server" ForeColor="White" Visible="false" Style="float: left; text-align: center;" Text="Fecha Desde" /><asp:Label ID="FechaAddress2" runat="server" ForeColor="White" Visible="false" Style="float: right; text-align: center;" Text="Fecha Hasta" /><br />
            <asp:TextBox ID="txtdatefromaddress" runat="server" class="btn btn-default btn-lg" Type="Date" Operator="DataTypeCheck" Height="50px" Width="300px" Style="float: left;" /><asp:TextBox ID="txtdatetoaddress" runat="server" class="btn btn-default btn-lg" Type="Date" Operator="DataTypeCheck" Height="50px" Width="300px" Style="float: right;" /><br />
            <br />
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtdatefromaddress" Display="Dynamic" ErrorMessage="Por favor ingrese una fecha" SetFocusOnError="true" ForeColor="Red" Style="float: left;" ValidationGroup="addressreportvalidation" /><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtdatetoaddress" Display="Dynamic" ErrorMessage="Por favor ingrese una fecha" SetFocusOnError="true" ForeColor="Red" Style="float: right;" ValidationGroup="addressreportvalidation" />
            <br />
            <br />
            <asp:ScriptManager runat="server" />
            <asp:UpdatePanel runat="server" ID="UpdatePanel">
                <ContentTemplate>
                    <b>Provincia</b><br />
                    <asp:DropDownList ID="DropDownList_Provincia" runat="server" AutoPostBack="True" class="btn btn-default btn-lg" OnSelectedIndexChanged="DropDownList_Provincia_SelectedIndexChanged" Height="50px" Style="width: 300px;"></asp:DropDownList>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="DropDownList_Provincia" Display="Dynamic" ErrorMessage="Por favor ingrese una provincia" SetFocusOnError="true" ForeColor="Red" ValidationGroup="addressreportvalidation" /><br />
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                <ContentTemplate>
                    <b>Canton</b><br />
                    <asp:DropDownList ID="DropDownList_Canton" runat="server" class="btn btn-default btn-lg" OnSelectedIndexChanged="DropDownList_Canton_SelectedIndexChanged" AutoPostBack="True" Height="50px" Style="width: 300px;"></asp:DropDownList>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="DropDownList_Canton" Display="Dynamic" ErrorMessage="Por favor ingrese un canton" SetFocusOnError="true" ForeColor="Red" ValidationGroup="addressreportvalidation" /><br />
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                <ContentTemplate>
                    <b>Distrito</b><br />
                    <asp:DropDownList ID="DropDownList_Distrito" runat="server" AutoPostBack="True" class="btn btn-default btn-lg" Height="50px" Style="width: 300px;"></asp:DropDownList>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="DropDownList_Distrito" Display="Dynamic" ErrorMessage="Por favor ingrese un distrito" SetFocusOnError="true" ForeColor="Red" ValidationGroup="addressreportvalidation" /><br />
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <br />
            <asp:GridView ID="GridViewAddress1" runat="server" HorizontalAlign="Center" OnRowCommand="GridAddress_RowCommand" AutoGenerateColumns="false" Style="background-color: gray; color: white;">
                <Columns>
                    <asp:BoundField DataField="userid" HeaderText="Correo Electronico" />
                    <asp:BoundField DataField="nombres" HeaderText="Nombre" />
                    <asp:BoundField DataField="primer_apellido" HeaderText="Primer Apellido" />
                    <asp:BoundField DataField="segundo_apellido" HeaderText="Segundo Apellido" />
                    <asp:BoundField DataField="Provincia" HeaderText="Provincia" />
                    <asp:BoundField DataField="Canton" HeaderText="Canton" />
                    <asp:BoundField DataField="Distrito" HeaderText="Distrito" />
                    <asp:TemplateField HeaderText="Detalles">
                    <ItemTemplate>
                    <asp:LinkButton ID="lnkVer" runat="server" CommandName="Ver" Font-Bold="true" CommandArgument='<%#Bind("userid") %>' CausesValidation="false">Ver</asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="#666666" />
            </asp:GridView>
            <br />
            <asp:TextBox ID="txtcounterheaderaddress" runat="server" Style="background-color: #666666; color: white; text-align: center;" Visible="false" />
            <br />
            <asp:TextBox ID="txtcounteraddress" runat="server" Style="background-color: gray; color: white; text-align: center;" Visible="false" />
            <br />
            <br />
            <br />
            <asp:Button ID="addressreportbtn" runat="server" OnClick="addressreportsubmit_Click" Text="Consultar" class="btn btn-default btn-lg" ValidationGroup="addressreportvalidation" />
        </div>


        <div id="schoolreportdiv" runat="server" class="text-center" visible="false">
            <br />
            <br />
            <asp:Label ID="FechaSchool1" runat="server" ForeColor="White" Visible="false" Style="float: left; text-align: center;" Text="Fecha Desde" /><asp:Label ID="FechaSchool2" runat="server" ForeColor="White" Visible="false" Style="float: right; text-align: center;" Text="Fecha Hasta" /><br />
            <asp:TextBox ID="txtdatefromschool" runat="server" class="btn btn-default btn-lg" Type="Date" Operator="DataTypeCheck" Height="50px" Width="300px" Style="float: left;" /><asp:TextBox ID="txtdatetoschool" runat="server" class="btn btn-default btn-lg" Type="Date" Operator="DataTypeCheck" Height="50px" Width="300px" Style="float: right;" /><br />
            <br />
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtdatefromschool" Display="Dynamic" ErrorMessage="Por favor ingrese una fecha" SetFocusOnError="true" ForeColor="Red" Style="float: left;" ValidationGroup="schoolreportvalidation" /><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtdatetoschool" Display="Dynamic" ErrorMessage="Por favor ingrese una fecha" SetFocusOnError="true" ForeColor="Red" Style="float: right;" ValidationGroup="schoolreportvalidation" />
            <br />
            <br />
            <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                <ContentTemplate>
                    <b>Colegio</b><br />
                    <asp:DropDownList ID="DropDownList_HighSchool" runat="server" class="btn btn-default btn-lg" Height="50px" Style="width: 300px;"></asp:DropDownList>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="DropDownList_HighSchool" Display="Dynamic" ErrorMessage="Por favor ingrese un colegio" SetFocusOnError="true" ForeColor="Red" ValidationGroup="schooolreportvalidation" /><br />
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <br />
            <asp:GridView ID="GridViewSchool1" runat="server" HorizontalAlign="Center" OnRowCommand="GridSchool_RowCommand" AutoGenerateColumns="false" Style="background-color: gray; color: white;">
                <Columns>
                    <asp:BoundField DataField="userid" HeaderText="Correo Electronico" />
                    <asp:BoundField DataField="nombres" HeaderText="Nombre" />
                    <asp:BoundField DataField="primer_apellido" HeaderText="Primer Apellido" />
                    <asp:BoundField DataField="segundo_apellido" HeaderText="Segundo Apellido" />
                    <asp:BoundField DataField="Colegio" HeaderText="Colegio" />
                    <asp:TemplateField HeaderText="Detalles">
                    <ItemTemplate>
                    <asp:LinkButton ID="lnkVer" runat="server" CommandName="Ver" Font-Bold="true" CommandArgument='<%#Bind("userid") %>' CausesValidation="false">Ver</asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="#666666" />
            </asp:GridView>
            <br />
            <asp:TextBox ID="txtcounterheaderschool" runat="server" Style="background-color: #666666; color: white; text-align: center;" Visible="false" />
            <br />
            <asp:TextBox ID="txtcounterschool" runat="server" Style="background-color: gray; color: white; text-align: center;" Visible="false" />
            <br />
            <br />
            <br />
            <asp:Button ID="schoolreportbtn" runat="server" OnClick="schoolsreportsubmit_Click" Text="Consultar" class="btn btn-default btn-lg" ValidationGroup="schoolreportvalidation" />
        </div>


        <div id="genderreportdiv" runat="server" class="text-center" visible="false">
            <br />
            <br />
            <asp:Label ID="FechaGender1" runat="server" ForeColor="White" Visible="false" Style="float: left; text-align: center;" Text="Fecha Desde" /><asp:Label ID="FechaGender2" runat="server" ForeColor="White" Visible="false" Style="float: right; text-align: center;" Text="Fecha Hasta" /><br />
            <asp:TextBox ID="txtdatefromgender" runat="server" class="btn btn-default btn-lg" Type="Date" Operator="DataTypeCheck" Height="50px" Width="300px" Style="float: left;" /><asp:TextBox ID="txtdatetogender" runat="server" class="btn btn-default btn-lg" Type="Date" Operator="DataTypeCheck" Height="50px" Width="300px" Style="float: right;" /><br />
            <br />
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtdatefromgender" Display="Dynamic" ErrorMessage="Por favor ingrese una fecha" SetFocusOnError="true" ForeColor="Red" Style="float: left;" ValidationGroup="genderreportvalidation" /><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtdatetogender" Display="Dynamic" ErrorMessage="Por favor ingrese una fecha" SetFocusOnError="true" ForeColor="Red" Style="float: right;" ValidationGroup="genderreportvalidation" />
            <br />
            <br />
            <asp:UpdatePanel runat="server" ID="UpdatePanel4">
                <ContentTemplate>
                    <b>Sexo</b><br />
                    <asp:DropDownList ID="DropDownList_Gender" runat="server" class="btn btn-default btn-lg" Height="50px" Style="width: 300px;">
                        <asp:ListItem Value="M">Hombre</asp:ListItem>
                        <asp:ListItem Value="F">Mujer</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="DropDownList_Gender" Display="Dynamic" ErrorMessage="Por favor ingrese un sexo" SetFocusOnError="true" ForeColor="Red" ValidationGroup="genderreportvalidation" /><br />
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <br />
            <asp:GridView ID="GridViewGender1" runat="server" HorizontalAlign="Center" OnRowCommand="GridGender_RowCommand" AutoGenerateColumns="false" Style="background-color: gray; color: white;">
                <Columns>
                    <asp:BoundField DataField="userid" HeaderText="Correo Electronico" />
                    <asp:BoundField DataField="nombres" HeaderText="Nombre" />
                    <asp:BoundField DataField="primer_apellido" HeaderText="Primer Apellido" />
                    <asp:BoundField DataField="segundo_apellido" HeaderText="Segundo Apellido" />
                    <asp:BoundField DataField="sexo" HeaderText="Sexo" />
                    <asp:TemplateField HeaderText="Detalles">
                    <ItemTemplate>
                    <asp:LinkButton ID="lnkVer" runat="server" CommandName="Ver" Font-Bold="true" CommandArgument='<%#Bind("userid") %>' CausesValidation="false">Ver</asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="#666666" />
            </asp:GridView>
            <br />
            <asp:TextBox ID="txtcounterheadergender" runat="server" Style="background-color: #666666; color: white; text-align: center;" Visible="false" />
            <br />
            <asp:TextBox ID="txtcountergender" runat="server" Style="background-color: gray; color: white; text-align: center;" Visible="false" />
            <br />
            <br />
            <br />
            <asp:Button ID="genderreportbtn" runat="server" OnClick="genderreportsubmit_Click" Text="Consultar" class="btn btn-default btn-lg" ValidationGroup="genderreportvalidation" />
        </div>



        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
    <br />
    <br />
    <br />
    <br />
    <footer>
        <div class="content-wrapper">
            <div class="float-left">
                <p>
                    &copy; <%: DateTime.Now.Year %> - All Rights Reserved
                </p>
            </div>
        </div>
    </footer>
</body>
</html>
