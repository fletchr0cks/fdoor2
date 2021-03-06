﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<LinqToTwitterMvcDemo.Models.TweetViewModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Fridge Door
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">

</script>
<div class="top">
   
    <table>
<%
    foreach (var tweet in Model)
    {
      
    %>
     <tr>
    <td style="width:100px;vertical-align:text-top" class="term2">
    <% if (tweet.dayssince(Convert.ToDateTime(tweet.TimeStamp)) < 1)
        { %>
      <%: Convert.ToDateTime(tweet.TimeStamp).GetDateTimeFormats('t').First() %>:
       <% }
       else
       { %>
        <%: Convert.ToDateTime(tweet.TimeStamp).GetDateTimeFormats('d').First() %>:
       <% } %>
      
    </td>
     <td><% if (tweet.MediaUrl.Length > 3)
            {
            %><div onclick="ClickLink('<%=tweet.MediaUrl %>')" style="cursor:pointer"><img src="../../Content/updown.png" /></div><%
            } %></td> 
    <td class="term1"><%: tweet.Tweet %></td>   
   
    </tr>
       
    <%    
    }
%>
</table>




<div class="thick"></div>
</div>
<%
   
    var toptweet = Model.First();
    
    //foreach (var tweet in Model)
    
        if (toptweet.BannerText.Length > 3)
            
        {
            
            var banner = toptweet.BannerText; 
%>
<script type="text/javascript">
    timerStart(10000);
</script>
<div id="bann1" class="closeBanner" onclick="closeBanner()">Close</div>
<div id="bann2" class="bigbanner"><%:banner %></div>
<%
            } %>
  <div id="cal" class="bottom">
  <div id="towns" class="term1" style="display:none">
  Set location: <input type="text" id="town" value="North Berwick" />
  <div onclick="setTown()" style="cursor:pointer;display:inline">Submit</div>
  </div>
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
     </div>
    
<div onclick="filldiv()"><iframe id="iframe1" style="display:none" ></iframe></div>
   <div id="adiv">
   </div>
   
</asp:Content>
