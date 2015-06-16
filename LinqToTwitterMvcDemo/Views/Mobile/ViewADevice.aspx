<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MobileC.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="LinqToTwitterMvcDemo.Models" %>
<%@ Import Namespace="LinqToTwitterMvcDemo.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	View A Device
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">

<%= Html.ActionLink("Back", "ListDevices", "Mobile")%>
<h1><img id="headerIMG" src="../../Content/images/logo_header6.png" /></h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    $(document).ready(function () {

       // viewDevices();
        $("#chart-div3701").html("hihi");
    });
</script>
<%=ViewData["device"]%>
<% var deviceURL = "http://fridgedoor.apphb.com/Mobile/Index?zcguid=" + ViewData["deviceGUID"];%> 
<div><%=GoogleChartHelpers.GoogleQR(deviceURL)%></div>
</asp:Content>
