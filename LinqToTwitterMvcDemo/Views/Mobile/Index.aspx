﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Mobile.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Front
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">

<div data-role="header">

 <a href="#mypanel" class="ui-btn-left ui-btn ui-btn-b ui-btn-inline ui-mini ui-corner-all ui-btn-icon-notext ui-icon-gear">Setup</a>
<h1>FridgeDoor</h1>
<a id="lnkDialog" href="#popupNested" data-rel="popup" class="ui-btn-right ui-btn ui-btn-b ui-btn-inline ui-mini ui-corner-all ui-btn-icon-notext ui-icon-action" data-transition="pop" data-position-to="window">Choose</a>
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
<div style="font-size:30px">Get Started</div>
<div id="greeting"><p>Welcome to Fridge Door.</p>
<div class="ui-grid-a ui-responsive">    
    <div class="ui-block-a"><p>Use this site to render your Google calendar for today and the next five days, with weather for your location. </p>
    <div><img src="../../Content/images/pics/IMG_5005.JPG" /></div>
    <div id="wrapper"></div>
	<ul id="nav">
		<li id="prev" onclick="gallery.prev()">-</li>
		<li class="selected" onclick="gallery.goToPage(0)"></li>
		<li onclick="gallery.goToPage(1)"></li>
		<li onclick="gallery.goToPage(2)"></li>
		<li onclick="gallery.goToPage(3)"></li>
		<li onclick="gallery.goToPage(4)"></li>
		<li onclick="gallery.goToPage(5)"></li>
		<li id="next" onclick="gallery.next()">+</li>
	</ul>
    </div>
     <div class="ui-block-b"><p>Or, a Twitter powered display or sign: Tweets to your account registered to Fridge Door containing #banner will display in a large font for a specified time, or until dismissed.</p>
    <div><img src="../../Content/images/pics/IMG_5005.JPG" /></div>
     <p></p>
     </div>
     </div>
     </div>
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
   </div>
   <br />
</div>
<div id="blog" style="display:none">
<div class="ui-body ui-body-a ui-corner-all">
<div style="font-size:20px">Blog</div>
     <div data-role="collapsible-set" data-theme="a" data-content-theme="a" data-inset="false">
     <div id="BlogList"></div>
     <div data-role="collapsible">
        <h3>Section 3</h3>
    <p>I'm the collapsible content for section 3</p>
    </div>
     </div>
     
     </div>
     </div>
  <br />

<div id="tweetsfull" style="display:none">Loading Tweets ....
</div>

<div id="tweets" style="display:none">
<div class="ui-body ui-body-a ui-corner-all">
<div data-role="collapsible-set" data-theme="a" data-content-theme="a" data-inset="false">
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
  </div>
  <br />
  </div>
<div id="days2go" style="display:none">


<table>
      <tr><td class="td80"><div class="days_head" id="days_party">02</div></td>
      <td><div class="days_text">Days until Ursula's party</div></td>
      </tr>
     <tr><td class="td80"><div class="days_head" id="days_holiday">15</div></td>
      <td><div class="days_text">Days until snowboarding trip</div></td>
      </tr>
    </table>
</div>

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
<div id="stats" style="display:none">

</div>

<div id="kindletricks" style="display:none">
<div class="ui-body ui-body-a ui-corner-all">
<div style="font-size:30px">Kindle Tricks</div>
<p style="font-size:18px"><strong>Easy shortcut menu</strong></p>
<p>Just press the <strong>next page</strong> then <strong>previous page</strong> side buttons in quick succession to show the quick shortcut menu.</p>
<br />
<p style="font-size:18px"><strong>Zero typing setup</strong></p>
<p>To save typing your Twitter and Google credentials on the Kindle, do all the authentication on another device, then click the Kindle No Typing Setup button on the left and follow the instructions. </p>
<p></p>

</div>
</div>
<div id="toptweet" style="display:none">20</div>
<div style="display:none" id="toptweettime"></div>
    </div>

	
<script type="text/javascript">
    document.addEventListener('touchmove', function (e) { e.preventDefault(); }, false);

    var gallery,
	el,
	i,
	page,
	dots = document.querySelectorAll('#nav li'),
	slides = [
		{
		    img: '../../Content/images/pics/IMG_5005.JPG',
		    width: 300,
		    height: 213,
		    desc: 'Piazza del Duomo, Florence, Italy'
		},
		{
		    img: 'images/pic02.jpg',
		    width: 300,
		    height: 164,
		    desc: 'Tuscan Landscape'
		},
		{
		    img: 'images/pic03.jpg',
		    width: 300,
		    height: 213,
		    desc: 'Colosseo, Rome, Italy'
		},
		{
		    img: 'images/pic04.jpg',
		    width: 147,
		    height: 220,
		    desc: 'Somewhere near Chinatown, San Francisco'
		},
		{
		    img: 'images/pic05.jpg',
		    width: 300,
		    height: 213,
		    desc: 'Medieval guard tower, Asciano, Siena, Italy'
		},
		{
		    img: 'images/pic06.jpg',
		    width: 165,
		    height: 220,
		    desc: 'Leaning tower, Pisa, Italy'
		}
	];

    gallery = new SwipeView('#wrapper', { numberOfPages: slides.length });

    // Load initial data
    for (i = 0; i < 3; i++) {
        page = i == 0 ? slides.length - 1 : i - 1;
        el = document.createElement('img');
        el.className = 'loading';
        el.src = slides[page].img;
        el.width = slides[page].width;
        el.height = slides[page].height;
        el.onload = function () { this.className = ''; }
        gallery.masterPages[i].appendChild(el);

        el = document.createElement('span');
        el.innerHTML = slides[page].desc;
        gallery.masterPages[i].appendChild(el)
    }

    gallery.onFlip(function () {
        var el,
		upcoming,
		i;

        for (i = 0; i < 3; i++) {
            upcoming = gallery.masterPages[i].dataset.upcomingPageIndex;

            if (upcoming != gallery.masterPages[i].dataset.pageIndex) {
                el = gallery.masterPages[i].querySelector('img');
                el.className = 'loading';
                el.src = slides[upcoming].img;
                el.width = slides[upcoming].width;
                el.height = slides[upcoming].height;

                el = gallery.masterPages[i].querySelector('span');
                el.innerHTML = slides[upcoming].desc;
            }
        }

        document.querySelector('#nav .selected').className = '';
        dots[gallery.pageIndex + 1].className = 'selected';
    });

    gallery.onMoveOut(function () {
        gallery.masterPages[gallery.currentMasterPage].className = gallery.masterPages[gallery.currentMasterPage].className.replace(/(^|\s)swipeview-active(\s|$)/, '');
    });

    gallery.onMoveIn(function () {
        var className = gallery.masterPages[gallery.currentMasterPage].className;
        /(^|\s)swipeview-active(\s|$)/.test(className) || (gallery.masterPages[gallery.currentMasterPage].className = !className ? 'swipeview-active' : className + ' swipeview-active');
    });

</script>

</asp:Content>
