<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Staff Member Not Found
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Staff Member Not Found</h2>
    
    <p>The requested staff member was not found. You can return to the <%=Html.ActionLink("staff member list", "Index")%></p>

</asp:Content>
