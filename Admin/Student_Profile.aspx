<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Student_Profile.aspx.cs" Inherits="Admin_Student_Profile" %>


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
<form id="form1" runat="server">
    <!-- Navigation -->
 <nav class="navbar navbar-expand-lg navbar-light fixed-top" id="mainNav">
      <div class="container">
          <%--<a href="HomePage"> Cerrar Sesion</a>--%>

          <%--para hacer un home button--%>
<%--                   <div style="float:right;padding-right:15px;">
     <asp:HyperLink ID="homelnk" runat="server" class="fa fa-home" Font-Size="XX-Large" NavigateUrl="~/Admin/Menu.aspx" ></asp:HyperLink>
     </div>--%>


        <a class="navbar-brand js-scroll-trigger" href="#page-top">Perfil Estudiante</a>
        <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
          <i class="fa fa-bars"></i>
        </button>
        <div class="collapse navbar-collapse" id="navbarResponsive">
          <ul class="navbar-nav ml-auto">
            <li class="nav-item">
              <a class="nav-link js-scroll-trigger" href="#Examenes">Examenes</a>
            </li>
            <li class="nav-item">
              <a class="nav-link js-scroll-trigger" href="#description">Mi Informacion</a>
            </li>   
              <li class="nav-item">
              <a class="nav-link js-scroll-trigger" href="HomePage">Cerrar Sesion</a>
            </li>  

          </ul>
        </div>
      </div>
    </nav>
    

    <!-- Description Section -->
    <section id="Informacion" class="content-section text-center">
      <div class="container">
        <div class="row">
          <div class="col-lg-8 mx-auto">
            <h2>Informacion</h2>
              <p>Bienvenido al Modulo de Pruebas Psicologicas</p>
            <table class="text-center table table-default" >            
              <tr>
                  <td>   
                      <%--<label class="text-justify">Bienvenido al Modulo de Pruebas Psicologicas</label> <br/> --%>
                      <label class="text-justify">Usuario:</label> <br/> 
                  </td> 
                  <td>     
                      <asp:TextBox ID="txt_Nombre" runat="server" Font-Bold="True"></asp:TextBox>                            
                  </td>
              </tr>  
           </table>
          </div>
        </div>
      </div>
      <br/>
      <br/>
      <br/>
    </section>

      <!-- Description Section -->
    <section id="Examenes" class="content-section text-center">
      <div class="container">
        <div class="row">
          <div class="col-lg-8 mx-auto">
            <h2>Examenes</h2>  
            <br/>
            <br/>
              <div id="examdiv" runat="server" class="text-center">
          <asp:Repeater ID="examrepeater" runat="server" OnItemCommand="examrepeater_ItemCommand">
            <HeaderTemplate>
                <table style="width: 100%">
                    <tr style="background-color: gray; color: white;">
                        <td style="height: 25px; padding-left: 10px; font-weight: bold;">Examen</td>
                        <td style="height: 25px; padding-left: 10px; font-weight: bold;">Descripcion</td>
                        <td style="height: 25px; padding-left: 10px; font-weight: bold;">&nbsp;</td>
                        
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr style="background-color: darkgray;border-color:white;">
                    <td style="height: 25px; padding-left: 10px;margin:0 auto 0 auto;text-align:left">
                        <asp:Label ID="lblquizname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "name")%>' Font-Bold="true" ></asp:Label>
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


<footer class="container-fluid">
  <p>@All Rights Reserved</p>
</footer>

        <!-- Bootstrap core JavaScript -->
    <script src="~/vendor/jquery/jquery.min.js"></script>
    <script src="~/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Plugin JavaScript -->
    <script src="~/vendor/jquery-easing/jquery.easing.min.js"></script>

  <!-- Custom scripts for this template -->
   <script src="~/js/grayscale.min.js"></script>
</form>
</body>
</html>

