<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.CompanyInvoice>" %>
<%@ Import Namespace="Conferenceware.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <h3>Are you sure you want to delete this and all the items linked to it?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Total Value</div>
        <div class="display-field"><%=Html.Encode(String.Format("{0:F}", Model.TotalValue))%></div>
        
        <div class="display-label">Created</div>
        <div class="display-field"><%=Html.Encode(String.Format("{0:g}", Model.created))%></div>
        
        <div class="display-label">Last Sent (only if later than created is real)</div>
        <div class="display-field"><%=Html.Encode(String.Format("{0:g}", Model.last_sent))%></div>
        
        <div class="display-label">Paid</div>
        <div class="display-field"><%=Html.Encode(Model.paid)%></div>
        
        <div class="display-label">When was paid? (only if later than created is real)</div>
        <div class="display-field"><%=Html.Encode(String.Format("{0:g}", Model.marked_paid_date))%></div>
        
        <div class="display-label">Items</div>
        <div class="display-field">
            <ul>
            <%
            	foreach (CompanyInvoiceItem cii in Model.CompanyInvoiceItems)
             {%>
  	            <li><%=String.Format("{0} ({1:C})", cii.name, cii.cost)%></li>
  <%
             }%>
            </ul>
        </div>
        
    </fieldset>
    <%
            	using (Html.BeginForm())
             {%>
        <p>
            <%=Html.HiddenFor(model => model.id)%>
		    <input type="submit" value="Delete" /> |
		    <%=Html.ActionLink("Back to Company",
             	                                  "Details",
             	                                  "Company",
             	                                  new {id = Model.company_id},
             	                                  null)%>
        </p>
    <%
             }%>

</asp:Content>

