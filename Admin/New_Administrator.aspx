<%@ Page Language="C#" AutoEventWireup="true" CodeFile="New_Administrator.aspx.cs" Inherits="Admin_New_Administrator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <!-- Para Date PickUp -->

    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.5/themes/base/jquery-ui.css" type="text/css" media="all" />
    <link rel="stylesheet" href="http://static.jquery.com/ui/css/demo-docs-theme/ui.theme.css" type="text/css" media="all" />
    <script src="../Scripts/jquery-1.8.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>


    <script type="text/javascript">
        $(function () {
            $("#<%= Txt_Date.ClientID  %>").datepicker({ dateFormat: 'yy-mm-dd', changeMonth: true, changeYear: true});
        });
    </script>

    <script type="text/javascript" src="../Scripts/ckeditor/ckeditor.js"></script>
    <style type="text/css">
        #ui-datepicker-div {
            display: none;
        }
    </style>

    <title>Universidad Hispanoamericana - Registro</title>

    <!-- Bootstrap core CSS -->
    <link href="~/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom fonts for this template -->
    <link href="~/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Lora:400,700,400italic,700italic" rel="stylesheet" type="text/css" />
    <link href='https://fonts.googleapis.com/css?family=Cabin:700' rel='stylesheet' type='text/css' />

    <!-- Custom styles for this template -->
    <link href="~/Styles/grayscale.min.css" rel="stylesheet" />

</head>
<div style="float: left; padding-left: 15px;">
    <asp:hyperlink id="homelnk" runat="server" class="fa fa-home" font-size="XX-Large" navigateurl="~/Admin/HomePage.aspx"></asp:hyperlink>
</div>
<body>
</body>


