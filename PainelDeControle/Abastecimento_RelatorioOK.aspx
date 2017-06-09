<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_RelatorioOK.aspx.cs" Inherits="Abastecimento_RelatorioOK" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Relatório de Abastecimentos</title>

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <script src="~/vendors/jquery/dist/jquery.min.js"></script>
    <script src="~/vendors/bootstrap/dist/js/bootstrap.min.js"></script>

</head>

<body>
    
    <button type="reset" class="btn btn-primary" onclick="cancelar()">VOLTAR</button>

    <h3>Relatório de Abastecimentos</h3>
    <br />

    <h4 class="text-primary"><asp:Literal ID="Literal_Placa" runat="server"></asp:Literal></h4>
    <p><em>Período Selecionado:</em>  <strong><asp:Label ID="lblPer" runat="server"></asp:Label></strong> </p> 
    <p><em>Total: </em><strong><asp:Label ID="lbltotalValor" runat="server"></asp:Label></strong>&nbsp;&nbsp;&nbsp;<em>Lts: </em><strong><asp:Label ID="lbltotalLts" runat="server"></asp:Label></strong> </p>
    <br />

    <!-- Dados -->
    <asp:Literal ID="Literal_Dados" runat="server"></asp:Literal>
    <!-- Dados -->


    <!-- VOLTAR  -->
    <script type="text/javascript">
        function cancelar() {
            var linkurl = "../Abastecimento_Relatorios.aspx";
            window.location.href = linkurl;
        }
    </script>
    <!-- VOLTAR  -->

</body>
</html>