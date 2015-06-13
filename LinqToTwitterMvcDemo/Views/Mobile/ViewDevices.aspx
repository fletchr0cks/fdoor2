<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MobileC.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="LinqToTwitterMvcDemo.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	View Devices
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">
<%= Html.ActionLink("Back", "IndexC", "Mobile")%>
<h1><img id="headerIMG" src="../../Content/images/logo_header6.png" /></h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div><%=ViewData["msgbar"]%></div>
<div id="deviceList"></div>
<% foreach (user u in (IEnumerable)ViewData.Model)
   { %>
   <ul data-role="listview" data-inset="true">
   
   <li><a href="ViewADevice?UserID=<%=u.id %>"><h2><%=u.uname %></h2>
   <% if (u.status == 0)
      { %>
   <p>Disabled</p>
   <% }
      else
      { %>
     <p>Enabled</p>
   <% } %>
   <p class="ui-li-aside">Last seen <strong><%=u.lastlogin %></strong> ago</p></a></li>
   </ul>
                 
<%} %>

</asp:Content>
