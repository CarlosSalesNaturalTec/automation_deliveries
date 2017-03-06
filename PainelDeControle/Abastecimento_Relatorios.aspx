<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_Relatorios.aspx.cs" Inherits="Abastecimento_Relatorios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <script src="~/vendors/jquery/dist/jquery.min.js"></script>
    <script src="~/vendors/bootstrap/dist/js/bootstrap.min.js"></script>
</head>

<body>

    <h3>Relatório de Abastecimentos</h3>

    <div class="row">
        <!-- Veiculos -->
        <label for="inputPlaca" class="col-md-1 control-label">Placa</label>
        <div class="col-md-2">
            <asp:Literal ID="Literal_Veiculos" runat="server"></asp:Literal>
        </div>
        <!-- Veiculos -->

        <div class="col-md-2">
            <button type="button" class="btn btn-primary" onclick="verificar()">VERIFICAR</button>
        </div>

    </div>

    <script type="text/javascript">
        function verificar() {

            var v1 = document.getElementById("inputPlaca").value;
            var linkurl = "../Abastecimento_RelatorioOK.aspx?p1=" + v1;

            window.location.href = linkurl;

        }

    </script>



</body>
</html>
