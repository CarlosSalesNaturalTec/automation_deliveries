<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_Planilha.aspx.cs" Inherits="Abastecimento_Planilha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Planilha Abastecimento</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Jquery-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <!-- Styles: W3, BootsStrap, Font-Awesome -->
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <!-- Gráficos HighCharts -->
    <script src="https://code.highcharts.com/highcharts.js"></script>

    <!-- Paginação -->
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.15/js/dataTables.bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.15/css/dataTables.bootstrap.min.css" />

</head>

<body style="margin-left: 2%; margin-right: 2%">

    <br />

    <div class="w3-row w3-container w3-border w3-round w3-padding-16 w3-light-gray">

        <div id="Bloco1" class="w3-col s4 m4 l4 w3-padding">
            <!-- Customize Aqui-->
            <div class="panel panel-success">

                <div class="panel-heading text-center">
                    <h4 class="panel-title">Total por Placa</h4>
                </div>

                <div class="panel-body">
                    <div id="Bloco1_Chart" style="min-width: 310px; height: 200px; margin: 0 auto"></div>
                    <!-- Customize Aqui-->
                </div>

            </div>
        </div>

        <div id="Bloco2" class="w3-col s4 m4 l4 w3-padding">
            <!-- Customize Aqui-->
            <div class="panel panel-success">

                <div class="panel-heading text-center">
                    <h4 class="panel-title">Total por Motorista</h4>
                </div>

                <div class="panel-body">
                    <div id="Bloco2_Chart" style="min-width: 310px; height: 200px; margin: 0 auto"></div>
                    <!-- Customize Aqui-->
                </div>

            </div>
        </div>

        <div id="Bloco3" class="w3-col s4 m4 l4 w3-padding">
            <!-- Customize Aqui-->
            <div class="panel panel-success">

                <div class="panel-heading text-center">
                    <h4 class="panel-title">Saldo Crédito</h4>
                </div>

                <div class="panel-body text-center" style="min-width: 310px; height: 200px; margin: 0 auto">
                    <h1><asp:Literal ID="Bloco3_Info" runat="server"></asp:Literal></h1>

                    <a href="Abastecimento_Novo.aspx" class="btn btn-block btn-danger">NOVA AUTORIZAÇÃO</a>
                    <p></p>
                    <a href="Abastecimento_Credito.aspx" class="btn btn-block btn-success">NOVO CRÉDITO</a>
                    <p></p>
                    <a href="Abastecimento_Relatorios.aspx" class="btn btn-block btn-primary">RELATÓRIOS</a>
                </div>

                
                <p>&nbsp;</p>
                

            </div>
        </div>

    </div>

    <div class="w3-row-padding ">
        <p>&nbsp;</p>
    </div>

    <!-- Auxiliares (input que recebe os dados para montagem do grafico) -->
    <asp:Literal ID="Literal_Bloco1_Dados" runat="server"></asp:Literal>
    <asp:Literal ID="Literal_Bloco2_Dados" runat="server"></asp:Literal>

    <!-- Planilha  -->
    <div class="w3-container w3-border w3-round w3-padding-16 w3-light-gray w3-small">
        <asp:Literal ID="Literal_Tabela" runat="server"></asp:Literal>
    </div>

    <!-- Script Paginação  -->
    <script type="text/javascript" src="Scripts/codePaginacao.js"></script>

    <!-- Script Gráficos  -->
    <script type="text/javascript" src="ScriptsCharts/codeAbastecimentoCharts.js"></script>

</body>
</html>
