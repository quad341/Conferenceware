<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Food Is Invalid
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Food Is Invalid</h2>
    
    <p>Requested food was not found. You can return to <%=Html.ActionLink("the list", "Index")%></p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ExtraHeadContent" runat="server">
</asp:Content>
