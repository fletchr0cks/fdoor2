<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Mobile.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Front
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">

<div data-role="header" data-theme="a">
<a href="#mypanel" class="ui-btn ui-icon-gear ui-btn-icon-notext ui-corner-all">Setup</a>
<h1><img id="headerIMG" src="../../Content/images/logo_header4.png" /></h1>
<a id="lnkDialog" href="#popupNested" data-rel="popup" class="ui-btn ui-icon-refresh ui-btn-icon-notext ui-corner-all" data-transition="pop" data-position-to="window">Refresh</a>
</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div id="mainframe">
<div class="closeBanner" id="banner_header">
</div>
<div class="bigbanner" id="banner_area"></div>
<div class="covercss" id="covertop"></div>
<div id="welcome" style="display:none">
<div class="ui-body ui-body-a ui-corner-all">
<div id="greeting">
<div class="ui-grid-a ui-responsive">    
    <div class="ui-block-a" style="width:75%">
    <div style="font-size:30px">Welcome.</div>
    <p>This site is designed to turn an unused Kindle, iPad or Android tablet into an information and messaging centre that shows:</p>
    <ul>
<li>Your Google Calendar for today and the next five days.</li>
<li>Twitter content - either your Tweets, Tweets from users you follow or mentions.</li>
<li>Weather for any location.</li>
</ul>
  
    </div>
    <div class="ui-block-b" style="width:25%" ><img id="OKFlogoIMG" src="../../Content/images/logo_large.png" /></div>
</div>
<p>Once authenticated, OK Fridge can display Tweets sent to public or even private Twitter accounts making it ideal for a secure household messaging system. If all members of the household use the same Twitter ID, including the device running OK Fridge everyone can see each other’s messages. There’s also a special hastag to display parts of your messages in a larger font size on the OK Fridge device. See the Twitter-powered section below.
</p>
<div style="height:20px"></div>
<div class="ui-body ui-body-a ui-corner-all">
<p>OK Fridge In Action</p>
<div data-role="collapsible-set" data-theme="a" data-content-theme="a">
    <div data-role="collapsible">
        <h3>Google Calendar</h3>
  <div><img id="smallIMG" src="../../Content/images/ss_cal1.gif" />
  <img id="smallIMG" src="../../Content/images/ss_days2.gif" /></div>
    </div>
    <div data-role="collapsible">
        <h3>Twitter</h3>
  <div><img id="smallIMG" src="../../Content/images/ss_t1.gif" />
      <img id="smallIMG" src="../../Content/images/ss_t2.gif" /></div>
    </div>
   <div data-role="collapsible">
        <h3>Twitter-powered Banners</h3>
  <div> <img id="smallIMG" src="../../Content/images/bann_hb.gif" />
      <img id="smallIMG" src="../../Content/images/bann_hh.gif" /></div>
    </div>
</div>
</div>
 <p> <%= ViewData["token"]%> </p>   
    
     </div>
<div style="font-size:30px">Get Started</div>
<p>Authenticate your Twitter and Google accounts below, and add your location, then use the menu on the top left to decide what to show.</p>
<div class="ui-grid-b ui-responsive">    
    <div class="ui-block-a"><div style="font-size:20px">Twitter</div>
     <%= ViewData["twitter"]%> 
     <div class="divider" id="divider1"><hr /></div>
    </div>
     <div class="ui-block-b"><div style="font-size:20px">Google</div>
      <%= ViewData["google"]%>
     <div class="divider" id="divider2" style="display:none"><hr /></div>
     </div>
    <div class="ui-block-c"><div style="font-size:20px">Location</div>
     <div id="setLocation"><%= ViewData["location"]%></div>
     
    </div>
   </div>
   <div id="townmsg"></div><div id="townlist"></div>
   <div style="font-size:30px">Kindle Setup</div>
<p style="font-size:18px"><strong>Zero typing setup</strong></p>
<p>To save typing your Twitter and Google credentials on the Kindle, do all the authentication on another device, then send the link below to your Kindle as a text attachment.</p>
<p></p>
<div id="zeroURL"></div>
<br />
<p style="font-size:18px"><strong>Easy shortcut menu</strong></p>
<p>Activate the <strong>Page Down/Up Shortcut</strong> checkbox in the Setup menu on the left. When viewing in the Kindle, just press the <strong>next page</strong> then <strong>previous page</strong> side buttons in quick succession to show the quick shortcut menu.</p>
   </div>
   <br />
</div>

<div id="tweetsfull" style="display:none">Loading Tweets ....</div>
<br />
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
        <h3>OK Fridge</h3>
  <div id="okf"></div>
</div>
</div>
  <br />
  </div>
<div id="days2go" style="display:none">
</div>
<p></p>
<div id="calblock" style="display:none">
<div class="ui-body ui-body-a ui-corner-all">
<div class="ui-grid-a">
    <div class="ui-block-a"><div style="font-size:20px" id="chosenDay">Today</div>
    
    <div id="eventsDay"></div>
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
<br />
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

<div id="blog" style="display:none">
<div class="ui-body ui-body-a ui-corner-all">
<div style="font-size:20px">What's happening at OK Fridge</div>
     <div data-role="collapsible-set" data-theme="a" data-content-theme="a" data-inset="false">
     <div id="BlogList"></div>
     </div>
     </div>
     </div>

<br />
<div id="stats" style="display:none">
</div>
<div id="map" style="display:none">
    <div id="map_msg" class="ui-bar ui-bar-b"></div>
		<div id="map_overlay" style="z-index:5000;position:absolute;display:none;background-color:Gray;opacity:0.8;height:300px"><h4 style="text-align:center;padding-top:100px">Loading sites....</h4></div>
		<div id="map_canvas" style="height:500px;"></div>
       <div id="place_name"></div>
       <div id="place_comments"></div>
       <a href="#" class="ui-btn ui-btn-inline ui-icon-delete ui-btn-icon-right" onClick="closeMap()">Close Map</a>
       </div>

<div id="toptweet" style="display:none">20</div>
<div style="display:none" id="toptweettime"></div>
    </div>
</asp:Content>
