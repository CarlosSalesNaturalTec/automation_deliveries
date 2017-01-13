<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Relatorio3.aspx.cs" Inherits="Relatorio3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <script src="~/vendors/jquery/dist/jquery.min.js"></script>
    <script src="~/vendors/bootstrap/dist/js/bootstrap.min.js"></script>

</head>
<body>
   
    <br />
    <h1>Relatório de Distância Percorrida</h1>
    <div class="btn-group">
        <a href="#" class="btn btn-default">Período</a>
        <a href="#" class="btn btn-default dropdown-toggle" data-toggle="dropdown"><span class="caret"></span></a>
        <ul class="dropdown-menu">
            <li>HOJE</li>
            <li class="divider"></li>
            <li>ONTEM</li>
            <li class="divider"></li>
            <li>ESTA SEMANA</li>
            <li class="divider"></li>
            <li>ESTE MÊS</li>
        </ul>
    </div>

    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <input id="Hidden1" name="dist" type="hidden" />

    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCOmedP-f3N7W7CPxaRoCZJ5mTMm6g0Ycc&callback=initMap"
        async defer></script>



</body>
</html>
