<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_Local_Relatorios.aspx.cs" Inherits="Abastecimento_Local_Relatorios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Relatórios de Abastecimentos - Posto Local</title>

    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">

    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>


</head>
<body style="margin-left: 2%; margin-right: 2%">

    <br />

    <div class="panel panel-success">

        <div class="panel-heading text-center">
            <h4 class="panel-title">Relatório de Abastecimentos - Posto Local</h4>
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
                                <option>ESTE MÊS</option>
                                <option>COMPLETO</option>
                                <option>ESTA SEMANA</option>
                                <option>ESPECÍFICO</option>
                            </select>
                        </div>

                        <label for="input_tipo" class="col-md-1 control-label">Tipo</label>
                        <div class="col-md-2">
                            <select class="form-control" id="input_tipo">
                                <option>SINTÉTICO</option>
                                <option>ANALÍTICO</option>
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
                            <button type="button" class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                                <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button type="button" class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="verificar()">
                                <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Verificar
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

    <!-- Scripts Diversos -->
    <script type="text/javascript" src="Scripts/codeAbast_Local_Relatorios.js"></script>

</body>
</html>
