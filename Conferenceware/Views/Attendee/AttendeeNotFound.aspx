<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Attendee Not Found
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Attendee Not Found</h2>
    
    <p>The requested attendee was not found. You can return to the <%=Html.ActionLink("attendee list", "Index")%></p>

</asp:Content>
