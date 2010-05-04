<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Conferenceware.Models.EventContentLink>>" %>
<%@ Import Namespace="Conferenceware.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Videos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Videos</h2>

    <table>
        <tr>
            <th>
                Event
            </th>
            <th>
                Filename
            </th>
        </tr>

    <%
    	foreach (EventContentLink item in Model)
     {%>
    
        <tr>
            <td>
                <%=Html.ActionLink(Html.Encode(item.Event.name),
     	                                  "Details",
     	                                  new {id = item.event_id})%>
            </td>
            <td>
                <a href="<%=item.link_location%>"><%=Html.Encode(item.filename)%>
            </td>
        </tr>
    
    <%
     }%>

    </table>

</asp:Content>

