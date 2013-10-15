<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<LinqToTwitterMvcDemo.Models.TweetViewModel>>" %>

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
    <td style="width:100px" class="term2">
    <% if (tweet.dayssince(Convert.ToDateTime(tweet.TimeStamp)) < 1)
       { %>
      <%: Convert.ToDateTime(tweet.TimeStamp).GetDateTimeFormats('t').First() %>:
       <% }
       else
       { %>
        <%: Convert.ToDateTime(tweet.TimeStamp).GetDateTimeFormats('d').First() %>:
       <% } %>
      
    </td>
    <td class="term1"><%: tweet.Tweet %></td>    
    </tr>
       
    <%    
    }
%>
</table>
<div class="thin"></div>
</div>

  <div class="bottom">
  <div id="towns" class="term1" style="display:none">
  Set location: <input type="text" id="town" value="North Berwick" />
  <div onclick="setTown()" style="cursor:pointer;display:inline">Submit</div>
  </div>
      <table>
      <tr><td colspan="2" style="width:400px"> <div id="datebanner" class="banner"></div>
      </td>
      </tr>
    <tr>
    <td style="width:400px"><div id="suminj"></div>
    </td>
    <td><div class="day" id="weather"></div>
    </td>
    </tr>  
    <tr>
    <td colspan="2"> <div class="buttons" id="btns"></div>
    </td></tr>  
   
    </table>
    </div>

</asp:Content>
