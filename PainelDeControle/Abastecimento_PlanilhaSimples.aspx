<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_PlanilhaSimples.aspx.cs" Inherits="Abastecimento_PlanilhaSimples" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Listagem Abastecimentos</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Paginação -->
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.15/js/dataTables.bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.15/css/dataTables.bootstrap.min.css" />

</head>

<body  style="margin-left: 2%; margin-right: 2%">

    <div class="row">

        <h3>Planilha Consolidação de Abastecimentos</h3>
        <br />

        <!-- Periodo -->
        <label for="inputPeriodo" class="col-md-1 control-label">Filtro Período</label>
        <div class="col-md-2">
            <select class="form-control" id="inputPeriodo" name="inputPeriodo" onchange="Selecao_Periodo(this.value)">
                <option>COMPLETO</option>
                <option>ESTA SEMANA</option>
                <option>ESTE MÊS</option>
                <option>ESPECÍFICO</option>
            </select>
        </div>

        <div id="divInput1" class="col-md-3" style="display: none">
            <input type="date" class="form-control" id="inputData1">
        </div>
        <div id="divInput2" class="col-md-3" style="display: none">
            <input type="date" class="form-control" id="inputData2">
        </div>
        <div class="col-md-3">
            <button id="btRel" type="button" class="btn btn-primary" onclick="verificar()">FILTRAR</button>
        </div>
        <!-- Periodo -->

    </div>
    <br />

    <div class="row">

        <div class="col-md-3">
            <div class="well">
                <h4>
                    <p>Total de Créditos:</p>
                </h4>
                <h3 class="text-success"><b>
                    <asp:Literal ID="Literal_TotalCR" runat="server"></asp:Literal></b></h3>
            </div>
        </div>

        <div class="col-md-3">
            <div class="well">
                <h4>
                    <p>Total de Débitos:</p>
                </h4>
                <h3 class="text-danger"><b>
                    <asp:Literal ID="Literal_TotalDB" runat="server"></asp:Literal></b></h3>
            </div>
        </div>
    </div>

    <div class="row">
        <br />
        <p>
            <em>Período Selecionado:</em>  <strong>
                <asp:Label ID="lblPer" runat="server"></asp:Label></strong>
        </p>
        <br />
    </div>

    <!-- Planilha  -->
    <div class="row">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>
    <!-- Planilha  -->
    

    <!-- Script Periodo  -->
    <script type="text/javascript">

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

        function verificar() {

            var linkurl = "Abastecimento_PlanilhaSimples.aspx";
            var params = "";

            var selecao = document.getElementById('inputPeriodo').value;
            if (selecao == 'ESPECÍFICO') {
                var v2 = document.getElementById("inputData1").value;
                var v3 = document.getElementById("inputData2").value;
                params = "?p1=4&p2=" + v2 + "&p3=" + v3;

            } else {

                if (selecao == 'COMPLETO') { params = "?p1=1"; }
                if (selecao == 'ESTA SEMANA') { params = "?p1=2"; }
                if (selecao == 'ESTE MÊS') { params = "?p1=3"; }
            }

            window.location.href = linkurl + params;
        }

    </script>


    <!-- Script Paginação  -->
    <script type="text/javascript" src="Scripts/codePaginacao.js"></script>

</body>
</html>
