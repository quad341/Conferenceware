<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.Event>" %>
<%@ Import Namespace="Conferenceware.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <div class="display-label">Name</div>
        <div class="display-field"><%=Html.Encode(Model.name)%></div>
        
        <div class="display-label">Description</div>
        <div class="display-field"><%=Model.description%></div>
        
        <div class="display-label">Max Attendees</div>
        <div class="display-field"><%=Html.Encode(Model.max_attendees)%></div>
        
        <div class="display-label">Timeslot</div>
        <div class="display-field"><%=Html.Encode(Model.TimeSlot.StringValue)%></div>
        
        <div class="display-label">Location</div>
        <div class="display-field"><%=Html.Encode(Model.Location.StringValue)%></div>
        
        <div class="display-label">Speaker(s)</div>
        <div class="display-field">
            <ul>
            <%
            	foreach (Speaker speaker in Model.Speakers)
             {%>
               <li><!-- remove button --> <%=speaker.People.name%></li> 
            <%
             }%>
            </ul>
        </div>
        
        <div class="display-label">Registered Attendee(s)</div>
        <div class="display-field">
            <ul>
            <%
            	foreach (Attendee attendee in Model.Attendees)
             {%>
               <li><!-- remove button --> <%=attendee.People.name%></li> 
            <%
             }%>
            </ul>
        </div>
        
        <div class="display-field">
                <ul>
                    <%
            	foreach (EventContentLink ecl in Model.EventContentLinks)
             {%>
                    <li><a href="<%=ecl.link_location%>" title="Related Content"><%=ecl.filename%></a></li>
                    <%
             }%>
                </ul>
           </div>
    </fieldset>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new {Model.id})%> |
        <%=Html.ActionLink("Back to List", "Index")%>
    </p>

</asp:Content>

