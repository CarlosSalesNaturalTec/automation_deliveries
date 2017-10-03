<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_Concluido.aspx.cs" Inherits="Abastecimento_Concluido" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Autorização de Abastecimento enviada com sucesso</title>

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!-- Jquery-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <!-- Styles: W3, BootsStrap, Font-Awesome -->
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    
</head>
<body>
   
    <h3>Autorização de Abastecimento enviada com sucesso</h3>
    <br />
    <p><asp:Literal ID="literal_ID" runat="server"></asp:Literal></p>
    <p><asp:Literal ID="literal_nome" runat="server"></asp:Literal></p>
    <p><asp:Literal ID="literal_placa" runat="server"></asp:Literal></p>
    <p><asp:Literal ID="literal_Km" runat="server"></asp:Literal></p>
    <p><asp:Literal ID="literal_valor" runat="server"></asp:Literal></p>
    <p></p>

    <button type="reset" class="btn btn-primary" onclick="cancelar()">Voltar</button>

    <!-- Operações  -->
    <script type="text/javascript">

        function cancelar() {
            var linkurl = "../Abastecimento_Planilha.aspx";
            window.location.href = linkurl;
        }
    </script>
    <!-- Operações  -->

</body>
</html>