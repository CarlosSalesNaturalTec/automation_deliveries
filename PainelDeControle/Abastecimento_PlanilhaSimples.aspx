<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_PlanilhaSimples.aspx.cs" Inherits="Abastecimento_PlanilhaSimples" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <script src="~/vendors/jquery/dist/jquery.min.js"></script>
    <script src="~/vendors/bootstrap/dist/js/bootstrap.min.js"></script>

</head>

<body>

    <h3>Planilha Consolidação de Abastecimentos</h3>
    <br />

    <div class="row">
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
            <input type="date" class="form-control" id="inputData1" style="visibility: hidden">
        </div>
        <div class="col-md-2">
            <input type="date" class="form-control" id="inputData2" style="visibility: hidden">
        </div>
        <div class="col-md-2">
            <button id="btRel" type="button" class="btn btn-primary" onclick="verificar()">VERIFICAR</button>
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

    <br />
    <br />

    <script type="text/javascript">

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

        function verificar() {

            if (selecao == 'ESPECÍFICO') {
                
                var v2 = document.getElementById("inputData1").value;
                var v3 = document.getElementById("inputData2").value;
                var linkurl = "Abastecimento_PlanilhaSimples.aspx?p1=4&p2=" + v2 + "&p3=" + v3;

            } else {
                document.getElementById("inputData1").style.visibility = "hidden";
                document.getElementById("inputData2").style.visibility = "hidden";
                document.getElementById("btRel").style.visibility = "hidden";

                var linkurl = "";
                if (selecao == 'COMPLETO') { linkurl = "Abastecimento_PlanilhaSimples.aspx?p1=1"; }
                if (selecao == 'ESTA SEMANA') { linkurl = "Abastecimento_PlanilhaSimples.aspx?p1=2"; }
                if (selecao == 'ESTE MÊS') { linkurl = "Abastecimento_PlanilhaSimples.aspx?p1=3"; }

                window.location.href = linkurl;
            }

            window.location.href = linkurl;
        }

    </script>


    <!-- Planilha  -->
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <!-- Planilha  -->

    <!-- Busca e Paginação modelo: datatables.net -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>

    <link rel="stylesheet" href="//cdn.datatables.net/1.10.10/css/jquery.dataTables.min.css">
    <script src="//cdn.datatables.net/1.10.10/js/jquery.dataTables.min.js"></script>
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.10/css/dataTables.bootstrap.min.css">

    <script>
        $(document).ready(function () {
            $('#tabela').DataTable({
                "language": {
                    "lengthMenu": "Mostrando _MENU_ registros por página",
                    "zeroRecords": "Nada encontrado",
                    "info": " _MAX_ registros no total",
                    "infoEmpty": "Nenhum registro disponível",
                    "infoFiltered": "(filtrado de _MAX_ registros no total)",
                    "search": "Pesquisa:"
                }
            });
        });
    </script>

</body>
</html>
