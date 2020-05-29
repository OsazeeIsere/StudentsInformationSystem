<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="students.aspx.cs" Inherits="StudentsInformationSystem.students" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container">
    <div class="text-center">
      <div class="wow bounceInDown" data-wow-offset="0" data-wow-delay="0.3s">
        <h3>UNIBEN STUDENTS' INFORMATION SYSTEM</h3>
      </div>
      <div class="wow bounceInDown" data-wow-offset="0" data-wow-delay="0.6s">
        <h2>Please Register New students</h2>
      </div>
    </div>
  </div>
     <div class="contact-form">
    <div class="container">
      <div class="col-md-8 col-md-offset-2">
        <div id="sendmessage">Your message has been sent. Thank you!</div>
        <div id="errormessage"></div>
       
          <div class="form-group">
              <asp:TextBox ID="txtlastname" class="form-control" Placeholder="Enter The Last Name" runat="server"></asp:TextBox>
            <div class="validation"></div>
          </div>
          <div class="form-group">
              <asp:TextBox ID="txtothername" class="form-control" Placeholder="Please Enter Other Names" runat="server" TextMode="MultiLine"></asp:TextBox>
             <div class="validation"></div>
          </div>
           <div class="form-group">
              <asp:TextBox ID="txtmatnumber" class="form-control" Placeholder="Enter The MAT Number" runat="server"></asp:TextBox>
            <div class="validation"></div>
          </div>
          <div class="form-group">
               <p style="color:black;">Select The Department:</p>
               <asp:DropDownList ID="ddldepartment" class="form-control" runat="server">
               </asp:DropDownList>
                          <div class="validation"></div>
          </div>
           <div class="form-group">
               <p style="color:black;">Select The Gender:</p>
               <asp:DropDownList ID="ddlgender" class="form-control" runat="server">
                   <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
               </asp:DropDownList>
                          <div class="validation"></div>
          </div>
                  <div class="form-group">
              <asp:TextBox ID="txtstartsession" class="form-control" Placeholder="Enter The Start Session" runat="server"></asp:TextBox>
            <div class="validation"></div>
          </div>
          <div class="form-group">
              <asp:TextBox ID="txtendsession" class="form-control" Placeholder="Please Enter Endsession" runat="server"></asp:TextBox>
             <div class="validation"></div>
          </div>  

          <div class="text-center"> <asp:Button ID="btnregister" class="btn btn-primary btn-lg" runat="server" Text="REGISTER" OnClick="btnregister_Click" /></div>
       
      </div>
    </div>
  </div>
    <asp:Label ID="lbmsg" style= "color:green;"  class="form-control" runat="server"  ><strong>Text=""</strong></asp:Label>

</asp:Content>
