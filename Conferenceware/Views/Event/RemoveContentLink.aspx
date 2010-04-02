<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.EventContentLinkDeleteData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Remove Content Link
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Remove Content Link</h2>

    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Link</div>
        <div class="display-field"><a href="<%= Model.EventContentLink.link_location %>"><%= Model.EventContentLink.filename %></a></div>
        
        <div class="display-label">List on video page?</div>
        <div class="display-field"><%= Html.Encode(Model.EventContentLink.list_on_video_page) %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
            <%= Html.HiddenFor(model => model.EventContentLink.id) %>
            <%= Html.CheckBoxFor(model => model.DeleteFile) %><%= Html.LabelFor(model => model.DeleteFile) %><br />
            <%= Html.CheckBoxFor(model => model.DeleteDir) %><%= Html.LabelFor(model => model.DeleteDir) %><br />
		    <input type="submit" value="Delete" /> |
		    <%= Html.ActionLink("Back to List", "Index") %>
        </p>
    <% } %>

</asp:Content>

