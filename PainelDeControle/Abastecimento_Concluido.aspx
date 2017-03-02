<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_Concluido.aspx.cs" Inherits="Abastecimento_Concluido" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Autorização de Abastecimento enviada com sucesso</title>

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">

</head>
<body>
   
    <h3>Autorização de Abastecimento enviada com sucesso</h3>
    <br />
    <p><asp:Literal ID="literal_ID" runat="server"></asp:Literal></p>
    <p><asp:Literal ID="literal_nome" runat="server"></asp:Literal></p>
    <p><asp:Literal ID="literal_modelo" runat="server"></asp:Literal></p>
    <p><asp:Literal ID="literal_placa" runat="server"></asp:Literal></p>
    <p><asp:Literal ID="literal_Km" runat="server"></asp:Literal></p>
    <p><asp:Literal ID="literal_valor" runat="server"></asp:Literal></p>
    <p></p>

    <button type="reset" class="btn btn-primary" onclick="cancelar()">Voltar</button>

    <!-- Operações  -->
    <script type="text/javascript">

        function cancelar() {
            var linkurl = "../Abastecimento_Lista.aspx";
            window.location.href = linkurl;
        }
    </script>
    <!-- Operações  -->

</body>
</html>