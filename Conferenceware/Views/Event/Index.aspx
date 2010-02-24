<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Conferenceware.Models.Event>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Conference Events
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Name
            </th>
            <th>
                Description
            </th>
            <th>
                Max Attendees
            </th>
            <th>
                Timeslot
            </th>
            <th>
                Location
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.id }) %> |
                <!--TODO:<%= Html.ActionLink("Details", "Details", new { id=item.id })%>-->
                <%= Html.ActionLink("Delete", "Delete", new { id=item.id}) %>
            </td>
            <td>
                <%= Html.Encode(item.name) %>
            </td>
            <td>
                <%= Html.Encode(item.description) %>
            </td>
            <td>
                <%= Html.Encode(item.max_attendees) %>
            </td>
            <td>
                <%= Html.Encode(item.TimeSlot.ToString()) %>
            </td>
            <td>
                <%= Html.Encode(item.Location.ToString()) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

