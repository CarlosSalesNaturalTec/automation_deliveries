﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Roteiros_Bairros.aspx.cs" Inherits="Roteiros_Bairros" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Lançamento de Roteiros - Definição de Motoboys</title>

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

    <br />

    <div class="panel panel-success">
        <br />
        <div class="panel-heading text-center">
            <h4 class="panel-title">Definir Motoboy</h4>
        </div>
        <div class="panel-body">
            <form class="form-horizontal">
                <fieldset>
                    <div class="form-group">
                        <label for="select_motoboy" class="col-md-1 control-label">Motoboy</label>
                        <div class="col-md-3">
                            <asp:Literal ID="Literal_Motoboy" runat="server"></asp:Literal>
                        </div>
                        <div class="col-md-3">

                            <button type="button" class="w3-btn w3-round w3-border w3-light-blue w3-hover-blue btcontroles" onclick="voltar()">
                                <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Voltar&nbsp;</button>

                            <button id="btselectmotoboy" type="button" class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="">
                                Definir&nbsp;<i class="fa fa-check-square-o" aria-hidden="true"></i></button>

                            <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>

                        </div>
                    </div>
                </fieldset>
            </form>
        </div>
    </div>

    <!-- GRID Roteiros Lançados por Bairro-->
    <div class="form-group">
        <div class="col-md-12 w3-border w3-padding w3-round w3-light-gray">
            <table id="MyTable" class="w3-table-all w3-hoverable">
                <thead>
                    <tr class="w3-grey">
                        <th>Bairro</th>
                        <th>Quant. Entregas</th>
                    </tr>
                </thead>
                <asp:Literal ID="Literal_grid" runat="server"></asp:Literal>
            </table>
        </div>
    </div>

    <!-- Auxiliares -->
    <script type="text/javascript">

        function voltar() {
            window.location.href = "Roteiros_Clientes1.aspx";
        }

    </script>


    <!-- Script Paginação  -->
    <script type="text/javascript" src="Scripts/codePaginacaoX.js"></script>


</body>
</html>
