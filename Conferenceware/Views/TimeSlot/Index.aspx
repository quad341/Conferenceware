<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Conferenceware.Models.TimeSlot>>" %>
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
                ID
            </th>
            <th>
                Start Time
            </th>
            <th>
                End Time
            </th>
        </tr>

    <%
    	foreach (TimeSlot item in Model)
     {%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit", "Edit", new {item.id})%> |
                <%=Html.ActionLink("Delete", "Delete", new {item.id})%>
            </td>
            <td>
                <%=Html.Encode(item.id)%>
            </td>
            <td>
                <%=Html.Encode(String.Format("{0:g}", item.start_time))%>
            </td>
            <td>
                <%=Html.Encode(String.Format("{0:g}", item.end_time))%>
            </td>
        </tr>
    
    <%
     }%>

    </table>

    <p>
        <%=Html.ActionLink("Create New", "Create")%>
    </p>

</asp:Content>

