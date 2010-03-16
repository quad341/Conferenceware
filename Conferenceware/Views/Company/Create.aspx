<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.Company>" %>

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
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.name) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.name) %>
                <%= Html.ValidationMessageFor(model => model.name) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.address_line1) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.address_line1) %>
                <%= Html.ValidationMessageFor(model => model.address_line1) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.address_line2) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.address_line2) %>
                <%= Html.ValidationMessageFor(model => model.address_line2) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.city) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.city) %>
                <%= Html.ValidationMessageFor(model => model.city) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.state) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.state) %>
                <%= Html.ValidationMessageFor(model => model.state) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.zip) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.zip) %>
                <%= Html.ValidationMessageFor(model => model.zip) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.needs_power) %>
            </div>
            <div class="editor-field">
                <%= Html.CheckBoxFor(model => model.needs_power) %>
                <%= Html.ValidationMessageFor(model => model.needs_power) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.priority_shipping) %>
            </div>
            <div class="editor-field">
                <%= Html.CheckBoxFor(model => model.priority_shipping) %>
                <%= Html.ValidationMessageFor(model => model.priority_shipping) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

