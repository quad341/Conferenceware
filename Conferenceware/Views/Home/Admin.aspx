<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Admin
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Admin Resources</h2>
    <ul>
        <li><%= Html.ActionLink("Locations", "Index", "Location") %></li>
        <li><%= Html.ActionLink("T-Shirt Sizes", "Index", "TShirtSize") %></li>
        <li><%= Html.ActionLink("Foods", "Index", "Food") %></li>
        <li><%= Html.ActionLink("Time Slots", "Index", "TimeSlot") %></li>
        <li><%= Html.ActionLink("Speakers", "Index", "Speaker") %></li>
        <li><%= Html.ActionLink("Attendees", "Index", "Attendee") %></li>
        <li><%= Html.ActionLink("Events", "Index", "Event") %></li>
        <li><%= Html.ActionLink("Volunteer Time Slots", "Index", "VolunteerTimeSlot") %></li>
        <li><%= Html.ActionLink("MechMania Teams", "Index", "MechManiaTeam") %></li>
    </ul>
</asp:Content>
