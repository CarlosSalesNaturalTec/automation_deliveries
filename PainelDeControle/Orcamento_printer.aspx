<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Orcamento_printer.aspx.cs" Inherits="Orcamento_printer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Proposta Comercial</title>

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <script type="text/javascript" src="Scripts/jquery-3.1.1.min.js"></script>

</head>
<body>

    <asp:Literal ID="Literal_Local_Data" runat="server"></asp:Literal>
    <br />
    <br />
    <b>A <asp:Literal ID="Literal_Cliente" runat="server"></asp:Literal>
        <asp:Literal ID="Literal_Contato" runat="server"></asp:Literal>
    </b>

    <br />
    
    <p>Apresentamos nossa proposta comercial para a prestação de serviços de transporte</p>
    <p>nas cidades de <asp:Literal ID="Literal_Cidades" runat="server"></asp:Literal>, formatada de acordo</p>
    <p>com o regime de trabalho de sua empresa, conforme descrito abaixo:</p>

    <b>CARACTERISTICAS OPERACIONAIS</b>

    <b>Roteiro: </b> <asp:Literal ID="Literal_Roteiro" runat="server"></asp:Literal>
    <br />


</body>
</html>
