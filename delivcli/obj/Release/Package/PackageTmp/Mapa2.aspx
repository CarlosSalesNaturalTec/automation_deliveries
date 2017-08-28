<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mapa2.aspx.cs" Inherits="delivcli.Mapa2" %>

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

    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB2PC8H2Mi0TZsYN-j17OtXsNb8DktSH64&callback=initMap"
        async defer></script>
    
</body>
</html>
