<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Mobile.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	OK fridge
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">

<div data-role="header" data-theme="b">
<a href="#mypanel" class="ui-btn ui-icon-gear ui-btn-icon-notext ui-corner-all">Setup</a>
<h1><img id="headerIMG" src="../../Content/images/logo_header6.png" /></h1>
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
<div style="font-size:30px">Welcome...</div>
<div class="ui-grid-a ui-responsive">    
    <div class="ui-block-a" style="width:75%">
     <p>This site is designed to turn an unused Kindle, iPad or Android tablet into an information and messaging centre that shows:</p>
   
     <ul>
<li>Your Google calendar for today and the next five days.</li>
<li>Number of days countdown to an event in your Google calendar.</li>
<li>Twitter content - either your Tweets, Tweets from users you follow or mentions.</li>
<li>Weather for any location.</li>
</ul>
  
    </div>
    <div class="ui-block-b" style="width:25%" ><img id="OKFlogoIMG" src="../../Content/images/logo_large2.png" /></div>
</div>
<p>Once authenticated, OK fridge can display Tweets sent to public or even private Twitter accounts making it ideal for a secure household messaging system. If all members of the household use the same Twitter ID, including the device running OK fridge everyone can see each other’s messages. There’s also a special hastag to display parts of your messages in a larger font size on the OK fridge device. See the Twitter-powered Banners section below.
</p>
<div style="height:20px"></div>
<div class="ui-body ui-body-a ui-corner-all">
<div style="font-size:30px">OK fridge in Action</div>
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
      <div>Include #okbnnr in your tweet and all the text after the hashtag will display as a banner.</div>
      <div>Add hours or minutes and you can choose for how long the banner is displayed:</div>
      <p></p>
      <div>#okbnnr 30m &lt;your banner&gt;</div>
      <div>#okbnnr 2h &lt;your banner&gt;</div>
    </div>
</div>
</div>
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
   <br />
   <br />
<div style="font-size:30px">Kindle Setup</div>
<p style="font-size:18px"><strong>Zero typing setup</strong></p>
<p>To save typing your Twitter and Google credentials on the Kindle, do all the authentication on another device, then send the link below to your Kindle as a text attachment.</p>
<p></p>
<div id="zeroURL"></div>
<br />
<p style="font-size:18px"><strong>Easy shortcut menu</strong></p>
<p>Activate the <strong>Page Down/Up Shortcut</strong> checkbox in the Setup menu on the left. When viewing in the Kindle, just press the <strong>next page</strong> then <strong>previous page</strong> side buttons in quick succession to show the quick shortcut menu.</p>
   </div>
</div>

<div id="tweetsfull" style="display:none">Loading Tweets ....</div>
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
  </div>
        <div style="font-family:Montserrat,'Arial Black','Arial-BoldMT','Arial Bold',Arial,Helvetica,sans-serif;width:100%;text-align: center;">
        <a href="https://time.is/North_Berwick,_United_Kingdom" id="time_is_link" rel="nofollow" style="font-size:36px"></a>
<span id="North_Berwick__United_Kingdom_z716" style="font-size:120px;text-align: center;"></span>
<script src="//widget.time.is/en_gb.js"></script>
<script>
    time_is_widget.init({ North_Berwick__United_Kingdom_z716: { time_format: "12hours:minutesAMPM" } });
</script>

    </div>
<div id="days2go" style="display:none">
</div>
<div id="calblock" style="display:none">
<div class="ui-body ui-body-a ui-corner-all">
<div class="ui-grid-a">
    <div class="ui-block-a"><div style="font-size:25px" id="chosenDay">Today</div>
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
  
<a class="weatherwidget-io" href="https://forecast7.com/en/56d06n2d72/north-berwick/" data-icons="Climacons Animated" data-theme="dark" > </a>
<script>
    !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = 'https://weatherwidget.io/js/widget.min.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'weatherwidget-io-js');
</script>
    <br />
<div
data-windywidget="forecast"
data-spotid="425776"
data-appid="4934288d2f634cf426edd0cb36df5480">
</div>
<script async="true" data-cfasync="false" type="text/javascript" src="https://windy.app/widget/windy_forecast_async.js"></script>
    <iframe src="https://calendar.google.com/calendar/embed?height=600&amp;wkst=2&amp;bgcolor=%23ffffff&amp;ctz=Europe%2FLondon&amp;src=bmIxOWpmbGV0Y2hlckBlZHVidXp6Lm9yZw&amp;src=YWRkcmVzc2Jvb2sjY29udGFjdHNAZ3JvdXAudi5jYWxlbmRhci5nb29nbGUuY29t&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tZjZkOWIzZTJAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tN2NkZWI0ZjhAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tNjZkNjA4MDZAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tZDk0MDZkMThAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tMWJmOGFhMjlAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tZDVhMTlkYjhAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tNGViYWY4NGZAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tOGU1MDMzZjhAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tNTNmODkxNWFAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tNzAzNGIwNzhAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;src=ZW4udWsjaG9saWRheUBncm91cC52LmNhbGVuZGFyLmdvb2dsZS5jb20&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tMjQ4ZDc3M2FAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tYjMwYjVmNTdAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tZTZmNjAyYmZAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tZTMyMzg1NzJAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tZTc0NjI3MTVAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tZThhZDFlMDlAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tMjFiZGFlYjdAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tZDEyZGI3OThAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tNzBjZWE0Y2NAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tNzE5MTk2ZmZAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tYjU2OTdhNmVAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tNWQ0YTM1ZDVAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;src=ZWR1YnV6ei5vcmdfY2xhc3Nyb29tMTVmNDJlODhAZ3JvdXAuY2FsZW5kYXIuZ29vZ2xlLmNvbQ&amp;color=%23039BE5&amp;color=%2333B679&amp;color=%23174ea6&amp;color=%23202124&amp;color=%230047a8&amp;color=%23202124&amp;color=%23b80672&amp;color=%23c26401&amp;color=%237627bb&amp;color=%233e2723&amp;color=%230047a8&amp;color=%23202124&amp;color=%230B8043&amp;color=%23174ea6&amp;color=%230047a8&amp;color=%237627bb&amp;color=%23202124&amp;color=%230047a8&amp;color=%23007b83&amp;color=%23c26401&amp;color=%230047a8&amp;color=%23202124&amp;color=%23137333&amp;color=%230047a8&amp;color=%230047a8&amp;color=%23c26401&amp;title=Jacob&amp;showPrint=0" style="border:solid 1px #777" width="800" height="600" frameborder="0" scrolling="no"></iframe>
<div id="map_spacer" style="display:none"></div>
<div id="map" style="display:none">
    <div id="map_msg" class="ui-bar ui-bar-b"></div>
		<div id="map_overlay" style="z-index:5000;position:absolute;display:none;background-color:Gray;opacity:0.8;height:300px"><h4 style="text-align:center;padding-top:100px">Loading sites....</h4></div>
		<div id="map_canvas" style="height:380px;"></div>
       <div id="place_name" class="ui-bar ui-bar-b"></div>
       <div id="place_comments" class="ui-bar ui-bar-b"></div>
       <a href="#" class="ui-btn ui-btn-inline ui-icon-delete ui-btn-icon-right" onClick="closeMap()">Close Map</a>
       </div>

<div id="toptweet" style="display:none">20</div>
<div style="display:none" id="toptweettime"></div>
    </div>
</asp:Content>
