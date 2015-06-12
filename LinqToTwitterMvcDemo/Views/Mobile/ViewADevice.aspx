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

</asp:Content>
