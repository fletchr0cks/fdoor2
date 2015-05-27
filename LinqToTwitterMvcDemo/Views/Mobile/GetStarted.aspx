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
<div style="height:20px"></div>
<div class="ui-grid-a ui-responsive">    
<div class="ui-block-a">
<div class="ui-body ui-body-a ui-corner-all">
<h2>Add a Device</h2>
<form>
<ul data-role="listview" data-inset="true">
<li class="ui-field-contain">
<input type="text" name="text-basic" id="text-basic" value="Device name here, i.e. Kitchen or Bob" />
</li>
<li class="ui-field-contain">
<fieldset data-role="controlgroup" data-mini="true">
<input type="radio" name="radio-choice-m" id="radio-choice-c" value="0">
<label for="radio-choice-c">No Messaging</label>
<input type="radio" name="radio-choice-m" id="radio-choice-d" value="1" checked="checked">
<label for="radio-choice-d">View Messages</label>
<input type="radio" name="radio-choice-m" id="radio-choice-e" value="2">
<label for="radio-choice-e">View and Send</label>
<input type="radio" name="radio-choice-m" id="radio-choice-f" value="3">
<label for="radio-choice-f">Advanced Messaging (All Twitter message types)</label>
</fieldset>
</li>
<li class="ui-field-contain">
<fieldset data-role="controlgroup" data-mini="true">
<input type="radio" name="radio-choice-e" id="radio1" value="0">
<label for="radio1">No Events</label>
<input type="radio" name="radio-choice-e" id="radio2" value="1" checked="checked">
<label for="radio2">View Events</label>
</fieldset>
</li>
<li class="ui-field-contain">
<fieldset data-role="controlgroup" data-mini="true">
<input type="radio" name="radio-choice-w" id="radio3" value="0">
<label for="radio3">No Weather</label>
<input type="radio" name="radio-choice-w" id="radio4" value="1" checked="checked">
<label for="radio4">View Weather</label>
</fieldset>
</li>
<li class="ui-field-contain">
<a href="#" class="ui-btn ui-btn-c" onclick="addNewuser()">Submit</a>
</li>
</ul>
</form>
</div>
</div>
<div class="ui-block-b">
<div class="ui-corner-all custom-corners">
<div class="ui-body ui-body-a ui-corner-all">
<h2>Saved Devices</h2>
<div id="deviceView"></div>
</div>
</div>
</div>
</div>
</div>
</div>




<div id="zeroURL"></div>
<div id="cookies"></div>

</asp:Content>
