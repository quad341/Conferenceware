<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Person Not Found
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<h2>Person Not Found</h2>
	
	<p>The requested person was not found. You can return to <%= Html.ActionLink("the companies list", "Index", "Company") %>.</p>

</asp:Content>
