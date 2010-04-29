<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.TShirtSize>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%
    	using (Html.BeginForm())
     {%>

        <fieldset>
            <legend>Fields</legend>
            
            <%=Html.HiddenFor(model => model.id)%>
            
            <div class="editor-label">
                <%=Html.LabelFor(model => model.name)%>
            </div>
            <div class="editor-field">
                <%=Html.TextBoxFor(model => model.name)%>
                <%=Html.ValidationMessageFor(model => model.name)%>
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

