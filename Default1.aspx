<%@ Page Title="Product quiz Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default1.aspx.cs" Inherits="_Default" %>

<asp:Content ID="headerContent" ContentPlaceHolderID="HeadContent" runat="server">  
</asp:Content>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" updatemode="Conditional">
  <ContentTemplate>
      &nbsp;<asp:Label ID="Label1" runat="server" Font-Size="XX-Large"></asp:Label>
    <asp:Timer ID="tm1" Interval="1000" runat="server" ontick="tm1_Tick" />
  </ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="tm1" EventName="Tick" />
  </Triggers>
</asp:UpdatePanel>
    <asp:Label ID="lblmessage" runat="server" ForeColor="#ff0000" Visible="false" /><br />
    <asp:HiddenField ID="quizfield" runat="server" />
    <!-- quiz details -->
    <div id="quizdetails" runat="server">
        <!-- quiz title -->
        <asp:Label ID="lblquizname" runat="server" CssClass="quizname" />
        <br />
        <br />

        <!-- description -->
        <asp:Label ID="lbldescription" runat="server" CssClass="quizdesc" />
        <br />
        <br />
    </div>
    <div id="Questions" runat="server">
        <br />
        <br />
        <asp:Image ID="Image" runat="server" Height="191px" Width="392px" />
        <br />
        <asp:Label ID="lbMessage" runat="server" Font-Size="XX-Large"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnExit" runat="server" OnClick="btnExit_Click" Text="Exit" />
        <br />
        <asp:Label runat="server" id="lbQuestion" />
        <br />
        <br />
         <asp:Repeater ID="multiplequestionsrpt" runat="server" OnItemDataBound="multiplequestionsrpt_ItemDataBound">
                <ItemTemplate>
                    <asp:HiddenField ID="hfID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "id")%>' Visible="false" />
                    <asp:RequiredFieldValidator ID="rfvquiz" runat="server" Display="Dynamic" ControlToValidate="rbloptions" ValidationGroup="quizvalidation" ForeColor="Red" Text="*" SetFocusOnError="true"/><br />
                    <asp:RadioButtonList ID="rbloptions" runat="server" ValidationGroup="quizvalidation" />                    
                </ItemTemplate>
            </asp:Repeater>
        <br />
        <asp:TextBox ID="txtanswer" runat="server" Height="23px" Width="400px" OnTextChanged="txtanswer_TextChanged" AutoPostBack="true"/>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtanswer" Display="Dynamic" ErrorMessage="Please enter a response" SetFocusOnError="true" ForeColor="Red" ValidationGroup="txtanswerquizvalidation" />
<%--        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtanswer" runat="server" ValidationExpression="\d+"> </asp:RegularExpressionValidator>--%>
        <br />
         <asp:Label ID="lberror" runat="server" ForeColor="#ff0000" Visible="false" /><br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text="Next" ValidationGroup="quizvalidation" />
        <br />
    </div>

    <!-- quiz questions -->
    <div id="quiz">
        <div id="detailsdiv" runat="server">
            <fieldset>
                <legend>Please fill your details</legend>
            </fieldset>
        </div>
       

    </div>
</asp:Content>