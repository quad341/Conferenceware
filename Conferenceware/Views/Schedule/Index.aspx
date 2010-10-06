<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Conferenceware.Models.Event>>" %>
<%@ Import Namespace="Conferenceware.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Schedule
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Conference Schedule</h2>

    <%
	int currentDay = 0;
    	foreach (Event item in Model)
     {%>
	<%if (item.TimeSlot.start_time.Day != currentDay) {%>
	<%if (currentDay != 0) { %></table><% } %>
	<%
		currentDay = item.TimeSlot.start_time.Day; %>
	<h3><%=item.TimeSlot.start_time.ToString("dddd") %></h3>
	<table style="width: 100%">
	<tr><th style="width: 20%">Location</th><th style="width: 30%">Event</th><th>Speaker</th><th style="width: 20%">Start Time</th></tr>
	<% } %>
    
        <tr>
        <td><%=item.Location.room_number%> <%=item.Location.building_name%></td>
        <td>
		<%=Html.ActionLink(item.name, "Details", new {item.id})%>
	</td>
	<td>
		<%
			foreach (Speaker speaker in item.Speakers) {
		%> <%=Html.ActionLink(Html.Encode(speaker.People.name), "Display", "SpeakerInfo", new {id = speaker.person_id}, null) %> 
		<% } %>
	</td> 
        <td><%=item.TimeSlot.start_time.ToString("h:mm tt") %></td>
        </tr>
    <%
     }%>
	</table>

    <p>You can also check out the <%=Html.ActionLink("videos", "Videos")%><small>(Posted as they are available)</small></p>
</asp:Content>

