<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Roteiros_Pcontas_Indiv.aspx.cs" Inherits="Roteiros_Pcontas_Indiv" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Prestação de Contas</title>

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

<body style="margin-left: 2%; margin-right: 2%">

    <br />
    <!-- GRID eNTREGAS eFETUADAS-->
    <div class="panel panel-success">
        <div class="panel-heading text-center">
            <h4 class="panel-title">Entregas Realizadas</h4>
        </div>

        <h4>&nbsp;&nbsp;&nbsp;<asp:Literal ID="lbl_motoboy" runat="server"></asp:Literal></h4>

        <div class="panel-body">
            <div class="w3-container w3-border w3-round w3-padding-16 w3-light-gray w3-small">

                <table id="tabela" class="w3-table-all w3-hoverable">
                    <thead>
                        <tr class="w3-gray">
                            <th>Cliente</th>
                            <th>Destinatário</th>
                            <th>End/Num</th>
                            <th>Bairro</th>
                            <th>Cidade</th>
                            <th>Valor Cliente</th>
                        </tr>
                    </thead>
                    <asp:Literal ID="literal_realizadas" runat="server"></asp:Literal>
                </table>

                <br />
                <h4><asp:Literal ID="lbl_totalPconta" runat="server"></asp:Literal></h4>

            </div>
        </div>
    </div>

    <br />
    <!-- GRID ENTREGAS NÃO EFETUADAS-->
    <div class="panel panel-success">
        <div class="panel-heading text-center">
            <h4 class="panel-title">Entregas não Realizadas</h4>
        </div>
        <div class="panel-body">
            <div class="w3-container w3-border w3-round w3-padding-16 w3-light-gray w3-small">
                <table id="tabela2" class="w3-table-all w3-hoverable">
                    <thead>
                        <tr class="w3-gray">
                            <th>Cliente</th>
                            <th>Destinatário</th>
                            <th>End/Num</th>
                            <th>Bairro</th>
                            <th>Cidade</th>
                            <th>Valor Cliente</th>
                            <th>Status</th>
                        </tr>
                    </thead>
                    <asp:Literal ID="literal_nao_Realizadas" runat="server"></asp:Literal>
                </table>
            </div>
        </div>
    </div>

</body>
</html>
