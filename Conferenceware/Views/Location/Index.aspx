<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Conferenceware.Models.Location>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                max_capacity
            </th>
            <th>
                building_name
            </th>
            <th>
                room_number
            </th>
            <th>
                notes
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.id }) %> |
                <%= Html.ActionLink("Delete", "Delete", new { id=item.id })%>
            </td>
            <td>
                <%= Html.Encode(item.max_capacity) %>
            </td>
            <td>
                <%= Html.Encode(item.building_name) %>
            </td>
            <td>
                <%= Html.Encode(item.room_number) %>
            </td>
            <td>
                <%= Html.Encode(item.notes) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

