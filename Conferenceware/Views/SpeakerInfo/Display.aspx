<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.Speaker>" %>
<%@ Import Namespace="Conferenceware.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Speaker Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Info</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Name</div>
        <div class="display-field"><%= Html.Encode(Model.People.name) %></div>
        <div class="display-label"><img height="300" src="<%=Html.Encode(Model.image) %>" alt="<%=Html.Encode(Model.People.name) %>" /></div>
        
        <div class="display-label">Biography</div>
        <div class="display-field"><%= Model.bio %></div>

        <% if (SettingsData.Default.ShowEvents)
           {%>
        <div class="display-label">Events Presenting</div>
        <div class="display-field">
            <ul>
            <% foreach (var ev in Model.Events)
{%>
                <li><%=Html.ActionLink(ev.name,
	                                  "Details",
	                                  "Schedule",
	                                  new {ev.id},
	                                  null)%></li>
            <%
}%>
            </ul>
        </div>
        <%
           }%>
        
    </fieldset>
    <p>
        <%= Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ExtraHeadContent" runat="server">
</asp:Content>

