<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.Company>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label"><%= Html.LabelFor(x => x.name) %></div>
        <div class="display-field"><%= Html.Encode(Model.name) %></div>
        
        <div class="display-label"><%= Html.LabelFor(x => x.address_line1) %></div>
        <div class="display-field"><%= Html.Encode(Model.address_line1) %></div>
        
        <div class="display-label"><%= Html.LabelFor(x => x.address_line2) %></div>
        <div class="display-field"><%= Html.Encode(Model.address_line2) %></div>
        
        <div class="display-label"><%= Html.LabelFor(x => x.city) %></div>
        <div class="display-field"><%= Html.Encode(Model.city) %></div>
        
        <div class="display-label"><%= Html.LabelFor(x => x.state) %></div>
        <div class="display-field"><%= Html.Encode(Model.state) %></div>
        
        <div class="display-label"><%= Html.LabelFor(x => x.zip) %></div>
        <div class="display-field"><%= Html.Encode(Model.zip) %></div>
        
        <div class="display-label"><%= Html.LabelFor(x => x.needs_power) %></div>
        <div class="display-field"><%= Html.Encode(Model.needs_power) %></div>
        
        <div class="display-label"><%= Html.LabelFor(x => x.priority_shipping) %></div>
        <div class="display-field"><%= Html.Encode(Model.priority_shipping) %></div>
        
        <div class="display-label"><%= Html.LabelFor(x => x.TotalOwed) %></div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:C}",Model.TotalOwed)) %></div>
        
        <div class="display-label">People</div>
        <div class="display-field">
            <ul>
                <% foreach (var cp in Model.CompanyPersons)
  {%>
                <li class="entry-with-inline-form">
                    <%
  	using (Html.BeginForm("Delete", "CompanyPerson"))
  	{%>
                    <%=Html.Hidden("id", cp.person_id)%>
                    <input type="submit" value="Delete" />
                    <%
  	}%>
                    <%=Html.ActionLink(cp.People.name,
  	                                  "Edit",
  	                                  "CompanyPerson",
  	                                  new {cp.person_id})%>
                </li>
                <%
  }%>
            </ul>
            <%= Html.ActionLink("Create Company Person", "Create", "CompanyPerson") %>
        </div>
         
        <div class="display-label">Invoices</div>
        <div class="display-field">
            <ul>
                <% foreach (var invoice in Model.CompanyInvoices)
  {%>
                <li class="entry-with-inline-form">
                    <%
  	using (Html.BeginForm("Delete", "CompanyInvoice"))
  	{%>
                    <%=Html.Hidden("id", invoice.id) %>
                    <input type="submit" value="Delete" />
                    <%
  	}%>
                    <%=Html.ActionLink(String.Format("{0} (Last Sent {1})",invoice.id, invoice.last_sent),
  	                                  "Edit",
  	                                  "CompanyInvoice",
  	                                  new {invoice.id})%>
                </li>
                <%
  }%>
            </ul>
            <div class="display-label"><%= Html.LabelFor(x => x.InvoiceTotal) %></div>
            <div class="display-field"><%= Html.Encode(String.Format("{0:C}",Model.InvoiceTotal)) %></div>
            <%= Html.ActionLink("Create Invoice", "Create", "CompanyInvoice", new {Model.id}) %>
        </div>
        
        <div class="display-label">Payments</div>
        <div class="display-field">
            <ul>
                <% foreach (var payment in Model.CompanyPayments)
  {%>
                <li class="entry-with-inline-form">
                    <%
  	using (Html.BeginForm("Delete", "CompanyPayment"))
  	{%>
                    <%=Html.Hidden("id", payment.id) %>
                    <input type="submit" value="Delete" />
                    <%
  	}%>
                    <%=Html.ActionLink(String.Format("{0} (Received {1})", payment.id, payment.received_date),
  	                                  "Edit",
  	                                  "CompanyPayment",
  	                                  new {payment.id})%>
                </li>
                <%
  }%>
            </ul>
            <div class="display-label"><%= Html.LabelFor(x => x.PaymentsTotal) %></div>
            <div class="display-field"><%= Html.Encode(String.Format("{0:C}",Model.PaymentsTotal)) %></div>
            <%= Html.ActionLink("Create Payment", "Create", "CompanyPayment", new {Model.id}) %>
        </div>
       
    </fieldset>
    <p>

        <%= Html.ActionLink("Edit", "Edit", new { id=Model.id }) %> |
        <%= Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

