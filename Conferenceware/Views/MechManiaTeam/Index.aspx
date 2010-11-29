<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Conferenceware.Models.MechManiaTeam>>" %>
<%@ Import Namespace="Conferenceware.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Team Name
            </th>
            <th>
                Member1
            </th>
            <th>
                Member1 Tshirt Size
            </th>
            <th>
                Member2
            </th>
            <th>
                Member2 Tshirt Size
            </th>
            <th>
                Member3
            </th>
            <th>
                Member 3 Tshirt Size
            </th>
            <th>
                Account Name
            </th>
        </tr>

    <%
    	foreach (MechManiaTeam item in Model)
     {%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit", "Edit", new {item.id})%> |
                <%=Html.ActionLink("Delete", "Delete", new {item.id})%>
            </td>
            <td>
                <%=Html.Encode(item.team_name)%>
            </td>
            <td>
                <%=Html.Encode(item.Attendee.People.name)%>
            </td>
            <td>
                <%=Html.Encode(item.Attendee.TShirtSize) %>
            </td>
            <td>
                <%=Html.Encode(item.Attendee1.People.name)%>
            </td>
            <td>
                <%=Html.Encode(item.Attendee1.TShirtSize) %>
            </td>
            <td>
                <%=Html.Encode(item.Attendee2.People.name)%>
            </td>
            <td>
                <%=Html.Encode(item.Attendee2.TShirtSize) %>
            </td>
            <td>
                <%=Html.Encode(item.account_name)%>
            </td>
        </tr>
    
    <%
     }%>

    </table>
    <p>
        There are <%=Html.Encode(Model.Count()) %> mechmania teams.
    </p>
    <p>
        <%=Html.ActionLink("Create New", "Create")%>
    </p>

</asp:Content>

