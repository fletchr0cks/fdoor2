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
<input type="checkbox" name="checkbox-1a" id="checkbox-1a">
<label for="checkbox-1a">Today</label>
<input type="checkbox" name="checkbox-2a" id="checkbox-2a">
<label for="checkbox-2a">Next 5 Days</label>
<input type="checkbox" name="checkbox-3a" id="checkbox-3a">
<label for="checkbox-3a">Days To Go</label>
</fieldset>
<fieldset data-role="controlgroup">
<legend></legend>
<input type="checkbox" name="checkbox-1b" id="checkbox-1b">
<label for="checkbox-1b">Include Weather</label>
</fieldset>
<div id="editDays2go"><a href="#" class="ui-btn ui-icon-gear ui-btn-c ui-mini ui-btn-icon-left ui-corner-all" onclick="editDays2Go()">Edit Days to Go</a></div>
<div id="days2go">
</div>

</asp:Content>
