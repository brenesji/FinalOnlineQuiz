<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="newquiz.aspx.cs" Inherits="Admin_newquiz" %>
<%@ Register Assembly="FredCK.CKEditor" Namespace="FredCK.CKEditor" TagPrefix="FredCK" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.5/themes/base/jquery-ui.css" type="text/css" media="all" />
    <link rel="stylesheet" href="http://static.jquery.com/ui/css/demo-docs-theme/ui.theme.css" type="text/css" media="all" />
    <script src="../Scripts/jquery-1.8.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.min.js" type="text/javascript"></script>

     <div style="float:right;padding-right:15px;">
     <asp:HyperLink ID="homelnk" runat="server" class="fa fa-home" Font-Size="XX-Large" NavigateUrl="~/Admin/Menu.aspx" ></asp:HyperLink>
     </div>
    <script type="text/javascript">
        $(function () {
            $("#<%= txtstartdate.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: true, changeYear: true, minDate: '+0d' });
            $("#<%= txtenddate.ClientID  %>").datepicker({ dateFormat: 'dd/mm/yy', changeMonth: true, changeYear: true, minDate: '+0d' });
        });
    </script>

    <script type="text/javascript" src="../Scripts/ckeditor/ckeditor.js"></script>
    <style type="text/css">
        #ui-datepicker-div {
            display: none;
        }


    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="startquiz">
        <br />
        <h2>Nuevo Examen</h2>
        <br />
        <asp:Label ID="lblname" Text="Nombre del Examen" runat="server" />
        <br />
        <asp:TextBox ID="txtname" runat="server" height="25px" Width="350px"/>&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="namevalidator" runat="server" ControlToValidate="txtname" Display="Dynamic" ErrorMessage="Por Favor Ingrese el Nombre del Quiz" SetFocusOnError="true" ForeColor="Red" ValidationGroup="submitvalidation" />
        <asp:RegularExpressionValidator ID="nameregexvalidator" runat="server" ErrorMessage="only alphabets allowed" ControlToValidate="txtname" Display="Dynamic" ValidationExpression ="^[a-zA-Z'.\s]{1,100}$" SetFocusOnError="true" ForeColor="Red" ValidationGroup="submitvalidation" />
        
        <br />
        <br />
        <asp:Label ID="lbldescription" Text="Description" runat="server" />
        <br />
        <asp:TextBox ID="txtdescription" runat="server" height="25px" Width="350px"/>&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="descriptionvalidator" runat="server" ControlToValidate="txtdescription" Display="Dynamic" ErrorMessage="Ingrese una Descripcion" SetFocusOnError="true" ForeColor="Red" ValidationGroup="submitvalidation" />

        <br />
        <br />
        <asp:Label ID="lblstartdate" Text="Fecha Incio" runat="server" />
        <br />
        <asp:TextBox ID="txtstartdate" runat="server" height="25px" Width="125px"/>&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="startdatevalidator" runat="server" ControlToValidate="txtstartdate" Display="Dynamic" ErrorMessage="Por Favor Ingrese Fecha de inicio" SetFocusOnError="true" ForeColor="Red" ValidationGroup="submitvalidation" />

        <br />
        <br />
        <asp:Label ID="lblenddate" Text="Fecha Final" runat="server" />
        <br />
        <asp:TextBox ID="txtenddate" runat="server" height="25px" Width="125px"/>&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="enddatevalidator" runat="server" ControlToValidate="txtenddate" Display="Dynamic" ErrorMessage="Por Favor Ingrese Fecha Final" SetFocusOnError="true" ForeColor="Red" ValidationGroup="submitvalidation" />

        <br />
        <br />
        <asp:Label ID="lblcompletiondescription" Text="Descripcion de la Prueba" runat="server" />
        <br />
        <asp:TextBox ID="txtcompletiondescription" runat="server" height="25px" Width="350px" TextMode="MultiLine"/>&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="completiondescriptionvalidator" runat="server" ControlToValidate="txtcompletiondescription" Display="Dynamic" ErrorMessage="Por Favor Agregue la Descripcion" SetFocusOnError="true" ForeColor="Red" ValidationGroup="submitvalidation" /> 
        



        <br />
        <br />
        <asp:Label ID="lbladdquestions" Text="Agregar Preguntas" runat="server" />
        
        <br />
        <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>&nbsp;&nbsp;
        <%--<asp:TextBox ID="TextBox1" runat="server" height="25px" Width="350px" TextMode="MultiLine"/>&nbsp;&nbsp;--%>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcompletiondescription" Display="Dynamic" ErrorMessage="Por Favor Agregue preguntas" SetFocusOnError="true" ForeColor="Red" ValidationGroup="submitvalidation" />--%>
        




        <br />
        <br />
        <asp:Label ID="lblterms" Text="Terminos y Condiciones" runat="server" />
        <FredCK:CKEditor ID="txtterms" runat="server" BasePath="~/scripts/ckeditor" Width="950px"></FredCK:CKEditor>

        <br />
        <br />
        <asp:Button ID="submitquiz" runat="server" Text="Crear " Height="25px" Width="75px" OnClick="submitquiz_click" ValidationGroup="submitvalidation" />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblalert" runat="server" Visible="false" ForeColor="Red" /><br /><br />
    </div>
</asp:Content>

