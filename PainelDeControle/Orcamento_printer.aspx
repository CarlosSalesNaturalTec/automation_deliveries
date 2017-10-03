<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Orcamento_printer.aspx.cs" Inherits="Orcamento_printer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Proposta Comercial</title>

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

    <asp:Literal ID="Literal_Local_Data" runat="server"></asp:Literal>
    <br />
    <br />
    <b>A
        <asp:Literal ID="Literal_Cliente" runat="server"></asp:Literal>
        <asp:Literal ID="Literal_Contato" runat="server"></asp:Literal>
    </b>

    <br />

    <p>Apresentamos nossa proposta comercial para a prestação de serviços de transporte</p>
    <p>nas cidades de
        <asp:Literal ID="Literal_Cidades" runat="server"></asp:Literal>, formatada de acordo</p>
    <p>com o regime de trabalho de sua empresa, conforme descrito abaixo:</p>

    <b>CARACTERISTICAS OPERACIONAIS</b>

    <b>Roteiro: </b>
    <asp:Literal ID="Literal_Roteiro" runat="server"></asp:Literal>
    <br />


</body>
</html>
