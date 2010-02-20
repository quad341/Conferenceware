<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Location Not Found
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Location Not Found</h2>
    
    <p>The requested location was not found</p>
    
    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>
