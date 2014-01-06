<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Choose.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Setup
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">

</script>
    <h2>Setup</h2>
    <table>
    <tr>
    <td>
   <div class="term3">Twitter Feed:</div>
    </td>
    <td style="height:60px">
     <%= ViewData["twitter"]%>
    </td>
    </tr>
     <tr>
    <td>
   <div class="term3">Google Calendar:</div>
    </td>
    <td style="height:60px">
      <%= ViewData["google"]%>
    </td>
    </tr> <tr>
    <td>
   <div class="term3">Weather:</div>
    </td>
    <td style="height:60px">
   <%= ViewData["location"]%>
    <div id="towns" class="term1" style="display:none">
  <input type="text" id="town" value="North Berwick" />
  <div onclick="setTown()" style="cursor:pointer;display:inline">Submit</div>
  </div>
    </td>
    </tr>
    <tr>
    <td><div class="term2" id="townmsg"></div></td>
    <td><div id="townlist"></div></td>
    </tr>
   
</table>
<div class="footer" onclick="goFront()">Back</div>
</asp:Content>
