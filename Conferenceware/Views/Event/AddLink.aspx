<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.EventContentLink>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AddLink
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>AddLink</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
                <%= Html.HiddenFor(model => model.id) %>
            
                <%= Html.HiddenFor(model => model.event_id) %>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.link_location) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.link_location) %>
                <%= Html.ValidationMessageFor(model => model.link_location) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.list_on_video_page) %>
            </div>
            <div class="editor-field">
                <%= Html.CheckBoxFor(model => model.list_on_video_page) %>
                <%= Html.ValidationMessageFor(model => model.list_on_video_page) %>
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

