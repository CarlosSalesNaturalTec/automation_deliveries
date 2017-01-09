﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SituacaoMapa.aspx.cs" Inherits="SituacaoMapa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <style>
      html, body {
        height: 100%;
        margin: 0;
        padding: 0;
      }
      #map {
        height: 100%;
      }
    </style>

</head>

<body>

    <div id="map"></div>

    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCOmedP-f3N7W7CPxaRoCZJ5mTMm6g0Ycc&callback=initMap"
        async defer></script>
    
</body>
</html>
