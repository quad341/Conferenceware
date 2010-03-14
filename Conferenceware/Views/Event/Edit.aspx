<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.EventEditData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.EnableClientValidation(); %>
    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
             
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Event.name) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Event.name) %>
                <%= Html.ValidationMessageFor(model => model.Event.name) %>
            </div>
             
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Event.description) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Event.description) %>
                <%= Html.ValidationMessageFor(model => model.Event.description) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Event.max_attendees) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Event.max_attendees) %>
                <%= Html.ValidationMessageFor(model => model.Event.max_attendees) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Event.location_id) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.Event.location_id, Model.Locations) %>
                <%= Html.ValidationMessageFor(model => model.Event.location_id) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Event.timeslot_id) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.Event.timeslot_id, Model.Timeslots) %>
                <%= Html.ValidationMessageFor(model => model.Event.timeslot_id) %>
            </div>
           
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>
    <div class="display-label">
        Speaker(s)</div>
    <div class="display-field">
        <ul>
            <% foreach (var speaker in Model.Event.Speakers) {%>
            <li>
                <!-- remove button -->
                <%= speaker.People.name %></li>
            <% }%>
        </ul>
        <% using (Html.BeginForm("AddSpeaker", "Event")) {%>
            <%= Html.Hidden("eventId", Model.Event.id) %>
            <div class="editor-label">
                Add Speaker
            </div>
            <div class="editor-field">
                <%=  Html.DropDownList("speakerId", Model.Speakers) %>
            </div>
           
            <p>
                <input type="submit" value="Add" />
            </p>
        
         <% }%>
    <div class="display-label">Registered Attendee(s)</div>
    <div class="display-field">
        <ul>
            <% foreach (var attendee in Model.Event.Attendees) {%>
            <li>
                <!-- remove button -->
                <%= attendee.People.name %></li>
            <% }%>
        </ul>
    </div>
    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

