<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Orcamento_Ficha.aspx.cs" Inherits="Orcamento_Ficha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Orçamentos Solicitados</title>

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <script type="text/javascript" src="Scripts/jquery-3.1.1.min.js"></script>
    <script type="text/javascript" src="Scripts/webcam.js"></script>

</head>
<body>
    <form class="form-horizontal" id="view1">

        <fieldset>
            <legend>Solicitação de Orçamento</legend>

            <input type="hidden" id="IDHidden" />

            <div class="form-group">
                <label for="inputEmpresa" class="col-md-1">Empresa</label>
                <div class="col-md-9">
                    <input type="text" class="form-control" id="inputEmpresa" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="inputContato" class="col-md-1 control-label">Contato</label>
                <div class="col-md-9">
                    <input type="text" class="form-control" id="inputContato" readonly >
                </div>
            </div>

            <div class="form-group">
                <label for="inputTelefone" class="col-md-1 control-label">Telefone</label>
                <div class="col-md-9">
                    <input type="text" class="form-control" id="inputTelefone" readonly>
                </div>
            </div>

            <div class="form-group">
                 <label for="inputEmail" class="col-md-1 control-label">E-mail</label>
                <div class="col-md-9">
                    <input type="text" class="form-control" id="inputEmail" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="inputNecessidade" class="col-md-1 control-label">Necessidade</label>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputNecessidade" readonly>
                </div>

                <label for="inputDisponibilidade" class="col-md-1 control-label">Disponibilidade</label>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputDisponibilidade" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="inputPerfil" class="col-md-1 control-label">Perfil</label>
                <div class="col-md-9">
                    <textarea class="form-control" rows="3" id="inputPerfil" readonly></textarea>
                </div>
            </div>

            <div class="form-group">

                <label for="inputData" class="col-md-1 control-label">Data da Solicitação</label>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputData" readonly>
                </div>

                <label for="inputStatus" class="col-md-1 control-label">Status</label>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputStatus" readonly>
                </div>

            </div>

            <br />

            <legend>Proposta Comercial</legend>

            <div class="form-group">
                <label for="inputRoteiro" class="col-md-1 control-label">Roteiro</label>
                <div class="col-md-9">
                    <input type="text" class="form-control"  id="inputRoteiro">
                </div>
            </div>

            <div class="form-group">
                <label for="inputPeriodo" class="col-md-1 control-label">Período</label>
                <div class="col-md-9">
                    <input type="text" class="form-control" id="inputPeriodo">
                </div>
            </div>

            <div class="form-group">
                <label for="inputFuncionario" class="col-md-1 control-label">Funcionario</label>
                <div class="col-md-9">
                    <input type="text" class="form-control" id="inputFuncionario">
                </div>
            </div>

            <div class="form-group">
                <label for="inputHorario" class="col-md-1 control-label">Horário</label>
                <div class="col-md-9">
                    <input type="text" class="form-control" id="inputHorario">
                </div>
            </div>

            <div class="form-group">
                <label for="inputFranquia" class="col-md-1 control-label">Franquia</label>
                <div class="col-md-9">
                    <input type="text" class="form-control" id="inputFranquia">
                </div>
            </div>

            <div class="form-group">
                <label for="inputValor1" class="col-md-1 control-label">Valor 1:</label>
                <div class="col-md-2">
                    <input type="number" class="form-control" id="inputValor1">
                </div>

                <label for="inputDescricao1" class="col-md-1 control-label">Descrição:</label>
                <div class="col-md-6">
                    <textarea class="form-control" rows="3" id="inputDescricao1"></textarea>
                </div>
            </div>

            <div class="form-group">
                <label for="inputValor2" class="col-md-1 control-label">Valor 2:</label>
                <div class="col-md-2">
                    <input type="number" class="form-control" id="inputValor2">
                </div>

                <label for="inputDescricao2" class="col-md-1 control-label">Descrição:</label>
                <div class="col-md-6">
                    <textarea class="form-control" rows="3" id="inputDescricao2"></textarea>
                </div>
            </div>

            <div class="form-group">
                <label for="inputValor3" class="col-md-1 control-label">Valor 3:</label>
                <div class="col-md-2">
                    <input type="number" class="form-control" id="inputValor3">
                </div>

                <label for="inputDescricao3" class="col-md-1 control-label">Descrição:</label>
                <div class="col-md-6">
                    <textarea class="form-control" rows="3" id="inputDescricao3"></textarea>
                </div>
            </div>

            <div class="form-group">
                <label for="inputObsGerais" class="col-md-1 control-label">Observações</label>
                <div class="col-md-9">
                    <textarea class="form-control" rows="3" id="inputObsGerais"></textarea>
                </div>
            </div>

            <legend></legend>

            <div class="form-group">
                <div class="col-md-4 col-md-offset-1">
                    <button type="button" class="btn btn-primary" onclick="Voltar()" id="btVoltar">Voltar</button>                    
                    <button type="button" class="btn btn-success" onclick="GerarProposta()" id="btGerar">Gerar Proposta</button>
                </div>
            </div>

        </fieldset>
    </form>
</body>
    
    <!-- Botão Voltar -->
    <script type="text/javascript">
        function Voltar() {
            window.location.href = "../Orcamento_lista.aspx#view1";
        }
    </script>
    <!-- Botão Voltar -->


    <!-- Gerar Porposta Comercial  -->
    <script type="text/javascript">
        function GerarProposta() {

            var r = confirm("CONFIRMA GERAÇÃO DE PROPOSTA COMERCIAL?");
            if (r == false) {
                return;
            }

            var v1 = document.getElementById("IDHidden").value
            var v2 = document.getElementById("inputRoteiro").value
            var v3 = document.getElementById("inputPeriodo").value
            var v4 = document.getElementById("inputFuncionario").value
            var v5 = document.getElementById("inputHorario").value
            var v6 = document.getElementById("inputFranquia").value
            var v7 = document.getElementById("inputValor1").value
            var v8 = document.getElementById("inputDescricao1").value
            var v9 = document.getElementById("inputValor2").value
            var v10 = document.getElementById("inputDescricao2").value
            var v11 = document.getElementById("inputValor3").value
            var v12 = document.getElementById("inputDescricao3").value
            var v13 = document.getElementById("inputObsGerais").value

            document.getElementById("btGerar").disabled = true;

            $.ajax({
                type: "POST",
                url: "wspainel.asmx/GerarProposta",
                data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 +
                    '", param6: "' + v6 + '", param7: "' + v7 + '", param8: "' + v8 + '", param9: "' + v9 + '", param10: "' + v10 +
                    '", param11: "' + v11 + '", param12: "' + v12 + '", param13: "' + v13 + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var linkurl = response.d;
                    window.location.href = linkurl;
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
    </script>
    <!-- Gerar Porposta Comercial -->


    <!-- Excluir Registro  -->
    <script type="text/javascript">
        function ExcluirRegistro() {

            var r = confirm("CONFIRMA EXCLUSÂO DE ORÇAMENTO?");
            if (r == false) {
                return;
            }

            var v1 = document.getElementById("IDHidden").value
            
            document.getElementById("btExcluir").disabled = true;

            $.ajax({
                type: "POST",
                url: "wspainel.asmx/ExcluirOrcamento",
                data: '{param1: "' + v1 + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var linkurl = response.d;
                    window.location.href = linkurl;
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
    </script>
    <!-- Excluir Registro  -->

    <!-- preenche campos  -->
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <!-- preenche campos  -->

    <!-- Foco  -->
    <script type="text/javascript">
        document.getElementById("inputRoteiro").focus();
    </script>
    <!-- Foco  -->


</html>
