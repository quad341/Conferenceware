<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
         Logged in as : <b><%= Html.Encode(Page.User.Identity.Name) %></b>
         <br />
         <%= Html.ActionLink("Log Off", "LogOff", "Account") %> 
<%
    }
    else {
%> 
         <%= Html.ActionLink("Log On", "LogOn", "Account") %> 
<%
    }
%>
