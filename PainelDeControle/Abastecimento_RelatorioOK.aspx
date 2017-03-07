<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_RelatorioOK.aspx.cs" Inherits="Abastecimento_RelatorioOK" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <script src="~/vendors/jquery/dist/jquery.min.js"></script>
    <script src="~/vendors/bootstrap/dist/js/bootstrap.min.js"></script>

</head>

<body>
    
    <button type="reset" class="btn btn-primary" onclick="cancelar()">VOLTAR</button>

    <h3>Relatório de Abastecimentos</h3>
    <h4 class="text-primary"><asp:Literal ID="Literal_Placa" runat="server"></asp:Literal></h4>

    <!-- Dados -->
    <asp:Literal ID="Literal_Dados" runat="server"></asp:Literal>
    <!-- Dados -->

    <!-- Operações  -->
    <script type="text/javascript">

        function cancelar() {
            var linkurl = "../Abastecimento_Relatorios.aspx";
            window.location.href = linkurl;
        }
    </script>
    <!-- Operações  -->

</body>
</html>