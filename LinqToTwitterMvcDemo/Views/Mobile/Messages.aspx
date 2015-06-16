<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MobileC.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Messages
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">
 <%= Html.ActionLink("Back", "IndexC", "Mobile")%>
  <h1><img id="headerIMG" src="../../Content/images/logo_header6.png" /></h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    $(document).ready(function () {
        // if ($('#add_site').hasClass('ui-collapsible-collapsed')
        getTweets3(); //gets from lawnchair
    });
</script>

<div class="ui-body ui-body-a ui-corner-all">
<div style="font-size:30px">Messages</div>

  <%= ViewData["twitter"]%> 

  </div>
 
  <div id="tweetsfull">Loading Tweets ....</div>
  <div id="tweetsend"></div>
</asp:Content>
