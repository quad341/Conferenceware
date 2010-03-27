<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Volunteer Not Found
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Volunteer Not Found</h2>
    
    <p>The requested volunteer was not found. You can return to the <%= Html.ActionLink("volunteers list", "Index") %></p>

</asp:Content>
