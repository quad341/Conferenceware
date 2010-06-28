<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    These are the following scheduling actions:
    <dl>
        <dt><%= Html.ActionLink("Simple Event Scheduling", "Index", "Event") %></dt><dd>Edit the entries to schedule</dd>
        <dt><%= Html.ActionLink("Simple Volunteer Scheduling", "Index", "VolunteerTimeSlot") %></dt><dd>Click schedule to schedule each volunteer one at a time</dd>
        <dt>Advanced Event Scheduling</dt><dd>JavaScript interface to schedule many events quickly <small>Coming soon</small></dd>
        <dt>Advanced Volunteer Scheduling</dt><dd>JavaScript interface to schedule many volunteers quickly <small>Coming soon</small></dd>
        <dt><%= Html.ActionLink("Email Volunteer Schedule to volunteers", "EmailScheduleToVolunteers") %></dt>
            <dd>
                Emails each volunteer their schedule. Click the links below to preview the emails. Change the text in <%= Html.ActionLink("Settings", "Index", "Settings") %>
                <ul>
                    <li><%= Html.ActionLink("Preview Regular Email", "PreviewRegularEmail") %></li>
                    <li><%= Html.ActionLink("Preview Video Email", "PreviewVideoEmail") %></li>
                </ul>
            </dd>
    </dl>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ExtraHeadContent" runat="server">
</asp:Content>
