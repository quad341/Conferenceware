<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.VolunteerTimeSlotScheduleData>" %>
<%@ Import Namespace="Conferenceware.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Schedule
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Schedule</h2>
    <div class="display-label">Currently Confirmed volunteers</div>
    <div class="display-field">
        <ul>
            <%
            	foreach (Volunteer vol in Model.VolunteerTs.ConfirmedVolunteers)
             {%>
               <li class="entry-with-inline-form">
                    <%
             	using (
             		Html.BeginForm("UnSchedule", "VolunteerTimeSlot", FormMethod.Post)
             		)
             	{%>
                    <input type="hidden" name="id" value="<%=
             			vol.VolunteersVolunteerTimeSlots.SingleOrDefault(
             				x => x.volunteer_timeslot_id == Model.VolunteerTs.timeslot_id).
             				id%>" />
                    <input type="submit" value="Remove" />
                    <%
             	}%>
                    <%=Html.Encode(vol.People.name)%>
               </li>
            <%
             }%>
        </ul>
    </div>

    <%
            	using (Html.BeginForm())
             {%>

        <fieldset>
            <legend>Fields</legend>  
            <div class="editor-label">
                Volunteer
            </div>
            <div class="editor-field">
                <%=Html.DropDownList(
             		"VolunteersVolunteerTimeSlot", Model.Volunteers)%>
            </div>
            <div class="editor-label">
                Comment (optional)
            </div>
            <div class="editor-field">
                <textarea name="comment" id="comment" rows="15" cols="80"></textarea>
            </div>
            
            
            <p>
                <input type="submit" value="Schedule" />
            </p>
        </fieldset>

    <%
             }%>

    <div>
        <%=Html.ActionLink("Back to List", "Index")%>
    </div>
</asp:Content>
