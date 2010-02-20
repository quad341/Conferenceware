<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.Event>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">id</div>
        <div class="display-field"><%= Html.Encode(Model.id) %></div>
        
        <div class="display-label">name</div>
        <div class="display-field"><%= Html.Encode(Model.name) %></div>
        
        <div class="display-label">description</div>
        <div class="display-field"><%= Html.Encode(Model.description) %></div>
        
        <div class="display-label">max_attendees</div>
        <div class="display-field"><%= Html.Encode(Model.max_attendees) %></div>
        
        <div class="display-label">timeslot_id</div>
        <div class="display-field"><%= Html.Encode(Model.timeslot_id) %></div>
        
        <div class="display-label">location_id</div>
        <div class="display-field"><%= Html.Encode(Model.location_id) %></div>
        
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", new { id=Model.id }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

