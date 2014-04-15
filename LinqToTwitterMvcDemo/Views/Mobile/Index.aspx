<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Mobile.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Front
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">

<div data-role="header">

 <a href="#mypanel" class="ui-btn-left ui-btn ui-btn-b ui-btn-inline ui-mini ui-corner-all ui-btn-icon-notext ui-icon-gear">Setup</a>
<h1><div id="headtext">Fridge Door</div></h1>
<a id="lnkDialog" href="#popupNested" data-rel="popup" class="ui-btn-right ui-btn ui-btn-b ui-btn-inline ui-mini ui-corner-all ui-btn-icon-notext ui-icon-action" data-transition="pop" data-position-to="window">Choose</a>
</div>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div id="mainframe">
<div class="closeBanner" id="banner_header">
</div>
<div class="bigbanner" id="banner_area"></div>
<div class="covercss" id="covertop">cover</div>
<div id="welcome" style="display:none">
<div class="ui-body ui-body-a ui-corner-all">
<div style="font-size:30px">Get Started</div>
<p>Welcome to Fridge Door.</p>
<div class="ui-grid-a ui-responsive">    
    <div class="ui-block-a"><p>Use this site to render your Google calendar for today and the next five days, with weather for your location. </p>
    <p><img src="../../Content/images/pics/IMG_5005.JPG" /></p>
    </div>
     <div class="ui-block-b"><p>Or, a Twitter powered display or sign: Tweets to your account registered to Fridge Door containing #banner will display in a large font for a specified time, or until dismissed.</p>
    <p><img src="../../Content/images/pics/IMG_5005.JPG" /></p>
     <p></p>
     </div>
     </div>

<p>Authenticate your Twitter and Google accounts below, and add your location, then use the menu on the top left to decide what to show.</p>
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
<div id="blog">
<div class="ui-body ui-body-a ui-corner-all">
<div class="ui-grid-a ui-responsive">    
    <div class="ui-block-a"><div style="font-size:20px">Blog</div>  
    </div>
     <div class="ui-block-b"><div style="font-size:10px">Last comment: </div>  
     </div>
     </div>
<div data-role="collapsible-set" data-theme="a" data-content-theme="a" data-inset="false">
    <div data-role="collapsible">
        <h3>Section 1 <span class="ui-li-count">12</span></h3>
    <ul data-role="listview">
    <li><a href="#">Acura</a></li>
    <li><a href="#">Audi</a></li>
    <li><a href="#">BMW</a></li>
    <li><a href="#">Cadillac</a></li>
    <li><a href="#">Ferrari</a></li>
</ul>
    </div>
    <div data-role="collapsible">
        <h3>Section 2</h3>
    <p>I'm the collapsible content for section 2</p>
    </div>
    <div data-role="collapsible">
        <h3>Section 3</h3>
    <p>I'm the collapsible content for section 3</p>
    </div>
</div>
  </div>
</div>
<div class="ui-body ui-body-a ui-corner-all">
<div data-role="collapsible-set" data-theme="a" data-content-theme="a" data-inset="false">
    <div data-role="collapsible">
        <h3>My Tweets<span class="ui-li-count">12</span></h3>
  <div id="mytweets"></div>
    </div>
    <div data-role="collapsible">
        <h3>Following<span class="ui-li-count">12</span></h3>
  <div id="following"></div>
    </div>
   <div style="display:none" data-role="collapsible">
        <h3>Mentions<span class="ui-li-count">12</span></h3>
  <div id="mentions"></div>
    </div>
</div>
  </div>
<div id="tweets" style="display:none">
<div data-role="collapsible">
    <h2>Tweets</h2>
        <ul data-role="listview" data-theme="a">
            <li data-role="list-divider">Following<span class="ui-li-count"></span></li>
            <li><div id="followingo"></div></li>
            <li data-role="list-divider">My Tweets<span class="ui-li-count"></span></li>
            <li><div id="mytweetso"></div></li>
             <li data-role="list-divider">Mentions<span class="ui-li-count"></span></li>
            <li><div id="mentionso"></div></li>
            <li data-role="list-divider">@FridgeDoor<span class="ui-li-count">Follow</span></li>
            <li><div id="fridgedoor">
               </div></li>
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
<div class="ui-body ui-body-a ui-corner-all">
<div style="font-size:20px" id="weatherday">Today</div>
<div id="weatherblocdata">
</div>
<div id="calendarbloc_next5">
</div>
<div id="weatherbloc_next5">
</div>
</div>
</div>
<br />
<div id="agentsID" style="display:none">
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

<div id="kindletricks" style="display:none">
<div class="ui-body ui-body-a ui-corner-all">
<div style="font-size:30px">Kindle Tricks</div>
<p style="font-size:18px"><strong>Easy shortcut menu</strong></p>
<p>Just press the <strong>next page</strong> then <strong>previous page</strong> side buttons in quick succession to show the quick shortcut menu.</p>
    </div>
</div>
<div id="toptweet" style="display:inline-block">20</div>
<div style="display:inline-block" id="toptweettime"></div>
    </div>
</asp:Content>
