<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Conferenceware.Models.Volunteer>>" %>
<%@ Import Namespace="Conferenceware.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Name
            </th>
            <th>
                Is Video Trained?
            </th>
            <th>
                Food Choice
            </th>
            <th>
                T-Shirt Size
            </th>
            <th>
                Timeslot
            </th>
        </tr>

    <%
    	foreach (Volunteer item in Model)
     {%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit",
     	                                  "Edit",
     	                                  new {id = item.person_id})%> |
                <%=Html.ActionLink("Delete",
     	                                  "Delete",
     	                                  new {id = item.person_id})%>
            </td>
            <td>
                <%=Html.Encode(item.People.name)%>
            </td>
            <td>
                <%=Html.Encode(item.is_video_trained)%>
            </td>
            <td>
                <%=Html.Encode(item.Food.name)%>
            </td>
            <td>
                <%=Html.Encode(item.TShirtSize.name)%>
            </td>
            <td>
            <%foreach(var time in item.ScheduledVolunteerTimeSlots.Select(x => x.TimeSlot)){ %>
                <%=Html.Encode(time)%>
                <br />
            <%} %>
            </td>
        </tr>
    
    <%
     }%>

    </table>
    <p>
        There are <%=Html.Encode(Model.Count())%> volunteers.
    </p>
    <p>
        <%=Html.ActionLink("Create New", "Create")%>
    </p>

</asp:Content>

