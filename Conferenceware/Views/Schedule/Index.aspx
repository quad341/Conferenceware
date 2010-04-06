<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Conferenceware.Models.Event>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Conference Schedule</h2>

    <% foreach (var item in Model) { %>
    
        <p>
        <%= Html.ActionLink(item.name, "Details", new { id=item.id })%> at 
        <%= item.TimeSlot.start_time %>  
        (<%= item.Location.room_number %> <%= item.Location.building_name %>)
        </p>
    <% } %>

    <p>You can also check out the <%= Html.ActionLink("videos", "Videos") %><small>(Posted as they are available)</small></p>
</asp:Content>

