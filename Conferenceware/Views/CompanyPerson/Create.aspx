<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.CompanyPerson>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.EnableClientValidation(); %>
    <h2>Create</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <%= Html.HiddenFor(model => model.person_id, new {value=0}) %>
            
            <div class="editor-label">
                Company
            </div>
            <div class="editor-field">
                <%= Html.HiddenFor(model => model.company_id) %>
                <%= Model.Company.name %>
            </div>
              
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
                <%= Html.LabelFor(model => model.is_contact) %>
            </div>
            <div class="editor-field">
                <%= Html.CheckBoxFor(model => model.is_contact) %>
                <%= Html.ValidationMessageFor(model => model.is_contact) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.is_attending) %>
            </div>
            <div class="editor-field">
                <%= Html.CheckBoxFor(model => model.is_attending) %>
                <%= Html.ValidationMessageFor(model => model.is_attending) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("Back to Company", "Details", "Company", new {id=Model.company_id}, null) %>
    </div>

</asp:Content>

