<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Mobile.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Front
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">
<h4>Header</h4>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div id="tweets">
<a href="#mypanel">panel</a>
<ul data-role="listview" data-inset="true" data-theme="a" data-divider-theme="b">
    <li data-role="list-divider">FletcherFridge Tweets<span class="ui-li-count">2</span></li>
    <li data-icon="delete"><a href="index.html">
    <p><strong>6:24PM</strong> Hey Stephen, if you're available at 10am tomorrow, we've got a meeting with the jQuery team.</p>
    </a></li>
    <li data-icon="delete"><a href="index.html">
    <p><strong>6:24PM</strong> Hey Stephen, if you're available at 10am tomorrow, we've got a meeting with the jQuery team.</p>
    </a></li><li data-icon="delete"><a href="index.html">
    <p><strong>6:24PM</strong> Hey Stephen, if you're available at 10am tomorrow, we've got a meeting with the jQuery team.</p>
    </a></li>
    <li data-role="list-divider" id="mentions">Mentions<span class="ui-li-count">1</span></li>
   <li data-icon="delete"><a href="index.html">
    <p><strong>6:24PM</strong> Hey Stephen, if you're available at 10am tomorrow, we've got a meeting with the jQuery team.</p>
    </a></li>
    
</ul>

</div>
<div id="calendar_today">
<div class="ui-grid-a">
    <div class="ui-block-a"><div class="ui-bar ui-bar-a" style="height:60px">Today</div></div>
    <div class="ui-block-b"><div class="ui-bar ui-bar-a" style="height:60px">Weather</div></div>
</div>
</div>
<div id="calendar_next5">
<div class="ui-grid-d">
    <div class="ui-block-a"><div class="ui-bar ui-bar-a" style="height:60px">Block A</div></div>
    <div class="ui-block-b"><div class="ui-bar ui-bar-a" style="height:60px">Block B</div></div>
    <div class="ui-block-c"><div class="ui-bar ui-bar-a" style="height:60px">Block C</div></div>
    <div class="ui-block-d"><div class="ui-bar ui-bar-a" style="height:60px">Block D</div></div>
    <div class="ui-block-e"><div class="ui-bar ui-bar-a" style="height:60px">Block E</div></div>
    <div class="ui-block-a"><div class="ui-bar ui-bar-a" style="height:60px">Block A</div></div>
    <div class="ui-block-b"><div class="ui-bar ui-bar-a" style="height:60px">Block B</div></div>
    <div class="ui-block-c"><div class="ui-bar ui-bar-a" style="height:60px">Block C</div></div>
    <div class="ui-block-d"><div class="ui-bar ui-bar-a" style="height:60px">Block D</div></div>
    <div class="ui-block-e"><div class="ui-bar ui-bar-a" style="height:60px">Block E</div></div>
</div></div>

</asp:Content>
