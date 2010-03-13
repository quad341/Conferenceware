<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.TimeSlot>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            
            <%= Html.HiddenFor(model => model.id) %>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.start_time) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.start_time, String.Format("{0:g}", Model.start_time)) %>
                <%= Html.ValidationMessageFor(model => model.start_time) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.end_time) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.end_time, String.Format("{0:g}", Model.end_time)) %>
                <%= Html.ValidationMessageFor(model => model.end_time) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

