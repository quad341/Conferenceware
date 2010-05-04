<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.Event>" %>
<%@ Import Namespace="Conferenceware.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Delete</h2>
    <h3>
        Are you sure you want to delete this event and unregister all speakers and attendees
        for this event?</h3>
    <fieldset>
        <legend>Fields</legend>
        <div class="diplay-label">Event</div>
        <div class="display-label"><%=Model.name%></div>
        <div class="display-label">Speakers</div>
        <div class="display-field">
            <ul>
                <%
                	foreach (Speaker sp in Model.Speakers)
                 {%>
                    <li><%=sp.People.name%></li>
                <%
                 }%>
            </ul>
        </div>
        <div class="display-label">Attendees</div>
        <div class="display-field">
            <ul>
                <%
                	foreach (Attendee at in Model.Attendees)
                 {%>
                    <li><%=at.People.name%></li>
                <%
                 }%>
            </ul>
        </div>
    </fieldset>
    <%
                	using (Html.BeginForm())
                 {%>
        <p>
            <%=Html.HiddenFor(model => model.id)%>
		    <input type="submit" value="Delete" /> |
		    <%=Html.ActionLink("Back to Events Page",
                 	                                  "Index")%>
        </p>
    <%
                 }%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ExtraHeadContent" runat="server">
</asp:Content>
