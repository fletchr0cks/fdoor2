<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MobileC.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Add Device
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">
<%= Html.ActionLink("Back", "IndexC", "Mobile")%>
<h1><img id="headerIMG" src="../../Content/images/logo_header6.png" /></h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

<p>Add device form</p>
<h2>Add a Device</h2>
<form>
<ul data-role="listview" data-inset="true">
<li class="ui-field-contain">
<input type="text" name="text-basic" id="device-name" value="Device name here, i.e. Kitchen or Bob" />
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
</asp:Content>
