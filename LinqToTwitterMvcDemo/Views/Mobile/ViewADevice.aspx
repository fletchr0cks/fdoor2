<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MobileC.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	View A Device
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">

<%= Html.ActionLink("Back", "ListDevices", "Mobile")%>
<h1><img id="headerIMG" src="../../Content/images/logo_header6.png" /></h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<%=ViewData["device"]%>

<ul data-role="listview" data-inset="true">
<li data-role="list-divider">Friday, October 8, 2010 <span class="ui-li-count">2</span></li>
<li><h2>Stephen Weber</h2>
<p><strong>You've been invited to a meeting at Filament Group in Boston, MA</strong></p>
<p>Hey Stephen, if you're available at 10am tomorrow, we've got a meeting with the jQuery team.</p>
</li>
<li>
<div class="ui-grid-a ui-responsive">    
<div class="ui-block-a">
<fieldset data-role="controlgroup" data-type="horizontal" data-mini="true">
<legend>Horizontal, mini sized:</legend>
<input type="radio" name="radio-choice-h-6" id="radio-choice-h-6a" value="on" checked="checked">
<label for="radio-choice-h-6a">One</label>
<input type="radio" name="radio-choice-h-6" id="radio-choice-h-6b" value="off">
<label for="radio-choice-h-6b">Two</label>
</fieldset>
</div>
<div class="ui-block-b">
<a href="#" class="ui-shadow ui-btn ui-corner-all ui-btn-inline ui-btn-icon-left ui-icon-star">Inline + icon</a>
<a href="#" class="ui-shadow ui-btn ui-corner-all ui-btn-inline ui-mini">Mini + theme</a>
<a href="#" class="ui-shadow ui-btn ui-corner-all ui-btn-inline ui-icon-plus ui-btn-icon-notext ui-btn-b ui-mini">icon only button</a>
</div>
</div><p>ss</p></li>
</ul>



</asp:Content>
