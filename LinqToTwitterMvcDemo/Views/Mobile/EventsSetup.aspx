<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MobileC.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="LinqToTwitterMvcDemo.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Events Setup
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">
<h1><img id="headerIMG" src="../../Content/images/logo_header6.png" /></h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<fieldset data-role="controlgroup">
<legend>Show Calendar Events</legend>
<input type="checkbox" name="ev1" id="ev1a" value="ev_tod" class="custom">
<label for="ev1a">Today</label>
<input type="checkbox" name="ev1" id="ev1b" value="ev_next5" class="custom">
<label for="ev1b">Next 5 Days</label>
<input type="checkbox" name="ev1" id="ev1c" value="ev_d2g" class="custom">
<label for="ev1c">Days To Go</label>
</fieldset>
<fieldset data-role="controlgroup">
<legend></legend>
<input type="checkbox" name="ev2" id="ev2a" value="ev_wea">
<label for="ev2a">Include Weather</label>
</fieldset>
<a href="#" class="ui-btn ui-btn-c" onclick="setEvents()">Submit</a>
<div id="editDays2go"><a href="#" class="ui-btn ui-icon-gear ui-btn-c ui-mini ui-btn-icon-left ui-corner-all" onclick="editDays2Go()">Edit Days to Go</a></div>
<div id="days2go">
</div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterContent" runat="server">
 <div data-role="footer" data-position="fixed" data-tap-toggle="false">
<a data-role="button" data-icon="gear" href="Events">Back</a>
    </div>
</asp:Content>