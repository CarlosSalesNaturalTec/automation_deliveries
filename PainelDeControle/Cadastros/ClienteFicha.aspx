<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClienteFicha.aspx.cs" Inherits="ClienteFicha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <style type="text/css">
        #results {
            float: right;
            margin: 5px;
            padding: 5px;
            border: 1px solid;
            background: #ccc;
        }
    </style>

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <script type="text/javascript" src="Scripts/jquery-3.1.1.min.js"></script>
    <script type="text/javascript" src="Scripts/webcam.js"></script>

</head>
<body>

    <form class="form-horizontal">
        <fieldset>
            <legend>Ficha Cliente</legend>

            <div class="form-group">
                <label for="inputNome" class="col-md-1 control-label">Nome</label>
                <div class="col-md-8">
                    <input type="text" class="form-control" id="inputNome">
                </div>
            </div>

            <div class="form-group">
                <label for="inputResponsavel" class="col-md-1 control-label">Respons.</label>
                <div class="col-md-8">
                    <input type="text" class="form-control" id="inputResponsavel">
                </div>
            </div>

            <div class="form-group">
                <label for="inputEmail" class="col-md-1 control-label">E-mail</label>
                <div class="col-md-8">
                    <input type="text" class="form-control" id="inputEmail">
                </div>
            </div>

            <div class="form-group">
                <label for="inputTelefone" class="col-md-1 control-label">Telefone</label>
                <div class="col-md-8">
                    <input type="text" class="form-control" id="inputTelefone">
                </div>
            </div>

            <div class="form-group">
                <label for="inputUsuario" class="col-md-1 control-label">Usuario</label>
                <div class="col-md-4">
                    <input type="text" class="form-control" id="inputUsuario" placeholder="Acesso ao Painel de Controle">
                </div>

                <label for="inputSenha" class="col-md-1 control-label">Senha</label>
                <div class="col-md-3">
                    <input type="password" class="form-control" id="inputSenha">
                </div>
            </div>

            <legend></legend>

            <input id="IDHidden" name="IDHidden" type="hidden" />

            <div class="form-group">
                <div class="col-md-4 col-md-offset-1">
                    <button type="button" class="btn btn-danger" onclick="ExcluirRegistro()">Excluir</button>
                    <button type="reset" class="btn btn-primary" onclick="cancelar()">Cancelar</button>
                    <button type="button" class="btn btn-success" onclick="AtualizarRegistro()">Salvar</button>
                </div>
            </div>

        </fieldset>
    </form>

    <!-- preenche campos  -->
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <!-- preenche campos  -->

    <!-- Operações com Registro  -->
    <script type="text/javascript">

        function AtualizarRegistro() {

            var v1 = document.getElementById("inputNome").value
            var v2 = document.getElementById("inputResponsavel").value
            var v3 = document.getElementById("inputEmail").value
            var v4 = document.getElementById("inputTelefone").value
            var v5 = document.getElementById("IDHidden").value
            var v6 = document.getElementById("inputUsuario").value
            var v7 = document.getElementById("inputSenha").value

            $.ajax({
                type: "POST",
                url: "wspainel.asmx/EditarCliente",
                data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 + '", param6: "' + v6 + '", param7: "' + v7 + '" }',
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

        function ExcluirRegistro() {

            var r = confirm("CONFIRMA EXCLUSÂO ?");
            if (r == false) {
                return;
            } 

            var v1 = document.getElementById("IDHidden").value

            $.ajax({
                type: "POST",
                url: "wspainel.asmx/ExcluirCliente",
                data: '{param1: "' + v1 + '" }',
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

        function cancelar() {
            var linkurl = "../Clientes.aspx";
            window.location.href = linkurl;
        }
    </script>
    <!-- Operações com Registro  -->

</body>
</html>
