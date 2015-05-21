<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MobileC.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	GetStarted
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">
 <%= Html.ActionLink("Back", "IndexC", "Mobile")%>
<h1><img id="headerIMG" src="../../Content/images/logo_header6.png" /></h1>

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


<div class="ui-body ui-body-a ui-corner-all">
<div id="greeting">
<div style="font-size:30px">Welcome.</div>
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

</div>
      

</asp:Content>
