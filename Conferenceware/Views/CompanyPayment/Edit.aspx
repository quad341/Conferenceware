<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.CompanyPayment>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <%= Html.HiddenFor(model => model.id) %>
            
            <div class="editor-label">
                Company
            </div>
            <div class="editor-field">
                <%= Html.HiddenFor(model => model.company_id) %>
                <%= Model.Company.name %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.received_date) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.received_date, String.Format("{0:g}", Model.received_date)) %>
                <%= Html.ValidationMessageFor(model => model.received_date) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.amount) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.amount, String.Format("{0:F}", Model.amount)) %>
                <%= Html.ValidationMessageFor(model => model.amount) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.comments) %>
            </div>
            <div class="editor-field">
                <%= Html.TextAreaFor(model => model.comments, 15, 80, null) %>
                <%= Html.ValidationMessageFor(model => model.comments) %>
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

