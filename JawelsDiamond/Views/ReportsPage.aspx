<%@ Page Title="" Language="C#" MasterPageFile="~/Views/PageMaster.Master" AutoEventWireup="true" CodeBehind="ReportsPage.aspx.cs" Inherits="JawelsDiamond.Views.ReportsPage" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <h2>Reports</h2>
    <form runat="server">
        <div style="width: 100%; height: auto; overflow: scroll">
            <CR:CrystalReportViewer ID="CrystalReportView" runat="server" AutoDataBind="true" />
        </div>
    </form>
</asp:Content>
