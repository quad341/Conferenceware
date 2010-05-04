<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Invoice Item Not Found
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Invoice Item Not Found</h2>
    
    <p>The requested invoice item was not found. You can return to the <%=Html.ActionLink("company list", "Index", "Company")%>.</p>

</asp:Content>
