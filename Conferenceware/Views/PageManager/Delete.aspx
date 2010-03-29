<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.Page>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <h3>Are you sure you want to delete this?</h3>
    <h5>Any children of this page will automatically be promoted to be children of this page's parent</h5>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Title</div>
        <div class="display-field"><%= Html.Encode(Model.title) %></div>
        
        <div class="display-label">Content</div>
        <div class="display-field">
            <pre>
                <%= Html.Encode(Model.page_content) %>
            </pre>
        </div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
            <%= Html.HiddenFor(model => model.id) %>
		    <input type="submit" value="Delete" /> |
		    <%= Html.ActionLink("Back to List", "Index") %>
        </p>
    <% } %>

</asp:Content>

