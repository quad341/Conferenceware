<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.CompanyInvoice>" %>
<%@ Import Namespace="Conferenceware.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%
    	using (Html.BeginForm())
     {%>
        <%=Html.ValidationSummary(true)%>
        
        <fieldset>
            <legend>Fields</legend>
            
            <%=Html.HiddenFor(model => model.id)%>
            
            <div class="editor-label">
                Company
            </div>
            <div class="editor-field">
                <%=Html.HiddenFor(model => model.company_id)%>
                <%=Model.Company.name%>
            </div>
            
            <div class="editor-label">
                <%=Html.LabelFor(model => model.created)%>
            </div>
            <div class="editor-field">
                <%=String.Format("{0:g}", Model.created)%>
            </div>
            
            <div class="editor-label">
                <%=Html.LabelFor(model => model.last_sent)%>
            </div>
            <div class="editor-field">
                <%=Html.TextBoxFor(model => model.last_sent,
     	                                  String.Format("{0:g}", Model.last_sent))%>
                <%=Html.ValidationMessageFor(model => model.last_sent)%>
            </div>
            
            <div class="editor-label">
                <%=Html.LabelFor(model => model.paid)%>
            </div>
            <div class="editor-field">
                <%=Html.CheckBoxFor(model => model.paid)%>
                <%=Html.ValidationMessageFor(model => model.paid)%>
            </div>
            
            <div class="editor-label">
                <%=Html.LabelFor(model => model.marked_paid_date)%>
            </div>
            <div class="editor-field">
                <%=Model.created >= Model.marked_paid_date
     	                  	? "N/A"
     	                  	: String.Format("{0:g}", Model.marked_paid_date)%>
            </div>
            
            <div class="display-label">
                <%=Html.LabelFor(model => model.TotalValue)%>
            </div>
            <div class="display-field">
                <%=String.Format("{0:C}", Model.TotalValue)%>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <%
     }%>
    <%= Html.ActionLink("Download", "DownloadInvoice", "Company", new { Model.id }, null)%> |
    <%= Html.ActionLink("Email", "Email", "CompanyInvoice", new { Model.id }, null)%>
    <div class="display-label">Items</div>
    <div class="display-field">
        <ul>
            <%
    	foreach (CompanyInvoiceItem cii in Model.CompanyInvoiceItems)
     {%>
            <li class="entry-with-inline-form">
            <%
     	using (Html.BeginForm("Delete", "CompanyInvoiceItem"))
     	{%>
            <%=Html.Hidden("itemId", cii.ItemId)%>	
            <input type="submit" value="Delete" />
<%
     	}%>
                <%=String.Format("{0} ({1:C})", cii.name, cii.cost)%>
            </li>
	
<%
     }%>
        </ul>
        <%=Html.ActionLink("Add item",
			                                  "Create",
			                                  "CompanyInvoiceItem",
			                                  new {Model.id},
			                                  null)%>
    </div>

    <div>
        <%=Html.ActionLink("Back to Company",
			                                  "Details",
			                                  "Company",
			                                  new {id = Model.company_id},
			                                  null)%>
    </div>

</asp:Content>

