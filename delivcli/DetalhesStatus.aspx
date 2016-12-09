<%@  Language="C#" AutoEventWireup="true" CodeBehind="DetalhesStatus.aspx.cs" Inherits="delivcli.DetalhesStatus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/Content/bootstrap.min.css">
    <script src="~/Scripts/jquery.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>

</head>

<body>

    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <div class="well">
        <p class="text-info">Destinatário:</p>
        <p><b><asp:Label ID="lblDestinatario" runat="server"></asp:Label></b></p>
        <p><asp:Label ID="lblEnd" runat="server"></asp:Label></p>
        <p><asp:Label ID="lblBairro" runat="server"></asp:Label></p>
           
        <p class="text-info">Status:</p>
        <p><b><asp:Label ID="lblStatus" runat="server"></asp:Label></b></p>
        
        <p class="text-info">Entregador:</p>
        <p><asp:Label ID="lblEntregador" runat="server"></asp:Label></p>
    </div>

    <div class="well">
        <div id="output"></div>
    </div>

    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCOmedP-f3N7W7CPxaRoCZJ5mTMm6g0Ycc&callback=initMap"
        async defer></script>

</body>
</html>


