<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.EventEditData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.EnableClientValidation(); %>
    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
             
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Event.name) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Event.name) %>
                <%= Html.ValidationMessageFor(model => model.Event.name) %>
            </div>
             
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Event.description) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Event.description) %>
                <%= Html.ValidationMessageFor(model => model.Event.description) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Event.max_attendees) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Event.max_attendees) %>
                <%= Html.ValidationMessageFor(model => model.Event.max_attendees) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Event.location_id) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.Event.location_id, Model.Locations) %>
                <%= Html.ValidationMessageFor(model => model.Event.location_id) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Event.timeslot_id) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.Event.timeslot_id, Model.Timeslots) %>
                <%= Html.ValidationMessageFor(model => model.Event.timeslot_id) %>
            </div>
           
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

