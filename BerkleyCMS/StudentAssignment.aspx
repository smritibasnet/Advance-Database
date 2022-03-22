<%@ Page Title="Student Assignment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentAssignment.aspx.cs" Inherits="BerkleyCMS.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Label ID="Label1" runat="server" Text="Student Assignment Details" Font-Bold="True" Font-Size="X-Large" ForeColor="#663300" CssClass="col-md-10" Font-Names="roboto"></asp:Label>
    <br />
    <br />
    <asp:DropDownList ID="nameddl" runat="server" DataSourceID="SqlDataSource1" DataTextField="NAME" DataValueField="NAME" CssClass="form-control" Font-Names="roboto">
    </asp:DropDownList>
      &nbsp;&nbsp;
      <asp:Button ID="Button1" runat="server" Text="Show" OnClick="Button1_Click" BorderColor="#663300" CssClass="form-control" Font-Names="roboto" Height="30px" Width="107px" />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT p.name FROM person p join student s on p.person_id=s.student_id"></asp:SqlDataSource>
    <br />
    <asp:GridView ID="studentassignmentGridView" runat="server" BorderColor="#663300" BorderStyle="None" CellSpacing="10" CssClass="container" Font-Names="roboto" HorizontalAlign="Center" Width="100%" >
    </asp:GridView>
  
</asp:Content>


