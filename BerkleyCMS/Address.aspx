﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Address.aspx.cs" Inherits="BerkleyCMS.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <h3>Address Details</h3>
        </div>
        <div>
            <div>
                <asp:Label ID="Label1" runat="server" Text="ID" Font-Names="roboto"></asp:Label>
                <asp:TextBox ID="idTxt" runat="server" CssClass="form-control" Font-Names="roboto"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="Address" Font-Names="roboto"></asp:Label>
                <asp:TextBox ID="addTxt" runat="server" CssClass="form-control" Font-Names="roboto"></asp:TextBox>
            </div>
            <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click" CssClass="btn-primary" Font-Names="roboto" />
            <br />
            <asp:TextBox ID="IDStore" runat="server" Visible="False"></asp:TextBox>

        </div>
        <div>
            <asp:GridView ID="addressGridView" runat="server" OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit"  OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." AutoGenerateEditButton="true" AutoGenerateDeleteButton="true" CellSpacing="10" Font-Names="roboto" Width="100%"></asp:GridView>
        </div>
    </div>
</asp:Content>
