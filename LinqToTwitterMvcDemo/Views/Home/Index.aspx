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
   
</asp:Content>
