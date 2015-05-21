<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MobileC.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	OK fridge
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">
<h1><img id="headerIMG" src="../../Content/images/logo_header6.png" /></h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 <ul data-role="listview" data-inset="true" data-theme="a" data-dividertheme="b">
	<li><%=Html.ActionLink("Get Started", "GetStarted", "Mobile") %></li>
    <li><%=Html.ActionLink("Messages", "Messages", "Mobile", new { target = "CourseGroups" }, null)%></li>
    <li><%=Html.ActionLink("Events", "Events", "Mobile") %></li>
</ul>

<div id="mainframe">
<div class="ui-grid-a ui-responsive">    
    <div class="ui-block-a">
<a href="#" onclick="getTweets(5)" class="ui-btn ui-btn-c ui-mini">Messages</a>
        </div>
    <div class="ui-block-b">
<a href="#" onclick="Events()" class="ui-btn ui-btn-c ui-mini">Events</a>
    </div>
</div>
<br />
<div id="tweetsfullooo" style="display:none">Loading Tweets ....</div>

<div id="tweets" style="display:none">
<div data-role="collapsible-set" data-theme="a" data-content-theme="a">
    <div data-role="collapsible">
        <h3>My Tweets</h3>
  <div id="mytweets"></div>
    </div>
    <div data-role="collapsible">
        <h3>Following</h3>
  <div id="following"></div>
    </div>
   <div data-role="collapsible">
        <h3>Mentions</h3>
  <div id="mentions"></div>
    </div>
    <div data-role="collapsible">
        <h3>OK fridge</h3>
  <div id="okf"></div>
</div>
</div>
  <br />
  </div>

<div id="toptweet" style="display:none">20</div>
<div style="display:none" id="toptweettime"></div>
    </div>
</asp:Content>
