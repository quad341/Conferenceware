<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.MechmaniaTeamEditData>" %>
<%@ Import Namespace="Conferenceware.Models"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%Html.EnableClientValidation();%>
    <h2>Index</h2>
    <%using (Html.BeginForm())
      { %>
    <fieldset>
        <legend>Fields</legend>
        <%Html.LabelFor(model => model.team_name); %>
        <%Html.TextBoxFor(model => model.team_name); %>
        <%Html.ValidationMessageFor(model => model.team_name); %>
        <%Html.LabelFor(model => model.member_email_1); %>
        <%Html.TextBoxFor(model => model.member_email_1); %>
        <%Html.ValidationMessageFor(model => model.member_email_1); %>
        <%Html.LabelFor(model => model.member_email_2); %>
        <%Html.TextBoxFor(model => model.member_email_2); %>
        <%Html.ValidationMessageFor(model => model.member_email_2); %>
        <%Html.LabelFor(model => model.member_email_3); %>
        <%Html.TextBoxFor(model => model.member_email_3); %>
        <%Html.ValidationMessageFor(model => model.member_email_3); %>
    </fieldset>
    <%Html.ActionLink("Create", "Index"); %>
    <%} %>    

</asp:Content>
