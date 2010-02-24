<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Conferenceware Management Console
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= Html.Encode(ViewData["Message"]) %></h2>
    <ul>
        <li><%= Html.ActionLink("Schedule", "Index", "Schedule") %></li>
        <li><%= Html.ActionLink("Locations", "Index", "Location") %></li>
        <li><%= Html.ActionLink("T-Shirt Sizes", "Index", "TShirtSize") %></li>
        <li><%= Html.ActionLink("Foods", "Index", "Food") %></li>
        <li><%= Html.ActionLink("Time Slots", "Index", "TimeSlot") %></li>
        <li><%= Html.ActionLink("Speakers", "Index", "Speaker") %></li>
        <li><%= Html.ActionLink("Attendees", "Index", "Attendee") %></li>
        <li><%= Html.ActionLink("Events", "Index", "Event") %></li>
    </ul>
</asp:Content>
