<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Invoice Not Found
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Invoice Not Found</h2>
    
    <p>The requested invoice was not found. You can view the <%=Html.ActionLink("company list", "Index", "Company")%>.</p>

</asp:Content>
