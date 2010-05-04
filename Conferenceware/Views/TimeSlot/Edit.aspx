<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.TimeSlot>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ContentPlaceHolderID="ExtraHeadContent" ID="JSStuff" runat="server">
<script type="text/javascript">
    $(function() {
        $('#start_time').datetime({
            userLang: 'en',
            americanMode: true
        });
        $('#end_time').datetime({
            userLang: 'en',
            americanMode: true
        });
    });
</script>
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
                <%=Html.LabelFor(model => model.start_time)%>
            </div>
            <div class="editor-field">
                <input type="text" name="start_time" id="start_time" value="<%=Model.start_time.ToString("u")%>" />
                <%=Html.ValidationMessageFor(model => model.start_time)%>
            </div>
            
            <div class="editor-label">
                <%=Html.LabelFor(model => model.end_time)%>
            </div>
            <div class="editor-field">
                <input type="text" name="end_time" id="end_time" value="<%=Model.end_time.ToString("u")%>" />
                <%=Html.ValidationMessageFor(model => model.end_time)%>
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

