<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="UploadScores.aspx.cs" Inherits="StudentsInformationSystem.Upload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                 <div>    <asp:Label ID="lbmsg" style= "color:green;" class="form-control" runat="server" Width="285px"  ><strong></strong></asp:Label></div>

     <div class="container">
    <div class="text-center">
      <div class="wow bounceInDown" data-wow-offset="0" data-wow-delay="0.3s">
        <h3>Welcome As The Score Entering Officer</h3>
      </div>
      <div class="wow bounceInDown" data-wow-offset="0" data-wow-delay="0.6s">
        <h2>You Are About To Upload Students' Scores To The Central Data Base For Transcript Generation</h2>
      </div>
    </div>
  </div>
 <div class="contact-form">
    <div class="container">
      <div class="col-md-8 col-md-offset-2">
        <div id="sendmessage">Your message has been sent. Thank you!</div>
        <div id="errormessage"></div>
          <div class="form-group">
               <p style="color:black;">Select The Department:</p>
               <asp:DropDownList ID="ddldepartment" class="form-control" runat="server">
               </asp:DropDownList>                        <div class="validation"></div>
          </div>
          <div class="form-group">
               <p style="color:black;">Select The Session:</p>
               <asp:DropDownList ID="ddlsession" class="form-control" runat="server">
               </asp:DropDownList>
               <div class="validation"></div>
          </div>
          
          <div class="text-center"> <asp:Button ID="btnsbmit" class="btn btn-primary btn-lg" runat="server" Text="UPLOAD" OnClick="btnsbmit_Click" /></div>
      </div>
    </div>
  </div>

</asp:Content>
