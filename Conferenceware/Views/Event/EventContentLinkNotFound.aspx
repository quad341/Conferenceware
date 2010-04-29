<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Event Content Link Not Found
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Event Content Link Not Found</h2>
    
    <p>The requested content link was not found. You can return to the <%=Html.ActionLink("event list", "Index")%></p>

</asp:Content>
