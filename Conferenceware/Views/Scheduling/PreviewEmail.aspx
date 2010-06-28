<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<String>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Preview Email
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Preview Email</h2>

    <pre>
    <%= Model %>
    </pre>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ExtraHeadContent" runat="server">
</asp:Content>
