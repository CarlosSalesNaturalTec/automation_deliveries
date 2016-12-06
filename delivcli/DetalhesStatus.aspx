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
    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
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



</body>
</html>


