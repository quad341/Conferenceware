<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.AttendeeEditData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Attendee Registration
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%
    	Html.EnableClientValidation();%>
    <h2>Attendee Registration</h2>

    <%
    	using (Html.BeginForm())
     {%>
        <%=Html.ValidationSummary(true)%>

        <fieldset>
            <legend>Fields</legend>
            <%=Html.HiddenFor(model => model.Attendee.person_id,
     	                                 new {value = 0})%>
            
            <div class="editor-label">
                <%=Html.LabelFor(model => model.Attendee.People.name)%>
            </div>
            <div class="editor-field">
                <%=Html.TextBoxFor(model => model.Attendee.People.name)%>
                <%=
     		Html.ValidationMessageFor(model => model.Attendee.People.name)%>
            </div>
            <!-- Wohoo ASP.NET MVC 2 bug -->
            <input type="hidden" name="Attendee.People.phone_number" value="111-111-1111" /> 
            <div class="editor-label">
                <%=Html.LabelFor(model => model.Attendee.People.email)%>
            </div>
            <div class="editor-field">
                <%=Html.TextBoxFor(model => model.Attendee.People.email)%>
                <%=
     		Html.ValidationMessageFor(model => model.Attendee.People.email)%>
            </div>
            
            
             
            <div class="editor-label">
                <%=Html.LabelFor(model => model.Attendee.tshirt_id)%>
            </div>
            <div class="editor-field">
                <%=Html.DropDownListFor(model => model.Attendee.tshirt_id,
     	                                       Model.TShirtSizes)%>
                <%=
     		Html.ValidationMessageFor(model => model.Attendee.tshirt_id)%>
            </div>
           
            <div class="editor-label">
                <%=Html.LabelFor(model => model.Attendee.food_choice_id)%>
            </div>
            <div class="editor-field">
                <%=
     		Html.DropDownListFor(model => model.Attendee.food_choice_id, Model.Foods)%>
                <%=
     		Html.ValidationMessageFor(model => model.Attendee.food_choice_id)%>
            </div>
            
            <div class="editor-label">
                <%=Html.LabelFor(model => model.Attendee.People.is_alum)%>
            </div>
            <div class="editor-field">
                <%=Html.CheckBoxFor(model => model.Attendee.People.is_alum)%>
                <%=
     		Html.ValidationMessageFor(model => model.Attendee.People.is_alum)%>
            </div>
          
            <p>
                <input id="submit-button" type="submit" value="Submit"
                onclick="document.getElementById('submit-button').style.visibility='hidden'; document.getElementById('submit-text').style.visibility='visible';return true;"/>
                <span id='submit-text' style="visibility:hidden">Registering. This can take up to 10 seconds. You will recieve a confirmation email when registration is complete.</span>
            </p>
        </fieldset>

    <%
     }%>

    <div>
        <%=Html.ActionLink("Back to List", "Index")%>
    </div>

</asp:Content>

