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

    <div class="well">
        <p class="text-info">Destinatário:</p>
        <p><asp:Label ID="lblDestinatario" runat="server"></asp:Label></p>
        <p>End.: <asp:Label ID="lblEnd" runat="server"></asp:Label></p>
        <p>Bairro: <asp:Label ID="lblBairro" runat="server"></asp:Label></p>
           
        <p class="text-info">Status:</p>
        <p><asp:Label ID="lblStatus" runat="server"></asp:Label></p>
        
        <p class="text-info">Entregador:</p>
        <p><asp:Label ID="lblEntregador" runat="server"></asp:Label></p>
    </div>

</body>
</html>


