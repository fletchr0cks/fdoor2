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
    //check last retrieval time
        var TweetRadio = get_cookie("tweets");
        if (TweetRadio == "my") {
            // if ($('#add_site').hasClass('ui-collapsible-collapsed')
            getTweets2(5); //retrieve and store
            $("#messages").removeClass("ui-disabled");
            $("#messages").addClass("ui-enabled");
        }
    });
</script>
<div class="modal"></div>
<div><%=ViewData["banner"]%></div>
<div><%=ViewData["details"]%></div>
<div><%=ViewData["details2"]%></div>
<div id="cookies"></div>

<% if (ViewData["type"] == "child")
   { %>

<ul data-role="listview" data-inset="true" data-theme="a" data-dividertheme="b">
    <li><a href="<%=Url.Action("Messages", "Mobile")%>">Messages<span class="ui-li-count"><div id="twct">Checking for new messages ...</div></span></a></li>
    <li><a href="<%=Url.Action("Events", "Mobile")%>">Events<span class="ui-li-count"><div id="evct">Checking for events ...</div></span></a></li>
</ul>
<% }
   else
   { %>
<ul data-role="listview" data-inset="true" data-theme="a" data-dividertheme="b">
	<li><%=Html.ActionLink("Get Started", "GetStarted", "Mobile")%></li>
</ul>
<ul data-role="listview" data-inset="true" data-theme="a" data-dividertheme="b">
    <li><%=Html.ActionLink("Message Setup", "MessageSetup", "Mobile")%></li>
    <li id="messages" class="ui-disabled"><a href="<%=Url.Action("Messages", "Mobile")%>">Messages<span class="ui-li-count"><div id="twct"></div></span></a></li>
</ul>
<ul data-role="listview" data-inset="true" data-theme="a" data-dividertheme="b" class="ui-disabled">
    <li><%=Html.ActionLink("Events Setup", "EventsSetup", "Mobile")%></li>
    <li id="events"><a href="<%=Url.Action("Events", "Mobile")%>">Events</a></li>
</ul>

<ul data-role="listview" data-inset="true" data-theme="a" data-dividertheme="b">
    <li id="viewdevices"><a href="<%=Url.Action("ListDevices", "Mobile")%>">View Devices</a></li>
    <li id="addadevice"><a href="<%=Url.Action("AddDevice", "Mobile")%>">Add a Device</a></li>
</ul>


 <ul data-role="listview" data-inset="true" data-theme="a" data-dividertheme="b">
 <li data-icon="gear" onclick="loadSpinner()"><a href="#">Refresh</a></li>
</ul>   

<% } %>
<div id="toptweet" style="display:none">2000</div>
<div style="display:none" id="toptweettime"></div>
</asp:Content>
