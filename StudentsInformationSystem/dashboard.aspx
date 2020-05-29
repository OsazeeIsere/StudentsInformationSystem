<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="StudentsInformationSystem.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
         .items {
             background-color:#e1ea94;
             padding:20px;
             margin:25px;
             width:45%;
             float:left;
             border-radius:5px;
         }
          .items2 {
             background-color:#e1ea94;
             padding:20px;
             margin:25px;
             width:25%;
             float:left;
             border-radius:5px;
         }
           .items2 h3 {
             background-color:#4800ff;
             color:#c1c7e4;
             padding:15px;
         }

         .items h3 {
             background-color:#4800ff;
             color:#c1c7e4;
             padding:15px;
         }

         .btn_item {
             padding: 5px 10px 5px 10px;
             border-radius:8px;
             font-size:larger;
             color:#ff00dc;
         }

         @media screen and (max-width: 920px) {
             .items {
                float:none;
             width:100%;
             margin-right:35px;
         }
         }
         .auto-style1 {
             width: 83px;
             height: 62px;
         }
     </style>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div  runat="server" visible="false" id="divtranscriptStatus" class="auto-style1">
          <h3>Action Box: Please Click The Drop Down List To Select MAT No. </h3>
                  <asp:DropDownList ID="ddlgeneratedTranscript" runat="server"></asp:DropDownList>
          </div>
      <div class="container">
            

    
      <div class="wow bounceInDown" data-wow-offset="0" data-wow-delay="0.3s">
        <h3>DASHBOARD</h3>
      </div>
      <div class="wow bounceInDown" data-wow-offset="0" data-wow-delay="0.6s">
        <h2>You are welcome As <asp:Label ID="lbluserrole" runat="server" Text=""></asp:Label></h2>
          <p>&nbsp;</p>
          <div class="items" runat="server" visible="false" id="divusers">
              <h3>Users</h3>
                     
                      <asp:Button ID="Button6" runat="server" Text="Add New" PostBackUrl="~/Users.aspx" CssClass="btn_item" />
                        <br />
                      <asp:Button ID="Button7" runat="server" Text="Manage Users" CssClass="btn_item" PostBackUrl="~/updateuser.aspx" OnClick="Button7_Click" />
                  </div>

                      <div class="items" runat="server" visible="false" id="divscores">
                              <h3>Scores</h3>
                                  <asp:Button ID="btnenterscores" runat="server" Text="Enter Scores" PostBackUrl="~/scores.aspx" CssClass="btn_item" />
                                    <br />
                      <asp:Button ID="btnbulkupload" runat="server" Text="Bulk Upload" CssClass="btn_item" OnClick="btnbulkupload_Click" />
                         <br />
                            <asp:Button ID="btnviewscores" runat="server" Text="View Scores" CssClass="btn_item" />
                           </div>
                      <p>&nbsp;</p>
      
           <div class="items" runat="server" visible="false" id="divtranscript">
                    <h3>Transcript</h3>
                    <asp:Button ID="btnmoveforactio" runat="server" Text="Move For Action" CssClass="btn_item" OnClick="btnmoveforactio_Click" />

               <asp:Button ID="btngeneratetranscript" runat="server" Text="Generate" PostBackUrl="~/transcript.aspx" CssClass="btn_item" OnClick="btngeneratetranscript_Click" />
                         <br />
                    <asp:Button ID="btnviewtranscript" runat="server" Text="View" CssClass="btn_item" PostBackUrl="~/viewtranscript.aspx" />
                         <br />
                    <asp:Button ID="btnmanagetranscript" runat="server" Text="Manage" CssClass="btn_item" />
                </div>

        <div class="items" runat="server" visible="false" id="divstudents">
                     <h3>Students</h3>
                      <asp:Button ID="btnaddstudent" runat="server" Text="Add New" PostBackUrl="~/students.aspx" CssClass="btn_item" OnClick="btnaddstudent_Click" />
                         <br />
                      <asp:Button ID="btnuploadsstudents" runat="server" Text="Upload Students' Info." CssClass="btn_item" OnClick="btnuploadsstudents_Click" />
                         <br />
                      <asp:Button ID="btnmanageStudent" runat="server" Text="Add New Session" CssClass="btn_item" OnClick="btnmanageStudent_Click" />
          
                      <asp:Button ID="btnadddepartment" runat="server" Text="Add New Department" CssClass="btn_item" OnClick="btnadddepartment_Click" />

                 </div>
             
        </div>
    </div>
   
</asp:Content>
