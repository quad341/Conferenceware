<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Begin Search
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Search For Attendees</h2>
    <!-- disallow external access the ghetto way -->
    <% if (Request.UserHostAddress != "128.174.251.38" && Request.UserHostAddress != "128.174.251.40" && Request.UserHostAddress != "128.174.251.28")
       {%>
    <%
        Html.RenderPartial("CheckInSearchForm", ""); %>
    <%} %>
</asp:Content>