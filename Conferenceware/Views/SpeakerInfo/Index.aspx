<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Conferenceware.Models.Speaker>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Speaker List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Speaker List</h2>

    <ul>
    <% foreach (var item in Model) { %>
    
            <li>
                <%= Html.ActionLink(Html.Encode(item.People.name), "Display", new { id = item.person_id })%>
            </li>
    
    <% } %>
    </ul>

</asp:Content>
