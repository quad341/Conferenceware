﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.AttendeeEditData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%
    	Html.EnableClientValidation();%>
    <h2>Create</h2>

    <%
    	using (Html.BeginForm())
     {%>

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
             
            <div class="editor-label">
                <%=Html.LabelFor(model => model.Attendee.People.email)%>
            </div>
            <div class="editor-field">
                <%=Html.TextBoxFor(model => model.Attendee.People.email)%>
                <%=
     		Html.ValidationMessageFor(model => model.Attendee.People.email)%>
            </div>
            <!-- Wohoo ASP.NET MVC 2 bug -->
            <input type="hidden" name="Attendee.People.phone_number" value="111-111-1111" />
  
             
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
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <%
     }%>

    <div>
        <%=Html.ActionLink("Back to List", "Index")%>
    </div>

</asp:Content>

