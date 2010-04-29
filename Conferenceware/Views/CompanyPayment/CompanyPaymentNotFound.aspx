<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Payment Not Found
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Payment Not Found</h2>
    
    <p>The requested payment was not found. You can return to the <%=Html.ActionLink("company list", "Index", "Company")%></p>

</asp:Content>
