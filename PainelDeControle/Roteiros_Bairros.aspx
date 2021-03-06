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

    <!-- GRID Roteiros Lançados por Bairro-->
    <div class="col-md-12 w3-border w3-padding w3-round w3-light-gray">
        <table id="MyTable" class="w3-table-all w3-hoverable">
            <thead>
                <tr class="w3-grey">
                    <th>Bairro</th>
                    <th>Quant. Entregas</th>
                    <th>Cliente</th>
                </tr>
            </thead>
            <asp:Literal ID="Literal_grid" runat="server"></asp:Literal>
        </table>
    </div>

    <br />

    <div class="panel panel-success">
         <div class="panel-heading text-center">
            <h4 class="panel-title">Definir Motoboy</h4>
        </div>
        <div class="panel-body">
            <form class="form-horizontal">
                <fieldset>
                    <div class="form-group">
                        <div class="col-md-3">
                            <asp:Literal ID="Literal_Motoboy" runat="server"></asp:Literal>
                        </div>
                        <div class="col-md-6">
                            <button id="btvoltar" type="button" class="w3-btn w3-round w3-border w3-light-gray w3-hover-gray btcontroles" onclick="voltar()">
                                Voltar&nbsp;<i class="fa fa-undo" aria-hidden="true"></i></button>

                            &nbsp;&nbsp;&nbsp;

                            <button id="btselectmotoboy" type="button" class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="definir_motoboy()">
                                Definir&nbsp;<i class="fa fa-check-square-o" aria-hidden="true"></i></button>
                        </div>
                    </div>
                </fieldset>
            </form>
        </div>
    </div>

    <!-- Auxiliares -->
    <script type="text/javascript">

        function definir_motoboy() {

            var idaux_1 = document.getElementById("select_motoboy");
            var idaux_2 = idaux_1.options[idaux_1.selectedIndex].value;
            if (idaux_2 == "0") { alert("Selecione um Motoboy"); return }

            $("body").css("cursor", "progress");
            document.getElementById("btselectmotoboy").disabled = true;

            var registros = document.getElementsByName("chkselecao");
            var registros_len = registros.length;
            var marcados = 0;
            var atualizados = 0;
            var aux_bairro = "";

            for (var i = 0; i < registros_len; i++) {
                if (registros[i].checked) {

                    marcados++;
                    aux_bairro = registros[i].value;

                    $.ajax({
                        type: "POST",
                        url: "wspainel.asmx/Roteiro_Bairro_Motoboy",
                        data: '{param0: "' + idaux_2 + '", param1: "' + aux_bairro + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            atualizados++;
                        },
                        failure: function (response) {
                            alert("Problemas ao tentar definir Motoboys");
                        }
                    });
                }
            }

            if (marcados == 0) { alert("Selecione um Bairro"); return }

            mensagem();

        }

        function mensagem() {
            alert("Ok");
            var linkurl = "Roteiros_Bairros.aspx";
            window.location.href = linkurl;
        }

        function voltar() {
            var linkurl = "Roteiros_Clientes1.aspx";
            window.location.href = linkurl;
        }

    </script>

    <!-- Script Paginação  -->
    <script type="text/javascript" src="Scripts/codePaginacaoX.js"></script>

</body>
</html>
