<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	TShirt Size Not Found
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>TShirt Size Not Found</h2>
    
    <p>The requested TShirt Size was not found</p>
    
    <div>
        <%=Html.ActionLink("Back to List", "Index")%>
    </div>

</asp:Content>
