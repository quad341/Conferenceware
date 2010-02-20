<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.AttendeeEditData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Attendee.People.name) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Attendee.People.name) %>
                <%= Html.ValidationMessageFor(model => model.Attendee.People.name) %>
            </div>
            
            <div class="editor-label>
                <%= Html.LabelFor(model => model.Attendee.People.phone_number) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Attendee.People.phone_number) %>
                <%= Html.ValidationMessageFor(model => model.Attendee.People.phone_number) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Attendee.TShirtSize) %>
            </div>
            <div class="editor-field">
                <!--<%= Html.DropDownListFor(model => model.Attendee.TShirtSize, Model.TShirtSizes) %>-->
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

