<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	MechMania Team Not Found
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>MechMania Team Not Found</h2>
    
    <p>The requested team was not found. You can return to the <%=Html.ActionLink("team list", "Index")%>.</p>

</asp:Content>
