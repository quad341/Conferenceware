<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.VolunteerTimeSlotScheduleData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Schedule
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Schedule</h2>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>  
            <%= Html.HiddenFor(model => model.VolunteerTs.timeslot_id) %>
            <div class="editor-label">
                Volunteer
            </div>
            <div class="editor-field">
                <%= Html.DropDownList("Volunteer", Model.Volunteers) %>
            </div>
            
            <p>
                <input type="submit" value="Schedule" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
