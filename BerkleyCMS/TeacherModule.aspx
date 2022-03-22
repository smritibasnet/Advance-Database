<%@ Page Title="Teacher-Module" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TeacherModule.aspx.cs" Inherits="BerkleyCMS.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br />
    <asp:Label ID="Label1" runat="server" Text="Teacher Module Details" Font-Bold="True" Font-Size="X-Large" ForeColor="#663300" CssClass="col-md-10" Font-Names="roboto"></asp:Label>
    <br />
     <br />
    <asp:DropDownList ID="idddl" runat="server" DataSourceID="SqlDataSource1" DataTextField="NAME" DataValueField="NAME" Font-Names="roboto" CssClass="form-control">
    </asp:DropDownList>
      &nbsp;&nbsp;
      <asp:Button ID="Button1" runat="server" Text="Show" OnClick="Button1_Click" BorderColor="#663300" CssClass="form-control" Height="30px" Width="107px" Font-Names="roboto" />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT p.name FROM person p join teacher t on p.person_id=t.teacher_id"></asp:SqlDataSource>
    <br />
     <asp:GridView ID="tmGridView" runat="server" CellSpacing="10" Width="100%" >
     </asp:GridView>
</asp:Content>
