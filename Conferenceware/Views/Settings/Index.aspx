<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.SettingsData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    View and Edit Settings
</asp:Content>
<asp:Content ID="JSData" ContentPlaceHolderID="ExtraHeadContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();
            $('#AttendeeRegistrationAutoCloseDateTime').datetime({
                userLang: 'en',
                americanMode: true
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        Html.EnableClientValidation();%>
    <h2>
        Settings</h2>
    <form action="<%=Url.Action("Index")%>" enctype="multipart/form-data" method="post">
    <%=Html.ValidationSummary(true)%>
    <fieldset>
        <legend>Fields</legend>
        <div id="tabs">
            <ul>
                <li><a href="#frontpageSettings" title="Frontpage Settings">Frontpage</a></li>
                <li><a href="#emailSettings" title="Email Settings">Email</a></li>
                <li><a href="#badgeSettings" title="Badge Settings">Badges</a></li>
                <li><a href="#registrationSettings" title="Registration Settings">Registration</a></li>
                <li><a href="#siteDisplayRelatedSettings" title="Site Display Related Settings">Site
                    Display Related Settings</a></li>
            </ul>
            <div id="frontpageSettings">
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.FrontpageTitle)%>
                </div>
                <div class="editor-field">
                    <%=Html.TextBoxFor(model => model.FrontpageTitle)%>
                    <%=Html.ValidationMessageFor(model => model.FrontpageTitle)%>
                </div>
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.FrontpageContent)%>
                </div>
                <div class="editor-field">
                    <%=Html.TextAreaFor(model => model.FrontpageContent,
			                                   15,
			                                   80,
			                                   null)%>
                    <%=Html.ValidationMessageFor(model => model.FrontpageContent)%>
                </div>
            </div>
            <div id="emailSettings">
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.EmailFrom)%>
                </div>
                <div class="editor-field">
                    <%=Html.TextBoxFor(model => model.EmailFrom)%>
                    <%=Html.ValidationMessageFor(model => model.EmailFrom)%>
                </div>
                <div class="editor-label">
                    <%=
				Html.LabelFor(model => model.EventRegistrationConfirmationSubjectFormat)%>
                </div>
                <div class="editor-field">
                    <%=
				Html.TextBoxFor(model => model.EventRegistrationConfirmationSubjectFormat)%>
                    <%=
				Html.ValidationMessageFor(
					model => model.EventRegistrationConfirmationSubjectFormat)%>
                </div>
                <div class="editor-label">
                    <%=
				Html.LabelFor(model => model.EventRegistrationConfirmationBodyFormat)%>
                </div>
                <div class="editor-field">
                    <%=
				Html.TextAreaFor(model => model.EventRegistrationConfirmationBodyFormat,
				                 15,
				                 80,
				                 null)%>
                    <%=
				Html.ValidationMessageFor(
					model => model.EventRegistrationConfirmationBodyFormat)%>
                </div>
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.RegistrationSubject)%>
                </div>
                <div class="editor-field">
                    <%=Html.TextBoxFor(model => model.RegistrationSubject)%>
                    <%=
				Html.ValidationMessageFor(model => model.RegistrationSubject)%>
                </div>
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.RegistrationMessage)%>
                </div>
                <div class="editor-field">
                    <%=Html.TextAreaFor(model => model.RegistrationMessage,
			                                   15,
			                                   80,
			                                   null)%>
                    <%=
				Html.ValidationMessageFor(model => model.RegistrationMessage)%>
                </div>
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.SmtpHostname)%>
                </div>
                <div class="editor-field">
                    <%=Html.TextBoxFor(model => model.SmtpHostname)%>
                    <%=Html.ValidationMessageFor(model => model.SmtpHostname)%>
                </div>
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.SmtpPort)%>
                </div>
                <div class="editor-field">
                    <%=Html.TextBoxFor(model => model.SmtpPort)%>
                    <%=Html.ValidationMessageFor(model => model.SmtpPort)%>
                </div>
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.SmtpNeedsAuthentication)%>
                </div>
                <div class="editor-field">
                    <%=Html.CheckBoxFor(model => model.SmtpNeedsAuthentication)%>
                    <%=
				Html.ValidationMessageFor(model => model.SmtpNeedsAuthentication)%>
                </div>
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.SmtpAuthenticationUserName)%>
                </div>
                <div class="editor-field">
                    <%=Html.TextBoxFor(model => model.SmtpAuthenticationUserName)%>
                    <%=
				Html.ValidationMessageFor(model => model.SmtpAuthenticationUserName)%>
                </div>
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.SmtpAuthenticationPassword)%>
                </div>
                <div class="editor-field">
                    <%=Html.TextBoxFor(model => model.SmtpAuthenticationPassword)%>
                    <%=
				Html.ValidationMessageFor(model => model.SmtpAuthenticationPassword)%>
                </div>
            </div>
            <div id="badgeSettings">
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.AttendeeBadgeBackground)%><br />
                    <img src="<%=Url.Action("GetImage",
			                             new {filename = "AttendeeBadgeBackground"})%>" class="badge-background-image"
                        alt="Attendee Badge Background" />
                </div>
                <div class="editor-field">
                    <input type="file" name="AttendeeBadgeBackground" id="AttendeeBadgeBackground" />
                </div>
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.MechmaniaBadgeBackground)%><br />
                    <img src="<%=Url.Action("GetImage",
			                             new {filename = "MechmaniaBadgeBackground"})%>" class="badge-background-image"
                        alt="Mechmania Badge Background" />
                </div>
                <div class="editor-field">
                    <input type="file" name="MechmaniaBadgeBackground" id="MechmaniaBadgeBackground" />
                </div>
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.SpeakerBadgeBackground)%><br />
                    <img src="<%=Url.Action("GetImage",
			                             new {filename = "SpeakerBadgeBackground"})%>" class="badge-background-image"
                        alt="Speaker Badge Background" />
                </div>
                <div class="editor-field">
                    <input type="file" name="SpeakerBadgeBackground" id="SpeakerBadgeBackground" />
                </div>
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.SponsorBadgeBackground)%><br />
                    <img src="<%=Url.Action("GetImage",
			                             new {filename = "SponsorBadgeBackground"})%>" class="badge-background-image"
                        alt="Sponsor Badge Background" />
                </div>
                <div class="editor-field">
                    <input type="file" name="SponsorBadgeBackground" id="SponsorBadgeBackground" />
                </div>
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.StaffBadgeBackground)%><br />
                    <img src="<%=Url.Action("GetImage",
			                             new {filename = "StaffBadgeBackground"})%>" class="badge-background-image"
                        alt="Staff Badge Background" />
                </div>
                <div class="editor-field">
                    <input type="file" name="StaffBadgeBackground" id="StaffBadgeBackground" />
                </div>
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.VolunteerBadgeBackground)%><br />
                    <img src="<%=Url.Action("GetImage",
			                             new {filename = "VolunteerBadgeBackground"})%>" class="badge-background-image"
                        alt="Volunteer Badge Background" />
                </div>
                <div class="editor-field">
                    <input type="file" name="VolunteerBadgeBackground" id="VolunteerBadgeBackground" />
                </div>
            </div>
            <div id="registrationSettings">
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.MaxAttendees)%>
                </div>
                <div class="editor-field">
                    <%=Html.TextBoxFor(model => model.MaxAttendees)%>
                    <%=Html.ValidationMessageFor(model => model.MaxAttendees)%>
                </div>
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.AttendeeRegistrationAutoCloseDateTime)%>
                </div>
                <div class="editor-field">
                    <input type="text" name="AttendeeRegistrationAutoCloseDateTime" id="AttendeeRegistrationAutoCloseDateTime" value="<%=Model.AttendeeRegistrationAutoCloseDateTime.ToString("u")%>" />
                    <%=Html.ValidationMessageFor(model => model.AttendeeRegistrationAutoCloseDateTime)%>
                </div>
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.MaxVolunteers)%>
                </div>
                <div class="editor-field">
                    <%=Html.TextBoxFor(model => model.MaxVolunteers)%>
                    <%=Html.ValidationMessageFor(model => model.MaxVolunteers)%>
                </div>
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.VolunteerRegistrationAutoCloseDateTime)%>
                </div>
                <div class="editor-field">
                    <input type="text" name="VolunteerRegistrationAutoCloseDateTime" id="VolunteerRegistrationAutoCloseDateTime" value="<%=Model.VolunteerRegistrationAutoCloseDateTime.ToString("u")%>" />
                    <%=Html.ValidationMessageFor(model => model.VolunteerRegistrationAutoCloseDateTime)%>
                </div>
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.MaxMechManiaTeams)%>
                </div>
                <div class="editor-field">
                    <%=Html.TextBoxFor(model => model.MaxMechManiaTeams)%>
                    <%=Html.ValidationMessageFor(model => model.MaxMechManiaTeams)%>
                </div>
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.MechManiaRegistrationAutoCloseDateTime)%>
                </div>
                <div class="editor-field">
                    <input type="text" name="MechManiaRegistrationAutoCloseDateTime" id="MechManiaRegistrationAutoCloseDateTime" value="<%=Model.MechManiaRegistrationAutoCloseDateTime.ToString("u")%>" />
                    <%=Html.ValidationMessageFor(model => model.MechManiaRegistrationAutoCloseDateTime)%>
                </div>
            </div>
            <div id="siteDisplayRelatedSettings">
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.StartDate)%>
                </div>
                <div class="editor-field">
                    <input type="text" name="StartDate" id="StartDate" value="<%=Model.StartDate.ToString("u")%>" />
                    <%=Html.ValidationMessageFor(model => model.StartDate)%>
                </div>
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.EndDate)%>
                </div>
                <div class="editor-field">
                    <input type="text" name="EndDate" id="EndDate" value="<%=Model.EndDate.ToString("u")%>" />
                    <%=Html.ValidationMessageFor(model => model.EndDate)%>
                </div>
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.ShowEvents)%>
                </div>
                <div class="editor-field">
                    <%=Html.CheckBoxFor(model => model.ShowEvents)%>
                    <%=Html.ValidationMessageFor(model => model.ShowEvents)%>
                </div>
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.ShowSpeakers)%>
                </div>
                <div class="editor-field">
                    <%=Html.CheckBoxFor(model => model.ShowSpeakers)%>
                    <%=Html.ValidationMessageFor(model => model.ShowSpeakers)%>
                </div>
                <div class="editor-label">
                    <%=Html.LabelFor(model => model.DisableLinkLocationCheck)%>
                </div>
                <div class="editor-field">
                    <%=Html.CheckBoxFor(model => model.DisableLinkLocationCheck)%>
                    <%=Html.ValidationMessageFor(model => model.DisableLinkLocationCheck)%>
                </div>
            </div>
        </div>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    </form>
    <div>
        <%=Html.ActionLink("Back to List", "Index")%>
    </div>
</asp:Content>
