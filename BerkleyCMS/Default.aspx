<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BerkleyCMS._Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Berklee College</h1>
        <br />
        <div style="display: flex; justify-content: center">
            <p>Apply to one of our bachelor’s or master’s degree programs and receive an admissions decision within two weeks. There's still time to apply. 
                <br />
                <br />
                <br />
            Berklee's campus in New York City offers a one-year master’s degree program with three distinct specializations alongside world-class programming.
            </p>
            <asp:Image ID="Image1" runat="server" Height="336px" ImageUrl="img/1.jpg" Width="770px" />
        </div>


        <div style="display: flex; flex-wrap: wrap; gap: 10px;">
            <div style="height: 80px; width: 90px; padding: 10px; display: flex; gap: 5px; padding: 3px; flex-direction: column;">


                <a href="~/Student" runat="server">
                    <img src="img/add-user.svg" height="50" width="50" />
                    Student</a>
            </div>
            <div style="height: 80px; width: 90px; padding: 10px; display: flex; gap: 5px; padding: 3px; flex-direction: column;">


                <a href="Address.aspx">
                    <img src="img/address.svg" height="50" width="50" />
                    Address</a>
            </div>
            <div style="height: 80px; width: 90px; padding: 10px; display: flex; gap: 5px; padding: 3px; flex-direction: column;">
                <a href="TeacherModule.aspx"><img src="img/teacher.svg" height="50" width="50" />
                Teacher Module</a> 
            </div>
            <div style="height: 80px; width: 90px; padding: 10px; display: flex; gap: 5px; padding: 3px; flex-direction: column;">
                <a href="StudentFee.aspx"><img src="img/fee.svg" height="50" width="50" />
                Student Fee</a>
            </div>
            <div style="height: 80px; width: 90px; padding: 10px; display: flex; gap: 5px; padding: 3px; flex-direction: column;">
                <a href="StudentAssignment.aspx"><img src="img/exam.svg" height="50" width="50" />
                Result</a>
            <%--</div>
             <div style="height: 80px; width: 90px; padding: 10px; display: flex; gap: 5px; padding: 3px; flex-direction: column;">
                <a href="Student.aspx"><img src="img/student.svg" height="50" width="50" />
                Student Details</a>
            </div>
             <div style="height: 80px; width: 90px; padding: 10px; display: flex; gap: 5px; padding: 3px; flex-direction: column;">
                <a href="Module.aspx"><img src="img/module.svg" height="50" width="50" />
               Module</a>
            </div>--%>

        </div>
        <div style="display: flex; padding: 10px; justify-content: space-between; align-items: center">
            <asp:Chart ID="Chart2" runat="server" BackColor="238, 238, 238" DataSourceID="SqlDataSource1">
                <Series>
                    <asp:Series Name="Series1" XValueMember="MODULE_CODE" YValueMembers="CREDIT_HOURS">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;MODULE_CODE&quot;, &quot;CREDIT_HOURS&quot; FROM &quot;MODULE&quot;"></asp:SqlDataSource>
            <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource2" OnLoad="Chart1_Load" Width="500px" BackColor="238, 238, 238" Height="365px" BorderlineColor="238, 238, 238" BackImageAlignment="TopRight">
                <Series>
                    <asp:Series Name="Series1" XValueMember="MODULE_NAME" YValueMembers="CREDIT_HOURS" ChartArea="ChartArea1" ChartType="Pie" >
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>


            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;MODULE_NAME&quot;, &quot;CREDIT_HOURS&quot; FROM &quot;MODULE&quot;"></asp:SqlDataSource>

            <asp:Chart ID="Chart3" runat="server" DataSourceID="SqlDataSource3" BackColor="238, 238, 238" >
                <Series>
                    <asp:Series Name="Series1" XValueMember="MODULE_LEADER" YValueMembers="CREDIT_HOURS" ChartType="Bar">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;MODULE_LEADER&quot;, &quot;CREDIT_HOURS&quot; FROM &quot;MODULE&quot;"></asp:SqlDataSource>

        </div>

    </div>
    </div>
</asp:Content>
