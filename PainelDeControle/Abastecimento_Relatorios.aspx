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
            <input type="date" class="form-control" id="inputData1">
        </div>
        <div class="col-md-2">
            <input type="date" class="form-control" id="inputData2">
        </div>

        <!-- Periodo -->

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
            var linkurl = "../Abastecimento_RelatorioOK.aspx?p1=" + v1;

            window.location.href = linkurl;

        }

        function Selecao_Periodo(selecao) {

            dataPer1 = '';
            dataPer2 = '';
            hoje = new Date();
            
            dia = hoje.getDate();
            mes = hoje.getMonth() + 1 ;
            ano = hoje.getFullYear();

            switch (selecao) {
                case 'COMPLETO':
                    dataPer1 = '2017-01-01';
                    dataPer2 = ano + '-' + pad(mes) + '-' + pad(dia);
                    break;
                case 'ESTA SEMANA':
                    dataPer1 = ano + '-' + pad(mes) + '-01';
                    dataPer2 = ano + '-' + pad(mes) + '-' + pad(dia);
                    break;
                case 'ESTE MÊS':
                    dataPer1 = ano + '-' + pad(mes) + '-01';
                    dataPer2 = ano + '-' + pad(mes) + '-' + pad(dia);
                    break;
                case 'ESPECÍFICO':
                    document.getElementById("inputData1").focus();
                    break;

                default:
                    break;
            }
            document.getElementById("inputData1").value = dataPer1;
            document.getElementById("inputData2").value = dataPer2;
        }

        function pad(n) {
            return (n < 10) ? ("0" + n) : n;
        }

        function voltar() {
            var linkurl = "../Abastecimento_Planilha.aspx";
            window.location.href = linkurl;
        }

    </script>



</body>
</html>
