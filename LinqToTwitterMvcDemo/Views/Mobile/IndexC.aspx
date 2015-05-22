<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MobileC.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	OK fridge
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">
<h1><img id="headerIMG" src="../../Content/images/logo_header6.png" /></h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">

    $(document).ready(function () {
        var TweetRadio = get_cookie("tweets");
        if (TweetRadio == "my") {
            // if ($('#add_site').hasClass('ui-collapsible-collapsed')
            getTweets2(5);
            $("#messages").removeClass("ui-disabled");
            $("#messages").addClass("ui-enabled");
        }
    });
</script>
<div class="modal"></div>
 <ul data-role="listview" data-inset="true" data-theme="a" data-dividertheme="b">
	<li><%=Html.ActionLink("Get Started", "GetStarted", "Mobile") %></li>
    <li id="messages" class="ui-disabled"><a href="<%=Url.Action("Messages", "Mobile")%>">Messages<span class="ui-li-count"><div id="twct"></div></span></a></li>
    <li><%=Html.ActionLink("Events", "Events", "Mobile") %></li>
</ul>


 <ul data-role="listview" data-inset="true" data-theme="a" data-dividertheme="b">
 <li data-icon="gear" onclick="getTweets2(5)"><a href="#">Refresh</a></li>
</ul>   
<div id="toptweet" style="display:none">20</div>
<div style="display:none" id="toptweettime"></div>
</asp:Content>
