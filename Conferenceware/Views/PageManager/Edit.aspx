<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.PageEditData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.EnableClientValidation(); %>
    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
      
            <%= Html.HiddenFor(model => model.Page.id) %>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Page.title) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Page.title) %>
                <%= Html.ValidationMessageFor(model => model.Page.title) %>
            </div>
             
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Page.page_content) %>
            </div>
            <div class="editor-field">
                <%= Html.TextAreaFor(model => model.Page.page_content, 15, 80, null) %>
                <%= Html.ValidationMessageFor(model => model.Page.page_content) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Page.parent_id) %>
            </div>
            <div class="editor-field">
                <select id="Page_parent_id" name="Page.parent_id">
                    <option value="0" <%= Model.Page.parent_id==0?"selected=\"selected\"":"" %>>None</option>
                    <% foreach (var page in Model.ExistingPages)
{%>
                    <option value="<%= page.id %>" <%= Model.Page.parent_id==page.id?"selected=\"selected\"":"" %>><%= page.title %></option>
                    <%
}%>
                </select>
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

