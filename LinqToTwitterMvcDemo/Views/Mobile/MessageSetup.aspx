<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MobileC.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="LinqToTwitterMvcDemo.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	MessageSetup
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">
 <a href="/" class="ui-btn ui-icon-home ui-btn-icon-notext ui-corner-all">Setup</a>
<h1><img id="headerIMG" src="../../Content/images/logo_header6.png" /></h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">

    $(document).ready(function () {
        //check last retrieval time
        var TweetRadio = get_cookie("tweets");
        

        if (TweetRadio == "all") {
            $('#radio-3e').attr('checked', true).checkboxradio('refresh');
        }
        if (TweetRadio == "dm") {
            $('#radio-3f').attr('checked', true).checkboxradio('refresh');
        }
        if (TweetRadio == "my") {
            $('#radio-3a').attr('checked', true).checkboxradio('refresh');
        }
        if (TweetRadio == "fol") {
            $('#radio-3b').attr('checked', true).checkboxradio('refresh');
        }
        if (TweetRadio == "men") {
            $('#radio-3c').attr('checked', true).checkboxradio('refresh');
        }
        if (TweetRadio == "okf") {
            $('#radio-3d').attr('checked', true).checkboxradio('refresh');
        }
    });
</script>

<div id="msgdiv">Select Twitter message type</div>
<fieldset data-role="controlgroup" data-mini="true" name="tweettypesmenu" id="tweettypesmenu">
     <input type="radio" name="radio-3" id="radio-3e" value="all">
    <label for="radio-3e">All</label>
    <input type="radio" name="radio-3" id="radio-3f" value="dm">
    <label for="radio-3f">Direct Messages</label>
     <input type="radio" name="radio-3" id="radio-3a" value="my">
    <label for="radio-3a">My Tweets</label>
     <input type="radio" name="radio-3" id="radio-3b" value="fol">
    <label for="radio-3b">Following</label>
     <input type="radio" name="radio-3" id="radio-3c" value="men">
    <label for="radio-3c">Mentions</label>
     <input type="radio" name="radio-3" id="radio-3d" value="okf">
    <label for="radio-3d">@okfridge</label>  
</fieldset>
<a href="#" class="ui-btn ui-btn-c" onclick="setMessages()">Submit</a>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="FooterContent" runat="server">
 <div data-role="footer" data-position="fixed" data-tap-toggle="false">
<a data-role="button" data-icon="gear" href="/">Back</a>
    </div>
</asp:Content>
