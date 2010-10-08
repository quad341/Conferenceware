<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<String>" %>


    <% using (Html.BeginForm("Search", "AttendeeCheckIn", FormMethod.Get))
       {%>
       <div class="display-label">
        Search Query <small>All or part of the person's name or email</small>
       </div>
       <div class="display-data">
        <input type="text" name="query" value="<%= Model %>"/>
       </div>
       <input type="submit" value="Submit" />
    <%
       }%>