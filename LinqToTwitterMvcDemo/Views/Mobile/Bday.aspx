﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0">
	<meta name="apple-mobile-web-app-capable" content="yes">
	<meta name="apple-mobile-web-app-status-bar-style" content="black">
	<title>SwipeView</title>
	<link href="../../Content/style.css" rel="stylesheet" type="text/css">
	<script type="text/javascript" src="../../Scripts/swipeview.js"></script>
</head>

<body>
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
	
<script type="text/javascript">
    document.addEventListener('touchmove', function (e) { e.preventDefault(); }, false);

    var gallery,
	el,
	i,
	page,
	dots = document.querySelectorAll('#nav li'),
	slides = [
		{
		    img: 'images/pic01.jpg',
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
</body>
</html>
