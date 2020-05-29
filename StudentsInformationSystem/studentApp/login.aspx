<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="StudentsInformationSystem.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">

   <div class="text-center">
      <div class="wow bounceInDown" data-wow-offset="0" data-wow-delay="0.3s">
        <h3>LOGIN</h3>
      </div>
      <div class="wow bounceInDown" data-wow-offset="0" data-wow-delay="0.6s">
        <h2>You are welcome to LOGIN page</h2>
      </div>
    </div>
  </div>

<div class="contact-form">
    <div class="container">
      <div class="col-md-8 col-md-offset-2">
        <div id="sendmessage">Your message has been sent. Thank you!</div>
        <div id="errormessage"></div>
       
          <div class="form-group">
              <asp:TextBox ID="txtusername" class="form-control" Placeholder="Enter Your Username" runat="server"></asp:TextBox>
            <div class="validation"></div>
          </div>
          <div class="form-group" runat="server" id="lg">
              <asp:TextBox ID="txtpassword" class="form-control" Placeholder="Please Enter Password" runat="server" TextMode="Password"></asp:TextBox>
             <div class="validation"></div>
          </div>
           <div class="form-group">
              <asp:TextBox ID="txtpassword2" class="form-control" Placeholder="Please Re-Enter Password" runat="server" TextMode="Password" Width="910px"></asp:TextBox>
             <div class="validation"></div>
          </div>
         
          <div class="text-center"> <asp:Button ID="btnlogin" class="btn btn-primary btn-lg" runat="server" Text="LOGIN" Height="53px" Width="166px" OnClick="btnlogin_Click" /></div>
       
      </div>
    </div>
  </div>

</asp:Content>
