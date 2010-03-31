<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.SettingsData>" %>
<%@ Import Namespace="Conferenceware.Utils" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	View and Edit Settings
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.EnableClientValidation(); %>
    <h2>Settings</h2>

        <form action="<%= Url.Action("Index") %>" enctype="multipart/form-data" method="post">
        <%= Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.EmailFrom) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.EmailFrom) %>
                <%= Html.ValidationMessageFor(model => model.EmailFrom) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.FrontpageTitle) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.FrontpageTitle) %>
                <%= Html.ValidationMessageFor(model => model.FrontpageTitle) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.FrontpageContent) %>
            </div>
            <div class="editor-field">
                <%= Html.TextAreaFor(model => model.FrontpageContent, 15, 80, null) %>
                <%= Html.ValidationMessageFor(model => model.FrontpageContent) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.EventRegistrationConfirmationSubjectFormat) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.EventRegistrationConfirmationSubjectFormat) %>
                <%= Html.ValidationMessageFor(model => model.EventRegistrationConfirmationSubjectFormat) %>
            </div>
             
            <div class="editor-label">
                <%= Html.LabelFor(model => model.EventRegistrationConfirmationBodyFormat) %>
            </div>
            <div class="editor-field">
                <%= Html.TextAreaFor(model => model.EventRegistrationConfirmationBodyFormat, 15, 80, null) %>
                <%= Html.ValidationMessageFor(model => model.EventRegistrationConfirmationBodyFormat) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.AttendeeBadgeBackground) %><br />
                <img src="<%= Url.Action("GetImage", new {filename="AttendeeBadgeBackground"})%>" class="badge-background-image" alt="Attendee Badge Background" />
            </div>
            <div class="editor-field">
                <input type="file" name="AttendeeBadgeBackground" id="AttendeeBadgeBackground" />
            </div>
           
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>
    </form>

    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

