<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalhesEntrega.aspx.cs" Inherits="delivcli.DetalhesEntrega" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1">

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

    <link rel="stylesheet" href="~/Content/bootstrap.min.css">
    <script src="~/Scripts/jquery.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>

</head>

<body>

    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <br />

    <div id="map" class="col-sm-9 col-md-9 col-lg-9"></div>

    <div class="col-sm-3 col-md-3 col-lg-3">
        <div class="well">
            STATUS DA ENTREGA : 
        </div>

        <div class="well">
            ENTREGADOR              :
        </div>

        <div class="well">
            DISTÃNCIA PERCORRIDA    : 000 KM
        </div>
        
        <div class="well">
            TEMPO GASTO NO PERCURSO : 000 min
        </div>

    </div>

    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCOmedP-f3N7W7CPxaRoCZJ5mTMm6g0Ycc&callback=initMap"
        async defer></script>

</body>
</html>
