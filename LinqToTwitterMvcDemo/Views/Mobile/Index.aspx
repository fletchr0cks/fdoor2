<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Mobile.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Front
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">
<div data-role="header">
<a href="#mypanel" class="ui-btn ui-icon-bars ui-btn-icon-notext ui-corner-all">No text</a>
<h1>Fridge Door</h1>
<a href="#" class="ui-btn ui-icon-gear ui-btn-icon-notext ui-corner-all">No text</a>
</div>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div id="tweets">
<div data-role="collapsible-set" data-theme="a" data-content-theme="b">
    <div data-role="collapsible" id="tweets_home">
    <h2>Following</h2>
        <ul data-role="listview" data-filter="true" data-filter-theme="a" data-divider-theme="b">
            <li><a href="index.html">Adam Kinkaid</a></li>
            <li><a href="index.html">Alex Wickerham</a></li>
            <li><a href="index.html">Avery Johnson</a></li>
            <li><a href="index.html">Bob Cabot</a></li>
            <li><a href="index.html">Caleb Booth</a></li>
        </ul>
    </div>
    <div data-role="collapsible" data-collapsed="false">
    <h2>My Tweets <span data-count-theme="b" class="ui-li-count">12</span></h2>
        <ul data-role="listview" data-theme="a" data-divider-theme="a" data-count-theme="b">
            <li class="ui-btn ui-icon-camera ui-btn-icon-left">
    <p><strong style="padding-left:20px">6:24PM</strong> Hey Stephen, if you're available at 10am tomorrow, we've got a meeting with the jQuery team.</p>
   </li>
   <li data-role="list-divider">More<span class="ui-li-count">2</span></li>
        </ul>
         
    </div>
    <div data-role="collapsible">
    <h2>Mentions</h2>
        <ul data-role="listview" data-split-icon="gear" data-split-theme="a">
            <li><a href="index.html">
                <img src="../_assets/img/album-bb.jpg">
                <h3>Broken Bells</h3>
            <p>Broken Bells</p>
                </a><a href="lists-split-purchase.html" data-rel="dialog" data-transition="slideup">Purchase album
            </a></li>
            <li><a href="index.html">
                <img src="../_assets/img/album-hc.jpg">
                <h3>Warning</h3>
            <p>Hot Chip</p>
            </a><a href="lists-split-purchase.html" data-rel="dialog" data-transition="slideup">Purchase album
            </a></li>
            <li><a href="index.html">
                <img src="../_assets/img/album-p.jpg">
                <h3>Wolfgang Amadeus Phoenix</h3>
            <p>Phoenix</p>
                </a><a href="lists-split-purchase.html" data-rel="dialog" data-transition="slideup">Purchase album
            </a></li>
        </ul>
    </div>
</div>
</div>
<div id="calendar_today">
<div class="ui-body ui-body-a ui-corner-all">
<div class="ui-grid-a">
    <div class="ui-block-a"><div class="ui-bar ui-bar-c" style="height:60px">Today</div></div>
    <div class="ui-block-b">
    
    <div class="ui-grid-f">
    <div class="ui-block-a"><div class="ui-body ui-body-d">Monday</div></div>
    <div class="ui-block-b"><div class="ui-body ui-body-d">Tuesday</div></div>
    <div class="ui-block-c"><div class="ui-body ui-body-d">Wednesday</div></div>
    <div class="ui-block-d"><div class="ui-body ui-body-d">Thursday</div></div>
    <div class="ui-block-e"><div class="ui-body ui-body-d">Friday</div></div>
    <div class="ui-block-f"><div class="ui-body ui-body-d">Saturday</div></div>
    <div class="ui-block-g"><div class="ui-body ui-body-d">Sunday</div></div>
</div>
<div id="caldata"></div>
   
    
    </div>
</div>

<div id="calendar_next5">
<div class="ui-grid-d">
    <div class="ui-block-a"><div class="ui-bar ui-bar-c" style="height:60px">Block A</div></div>
    <div class="ui-block-b"><div class="ui-bar ui-bar-c" style="height:60px">Block B</div></div>
    <div class="ui-block-c"><div class="ui-bar ui-bar-c" style="height:60px">Block C</div></div>
    <div class="ui-block-d"><div class="ui-bar ui-bar-c" style="height:60px">Block D</div></div>
    <div class="ui-block-e"><div class="ui-bar ui-bar-c" style="height:60px">Block E</div></div>
    <div class="ui-block-a"><div class="ui-bar ui-bar-c" style="height:60px">Block A</div></div>
    <div class="ui-block-b"><div class="ui-bar ui-bar-c" style="height:60px">Block B</div></div>
    <div class="ui-block-c"><div class="ui-bar ui-bar-c" style="height:60px">Block C</div></div>
    <div class="ui-block-d"><div class="ui-bar ui-bar-c" style="height:60px">Block D</div></div>
    <div class="ui-block-e"><div class="ui-bar ui-bar-c" style="height:60px">Block E</div></div>
</div></div>
</div>
</div>
</asp:Content>
