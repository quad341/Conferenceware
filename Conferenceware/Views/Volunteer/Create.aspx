﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.VolunteerEditData>" %>
<%@ Import Namespace="Conferenceware.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%
    	Html.EnableClientValidation();%>
    <h2>Create</h2>

    <%
    	using (Html.BeginForm())
     {%>
        <%=Html.ValidationSummary(true)%>

        <fieldset>
            <legend>Fields</legend>
            
            <%=Html.HiddenFor(model => model.Volunteer.person_id,
     	                                 new {value = 0})%>
            
            <div class="editor-label">
                <%=Html.LabelFor(model => model.Volunteer.People.name)%>
            </div>
            <div class="editor-field">
                <%=Html.TextBoxFor(model => model.Volunteer.People.name)%>
                <%=
     		Html.ValidationMessageFor(model => model.Volunteer.People.name)%>
            </div>
             
            <div class="editor-label">
                <%=Html.LabelFor(model => model.Volunteer.People.email)%>
            </div>
            <div class="editor-field">
                <%=Html.TextBoxFor(model => model.Volunteer.People.email)%>
                <%=
     		Html.ValidationMessageFor(model => model.Volunteer.People.email)%>
            </div>
            
             <div class="editor-label">
                <%=Html.LabelFor(model => model.Volunteer.People.phone_number) %> <strong>Format: XXX-XXX-XXXX</strong>
            </div>
            <div class="editor-field">
                <%=Html.TextBoxFor(model => model.Volunteer.People.phone_number) %>
                <%=Html.ValidationMessageFor(model => model.Volunteer.People.phone_number) %>
            </div>
            
            <div class="editor-label">
                <%=Html.LabelFor(model => model.Volunteer.is_video_trained)%>
            </div>
            <div class="editor-field">
                <%=
     		Html.CheckBoxFor(model => model.Volunteer.is_video_trained)%>
                <%=
     		Html.ValidationMessageFor(model => model.Volunteer.is_video_trained)%>
            </div>
           
            <div class="editor-label">
                Time Slots
            </div>
            
            <div class="editor-field">
                <%
     	foreach (VolunteerTimeSlot ts in Model.VolunteerTimeSlots)
     	{%>
                <input type="checkbox" name="ChosenTimeSlots" value="<%=ts.timeslot_id%>" <%=Model.ChosenTimeSlots.Contains(ts.timeslot_id)
     		                  	? "checked=\"checked\""
     		                  	: ""%> />
                <%=ts.TimeSlot.StringValue%> <%=ts.is_video ? "(Video training needed)" : ""%>
                <br />
                <%
     	}%>
            </div>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <%
     }%>

    <div>
        <%=Html.ActionLink("Back to List", "Index")%>
    </div>

</asp:Content>

