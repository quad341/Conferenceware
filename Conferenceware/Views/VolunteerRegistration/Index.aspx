<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.VolunteerEditData>" %>
<%@ Import Namespace="Conferenceware.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Volunteer Registration
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%
    	Html.EnableClientValidation();%>
    <h2>Volunteer Registration</h2>

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
                UIUC Email Address
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
                <%=Html.LabelFor(model => model.Volunteer.tshirt_id)%>
            </div>
            <div class="editor-field">
                <%=Html.DropDownListFor(model => model.Volunteer.tshirt_id,
     	                                       Model.TShirtSizes)%>
                <%=
     		Html.ValidationMessageFor(model => model.Volunteer.tshirt_id)%>
            </div>
           
            <div class="editor-label">
                <%=Html.LabelFor(model => model.Volunteer.food_choice_id)%>
                <br /><strong>Note: Vounteers recieve a free food credit</strong>
            </div>
            <div class="editor-field">
                <%=
     		Html.DropDownListFor(model => model.Volunteer.food_choice_id, Model.Foods)%>
                <%=
     		Html.ValidationMessageFor(model => model.Volunteer.food_choice_id)%>
            </div>
            
            <div class="editor-label">
                Time Slots you would like to work
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
                <input type="submit" value="Submit" />
            </p>
        </fieldset>

    <%
     }%>

    <div>
        <%=Html.ActionLink("Back to List", "Index")%>
    </div>

</asp:Content>

