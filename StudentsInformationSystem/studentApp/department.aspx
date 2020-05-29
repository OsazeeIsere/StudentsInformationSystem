<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="department.aspx.cs" Inherits="StudentsInformationSystem.department" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>    <asp:Label ID="lbmsg" style= "color:green;" class="form-control" runat="server"  ><strong></strong></asp:Label></div>

      <div class="container">
    <div class="text-center">
      <div class="wow bounceInDown" data-wow-offset="0" data-wow-delay="0.3s">
        <h3>UNIBEN CENTRAL TRANSCRIPT SYSTEM</h3>
      </div>
      <div class="wow bounceInDown" data-wow-offset="0" data-wow-delay="0.6s">
        <h2>Please Enter The Department</h2> 
      </div>
    </div>
  </div>
     <div class="contact-form">
    <div class="container">
      <div class="col-md-8 col-md-offset-2">
        <div id="sendmessage">Your message has been sent. Thank you!</div>
        <div id="errormessage"></div>
     <div class="form-group">
               <p style="color:black;">Select The Faculty:</p>
               <asp:DropDownList ID="ddlfaculty" class="form-control" runat="server">
                    <asp:ListItem Text="Physical Sciences" Value="Physical Sciences"></asp:ListItem>
               <asp:ListItem Text="Social Sciences" Value="Social Sciences"></asp:ListItem>
               <asp:ListItem Text="Engineering" Value="Engineering"></asp:ListItem>
              
                   </asp:DropDownList>
      <div class="validation"></div>
             <div class="form-group">
              <asp:TextBox ID="txtdepartment" class="form-control" Placeholder="Enter The department" runat="server"></asp:TextBox>
            <div class="validation"></div>
          </div>
               <div class="text-center"> <asp:Button ID="btnsubmit" class="btn btn-primary btn-lg" runat="server" Text="SUBMIT" OnClick="btnsubmit_Click" /></div>
       </div>
      </div>
    </div>
  </div>
</asp:Content>
