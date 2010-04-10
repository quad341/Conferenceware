<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
         Logged in as : <b><%= Html.Encode(Page.User.Identity.Name) %></b>
         <br />
         <%= Html.ActionLink("Log Out", "LogOff", "Account") %> 
<%
    }
    else {
%> 
         <%= Html.ActionLink("Log In", "LogOn", "Account") %> 
<%
    }
%>
