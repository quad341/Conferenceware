<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.CompanyInvoiceEmailEditData>" %>
<%@ Import Namespace="Conferenceware.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Email
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.EnableClientValidation(); %>

    <h2>Email</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
                <div class="editor-label">
                Send Invoice To
            </div>
            
            <div class="editor-field">
                <%
     	foreach (CompanyPerson cp in Model.PeopleChoices)
     	{%>
                <input type="checkbox" name="SelectedRecipiants" value="<%=cp.person_id%>" <%=Model.SelectedRecipiants.Contains(cp.person_id)
     		                  	? "checked=\"checked\""
     		                  	: ""%> />
                <%=cp.People.name%> <%=cp.is_contact ? "(Primary contact)" : ""%>
                <br />
                <%
     	}%>
            </div>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Subject) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Subject) %>
                <%= Html.ValidationMessageFor(model => model.Subject) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Body) %>
            </div>
            <div class="editor-field">
                <%= Html.TextAreaFor(model => model.Body, 15, 80, null) %>
                <%= Html.ValidationMessageFor(model => model.Body) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.InvoiceAttachmentFileName) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.InvoiceAttachmentFileName) %>
                <%= Html.ValidationMessageFor(model => model.InvoiceAttachmentFileName) %>
            </div>
            
            <p>
                <input type="submit" value="Send" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ExtraHeadContent" runat="server">
</asp:Content>

