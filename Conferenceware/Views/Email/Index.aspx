<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.EmailEditData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ContentPlaceHolderID="ExtraHeadContent" ID="JsStuff" runat="server">
<script type="text/javascript">
    function checkSubs (checkall) {
        var checked = checkall.checked;
        checkall.parent().children(":checkbox").each(function() {
            this.checked = checked;
        });
    }
    $(document).ready(function() {
        $("#selectAllAttendees").click(function() {
            var checked = this.checked;
            $("#attendeeChoices input:checkbox").each(function() {
                this.checked = checked;
            });
        });
        $("#selectAllPeople").click(function() {
            var checked = this.checked;
            $("#people input:checkbox").each(function() {
                this.checked = checked;
            });
        });
        $("#selectAllMMT").click(function() {
            var checked = this.checked;
            $("#mmtChoices input:checkbox").each(function() {
                this.checked = checked;
            });
        });
        $("#selectAllSpeakers").click(function() {
            var checked = this.checked;
            $("#speakerChoices input:checkbox").each(function() {
                this.checked = checked;
            });
        });
        $("#selectAllSponsors").click(function() {
            var checked = this.checked;
            $("#sponsorChoices input:checkbox").each(function() {
                this.checked = checked;
            });
        });
        $("#selectAllStaff").click(function() {
            var checked = this.checked;
            $("#staffChoices input:checkbox").each(function() {
                this.checked = checked;
            });
        });
        $("#selectAllVolunteers").click(function() {
            var checked = this.checked;
            $("#volunteerChoices input:checkbox").each(function() {
                this.checked = checked;
            });
        });
    });
    $(function() {
        $("#people").accordion();
    });
</script>
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
            <input type="checkbox" id="selectAllPeople" name="selectAllPeople"/><label for="selectAllPeople">Select All/None People</label>
            <div id="people" class="editor-field">
                <h3><a href="#">Attendees</a></h3>
                <div id="attendeeChoices" class="editor-field">
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
                <input type="checkbox" id="selectAllAttendees" name="selectAllAttendees"/><label for="selectAllAttendees">Select All/None Attendees</label>
                </div>
                <h3><a href="#">Mechmania Participants</a></h3>
                <div id="mmtChoices" class="editor-field">
                    <dl>
                        <% foreach (var mmt in Model.Everyone.MechManiaTeams)
                           {%>
                        <dt>
                            <%= String.Format("{0} (Account: {1})", Html.Encode(mmt.team_name), Html.Encode(mmt.account_name)) %></dt>
                        <dd>
                            <ul>
                            <% foreach (var member in mmt.Members)
{%>
                                <li>
                                    <input type="checkbox" name="SelectedPeopleIds" value="<%= member.person_id%>"
                                        <%=Model.SelectedPeopleIds.Contains(member.person_id)
	                  	? "checked=\"checked\""
	                  	: ""%> />
                                    <%=Html.Encode(member.People.name)%>
                                </li>
                                <%
}%>
                            </ul>
                        </dd>
                        <%
                            }%>
                    </dl>
                    <input type="checkbox" id="selectAllMMT" name="selectAllMMT"/><label for="selectAllMMT">Select All/None MechMania People</label>
                </div>
                <h3><a href="#">Speakers</a></h3>
                <div id="speakerChoices" class="editor-field">
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
                    <input type="checkbox" id="selectAllSpeakers" name="selectAllSpeakers"/><label for="selectAllSpeakers">Select All/None Speakers</label>
                </div>
                <h3><a href="#">Sponsors</a></h3>
                <div id="sponsorChoices" class="editor-field">
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
                    <input type="checkbox" id="selectAllSponsors" name="selectAllSponsors"/><label for="selectAllSponsors">Select All/None Sponsors</label>
                </div>
                <h3><a href="#">Staff</a></h3>
                <div id="staffChoices" class="editor-field">
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
                    <input type="checkbox" id="selectAllStaff" name="selectAllStaff"/><label for="selectAllStaff">Select All/None Staff</label>
                </div>
                <h3><a href="#">Volunteers</a></h3>
                <div id="volunteerChoices" class="editor-field">
                <ul>
                <% foreach (var vol in Model.Everyone.Volunteers)
{%>
                <li>
                    <input type="checkbox" name="SelectedPeopleIds" value="<%= vol.person_id %>" <%= Model.SelectedPeopleIds.Contains(vol.person_id)?"checked=\"checked\"":"" %> />
                    <%= vol.People.name %><%= vol.NeedsVideoTraining ? "(Needs Video Training)":"" %>
                </li>
                <%
}%>
                </ul>
                    <input type="checkbox" id="selectAllVolunteers" name="selectAllVolunteers"/><label for="selectAllVolunteers">Select All/None Volunteers</label>
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

