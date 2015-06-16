<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MobileC.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="LinqToTwitterMvcDemo.Models" %>
<%@ Import Namespace="LinqToTwitterMvcDemo.Helpers" %>
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
   <% if (u.lastlogin != null)
      { %>
   <p class="ui-li-aside">Last seen <strong><%=FormatHelpers.formatTimeStamp(u.lastlogin) %></strong></p></a></li>
   <% }
      else
      { %>
       <p class="ui-li-aside">Not yet active</p></a></li>
   <% } %>
   </ul>
                 
<%} %>

<ul data-role="listview" data-inset="true" data-theme="a" data-dividertheme="b">
	<li><%=Html.ActionLink("Back to Menu", "IndexC", "Mobile") %></li>
</ul>
</asp:Content>
