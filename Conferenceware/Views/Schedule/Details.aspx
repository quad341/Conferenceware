<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.Event>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Name</div>
        <div class="display-field"><%= Html.Encode(Model.name) %></div>
        
        <div class="display-label">Presenter<% if (Model.Speakers.Count() > 1){%>s<% }%></div>
        <div class="display-field">
            <ul>
                <% foreach (var speaker in Model.Speakers) {%>
                <li><%=speaker.People.name%></li>
                <% }%>
            </ul>
        </div>
        
        <div class="display-label">Description</div>
        <div class="display-field"><%= Html.Encode(Model.description) %></div>
        
        <div class="display-label">When?</div>
        <div class="display-field"><%= Html.Encode(Model.TimeSlot.StringValue) %></div>
        
        <div class="display-label">Where?</div>
        <div class="display-field"><%= Html.Encode(Model.Location.StringValue) %></div>
        
        <div class="display-label">Limited attendance?</div>
        <div class="display-field">
            <%= Model.max_attendees > 0 ? (Model.Attendees.Count() < Model.max_attendees ? "open":"full"):"no" %>
            <% if (Model.max_attendees > 0 && Model.Attendees.Count() < Model.max_attendees)
     {
     	using (Html.BeginForm("RegisterAttendee", "Schedule"))
     	{%>
                <%=Html.Hidden("eventId", Model.id)%>
                <div class="display-label">E-mail address</div>
                <div class="display-field"><%=Html.TextBox("email")%></div>
                <input type="submit" value="Register" />
                <%
     	}
     }%>
        </div>
        
    </fieldset>
    <p>

        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

