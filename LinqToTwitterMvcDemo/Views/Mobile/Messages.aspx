<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MobileC.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="LinqToTwitterMvcDemo.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Messages
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">
 <a href="/" class="ui-btn ui-icon-home ui-btn-icon-notext ui-corner-all">Setup</a>
  <h1><img id="headerIMG" src="../../Content/images/logo_header6.png" /></h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    $(document).ready(function () {
        // if ($('#add_site').hasClass('ui-collapsible-collapsed')
       // getTweets3(); //gets from lawnchair
    });
</script>
   <ul data-role="listview" data-inset="true">
<% foreach (TweetViewModel u in (IEnumerable)ViewData.Model)
   {
      
       %>

   <li><%=u.Tweet %><%=u.ID %></li>
  <% if (u.BannerText.Length > 1)
         
     { %>
         <script type="text/javascript">
        
    // getBanner('banner',<%=u.ID %>, 'auto', 'home');
     </script>
     <%  } %>
   <%} %>

 </ul>




</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterContent" runat="server">
<div data-role="footer" data-position="fixed" data-tap-toggle="false">
<a data-role="button" data-icon="gear" href="MsgSetup">Message Options</a>
 <div id="nameandtime"><%=ViewData["uname"] %></div>
 </div>
</asp:Content>