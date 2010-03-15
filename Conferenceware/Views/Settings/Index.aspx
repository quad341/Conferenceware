<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.SettingsData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	View and Edit Settings
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.EnableClientValidation(); %>
    <h2>Settings</h2>

    <% using (Html.BeginForm()) {%>
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
           
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

