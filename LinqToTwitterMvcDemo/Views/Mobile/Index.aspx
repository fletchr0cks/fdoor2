<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Mobile.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Front
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<ul data-role="listview" data-inset="true">
    <li data-role="list-divider">FletcherFridge Tweets<span class="ui-li-count">2</span></li>
    <li data-icon="delete"><a href="index.html">
    <p>Hey Stephen, if you're available at 10am tomorrow, we've got a meeting with the jQuery team.</p>
        <p class="ui-li-aside"><strong>6:24</strong>PM</p>
    </a></li>
    <li><a href="index.html">
    <h2>jQuery Team</h2>
    <p><strong>Boston Conference Planning</strong></p>
    <p>In preparation for the upcoming conference in Boston, we need to start gathering a list of sponsors and speakers.</p>
        <p class="ui-li-aside"><strong>9:18</strong>AM</p>
    </a></li>
    <li data-role="list-divider">Mentions<span class="ui-li-count">1</span></li>
    <li><a href="index.html">
    <h2>Avery Walker</h2>
    <p><strong>Re: Dinner Tonight</strong></p>
    <p>Sure, let's plan on meeting at Highland Kitchen at 8:00 tonight. Can't wait!</p>
        <p class="ui-li-aside"><strong>4:48</strong>PM</p>
    </a></li>
</ul>
 <ul data-role="listview" data-inset="true" data-theme="c" data-dividertheme="b">
    <li><%=Html.ActionLink("Weather", "Weather", "Home") %></li>
</ul>
</asp:Content>
