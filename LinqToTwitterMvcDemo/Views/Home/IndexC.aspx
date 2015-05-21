<%@ Page Title="Index1" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Fridge Door
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">

</script>
<div class="closeBanner" id="banner_header"></div>
<div class="bigbanner" id="banner_area"></div>
<div class="top">
<div id="tweets"></div>
<p><a href="#zerotype" data-rel="popup" class="ui-btn ui-btn-b ui-mini" data-transition="pop" data-position-to="window">Kindle No Typing Setup</a>
</p>
<div id="days2go">
<table>
      <tr><td class="td80"><div class="days_head" id="days_party">02</div></td>
      <td><div class="days_text">Days until Ursula's party</div></td>
      </tr>
     <tr><td class="td80"><div class="days_head" id="days_holiday">02</div></td>
      <td><div class="days_text">Days until skiing holiday</div></td>
      </tr>
    </table>
</div>
 <div class="thick"></div>
   </div>
    <div id="cal" class="bottom">
       <table>
      <tr><td colspan="2"><div id="datebanner" class="banner"></div>
      </td>
      </tr>
    <tr>
    <td class="td400"><div id="suminj"></div>
    </td>
    <td><div class="day" id="weather"></div>
    </td>
    </tr>  
    <tr>
    <td colspan="2"> <div class="buttons" id="btns"></div>
    </td></tr>  
    </table>
    <div class="thin"></div>
    <div id="suminjmini"></div>
    <div id="sumweathermini"></div>
    <div class="thin"></div>
    <div class="footer" onclick="goSetup()">Setup</div>
    <div id="toptweet" style="display:inline-block">20</div>
<div style="display:inline-block" id="toptweettime"></div>
     </div>
    
<div onclick="filldiv()"><iframe id="iframe1" style="display:none" ></iframe></div>
   <div id="adiv">
   </div>
<!-- /popup -->
<div data-role="popup" id="zerotype" data-theme="b">
  <div class="ui-body ui-body-b">
<p>Copy and paste this link into a text file. Use the Send to Kindle feature in Amazon to send that file to your Kindle. When it appears, just click on the link.</p>
 <p></p>
 <div id="wrapper"></div>
<div id="greeting"><p>Welcome to Fridge Door.</p>
<div class="ui-grid-a ui-responsive">    
    <div class="ui-block-a"><p>Use this site to render your Google calendar for today and the next five days, with weather for your location. </p>
    	
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
    </div>
    </div>
 <p><div id="zeroURL"></div></p>
 <div id="allcookies"></div>
    </div>
</div><!-- /popup -->

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
