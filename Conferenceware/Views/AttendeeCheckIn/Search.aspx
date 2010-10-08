<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.AttendeeCheckInDisplayData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Search Results
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Search</h2>
    <!-- disallow external access the ghetto way -->
    <%if (Request.UserHostAddress != "128.174.251.38" && Request.UserHostAddress != "128.174.251.40" && Request.UserHostAddress != "128.174.251.28")
      { %>
    <%
        Html.RenderPartial("CheckInSearchForm", Model.Query); %>

    <h4>Results:</h4>

    <table>
        <tr>
            <th>Name</th>
            <th>Email</th>
            <th>Food Choice</th>
            <th>Tshirt Size</th>
            <th>Checked In?</th>
            <th>Toggle Check In</th>
        </tr>
        <% foreach (var attendee in Model.Attendees)
           {%>
        <tr>
           <td><%= Html.Encode(attendee.People.name)%></td>
           <td><%= Html.Encode(attendee.People.email)%></td>
           <td><%= Html.Encode(attendee.Food)%></td>
           <td><%= Html.Encode(attendee.TShirtSize)%></td>
           <td><%= Html.Encode(attendee.checked_in)%></td>
           <td>
               <% using (Html.BeginForm(attendee.checked_in ? "UnCheckIn" : "CheckIn", "AttendeeCheckIn", FormMethod.Post))
                  {%>
                <input type="hidden" name="id" value="<%= attendee.person_id %>" />
                <input type="hidden" name="query" value="<%= Model.Query %>" />
                <input type="submit" value="<%= attendee.checked_in?"UnCheckIn":"CheckIn" %>" />
               <%
        }%>
           </td>
        </tr>
        <%
        }%>
    </table>
    <%} %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ExtraHeadContent" runat="server">
</asp:Content>
