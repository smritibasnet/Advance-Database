<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BerkleyCMS._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
         <h1>Berklee College</h1>
        <br />
        <p class="lead">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT derivedtbl_1.STUDENT_COUNT, derivedtbl_2.TEACHER_COUNT FROM (SELECT COUNT(NAME) AS STUDENT_COUNT FROM PERSON WHERE (DESIGNATION = 'Student')) derivedtbl_1, (SELECT COUNT(NAME) AS TEACHER_COUNT FROM PERSON PERSON_1 WHERE (DESIGNATION = 'Teacher')) derivedtbl_2"></asp:SqlDataSource>
            <p>Apply to one of our bachelor’s or master’s degree programs and receive an admissions decision within two weeks. There's still time to apply. </p>
            <asp:Image ID="Image1" runat="server" Height="336px" ImageUrl="img/1.jpg" Width="770px"  />
        </p>
        <div style="display: flex; flex-wrap: wrap; gap: 10px;">
            <div style="height: 80px; width: 90px; padding: 10px; display: flex; gap: 5px; padding: 3px; flex-direction: column;">


                <img src="img/add-user.svg" height="50" width="50" />
                Student
            </div>
            <div style="height: 80px; width: 90px; padding: 10px; display: flex; gap: 5px; padding: 3px; flex-direction: column;">


                <img src="img/address.svg" height="50" width="50" />
                Address
            </div>
            <div style="height: 80px; width: 90px; padding: 10px; display: flex; gap: 5px; padding: 3px; flex-direction: column;">
                <img src="img/teacher.svg" height="50" width="50" />
                Teacher Module
            </div>
            <div style="height: 80px; width: 90px; padding: 10px; display: flex; gap: 5px; padding: 3px; flex-direction: column;">
                <img src="img/fee.svg" height="50" width="50" />
                Student Fee
            </div>
            <div style="height: 80px; width: 90px; padding: 10px; display: flex; gap: 5px; padding: 3px; flex-direction: column;">
                <img src="img/exam.svg" height="50" width="50" />
                Exam
            </div>
        </div>
       </div>

</asp:Content>
