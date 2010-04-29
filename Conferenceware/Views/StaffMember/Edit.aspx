<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.StaffMember>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.EnableClientValidation(); %>
    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            
            <%= Html.HiddenFor(model => model.person_id) %>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.People.name) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.People.name) %>
                <%= Html.ValidationMessageFor(model => model.People.name) %>
            </div>
             
            <div class="editor-label">
                <%= Html.LabelFor(model => model.People.email) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.People.email) %>
                <%= Html.ValidationMessageFor(model => model.People.email) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.People.phone_number) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.People.phone_number) %>
                <%= Html.ValidationMessageFor(model => model.People.phone_number) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.auth_name) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.auth_name) %>
                <%= Html.ValidationMessageFor(model => model.auth_name) %>
            </div>          
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.password_hash) %>
                <small>Set to blank to not change</small>
            </div>
            <div class="editor-field">
                <%= Html.PasswordFor(model => model.password_hash) %>
                <%= Html.ValidationMessageFor(model => model.password_hash) %>
            </div>
  
             <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

