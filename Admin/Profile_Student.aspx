<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Profile_Student.aspx.cs" Inherits="Admin_Profile_Student" %>


<!DOCTYPE html>
<html>
<title>Universidad Hispanoamericana</title>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<%--<link href="~/CSS/CSS_de_prueba.css" rel="stylesheet" type="text/css">--%>
  <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway">
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
  <style>
    body,
    h1,
    h2,
    h3,
    h4,
    h5,
    h6 {
      font-family: "Raleway", sans-serif
    }
  </style>

  <body class="w3-light-grey w3-content" style="max-width: 1600px">

    <!-- Sidebar/menu -->
    <nav class="w3-sidebar w3-collapse w3-blue w3-animate-left" style="z-index: 3; width: 300px;" id="mySidebar">
      <br>
      <div class="w3-container">
        <a href="#" onclick="w3_close()" class="w3-hide-large w3-right w3-jumbo w3-padding w3-hover-grey" title="close menu">
                <i class="fa fa-remove"></i>
            </a>
        <%--<img src="~/Images/Logo.png" style="width: 45%;" class="w3-round"><br>--%>
          <br>
          <h4><b>Menú  Principal</b></h4>
          <p class="w3-text-black">Universidad Hispanoamericana</p>
      </div>
      <div class="w3-bar-block">
        <a href="#Examenes" onclick="w3_close()" class="w3-bar-item w3-padding w3-text-black" , style="background-color: #A9D0F5"><i class="fa fa-th-large fa-fw w3-margin-right"></i>Examenes</a>
        <a href="#informacion" onclick="w3_close()" class="w3-bar-item w3-padding w3-text-black" , style="background-color: #A9D0F5"><i class="fa fa-user fa-fw w3-margin-right"></i>Mi Información</a>
      </div>
    </nav>

    <!-- Overlay effect when opening sidebar on small screens -->
    <div class="w3-overlay w3-hide-large w3-animate-opacity" onclick="w3_close()" style="cursor: pointer" title="close side menu" id="myOverlay"></div>

    <!-- !PAGE CONTENT! -->
    <div class="w3-main" style="margin-left: 300px">

      <!-- Header -->
      <header id="Examenes">
        <%--<a href="#"><img src="/w3images/avatar_g2.jpg" style="width: 65px;" class="w3-circle w3-right w3-margin w3-hide-large w3-hover-opacity"></a>--%>
          <span class="w3-button w3-hide-large w3-xxlarge w3-hover-text-grey" onclick="w3_open()"><i class="fa fa-bars"></i></span>
          <div class="w3-container">
            <h1><b>Perfil Estudiante</b></h1>
          </div>
      </header>

      <!-- Examenes -->
      <form id="form1" runat="server">
        <div class="w3-container w3-padding-large" style="margin-bottom: 32px">
          <h4><b>Examenes</b></h4
        <section id="Examenes" class="content-section text-center">
            <div class="container" runat="server">
                <asp:TextBox ID="txt_Nombre" runat="server" Font-Bold="True"></asp:TextBox>
                <div class="row">
                    <div class="col-lg-8 mx-auto">
                        <div id="examdiv" runat="server" class="text-center">
                            <asp:Repeater ID="examrepeater" runat="server" OnItemCommand="examrepeater_ItemCommand">
                                <HeaderTemplate>
                                    <table style="width: 100%">
                                        <tr style="background-color: #013ADF; color: white;">
                                            <td style="height: 25px; padding-left: 10px; font-weight: bold;">Examen</td>
                                            <td style="height: 25px; padding-left: 10px; font-weight: bold;">Descripcion</td>
                                            <td style="height: 25px; padding-left: 10px; font-weight: bold;">&nbsp;</td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr style="background-color: #A9D0F5; border-color: white;">
                                        <td style="height: 25px; padding-left: 10px; margin: 0 auto 0 auto; text-align: left">
                                            <asp:Label ID="lblquizname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "name")%>' Font-Bold="true"></asp:Label>
                                        </td>
                                        <td style="height: 25px; padding-left: 10px;">
                                            <asp:Label ID="lblfromdate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "description")%>' Font-Bold="true"></asp:Label>
                                        </td>
                                        <td style="height: 25px; padding-left: 10px;">
                                            <asp:LinkButton ID="lnkIniciar" runat="server" CommandName="Iniciar" Font-Bold="true" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") + "|" +  DataBinder.Eval(Container.DataItem, "name") %>' CausesValidation="false">Iniciar</asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        </div>

        <!-- Informacion -->
        <section id="Informacion" class="content-section text-center">
        <div class="w3-container w3-padding-large w3-blue-grey">
            <h4 id="informacion"><b>Mi Informacion</b></h4>
          <table class="text-center table table-default">
            <tr>
              <td>
                <%--<label class="text-justify">Bienvenido al Modulo de Pruebas Psicologicas</label> <br/> --%>
                  <label class="text-justify">Usuario:</label>
                  <br />
              </td>
              <td>
                <asp:TextBox ID="TextBox1" runat="server" Font-Bold="True" Enabled="False"></asp:TextBox>
              </td>
            </tr>
            <tr>
              <td>
                <label class="text-justify">Primer Apellido:</label>
                <br />
              </td>
              <td>
                <asp:TextBox ID="txt_FirstName" runat="server" Enabled="False"></asp:TextBox>
              </td>
            </tr>
            <tr>
              <td>
                <label class="text-justify">Segundo Apellido:</label>
                <br />
              </td>
              <td>
                <asp:TextBox ID="txt_LastName" runat="server" Enabled="False"></asp:TextBox>
                <br />
              </td>
            </tr>
            <tr>
              <td>
                <label class="text-justify">Provincia:</label>
                <br />
              </td>
              <td>
                <asp:DropDownList ID="DropDownList_Provincia" runat="server" AutoPostBack="True" Style="width: 250px;"></asp:DropDownList>
                <br />
              </td>
            </tr>
            <tr>
              <td>
                <label class="text-justify">Canton:</label>
                <br />
              </td>
              <td>
                <asp:DropDownList ID="DropDownList_Canton" runat="server" AutoPostBack="True" Style="width: 250px;"></asp:DropDownList>
                <br />
              </td>
            </tr>
            <tr>
              <td>
                <label class="text-justify">Distrito:</label>
                <br />
              </td>
              <td>
                <asp:DropDownList ID="DropDownList_Distrito" runat="server" AutoPostBack="True" Style="width: 250px;"></asp:DropDownList>
                <br />
              </td>
            </tr>
            <tr>
              <td>
                <label class="text-justify">Colegio:</label>
                <br />
              </td>
              <td>
                <asp:DropDownList ID="DropDownList_HighSchool" runat="server" Style="width: 250px;"></asp:DropDownList>
                <br />
              </td>
            </tr>
            <tr>
              <td>
                <label class="text-justify">Sexo:</label>
                <br />
              </td>
              <td>
                <asp:DropDownList ID="DropDownList_Gender" runat="server" Style="width: 250px;">
                  <asp:ListItem Value="M">Hombre</asp:ListItem>
                  <asp:ListItem Value="F">Mujer</asp:ListItem>
                </asp:DropDownList>
                <br />
              </td>
            </tr>
            <tr>
              <td>
                <label class="text-justify">Telefono:</label>
                <br />
              </td>
              <td>
                <asp:TextBox ID="txt_Telefono" runat="server"></asp:TextBox>
                <br />
            </tr>
            <tr>
              <td>
                <label class="text-justify">Nacionalidad:</label>
                <br />
              </td>
              <td>
                <asp:DropDownList ID="DropDownList_Country" runat="server" Style="width: 250px;">
                </asp:DropDownList>
                <br />
              </td>
            </tr>
            <tr>
              <td>
                <label class="text-justify">Cedula:</label>
                <br />
              </td>
              <td>
                <asp:TextBox ID="txt_Cedula" runat="server"></asp:TextBox>
                <br />
              </td>
            </tr>
            <tr>
              <td>
                <label class="text-justify">Fecha de Nacimiento:</label>
                <br />
              </td>
              <td>
                <asp:TextBox ID="Txt_Date" runat="server"></asp:TextBox>
                <br />
              </td>
            </tr>
          </table>
        </div>
        </section>

      </form>
      <!-- Footer -->
      <footer class="w3-container w3-padding-32 w3-blue-grey"></footer>
      <!-- End page content -->
    </div>



    <script>
      // Script to open and close sidebar
      function w3_open() {
        document.getElementById("mySidebar").style.display = "block";
        document.getElementById("myOverlay").style.display = "block";
      }

      function w3_close() {
        document.getElementById("mySidebar").style.display = "none";
        document.getElementById("myOverlay").style.display = "none";
      }
    </script>

  </body>

</html>
