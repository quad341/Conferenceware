<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Conferenceware.Models.Event>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                id
            </th>
            <th>
                name
            </th>
            <th>
                description
            </th>
            <th>
                max_attendees
            </th>
            <th>
                timeslot_id
            </th>
            <th>
                location_id
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.id }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.id })%>
            </td>
            <td>
                <%= Html.Encode(item.id) %>
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
                <%= Html.Encode(item.timeslot_id) %>
            </td>
            <td>
                <%= Html.Encode(item.location_id) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

