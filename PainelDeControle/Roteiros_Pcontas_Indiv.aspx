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

    <!-- Paginação -->
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.15/js/dataTables.bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.15/css/dataTables.bootstrap.min.css" />

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

        <div class="w3-container">
            <div class="w3-left">
                <h4>&nbsp;&nbsp;&nbsp;<asp:Literal ID="lbl_motoboy" runat="server"></asp:Literal></h4>
            </div>
        </div>

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
                <div class="w3-container">
                    <div>
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

                        <div class="col-md-2">
                            <button id="btstatus" type="button" class="w3-btn w3-round w3-border w3-light-green w3-hover-green"
                                 onclick="definir_status();">ALTERAR STATUS&nbsp;<i class="fa fa-check-square-o" aria-hidden="true"></i></button>
                        </div>

                        <div class="col-md-2">
                            <button id="bt_arquivar" type="button" class="w3-btn w3-round w3-border w3-light-blue w3-hover-red" 
                                onclick="arquivar();">ARQUIVAR&nbsp;<i class="fa fa-floppy-o" aria-hidden="true"></i></button>
                        </div>

                    </div>
                    <div class="w3-right">
                        <h4><asp:Literal ID="lbl_totalPconta" runat="server"></asp:Literal></h4>
                    </div>

                </div>
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
                <table id="MyTable" class="w3-table-all w3-hoverable">
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

                <br />

                <div class="w3-container">

                    <div class="w3-left">
                        <button id="bt_reagendar" type="button" class="w3-btn w3-round w3-border w3-light-blue w3-hover-blue btcontroles" onclick="">
                            Reagendamento&nbsp;<i class="fa fa-undo" aria-hidden="true"></i>
                        </button>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <!-- Auxiliares -->
    <input type="hidden" id="idAuxHidden" />
    <input type="hidden" id="nomeAuxHidden" />

    <!-- Paginação -->
    <script type="text/javascript" src="Scripts/codePaginacao.js"></script>
    <script type="text/javascript" src="Scripts/codePaginacaoX.js"></script>

    <!-- Scripts Diversas -->
    <script type="text/javascript">

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
                alert("Selecione uma entrega para alterar Status");
                $("body").css("cursor", "default");
                document.getElementById("btstatus").disabled = false;
                return
            }

            mensagem();

        }

        function mensagem() {

            var v1 = document.getElementById('idAuxHidden');
            var v2 = document.getElementById('nomeAuxHidden');

            alert("Ok. Atualizado");
            var linkurl = "Roteiros_Pcontas_Indiv.aspx?p1=" + v1 + "&p2=" + v2;
            window.location.href = linkurl;
        }

        function arquivar() {

            var conf = confirm("Confirma Arquivamento de entregas Realizadas ?");
            if (conf == false) { return; }

            var v1 = document.getElementById('idAuxHidden').value;

            $("body").css("cursor", "progress");
            document.getElementById("bt_arquivar").disabled = true;

            $.ajax({
                type: "POST",
                url: "wspainel.asmx/Roteiro_Arquivar",
                data: '{param1: "' + v1 + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $("body").css("cursor", "default");
                    alert("Ok. Arquivados");
                },
                failure: function (response) {
                    alert(response.d);
                }
            });

        }

    </script>

    <asp:Literal ID="Literal_Aux" runat="server"></asp:Literal>

</body>
</html>
