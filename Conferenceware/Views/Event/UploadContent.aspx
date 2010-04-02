<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.EventContentLink>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	UploadContent
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.EnableClientValidation(); %>

    <h2>Upload Content for <%= Model.Event.name %></h2>

    <form action="<%= Url.Action("UploadContent") %>" enctype="multipart/form-data" method="post">
        <%= Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <%= Html.HiddenFor(model => model.id) %>
            
            <%= Html.HiddenFor(model => model.event_id) %>
            
            <div class="editor-label">
                Content to upload
            </div>
            <div class="editor-field">
                <input type="file" name="link_location" id="link_location" />
                <%= Html.ValidationMessageFor(model => model.link_location) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    </form>

    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

