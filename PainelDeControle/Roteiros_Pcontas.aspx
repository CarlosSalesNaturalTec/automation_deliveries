<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Roteiros_Pcontas.aspx.cs" Inherits="Roteiros_Pcontas" %>

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

    <!-- Paginação -->
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.15/js/dataTables.bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.15/css/dataTables.bootstrap.min.css" />

</head>

<body style="margin-left: 2%; margin-right: 2%">

    <!-- GRID Entregas Realizadas -->
    <br />
    <div class="panel panel-success">
        <div class="panel-heading text-center">
            <h4 class="panel-title">Prestação de Contas</h4>
        </div>
        <div class="panel-body">
            <div class="w3-container w3-border w3-round w3-padding-16 w3-light-gray w3-small">
                <table id="tabela" class="w3-table-all w3-hoverable">
                    <thead>
                        <tr class="w3-gray">
                            <th>Motoboy</th>
                            <th>Quant. Total</th>
                            <th>Valor Total</th>
                        </tr>
                    </thead>
                    <asp:Literal ID="Literal_grid1" runat="server"></asp:Literal>
                </table>
            </div>
        </div>
    </div>

    <div class="w3-container">
        <div class="col-md-3">
            <button id="btvoltar" type="button" class="w3-btn w3-round w3-border w3-light-gray w3-hover-gray btcontroles" onclick="window.location.href ='Roteiros_Clientes1.aspx';">
                Voltar&nbsp;<i class="fa fa-undo" aria-hidden="true"></i></button>
        </div>
    </div>

    <!-- Script Paginação  -->
    <script type="text/javascript" src="Scripts/codePaginacao.js"></script>

</body>
</html>
