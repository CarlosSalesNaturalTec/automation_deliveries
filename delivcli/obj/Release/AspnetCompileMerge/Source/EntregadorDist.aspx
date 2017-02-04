<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntregadorDist.aspx.cs" Inherits="delivcli.EntregadorDist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/Content/bootstrap.min.css">
    <script src="~/Scripts/jquery.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>

</head>

<body>

    <div id="map"></div>

    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <div class="well">
        <p class="text-info">Distância Percorrida (Km):</p>
        <input id="distanc" type="text" readonly="readonly" />
    </div>

    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCOmedP-f3N7W7CPxaRoCZJ5mTMm6g0Ycc&libraries=geometry&callback=initMap"
        async defer></script>

</body>
</html>
