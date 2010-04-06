<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.EmailEditData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.EnableClientValidation(); %>

    <h2>Index</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="display-label">People to email</div>
            <%= Html.ValidationMessageFor(model => model.SelectedPeopleIds) %>
            <div class="editor-field">
                <div class="editor-label">Attendees</div>
                <div class="editor-field">
                <ul>
                <% foreach (var at in Model.Everyone.Attendees)
{%>
                <li>
                    <input type="checkbox" name="SelectedPeopleIds" value="<%= at.person_id %>" <%= Model.SelectedPeopleIds.Contains(at.person_id)?"checked=\"checked\"":"" %> />
                    <%= Html.Encode(at.People.name) %>
                </li>
                <%
}%>
                </ul>
                <!-- select all button -->
                </div>
                <div class="editor-label">Mechmania Participants</div>
                <div class="editor-field">
                <ul>
                <% foreach (var mmp in Model.Everyone.MechmaniaParticipants)
{%>
                <li>
                    <input type="checkbox" name="SelectedPeopleIds" value="<%= mmp.person_id %>" <%= Model.SelectedPeopleIds.Contains(mmp.person_id)?"checked=\"checked\"":"" %> />
                    <%= Html.Encode(mmp.People.name) %>
                </li>
                <%
}%>
                </ul>
                <!-- select all button -->
                </div>
                <div class="editor-label">Speakers</div>
                <div class="editor-field">
                <ul>
                <% foreach (var speaker in Model.Everyone.Speakers)
{%>
                <li>
                    <input type="checkbox" name="SelectedPeopleIds" value="<%= speaker.person_id %>" <%= Model.SelectedPeopleIds.Contains(speaker.person_id)?"checked=\"checked\"":"" %> />
                    <%= Html.Encode(speaker.People.name) %>
                </li>
                <%
}%>
                </ul>
                <!-- select all button -->
                </div>
                <div class="editor-label">Sponsors</div>
                <div class="editor-field">
                <ul>
                <% foreach (var sponsor in Model.Everyone.Sponsors)
{%>
                <li>
                    <input type="checkbox" name="SelectedPeopleIds" value="<%= sponsor.person_id %>" <%= Model.SelectedPeopleIds.Contains(sponsor.person_id)?"checked=\"checked\"":"" %> />
                    <%= sponsor.People.name %>(<%= Html.Encode(sponsor.Company.name) %>, Primary Contact <%= Html.Encode(sponsor.is_contact) %>)
                </li>
                <%
}%>
                </ul>
                <!-- select all button -->
                </div>
                <div class="editor-label">Staff</div>
                <div class="editor-field">
                <ul>
                <% foreach (var sm in Model.Everyone.StaffMembers)
{%>
                <li>
                    <input type="checkbox" name="SelectedPeopleIds" value="<%= sm.person_id %>" <%= Model.SelectedPeopleIds.Contains(sm.person_id)?"checked=\"checked\"":"" %> />
                    <%= sm.People.name %>
                </li>
                <%
}%>
                </ul>
                <!-- select all button -->
                </div>
                <div class="editor-label">Volunteers</div>
                <div class="editor-field">
                <ul>
                <% foreach (var vol in Model.Everyone.Volunteers)
{%>
                <li>
                    <input type="checkbox" name="SelectedPeopleIds" value="<%= vol.person_id %>" <%= Model.SelectedPeopleIds.Contains(vol.person_id)?"checked=\"checked\"":"" %> />
                    <%= vol.People.name %>
                </li>
                <%
}%>
                </ul>
                <!-- select all button -->
                </div>
               
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.SendIndividualEmails) %>
            </div>
            <div class="editor-field">
                <%= Html.CheckBoxFor(model => model.SendIndividualEmails) %>
                <%= Html.ValidationMessageFor(model => model.SendIndividualEmails) %>
            </div>
             
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Subject) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Subject) %>
                <%= Html.ValidationMessageFor(model => model.Subject) %>
            </div>
           
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Message) %>
            </div>
            <div class="editor-field">
                <%= Html.TextAreaFor(model => model.Message, 15, 80, null) %>
                <%= Html.ValidationMessageFor(model => model.Message) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

