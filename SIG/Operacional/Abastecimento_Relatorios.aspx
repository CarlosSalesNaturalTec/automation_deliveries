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
    <br />

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

        <div class="col-md-2">
            <input type="date" class="form-control" id="inputData1" style="visibility:hidden">
        </div>
        <div class="col-md-2">
            <input type="date" class="form-control" id="inputData2" style="visibility:hidden">
        </div>
        <!-- Periodo -->

        <!-- Tipo de Relatório:  1=Completo   2=Esta Semana  3=Este Mes    4=Especifico-->
        <input type="hidden" id="tipoRel" value="1">

    </div>
    
    <br />

    <div class="row">
        <div class="col-md-1">         
        </div>
        <div class="col-md-2">
            <button type="button" class="btn btn-primary" onclick="verificar()">GERAR RELATÓRIO</button>
        </div>
        <div class="col-md-2">
            <button type="button" class="btn btn-primary" onclick="voltar()">VOLTAR</button>
        </div>
    </div>

    <script type="text/javascript">

        function verificar() {

            var v1 = document.getElementById("inputPlaca").value;
            var v2 = document.getElementById("tipoRel").value;
            var v3 = document.getElementById("inputData1").value;
            var v4 = document.getElementById("inputData2").value;

            var linkurl = "Abastecimento_RelatorioOK.aspx?p1=" + v1 + "&p2=" + v2 + "&p3=" + v3 + "&p4=" + v4;

            window.location.href = linkurl;

        }

        function Selecao_Periodo(selecao) {

            if (selecao == 'ESPECÍFICO') {
                document.getElementById("inputData1").style.visibility = "visible";
                document.getElementById("inputData2").style.visibility = "visible";
                document.getElementById("inputData1").focus();
            } else {
                document.getElementById("inputData1").style.visibility = "hidden";
                document.getElementById("inputData2").style.visibility = "hidden";
            }
            
        }

        function pad(n) {
            return (n < 10) ? ("0" + n) : n;
        }

        function voltar() {
            var linkurl = "Abastecimento_Planilha.aspx";
            window.location.href = linkurl;
        }
    </script>

</body>
</html>
