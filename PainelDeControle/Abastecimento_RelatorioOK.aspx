<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_RelatorioOK.aspx.cs" Inherits="Abastecimento_RelatorioOK" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Relatório de Abastecimentos</title>

    <meta name="viewport" content="width=device-width, initial-scale=1">

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

    <div class="w3-container w3-border w3-round w3-padding-16 w3-light-gray">

        <br />

        <button type="reset" class="btn btn-primary" onclick="cancelar()">VOLTAR</button>

        <h3>Relatório de Abastecimentos</h3>
        <br />

        <h4 class="text-primary"><asp:Literal ID="Literal_Placa" runat="server"></asp:Literal></h4>

        <p><em>Período Selecionado:</em>  <strong>
                <asp:Label ID="lblPer" runat="server"></asp:Label></strong>
        </p>

        <p><em>Total: </em><strong>
                <asp:Label ID="lbltotalValor" runat="server"></asp:Label></strong>&nbsp;&nbsp;&nbsp;<em>Lts: </em><strong>
                    <asp:Label ID="lbltotalLts" runat="server"></asp:Label></strong>
        </p>
        <br />
    </div>

    <br />

    <!-- Planilha -->
    <div class="w3-container w3-border w3-round w3-padding-16 w3-light-gray w3-small">
        <asp:Literal ID="Literal_Dados" runat="server"></asp:Literal>
    </div>
    <!-- Planilha -->

    <!-- VOLTAR  -->
    <script type="text/javascript">
        function cancelar() {
            var linkurl = "../Abastecimento_Relatorios.aspx";
            window.location.href = linkurl;
        }
    </script>   

</body>
</html>