<form id="form1" runat="server">
    <!-- Login Section -->
    <section id="login" class="content-section text-center">
        <div id="register" runat="server" class="container">
            <div class="col-lg-8 mx-auto">
                <h2>Registro de administrador</h2>
                <div class="text-center">

                    <h2>Usuario & Contraseña</h2>
                    <table class="text-center table table-default">

                        <tr>
                            <td>
                                <label class="text-justify">Correo Electronico:</label>
                                <br />
                                <br />
                            </td>
                            <td>&nbsp;&nbsp;<asp:textbox id="txt_IDusuario" runat="server" maxlength="50"></asp:textbox>
                                <br />
                                <br />
                            </td>
                            <td class="text-left">
                                <asp:requiredfieldvalidator runat="server" errormessage="Ingrese Nombre de Usuario" controltovalidate="txt_IDusuario" forecolor="Red" display="Dynamic"></asp:requiredfieldvalidator>
                                <br />
                                <asp:regularexpressionvalidator runat="server" errormessage="Ingrese una cuenta de Correo Valida" controltovalidate="txt_IDusuario" forecolor="Red" validationexpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:regularexpressionvalidator>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="text-justify">Contraseña:</label>
                                <br />
                            </td>
                            <td>&nbsp;&nbsp;<asp:textbox id="txt_Password" runat="server" maxlength="15" textmode="Password"></asp:textbox>
                                <br />
                                <br />
                            </td>
                            <td class="text-left">
                                <asp:requiredfieldvalidator runat="server" errormessage="Ingresa una Contrasena" forecolor="Red" controltovalidate="txt_Password"></asp:requiredfieldvalidator>
                                <br />
                                <asp:comparevalidator runat="server" errormessage="Las Contrasenas no son iguales" forecolor="Red" controltocompare="txt_Password1" controltovalidate="txt_Password"></asp:comparevalidator>
                                <br />

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="text-justify">Validar Contraseña:</label>
                                <br />
                                <br />
                            </td>
                            <td>&nbsp;&nbsp;<asp:textbox id="txt_Password1" runat="server" maxlength="15" textmode="Password"></asp:textbox>
                                <br />
                                <br />
                            </td>
                            <td class="text-left">
                                <asp:requiredfieldvalidator runat="server" errormessage="Reingresa una Contrasena" forecolor="Red" controltovalidate="txt_Password1"></asp:requiredfieldvalidator>
                                <br />

                            </td>
                        </tr>
                    </table>
                    <br />

                    <!-- Informacion Personal -->
                    <h2>Informacion Personal</h2>

                    <table class="text-center table table-default">
                        <tr>
                            <td>
                                <label class="text-justify">Nombre:</label>
                                <br />
                                <br />
                            </td>
                            <td>
                                <asp:textbox id="txt_Name" runat="server"></asp:textbox>
                                <br />
                                <br />
                            </td>
                            <td class="text-left">
                                <asp:requiredfieldvalidator runat="server" errormessage="Ingrese Nombre" controltovalidate="txt_Name" forecolor="Red"></asp:requiredfieldvalidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="text-justify">Primer Apellido:</label>
                                <br />
                                <br />
                            </td>
                            <td>
                                <asp:textbox id="txt_FirstName" runat="server"></asp:textbox>
                                <br />
                                <br />
                            </td>
                            <td class="text-left">
                                <asp:requiredfieldvalidator runat="server" errormessage="Ingrese Primer Apellido" controltovalidate="txt_FirstName" forecolor="Red"></asp:requiredfieldvalidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="text-justify">Segundo Apellido:</label>
                                <br />
                                <br />
                            </td>
                            <td>
                                <asp:textbox id="txt_LastName" runat="server"></asp:textbox>
                                <br />
                                <br />
                            </td>
                            <td class="text-left">
                                <asp:requiredfieldvalidator runat="server" errormessage="Ingrese Segundo Apellido" controltovalidate="txt_LastName" forecolor="Red"></asp:requiredfieldvalidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="text-justify">Provincia:</label>
                                <br />
                                <br />
                            </td>
                            <td>
                                <asp:scriptmanager runat="server" />
                                <asp:updatepanel runat="server" id="UpdatePanel">
                                    <ContentTemplate>
                                      <asp:dropdownlist ID="DropDownList_Provincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_Provincia_SelectedIndexChanged" style="width: 250px;"></asp:dropdownlist> <br /><br />
                                    </ContentTemplate>
                                  </asp:updatepanel>
                            </td>

                            <td class="text-left">
                                <asp:requiredfieldvalidator runat="server" errormessage="Seleccione una Provincia" controltovalidate="DropDownList_Provincia" forecolor="Red"></asp:requiredfieldvalidator>
                            </td>
                            >
                        </tr>
                        <tr>
                            <td>
                                <label class="text-justify">Canton:</label>
                                <br />
                                <br />
                            </td>
                            <td>
                                <asp:updatepanel runat="server" id="UpdatePanel1">
                                  <ContentTemplate>
                                    <asp:dropdownlist id="DropDownList_Canton" runat="server" OnSelectedIndexChanged="DropDownList_Canton_SelectedIndexChanged1" AutoPostBack="True" style="width: 250px;" ></asp:dropdownlist> <br /><br />
                                  </ContentTemplate>
                                </asp:updatepanel>
                            </td>

                            <td class="text-left">
                                <asp:requiredfieldvalidator runat="server" errormessage="Seleccione un Canton" controltovalidate="DropDownList_Canton" forecolor="Red"></asp:requiredfieldvalidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="text-justify">Distrito:</label>
                                <br />
                                <br />
                            </td>
                            <td>
                                <asp:updatepanel runat="server" id="UpdatePanel2">
                                 <ContentTemplate>
                                   <asp:DropDownList ID="DropDownList_Distrito" runat="server" AutoPostBack="True" style="width: 250px;" ></asp:DropDownList> <br /><br />
                                 </ContentTemplate>
                               </asp:updatepanel>
                            </td>

                            <td class="text-left">
                                <asp:requiredfieldvalidator runat="server" errormessage="Seleccione un Distrito " controltovalidate="DropDownList_Distrito" forecolor="Red"></asp:requiredfieldvalidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="text-justify">Sexo:</label>
                                <br />
                                <br />
                            </td>
                            <td>
                                <asp:dropdownlist id="DropDownList_Gender" runat="server" style="width: 250px;">
                                   <asp:ListItem Value="M">Hombre</asp:ListItem>
                                   <asp:ListItem Value="F">Mujer</asp:ListItem>
                                </asp:dropdownlist>
                                <br />
                                <br />
                            </td>
                            <td class="text-left">
                                <asp:requiredfieldvalidator runat="server" errormessage="Seleccione un Sexo" controltovalidate="DropDownList_Gender" forecolor="Red"></asp:requiredfieldvalidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%--<i class="fa fa-phone fa-fw"></i> --%>
                                <label class="text-justify">Telefono:</label>
                                <br />
                                <br />
                            </td>
                            <td>
                                <asp:textbox id="txt_Telefono" runat="server"></asp:textbox>
                                <br />
                                <br />
                                <%--<asp:TextBox ID="txt_Telefono" runat="server" TextMode="Phone"></asp:TextBox> <br /><br />--%>
                            </td>
                            <td class="text-left">
                                <asp:requiredfieldvalidator runat="server" errormessage="Ingrese un Numero de Telefono" controltovalidate="txt_Telefono" forecolor="Red"></asp:requiredfieldvalidator>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <label class="text-justify">Nacionalidad:</label>
                                <br />
                                <br />
                            </td>
                            <td>
                                <asp:dropdownlist id="DropDownList_Country" runat="server" style="width: 250px;">
                                </asp:dropdownlist>
                                <br />
                                <br />
                            </td>
                            <td class="text-left">
                                <asp:requiredfieldvalidator runat="server" errormessage="Seleccione una Nacionalidad" controltovalidate="DropDownList_Country" forecolor="Red"></asp:requiredfieldvalidator>
                            </td>

                        </tr>

                        <tr>
                            <td>
                                <label class="text-justify">Cedula:</label>
                                <br />
                                <br />
                            </td>
                            <td>
                                <asp:textbox id="txt_Cedula" runat="server"></asp:textbox>
                                <br />
                                <br />
                                <%--<asp:TextBox ID="txt_Cedula" runat="server" TextMode="Number"></asp:TextBox>--%>
                                <br />
                                <br />
                            </td>
                            <td class="text-left">
                                <asp:requiredfieldvalidator runat="server" errormessage="Ingrese una Cedula" controltovalidate="txt_Cedula" forecolor="Red"></asp:requiredfieldvalidator>
                            </td>
                        </tr>

                        <tr>



                            <td>
                                <label class="text-justify">Fecha de Nacimiento:</label>
                                <br />
                                <br />
                            </td>
                            <td>

                                <asp:textbox id="Txt_Date" runat="server"></asp:textbox>
                                <br />
                                <br />
                                <%--<asp:TextBox ID="Txt_Date" runat="server" height="25px" Width="125px"/>&nbsp;&nbsp;<br /><br />--%>
                              
                            </td>
                            <td class="text-left">
                                <%--<asp:RequiredFieldValidator ID="enddatevalidator" runat="server" ControlToValidate="Txt_Date" Display="Dynamic" ErrorMessage="Por Favor Ingrese Fecha Final" SetFocusOnError="true" ForeColor="Red" ValidationGroup="submitvalidation" />--%>
                                <asp:requiredfieldvalidator runat="server" type="Date" operator="DataTypeCheck" errormessage="Ingrese Fecha de Nacimiento" controltovalidate="txt_Date" forecolor="Red" style="text-align: center"></asp:requiredfieldvalidator>
                            </td>
                        </tr>

                    </table>
                    <br />
                    <br />
                    <asp:button id="Submit" runat="server" text="Registrar" class="btn btn-default btn-lg" onclick="Submit_Click" />
                    <br />
                    <asp:button id="btn_Return" runat="server" text="Home Page" class="btn btn-default btn-lg" visible="False" onclick="btn_Return_Click" />
                    <br />
                    <br />
                </div>
            </div>
        </div>
        <div>
            <asp:label id="lbMessage" runat="server" font-size="XX-Large" visible="false"></asp:label>
            <br />
            <br />
            <asp:button id="btnExit" runat="server" onclick="btnExit_Click" text="Salir" visible="false" class="btn btn-default btn-lg" />
        </div>

    </section>

    <!-- Footer -->


    <!-- Bootstrap core JavaScript -->
    <script src="~/vendor/jquery/jquery.min.js"></script>
    <script src="~/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
</form>

</html>
<footer>
    <div class="container text-center">
        <%--<p>Copyright &copy; Your Website 2018</p>--%>
    </div>
</footer>


