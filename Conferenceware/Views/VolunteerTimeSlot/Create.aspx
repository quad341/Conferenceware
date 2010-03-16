<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.VolunteerTimeSlotEditData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.VolunteerTimeSlot.timeslot_id) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.VolunteerTimeSlot.timeslot_id, Model.Timeslots) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.VolunteerTimeSlot.is_video) %>
            </div>
            <div class="editor-field">
                <%= Html.CheckBoxFor(model => model.VolunteerTimeSlot.is_video) %>
            </div>           
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
