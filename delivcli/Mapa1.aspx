<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mapa1.aspx.cs" Inherits="delivcli.Mapa1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

   <title>Mapa</title>
    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
   
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

    <input id="IDCli" type="hidden" />

    <div id="map"></div>

    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB2PC8H2Mi0TZsYN-j17OtXsNb8DktSH64&callback=initMap"
        async defer></script>
    
    <script type="text/javascript" src="Scripts/codeMapa1.js"></script>

</body>
</html>
