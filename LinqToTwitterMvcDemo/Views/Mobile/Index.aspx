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
     <div data-role="collapsible">
    <h2><div style="font-size:22px">Following</div></h2>
         <div id="following">  
        </div>
    </div>
    <div data-role="collapsible" data-collapsed="false">
    <h2><div style="font-size:20px">My Tweets</div></h2>
    <div id="mytweets">  
        </div>
    </div>
    <div data-role="collapsible">
    <h2><div style="font-size:20px">Mentions</div></h2>
     <div id="mentions">  
        </div>
    </div>
</div>
</div>
<div id="calblock">
<div class="ui-body ui-body-a ui-corner-all">
<div class="ui-grid-a">
    <div class="ui-block-a"><div id="chosenDay">Today</div>
    <div>&nbsp;</div>
    <div id="eventsDay">event here</div>
    </div>
    <div class="ui-block-b">    
    <div class="ui-grid-f">
    <div class="ui-block-a"><div class="ui-body ui-body-d">M</div></div>
    <div class="ui-block-b"><div class="ui-body ui-body-d">T</div></div>
    <div class="ui-block-c"><div class="ui-body ui-body-d">W</div></div>
    <div class="ui-block-d"><div class="ui-body ui-body-d">T</div></div>
    <div class="ui-block-e"><div class="ui-body ui-body-d">F</div></div>
    <div class="ui-block-f"><div class="ui-body ui-body-d">S</div></div>
    <div class="ui-block-g"><div class="ui-body ui-body-d">S</div></div>
</div>
<div id="caldata"></div>
</div>
</div>

<div id="calendar_next5">
<div class="ui-grid-d">
    <div class="ui-block-a"><div class="ui-bar ui-bar-c" style="height:60px" id="next0">Block A</div></div>
    <div class="ui-block-b"><div class="ui-bar ui-bar-c" style="height:60px" id="next1">Block B</div></div>
    <div class="ui-block-c"><div class="ui-bar ui-bar-c" style="height:60px" id="next2">Block C</div></div>
    <div class="ui-block-d"><div class="ui-bar ui-bar-c" style="height:60px" id="next3">Block D</div></div>
    <div class="ui-block-e"><div class="ui-bar ui-bar-c" style="height:60px" id="next4">Block E</div></div>
    </div>
    </div>
<div id="weather_next5">
<div class="ui-grid-d">
    <div class="ui-block-a"><div class="ui-bar ui-bar-c" style="height:60px"><img src="http://icons.wxug.com/i/c/i/clear.gif" /></div></div>
    <div class="ui-block-b"><div class="ui-bar ui-bar-c" style="height:60px"><img src="http://icons.wxug.com/i/c/i/clear.gif" /></div></div>
    <div class="ui-block-c"><div class="ui-bar ui-bar-c" style="height:60px"><img src="http://icons.wxug.com/i/c/i/clear.gif" /></div></div>
    <div class="ui-block-d"><div class="ui-bar ui-bar-c" style="height:60px"><img src="http://icons.wxug.com/i/c/i/clear.gif" /></div></div>
    <div class="ui-block-e"><div class="ui-bar ui-bar-c" style="height:60px"><img src="http://icons.wxug.com/i/c/i/clear.gif" /></div></div>
</div></div>
</div>
</div>
</asp:Content>
