<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Conferenceware.Models.Company>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <h3>Are you sure you want to delete this (and all related items; irreversable)?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Name</div>
        <div class="display-field"><%= Html.Encode(Model.name) %></div>
        
        <div class="display-label">Address Line 1</div>
        <div class="display-field"><%= Html.Encode(Model.address_line1) %></div>
        
        <div class="display-label">Address Line 2</div>
        <div class="display-field"><%= Html.Encode(Model.address_line2) %></div>
        
        <div class="display-label">City</div>
        <div class="display-field"><%= Html.Encode(Model.city) %></div>
        
        <div class="display-label">State</div>
        <div class="display-field"><%= Html.Encode(Model.state) %></div>
        
        <div class="display-label">Zip</div>
        <div class="display-field"><%= Html.Encode(Model.zip) %></div>
        
        <div class="display-label">Needs power?</div>
        <div class="display-field"><%= Html.Encode(Model.needs_power) %></div>
        
        <div class="display-label">Priority shipping?</div>
        <div class="display-field"><%= Html.Encode(Model.priority_shipping) %></div>

        <div class="display-label">People</div>
        <div class="display-field">
            <ol>
                <% foreach (var cp in Model.CompanyPersons)
                   {%>
                   <li><%= Html.ActionLink(cp.People.name, "Edit", "CompanyPerson", new { id = cp.person_id }, null) %></li>
                <%
                   }%>
            </ol>
        </div>

        <div class="display-label">Invoices</div>
        <div class="display-field">
            <ul>
                <% foreach (var invoice in Model.CompanyInvoices)
                   {%>
                   <li><%= Html.ActionLink(invoice.InvoiceId.ToString(), "Edit", "CompanyInvoice", new { id = invoice.InvoiceId }, null) %></li>
                <%
                    }%>
            </ul>
        </div>

        <div class="display-label">Invoice Total</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:F}", Model.InvoiceTotal)) %></div>

        
        <div class="display-label">Payments</div>
        <div class="display-field">
            <ul>
                <% foreach (var payment in Model.CompanyPayments)
                   {%>
                   <li><%= Html.ActionLink(payment.payment_id.ToString(), "Edit", "CompanyPayment", new { id = payment.payment_id }, null) %></li>
                <%
                    }%>
            </ul>
        </div>

        
        <div class="display-label">Payments Total</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:F}", Model.PaymentsTotal)) %></div>
        
        <div class="display-label">Total Owed</div>
        <div class="display-field"><%= Html.Encode(String.Format("{0:F}", Model.TotalOwed)) %></div>
        
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
        <%= Html.HiddenFor(model => model.id) %>
		    <input type="submit" value="Delete" /> |
		    <%= Html.ActionLink("Back to List", "Index") %>
        </p>
    <% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ExtraHeadContent" runat="server">
</asp:Content>

