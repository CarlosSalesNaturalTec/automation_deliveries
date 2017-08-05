<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_Local_Relatorios.aspx.cs" Inherits="Abastecimento_Local_Relatorios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Cadastro de Abastecimento Posto Local</title>

    <!-- Jquery-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <!-- Styles: W3, BootsStrap, Font-Awesome -->
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>
<body style="margin-left: 2%; margin-right: 2%">

    <br />

    <div class="panel panel-success">

        <div class="panel-heading text-center">
            <h4 class="panel-title">Nova Abastecimento - Posto Local</h4>
        </div>

        <div class="panel-body">
            <form class="form-horizontal">

                <fieldset>
                    <br />
                    <div class="form-group">
                        <label for="input1" class="col-md-2 control-label">Nome</label>
                        <div class="col-md-8">
                            <input type="text" class="form-control" id="input1" value="TODOS">
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="inputPeriodo" class="col-md-2 control-label">Período</label>
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

                    </div>

                    <legend></legend>

                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-2">
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                                <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="verificar()">
                                <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;&nbsp;
                            </button>

                            <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                        </div>
                    </div>

                </fieldset>
            </form>
        </div>
    </div>

    <!-- auxiliares -->
    <input id="IDAuxHidden" type="hidden" />
    <asp:Literal ID="Literal_Aux" runat="server"></asp:Literal>

    <!-- Autocomplete -->
    <asp:Literal ID="Literal_AutoComplete" runat="server"></asp:Literal>

    <script type="text/javascript">

        function verificar() {

            var v4 = document.getElementById('input1').value;
            if (v4 == "") {
                alert("Selecione o Responsável");
                return;
            }

            var linkurl = "Abastecimento_Local_Relatorios_PDF.aspx";
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
            var linkFinal = linkurl + params;
            window.open(linkFinal, '_blank');
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

        function cancelar() {
            var linkurl = "../Abastecimento_Local_Listagem.aspx";
            window.location.href = linkurl;
        }

    </script>


</body>
</html>
