<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="scores.aspx.cs" Inherits="StudentsInformationSystem.scores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
             <div>    <asp:Label ID="lbmsg" style= "color:green;" class="form-control" runat="server" Width="285px"  ><strong></strong></asp:Label></div>

    <div class="text-center">
      <div class="wow bounceInDown" data-wow-offset="0" data-wow-delay="0.3s">
        <h3>UNIBEN STUDENTS' INFORMATION SYSTEM</h3>
      </div>
      <div class="wow bounceInDown" data-wow-offset="0" data-wow-delay="0.6s">
        <h2>Please Enter The Student's Scores</h2> 
      </div>
    </div>
  </div>
     <div class="contact-form">
    <div class="container">
      <div class="col-md-8 col-md-offset-2">
        <div id="sendmessage">Your message has been sent. Thank you!</div>
        <div id="errormessage"></div>
          <div class="form-group">
               <p style="color:black;">Select The Student By Typing His MAT Number:</p>
               <asp:DropDownList ID="ddlmatnumber" class="form-control" runat="server">
               </asp:DropDownList>                        <div class="validation"></div>
          </div>
          <div class="form-group">
               <p style="color:black;">Select The Session:</p>
               <asp:DropDownList ID="ddlsession" class="form-control" runat="server">
               </asp:DropDownList>
               <div class="validation"></div>
          </div>
       <div class="form-group">
               <p style="color:black;">Select The Semester:</p> 
               <asp:DropDownList ID="ddlsemester" class="form-control" runat="server">
                    <asp:ListItem Text="First" Value="First"></asp:ListItem>
                    <asp:ListItem Text="Second" Value="Second"></asp:ListItem>
               </asp:DropDownList>
               <div class="validation"></div>
          </div>
           <div class="form-group">
               <p style="color:black;">Select The Current Level:</p> 
               <asp:DropDownList ID="ddllevel" class="form-control" runat="server">
                    <asp:ListItem Text="100L" Value="100"></asp:ListItem>
                    <asp:ListItem Text="200L" Value="200"></asp:ListItem>
                   <asp:ListItem Text="300L" Value="300"></asp:ListItem>
                    <asp:ListItem Text="400L" Value="400"></asp:ListItem>
                   <asp:ListItem Text="500L" value="500"></asp:ListItem>
                    <asp:ListItem Text="600L" Value="600"></asp:ListItem>
                   <asp:ListItem Text="700L" Value="700"></asp:ListItem>
                    <asp:ListItem Text="800L" Value="800"></asp:ListItem>
               </asp:DropDownList>
             <div class="validation"></div>
               <div class="form-group">
               <p style="color:black;">Select The Course:</p>
               <asp:DropDownList ID="ddlcourse" class="form-control" runat="server">
               </asp:DropDownList>
               <div class="validation"></div>
          </div>
          </div>
          <div class="form-group">
                <asp:TextBox ID="txtscore" class="form-control" Placeholder="Enter The Score Obtained" runat="server"></asp:TextBox>
            <div class="validation"></div>
          </div>
          <div class="text-center"> <asp:Button ID="btnsbmit" class="btn btn-primary btn-lg" runat="server" Text="SUBMIT" OnClick="btnsbmit_Click" /></div>
      </div>
    </div>
  </div>

</asp:Content>
