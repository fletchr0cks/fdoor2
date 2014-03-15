﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Mobile.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Front
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">

<div data-role="header">

 <a href="#mypanel" class="ui-btn-left ui-btn ui-btn-b ui-btn-inline ui-mini ui-corner-all ui-btn-icon-notext ui-icon-gear">Setup</a>
<h1>Fridge Door</h1>
</div>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div id="mainframe">
<div class="closeBanner" id="banner_header">
</div>
<div class="bigbanner" id="banner_area"></div>
<div id="welcome" style="display:none">
<div class="ui-body ui-body-a ui-corner-all">
<div style="font-size:30px">Get Started</div>
<p>Welcome to Fridge Door.</p>
<div class="ui-grid-b ui-responsive">    
    <div class="ui-block-a"><div style="font-size:20px">Twitter</div>
     <%= ViewData["twitter"]%>
    </div>
     <div class="ui-block-b"><div style="font-size:20px">Google</div>
      <%= ViewData["google"]%>
     </div>
    <div class="ui-block-c"><div style="font-size:20px">Location</div>
     <div id="setLocation"><%= ViewData["location"]%></div>
     
    </div>
   </div>
   <div id="townmsg"></div><div id="townlist"></div>
   </div>
</div>
<div id="tweets" style="display:none">
<div data-role="collapsible">
    <h2>Tweets</h2>
        <ul data-role="listview" data-theme="a" data-divider-theme="b">
            <li data-role="list-divider">Following<span class="ui-li-count"></span></li>
            <li><div id="following"></div></li>
            <li data-role="list-divider">My Tweets<span class="ui-li-count"></span></li>
            <li><div id="mytweets"></div></li>
             <li data-role="list-divider">Mentions<span class="ui-li-count"></span></li>
            <li><div id="mentions"></div></li>
        </ul>
    </div>
</div>
<div id="calblock" style="display:none">
<div class="ui-body ui-body-a ui-corner-all">
<div class="ui-grid-a">
    <div class="ui-block-a"><div style="font-size:20px" id="chosenDay">Today</div>
    
    <div id="eventsDay">event here</div>
    </div>
    <div class="ui-block-b">    
    <div class="ui-grid-f">
    <div class="ui-block-a"><div class="ui-body ui-body-d"><strong>M</strong></div></div>
    <div class="ui-block-b"><div class="ui-body ui-body-d"><strong>T</strong></div></div>
    <div class="ui-block-c"><div class="ui-body ui-body-d"><strong>W</strong></div></div>
    <div class="ui-block-d"><div class="ui-body ui-body-d"><strong>T</strong></div></div>
    <div class="ui-block-e"><div class="ui-body ui-body-d"><strong>F</strong></div></div>
    <div class="ui-block-f"><div class="ui-body ui-body-d"><strong>S</strong></div></div>
    <div class="ui-block-g"><div class="ui-body ui-body-d"><strong>S</strong></div></div>
</div>
<div id="caldata"></div>
</div>
</div>
<div id="weather"></div>

<div id="calendar_next5">
</div>
<div id="weather_next5">
</div>
</div>
</div>
<div id="weatherbloc" style="display:none">
<div style="font-size:20px" id="weatherday">Today</div>
<div id="weatherb">day b</div>
<div id="weather_next5b">next 5 b</div>
</div>
<br />
<div id="agentsID">
<div class="ui-body ui-body-a ui-corner-all">
<div style="font-size:30px">147 Users</div>
    <div class="ui-grid-d">
    <div class="ui-block-a"><p style="font-size:16px">Kindle</p><p>22</p></div>
     <div class="ui-block-b"><p style="font-size:16px">iOS</p><p>2</p></div>
   <div class="ui-block-c"><p style="font-size:16px">Android</p><p>100</p></div>
  <div class="ui-block-d"><p style="font-size:16px">Linux</p><p>100</p></div>
    <div class="ui-block-e"><p style="font-size:16px">Windows</p><p>100</p></div>
   </div>
    </div>
</div>
<div id="toptweet" style="display:inline-block">20</div>
<div style="display:inline-block" id="toptweettime"></div>
    </div>
</asp:Content>
