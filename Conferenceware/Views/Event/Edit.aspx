<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.EventEditData>" %>
<%@ Import Namespace="Conferenceware.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%
    	Html.EnableClientValidation();%>
    <h2>Edit</h2>

    <%
    	using (Html.BeginForm())
     {%>

        <fieldset>
            <legend>Fields</legend>
             
            <div class="editor-label">
                <%=Html.LabelFor(model => model.Event.name)%>
            </div>
            <div class="editor-field">
                <%=Html.TextBoxFor(model => model.Event.name)%>
                <%=Html.ValidationMessageFor(model => model.Event.name)%>
            </div>
             
            <div class="editor-label">
                <%=Html.LabelFor(model => model.Event.description)%>
            </div>
            <div class="editor-field">
                <%=Html.TextAreaFor(model => model.Event.description,15,80,null)%>
                <%=
                Html.ValidationMessageFor(model => model.Event.description)%>
            </div>
            
            <div class="editor-label">
                <%=Html.LabelFor(model => model.Event.max_attendees)%>
            </div>
            <div class="editor-field">
                <%=Html.TextBoxFor(model => model.Event.max_attendees)%>
                <%=
     		Html.ValidationMessageFor(model => model.Event.max_attendees)%>
            </div>
            
            <div class="editor-label">
                <%=Html.LabelFor(model => model.Event.location_id)%>
            </div>
            <div class="editor-field">
                <%=Html.DropDownListFor(model => model.Event.location_id,
     	                                       Model.Locations)%>
                <%=
     		Html.ValidationMessageFor(model => model.Event.location_id)%>
            </div>
            
            <div class="editor-label">
                <%=Html.LabelFor(model => model.Event.timeslot_id)%>
            </div>
            <div class="editor-field">
                <%=Html.DropDownListFor(model => model.Event.timeslot_id,
     	                                       Model.Timeslots)%>
                <%=
     		Html.ValidationMessageFor(model => model.Event.timeslot_id)%>
            </div>
           
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <%
     }%>
    <div class="display-label">
        Speaker(s)</div>
    <div class="display-field">
        <ul>
            <%
    	foreach (Speaker speaker in Model.Event.Speakers)
     {%>
            <li class="entry-with-inline-form">
                <%
     	using (Html.BeginForm("RemoveSpeaker", "Event"))
     	{%>
                    <%=Html.Hidden("eventId", Model.Event.id)%>
                    <%=Html.Hidden("speakerID", speaker.person_id)%>
                    <input type="submit" value="Remove" />
                <%
     	}%>
                <%=speaker.People.name%></li>
            <%
     }%>
        </ul>
        <%
    	using (Html.BeginForm("AddSpeaker", "Event"))
     {%>
            <%=Html.Hidden("eventId", Model.Event.id)%>
            <div class="editor-label">
                Add Speaker
            </div>
            <div class="editor-field">
                <%=Html.DropDownList("speakerId", Model.Speakers)%>
            </div>
           
            <p>
                <input type="submit" value="Add" />
            </p>
        
         <%
     }%>
    <div class="display-label">Registered Attendee(s)</div>
    <div class="display-field">
        <ul>
            <%
    	foreach (Attendee attendee in Model.Event.Attendees)
     {%>
            <li class="entry-with-inline-form">
                <%
     	using (Html.BeginForm("RemoveAttendee", "Event"))
     	{%>
                    <%=Html.Hidden("eventId", Model.Event.id)%>
                    <%=Html.Hidden("attendeeID", attendee.person_id)%>
                    <input type="submit" value="Remove" />
                <%
     	}%>
                <!-- remove button -->
                <%=attendee.People.name%></li>
            <%
     }%>
        </ul>
        <!-- Administrators should be able to do this always even exceeding maximums -->
        <%
    	using (Html.BeginForm("AddAttendee", "Event"))
     {%>
            <%=Html.Hidden("eventId", Model.Event.id)%>
            <div class="editor-label">
                Add Attendee
            </div>
            <div class="editor-field">
                <%=Html.DropDownList("attendeeId", Model.Attendees)%>
            </div>
           
            <p>
                <input type="submit" value="Add" />
            </p>
        
         <%
     }%>
    </div>
        <div class=display-label">Linked Content</div>
        <div class="display-field">
            <ul>
                <%
    	foreach (EventContentLink ecl in Model.Event.EventContentLinks)
     {%>
                <li class="entry-with-inline-form">
                <%
     	using (Html.BeginForm("RemoveContentLink", "Event", FormMethod.Get))
     	{%>
                    <%=Html.Hidden("contentId", ecl.ContentId)%>
                    <input type="submit" value="Remove" />
                <%
     	}%>
                <!-- remove button -->
                <a href="<%=ecl.link_location%>" title="Related Content">
                    <%=ecl.filename%></a></li>
                <%
     }%>
            </ul>
            <%=Html.ActionLink("Upload Content",
			                                  "UploadContent",
			                                  new {Model.Event.id})%> |
            <%=Html.ActionLink("Link to content",
			                                  "AddLink",
			                                  new {Model.Event.id})%>
        </div>
        <div>
            <%=Html.ActionLink("Back to List", "Index")%>
        </div>
</asp:Content>

