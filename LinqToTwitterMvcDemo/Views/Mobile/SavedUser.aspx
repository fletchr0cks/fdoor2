<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MobileC.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SavedUser
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">

    <h2>SavedUser</h2>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div data-role="page" data-dialog="true">

		<div data-role="header" data-theme="b">
		<h1>Dialog</h1>
		</div>

		<div role="main" class="ui-content">
		<h1>Delete page?</h1>
		<p>This is a regular page, styled as a dialog. To create a dialog, just link to a normal page and include a transition and <code>data-rel="dialog"</code> attribute.</p>
			<a href="index.html" data-rel="back" class="ui-btn ui-shadow ui-corner-all ui-btn-a">Sounds good</a>
			<a href="index.html" data-rel="back" class="ui-btn ui-shadow ui-corner-all ui-btn-a">Cancel</a>
		</div>
	</div>
</asp:Content>
