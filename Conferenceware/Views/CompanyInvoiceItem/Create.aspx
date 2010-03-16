<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.CompanyInvoiceItem>" %>

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
            
                <%= Html.HiddenFor(model => model.id, new {value = 0}) %>
            
            <div class="editor-label">
                Invoice
            </div>
            <div class="editor-field">
                <%= Html.HiddenFor(model => model.invoice_id) %>
                <%= Model.CompanyInvoice.InvoiceId %>
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
                <%= Html.TextAreaFor(model => model.description, 15, 80, null) %>
                <%= Html.ValidationMessageFor(model => model.description) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.cost) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.cost) %>
                <%= Html.ValidationMessageFor(model => model.cost) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("Back to Invoice", "Edit", "CompanyInvoice", new {id=Model.invoice_id}, null) %>
    </div>

</asp:Content>

