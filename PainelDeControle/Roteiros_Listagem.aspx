<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Roteiros_Listagem.aspx.cs" Inherits="Roteiros_Listagem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Listagem de Roteiros</title>

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
        <div class="panel-heading text-center">
            <h4 class="panel-title">Listagem de Roteiro</h4>
        </div>
    </div>

    <br />

    <!-- GRID Roteiros Lançados -->
    <div class="w3-container w3-border w3-round w3-padding-16 w3-light-gray w3-small">
        <div class="table-responsive">
            <table id="tabela" class="w3-table-all w3-hoverable">
                <thead>
                    <tr class="w3-gray">
                        <th>Cliente</th>
                        <th>Motoboy</th>
                        <th>Destinatário</th>
                        <th>End/Num</th>
                        <th>Bairro</th>
                        <th>Cidade</th>
                        <th>Valor Cliente</th>
                        <th>Status</th>
                    </tr>
                </thead>
                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
            </table>
        </div>
    </div>

    <!-- GRID Roteiros Lançados -->
    <div class="panel panel-success">
        <div class="panel-heading text-center">
            <h4 class="panel-title">Alterações</h4>
        </div>
        <div class="panel-body">
            <form class="form-horizontal">
                <fieldset>
                    <div class="form-group">
                        <div class="col-md-3">
                            <asp:Literal ID="Literal_Motoboy" runat="server"></asp:Literal>
                        </div>
                        <div class="col-md-2">
                            <button id="btselectmotoboy" type="button" class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="definir_motoboy()">
                                Alterar Motoboy&nbsp;<i class="fa fa-check-square-o" aria-hidden="true"></i></button>
                        </div>

                        <div class="col-md-3">
                            <select class="form-control" id="selectStatus">
                                <option selected value="0">Selecione um Status</option>
                                <option value="EM ABERTO">EM ABERTO</option>
                                <option value="ENTREGA REALIZADA">ENTREGA REALIZADA</option>
                                <option value="MUDOU-SE">MUDOU-SE</option>
                                <option value="AUSENTE">AUSENTE</option>
                                <option value="NÃO QUIZ RECEBER">NÃO QUIZ RECEBER</option>
                                <option value="ÁREA DE RISCO">ÁREA DE RISCO</option>
                                <option value="ENDEREÇO INSUFICIENTE">ENDEREÇO INSUFICIENTE</option>
                            </select>
                        </div>

                        <div class="col-md-4">
                            <button id="btstatus" type="button" class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="definir_status()">
                                Alterar Status&nbsp;<i class="fa fa-check-square-o" aria-hidden="true"></i></button>
                        </div>

                    </div>

                </fieldset>
            </form>
        </div>
    </div>

    <!-- Script Paginação  -->
    <script type="text/javascript" src="Scripts/codePaginacao.js"></script>

    <!-- Scripts Diversos-->
    <script type="text/javascript">

        function Excluir(r, idadux) {

            var conf = confirm("Confirma Exclusão ?");
            if (conf == false) { return; }

            $("body").css("cursor", "progress");

            $.ajax({
                type: "POST",
                url: "wspainel.asmx/Roteiro_Excluir",
                data: '{param1: "' + idadux + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    // excluir linha do Table
                    var i = r.parentNode.parentNode.rowIndex;
                    document.getElementById("tabela").deleteRow(i);
                    $("body").css("cursor", "default");
                },
                failure: function (response) {
                    alert(response.d);
                }
            });

        }

        function definir_motoboy() {

            var idaux_1 = document.getElementById("select_motoboy");
            var idaux_2 = idaux_1.options[idaux_1.selectedIndex].value;
            if (idaux_2 == "0") { alert("Selecione um Motoboy"); return }

            $("body").css("cursor", "progress");
            document.getElementById("btselectmotoboy").disabled = true;

            var registros = document.getElementsByName("chkselecao");
            var registros_len = registros.length;
            var marcados = 0;
            var aux_idEntrega = "";

            for (var i = 0; i < registros_len; i++) {
                if (registros[i].checked) {

                    marcados++;
                    aux_idEntrega = registros[i].value;

                    $.ajax({
                        type: "POST",
                        url: "wspainel.asmx/Roteiro_Alterar",
                        data: '{param0: "' + idaux_2 + '", param1: "' + aux_idEntrega + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        failure: function (response) {
                            alert("Problemas ao tentar definir Motoboys");
                        }
                    });
                }
            }

            if (marcados == 0) {
                alert("Selecione uma entrega");
                $("body").css("cursor", "default");
                document.getElementById("btselectmotoboy").disabled = false;
                return
            }

            mensagem();

        }

        function definir_status() {

            var idaux_1 = document.getElementById("selectStatus");
            var idaux_2 = idaux_1.options[idaux_1.selectedIndex].value;
            if (idaux_2 == "0") { alert("Selecione um Status"); return }

            $("body").css("cursor", "progress");
            document.getElementById("btstatus").disabled = true;

            var registros = document.getElementsByName("chkselecao");
            var registros_len = registros.length;
            var marcados = 0;
            var aux_idEntrega = "";

            for (var i = 0; i < registros_len; i++) {
                if (registros[i].checked) {

                    marcados++;
                    aux_idEntrega = registros[i].value;

                    $.ajax({
                        type: "POST",
                        url: "wspainel.asmx/Roteiro_Alterar_Status",
                        data: '{param0: "' + idaux_2 + '", param1: "' + aux_idEntrega + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        failure: function (response) {
                            alert("Problemas ao tentar definir Motoboys");
                        }
                    });
                }
            }

            if (marcados == 0) {
                alert("Selecione uma entrega");
                $("body").css("cursor", "default");
                document.getElementById("btstatus").disabled = false;
                return
            }

            mensagem();

        }

        function mensagem() {
            alert("Ok. Atualizado");
            var linkurl = "Roteiros_Listagem.aspx";
            window.location.href = linkurl;

        }

        function voltar() {
            window.location.href = "Roteiros_Clientes1.aspx";
        }

    </script>
</body>
</html>
