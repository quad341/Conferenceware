<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.MechManiaTeamAdminEditData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%
    	Html.EnableClientValidation();%>
    <h2>Edit</h2>

    <%
    	using (Html.BeginForm())
     {%>
        <%=Html.ValidationSummary(true)%>
        
        <fieldset>
            <legend>Fields</legend>
 
            <%=Html.HiddenFor(model => model.MechManiaTeam.id)%>
            
            <div class="editor-label">
                <%=Html.LabelFor(model => model.MechManiaTeam.team_name)%>
            </div>
            <div class="editor-field">
                <%=Html.TextBoxFor(model => model.MechManiaTeam.team_name)%>
                <%=
     		Html.ValidationMessageFor(model => model.MechManiaTeam.team_name)%>
            </div>
             
            <div class="editor-label">
                <%=Html.LabelFor(model => model.MechManiaTeam.member1_id)%>
            </div>
            <div class="editor-field">
                <%=
     		Html.DropDownListFor(model => model.MechManiaTeam.member1_id,
     		                     Model.Attendees)%>
                <%=
     		Html.ValidationMessageFor(model => model.MechManiaTeam.member1_id)%>
            </div>
              
            <div class="editor-label">
                <%=Html.LabelFor(model => model.MechManiaTeam.member2_id)%>
            </div>
            <div class="editor-field">
                <%=
     		Html.DropDownListFor(model => model.MechManiaTeam.member2_id,
     		                     Model.Attendees)%>
                <%=
     		Html.ValidationMessageFor(model => model.MechManiaTeam.member2_id)%>
            </div>
               
            <div class="editor-label">
                <%=Html.LabelFor(model => model.MechManiaTeam.member3_id)%>
            </div>
            <div class="editor-field">
                <%=
     		Html.DropDownListFor(model => model.MechManiaTeam.member3_id,
     		                     Model.Attendees)%>
                <%=
     		Html.ValidationMessageFor(model => model.MechManiaTeam.member3_id)%>
            </div>
  
            <div class="editor-label">
                <%=Html.LabelFor(model => model.MechManiaTeam.account_name)%>
            </div>
            <div class="editor-field">
                <%=
     		Html.TextBoxFor(model => model.MechManiaTeam.account_name)%>
                <%=
     		Html.ValidationMessageFor(model => model.MechManiaTeam.account_name)%>
            </div>
   
            <div class="editor-label">
                <%=
     		Html.LabelFor(model => model.MechManiaTeam.account_password)%>
            </div>
            <div class="editor-field">
                <%=
     		Html.TextBoxFor(model => model.MechManiaTeam.account_password)%>
                <%=
     		Html.ValidationMessageFor(model => model.MechManiaTeam.account_password)%>
            </div>
                             
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <%
     }%>

    <div>
        <%=Html.ActionLink("Back to List", "Index")%>
    </div>

</asp:Content>

