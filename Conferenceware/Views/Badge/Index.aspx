<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Badge Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Generate Badges</h2>
    
    <ul>
        <li><%= Html.ActionLink("Attendee badges", "AttendeeBadges") %></li>
        <li><%= Html.ActionLink("Sponsor badges", "MechmaniaBadges") %></li>
        <li><%= Html.ActionLink("Sponsor badges", "SpeakerBadges") %></li>
        <li><%= Html.ActionLink("Sponsor badges", "SponsorBadges") %></li>
        <li><%= Html.ActionLink("Sponsor badges", "StaffBadges") %></li>
        <li><%= Html.ActionLink("Sponsor badges", "VolunteerBadges") %></li>
    </ul>

</asp:Content>
