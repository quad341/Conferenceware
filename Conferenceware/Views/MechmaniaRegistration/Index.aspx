<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.MechmaniaTeamEditData>" %>
<%@ Import Namespace="Conferenceware.Models"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.EnableClientValidation(); %>
    <h2>Register for Mechmania</h2>
    
    <p>Note: if you want to register a team with less than 3 members, just repeat one of the member's emails address' for member 3</p>
    <%using (Html.BeginForm())
      { %>
    <fieldset>
        <legend>Fields</legend>
        <div>
        <%= Html.LabelFor(model => model.team_name) %>
        <%= Html.TextBoxFor(model => model.team_name) %>
        <%= Html.ValidationMessageFor(model => model.team_name) %>
        </div>
        <div>
        <%= Html.LabelFor(model => model.member_email_1) %>
        <%= Html.TextBoxFor(model => model.member_email_1) %>
        <%= Html.ValidationMessageFor(model => model.member_email_1) %>
        </div>
        <div>
        <%= Html.LabelFor(model => model.member_email_2) %>
        <%= Html.TextBoxFor(model => model.member_email_2) %>
        <%= Html.ValidationMessageFor(model => model.member_email_2) %>
        </div>
        <div>
        <%= Html.LabelFor(model => model.member_email_3) %>
        <%= Html.TextBoxFor(model => model.member_email_3) %>
        <%= Html.ValidationMessageFor(model => model.member_email_3) %>
        </div>
        
        <p>
            <input type="submit" value="Register" />
        </p>
    </fieldset>
    <%Html.ActionLink("Create", "Index"); %>
    <%} %>    

</asp:Content>
