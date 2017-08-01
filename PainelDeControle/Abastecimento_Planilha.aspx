<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_Planilha.aspx.cs" Inherits="Abastecimento_Planilha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Planilha Abastecimento</title>

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <script src="~/vendors/jquery/dist/jquery.min.js"></script>
    <script src="~/vendors/bootstrap/dist/js/bootstrap.min.js"></script>

</head>

<body style="margin-left: 2%; margin-right: 2%">

    <h3>Resumo de Abastecimentos</h3>

    <div class="row">

        <div class="col-md-3">
            <div class="well">
                <h4>
                    <p>Saldo Atual:</p>
                </h4>
                <h3 class="text-primary"><b>
                <asp:Literal ID="Literal_Saldo" runat="server"></asp:Literal></b></h3>
                <a href="Abastecimento_PlanilhaSimples.aspx?p1=1" class="btn btn-primary">PLANILHA</a>
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
                <a href="Abastecimento_Credito.aspx" class="btn btn-success">LANÇAR CRÉDITO</a>
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
                <a href="Abastecimento_Novo.aspx" class="btn btn-danger">NOVA AUTORIZAÇÃO</a>
                <p></p>
            </div>
        </div>

        <div class="col-md-3">
            <div class="well">
                <h4>
                    <p>Relatórios</p>
                </h4>
                <h3 class="text-danger"><b>
                    <asp:Literal ID="Literal_Rel" runat="server"></asp:Literal></b></h3>
                <a href="Abastecimento_Relatorios.aspx" class="btn btn-success">RELATÓRIOS</a>
                <p></p>
            </div>
        </div>

        <input type="hidden" id="TotalCRHidden"  name="TotalCR" runat="server"/>
        <input type="hidden" id="TotalSaldoHidden" name="TotalSaldo" runat="server"/>

    </div>

</body>
</html>
