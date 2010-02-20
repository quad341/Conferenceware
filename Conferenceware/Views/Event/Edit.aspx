<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.Event>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.id) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.id) %>
                <%= Html.ValidationMessageFor(model => model.id) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.name) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.name) %>
                <%= Html.ValidationMessageFor(model => model.name) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.description) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.description) %>
                <%= Html.ValidationMessageFor(model => model.description) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.max_attendees) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.max_attendees) %>
                <%= Html.ValidationMessageFor(model => model.max_attendees) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.timeslot_id) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.timeslot_id) %>
                <%= Html.ValidationMessageFor(model => model.timeslot_id) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.location_id) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.location_id) %>
                <%= Html.ValidationMessageFor(model => model.location_id) %>
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

