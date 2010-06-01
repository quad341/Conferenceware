<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Speaker Not Found
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Speaker Not Found</h2>

    <p>The requested speaker was not found. You can return to the <%= Html.ActionLink("speaker list", "Index") %>.</p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ExtraHeadContent" runat="server">
</asp:Content>
