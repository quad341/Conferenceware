<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Volunteer Time Slot Not Found
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Volunteer Time Slot Not Found</h2>
    
    <p>The requested time slot was not found. You can return to the <%= Html.ActionLink("list of volunteer time slots", "Index") %></p>

</asp:Content>
