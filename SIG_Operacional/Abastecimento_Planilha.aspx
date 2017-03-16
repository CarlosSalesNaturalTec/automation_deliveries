<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_Planilha.aspx.cs" Inherits="Abastecimento_Planilha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">

    <script src="~/vendors/jquery/dist/jquery.min.js"></script>
    <script src="~/vendors/bootstrap/dist/js/bootstrap.min.js"></script>

</head>

<body>

    <h3>Controle de Abastecimentos</h3>

    <div class="row">
        <div class="col-md-3">
            <div class="well">
                <h4>
                    <p>Saldo Atual:</p>
                </h4>
                <h3 class="text-primary"><b>
                <asp:Literal ID="Literal_Saldo" runat="server"></asp:Literal></b></h3>
                <a href="Abastecimento_PlanilhaSimples.aspx" class="btn btn-primary btn-block">PLANILHA</a>
                <p></p>
            </div>
        </div>

        <div class="col-md-3">
            <div class="well">
                <h4>
                    <p>Total de Créditos:</p>
                </h4>
                <h3 class="text-success"><b>
                    <asp:Literal ID="Literal_TotalCR" runat="server"></asp:Literal></b></h3>
                <a href="Abastecimento_Credito.aspx" class="btn btn-block btn-success">LANÇAR CRÉDITO</a>
                <p></p>
            </div>
        </div>

        <div class="col-md-3">
            <div class="well">
                <h4>
                    <p>Total de Débitos:</p>
                </h4>
                <h3 class="text-danger"><b>
                    <asp:Literal ID="Literal_TotalDB" runat="server"></asp:Literal></b></h3>
                <a href="Abastecimento_Novo.aspx" class="btn btn-block btn-danger">NOVA AUTORIZAÇÃO</a>
                <p></p>
            </div>
        </div>

        <div class="col-md-3">
            <div class="well">
                <h4><p>Relatórios</p></h4>
                <h3 class="text-danger"><b><i class="fa fa-line-chart"></i></b></h3>
                <a href="Abastecimento_Relatorios.aspx" class="btn btn-block btn-success">RELATÓRIOS</a>
                <p></p>
            </div>
        </div>

        <input type="hidden" id="TotalCRHidden"  name="TotalCR" runat="server"/>
        <input type="hidden" id="TotalSaldoHidden" name="TotalSaldo" runat="server"/>

    </div>

</body>
</html>
