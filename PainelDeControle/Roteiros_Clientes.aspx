﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Roteiros_Clientes.aspx.cs" Inherits="Roteiros_Clientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Lançamento de Roteiros - Selecione Cliente</title>

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!-- Jquery-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <!-- Styles: W3, BootsStrap, Font-Awesome -->
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

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

        <div class="panel-heading text-center">
            <h4 class="panel-title">Selecione um Cliente / Motoboy</h4>
        </div>

        <div class="panel-body">
            <form class="form-horizontal">

                <fieldset>
                    <br />

                    <div class="form-group">
                        <label for="select_empresa" class="col-md-1 control-label">Cliente</label>
                        <div class="col-md-6">
                            <asp:Literal ID="Literal_Empresa" runat="server"></asp:Literal>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="select_motoboy" class="col-md-1 control-label">Motoboy</label>
                        <div class="col-md-4">
                            <asp:Literal ID="Literal_Motoboy" runat="server"></asp:Literal>
                        </div>
                        <div class="col-md-4">
                            <button type="button" class="w3-btn w3-round w3-border w3-light-blue w3-hover-blue btcontroles" onclick="Roteiros_Cancelar()">
                                <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Voltar</button>

                            <button type="button" class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="Roteiros_Avançar()">
                                Avançar&nbsp;<i class="fa fa-arrow-circle-right" aria-hidden="true"></i></button>
                            <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                        </div>
                    </div>

                </fieldset>
            </form>
        </div>

    </div>

    <!-- GRID Roteiros Lançados -->

    <div class="panel panel-success">
        <div class="panel-heading text-center">
            <h4 class="panel-title">Roteiros já Lançados</h4>
        </div>
    </div>

    <div class="w3-container w3-border w3-round w3-padding-16 w3-light-gray w3-small">
        <table id="tabela" class="w3-table-all w3-hoverable">
            <thead>
                <tr class="w3-gray">
                    <th>Cliente</th>
                    <th>Motoboy</th>
                    <th>Destinatário</th>
                    <th>Bairro</th>
                    <th>Cidade</th>
                    <th>Valor</th>
                </tr>
            </thead>
            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
        </table>
    </div>

    <!-- Auxiliares -->
    <script type="text/javascript" src="Scripts/codeRoteiros_Clientes.js"></script>

    <!-- Script Paginação  -->
    <script type="text/javascript" src="Scripts/codePaginacao.js"></script>


</body>
</html>
