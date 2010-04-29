<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.Location>" %>

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

        <fieldset>
            <legend>Fields</legend>
            
            <%=Html.HiddenFor(model => model.id)%>
            
            <div class="editor-label">
                <%=Html.LabelFor(model => model.max_capacity)%>
            </div>
            <div class="editor-field">
                <%=Html.TextBoxFor(model => model.max_capacity)%>
                <%=Html.ValidationMessageFor(model => model.max_capacity)%>
            </div>
            
            <div class="editor-label">
                <%=Html.LabelFor(model => model.building_name)%>
            </div>
            <div class="editor-field">
                <%=Html.TextBoxFor(model => model.building_name)%>
                <%=Html.ValidationMessageFor(model => model.building_name)%>
            </div>
            
            <div class="editor-label">
                <%=Html.LabelFor(model => model.room_number)%>
            </div>
            <div class="editor-field">
                <%=Html.TextBoxFor(model => model.room_number)%>
                <%=Html.ValidationMessageFor(model => model.room_number)%>
            </div>
            
            <div class="editor-label">
                <%=Html.LabelFor(model => model.notes)%>
            </div>
            <div class="editor-field">
                <%=Html.TextBoxFor(model => model.notes)%>
                <%=Html.ValidationMessageFor(model => model.notes)%>
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

