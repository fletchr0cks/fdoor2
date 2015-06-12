<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MobileC.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	View Devices
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitleContent" runat="server">
<%= Html.ActionLink("Back", "IndexC", "Mobile")%>
<h1><img id="headerIMG" src="../../Content/images/logo_header6.png" /></h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">

    $(document).ready(function () {
        ListDevices();
    });

    
</script>
<div><%=ViewData["msgbar"]%></div>
<div id="deviceList"></div>


</asp:Content>
