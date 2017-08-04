<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_Relatorios.aspx.cs" Inherits="Abastecimento_Relatorios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Relatório de Abastecimentos</title>

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <script src="~/vendors/jquery/dist/jquery.min.js"></script>
    <script src="~/vendors/bootstrap/dist/js/bootstrap.min.js"></script>
</head>

<body style="margin-left: 2%; margin-right: 2%">

    <br />

    <div class="panel panel-success">

        <div class="panel-heading text-center">
            <h4 class="panel-title">Relatório de Abastecimentos</h4>
        </div>

        <div class="panel-body">

            <div class="row">

                <!-- Veiculos -->
                <label for="inputPlaca" class="col-md-1 control-label">Placa</label>
                <div class="col-md-2">
                    <asp:Literal ID="Literal_Veiculos" runat="server"></asp:Literal>
                </div>
                <!-- Veiculos -->

                <!-- Periodo -->
                <label for="inputPeriodo" class="col-md-1 control-label">Período</label>
                <div class="col-md-2">
                    <select class="form-control" id="inputPeriodo" name="inputPeriodo" onchange="Selecao_Periodo(this.value)">
                        <option>COMPLETO</option>
                        <option>ESTA SEMANA</option>
                        <option>ESTE MÊS</option>
                        <option>ESPECÍFICO</option>
                    </select>
                </div>

                <div id="divInput1" class="col-md-2" style="display: none">
                    <input type="date" class="form-control" id="inputData1">
                </div>
                <div id="divInput2" class="col-md-2" style="display: none">
                    <input type="date" class="form-control" id="inputData2">
                </div>
                <!-- Periodo -->

            </div>

            <br />

            <div class="row">
                <div class="col-md-1">
                </div>
                <div class="col-md-4">
                    <button type="reset" class="btn btn-primary" onclick="cancelar()">Voltar</button>
                    <button type="button" class="btn btn-success" onclick="verificar()">Gerar Relatório</button>
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">

        function verificar() {

            var v4 = document.getElementById('inputPlaca').value;
            if (v4 == "") {
                alert("Selecione a Placa do Veículo");
                return;
            }

            var linkurl = "Abastecimento_RelatorioOK.aspx";
            var params = "";

            var selecao = document.getElementById('inputPeriodo').value;
            if (selecao == 'ESPECÍFICO') {
                var v2 = document.getElementById("inputData1").value;
                var v3 = document.getElementById("inputData2").value;
                params = "?p1=4&p2=" + v2 + "&p3=" + v3 + "&p4=" + v4;
            } else {
                if (selecao == 'COMPLETO') { params = "?p1=1&p4=" + v4; }
                if (selecao == 'ESTA SEMANA') { params = "?p1=2&p4=" + v4; }
                if (selecao == 'ESTE MÊS') { params = "?p1=3&p4=" + v4; }
            }
            window.location.href = linkurl + params;
        }

        function Selecao_Periodo(selecao) {

            if (selecao == 'ESPECÍFICO') {
                document.getElementById("divInput1").style.display = "block";
                document.getElementById("divInput2").style.display = "block";
                document.getElementById("inputData1").focus();
            } else {
                document.getElementById("divInput1").style.display = "none";
                document.getElementById("divInput2").style.display = "none";
            }

        }

        function pad(n) {
            return (n < 10) ? ("0" + n) : n;
        }

        function cancelar() {
            var linkurl = "../Abastecimento_Planilha.aspx";
            window.location.href = linkurl;
        }

    </script>



</body>
</html>
