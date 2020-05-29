<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="session.aspx.cs" Inherits="StudentsInformationSystem.session" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
    <div class="text-center">
      <div class="wow bounceInDown" data-wow-offset="0" data-wow-delay="0.3s">
        <h3>Session</h3>
      </div>
      <div class="wow bounceInDown" data-wow-offset="0" data-wow-delay="0.6s">
        <h2>Please, Enter The Session</h2>
      </div>
    </div>
  </div>

<div class="contact-form">
    <div class="container">
      <div class="col-md-8 col-md-offset-2">
        <div id="sendmessage">Your message has been sent. Thank you!</div>
        <div id="errormessage"></div>
       
          <div class="form-group">
              <asp:TextBox ID="txtsession" class="form-control" Placeholder="Enter The Session" runat="server"></asp:TextBox>
            <div class="validation"></div>
          </div>
          <div class="text-center"> <asp:Button ID="btnsubmit" class="btn btn-primary btn-lg" runat="server" Text="SUBMIT" OnClick="btnsubmit_Click" /></div>    
      </div>
    </div>
  </div><asp:Label ID="lbmsg" style= "color:green;" class="form-control" runat="server"  ><strong>Text=""</strong></asp:Label>

</asp:Content>
