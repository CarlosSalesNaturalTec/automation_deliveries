<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Orcamento_Solicita.aspx.cs" Inherits="Orcamento_Solicita" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Orçamentos</title>
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

    <style>
        body {
            background-color:inherit;
        }
        form {
            padding-left :26em;
        }
    </style>

</head>

<body>

    <form class="form-horizontal">
        <fieldset>
            <legend>Orçamento</legend>

            <p>Entre em contato e solicite uma proposta. Deixe a LOG ajudá-lo a aperfeiçoar a sua logística. Preencha nosso formulário para </p>
            <p>que possamos customizar uma proposta comercial que atenda perfeitamente sua necessidade.</p>
            <br />

            <div class="form-group">
                <label for="inputEmpresa" class="col-md-1">Empresa</label>
                <div class="col-md-9">
                    <input type="text" class="form-control" id="inputEmpresa" required>
                </div>
            </div>

            <div class="form-group">
                <label for="inputContato" class="col-md-1 control-label">Contato</label>
                <div class="col-md-9">
                    <input type="text" class="form-control" id="inputContato" required >
                </div>
            </div>

            <div class="form-group">
                <label for="inputTelefone" class="col-md-1 control-label">Telefone</label>
                <div class="col-md-9">
                    <input type="text" class="form-control" id="inputTelefone" required>
                </div>
            </div>

            <div class="form-group">
                 <label for="inputEmail" class="col-md-1 control-label">E-mail</label>
                <div class="col-md-9">
                    <input type="email" class="form-control" id="inputEmail" required>
                </div>
            </div>

            <div class="form-group">
                <label for="inputNecessidade" class="col-md-1 control-label">Necessidade</label>
                <div class="col-md-3">
                    <select class="form-control" id="inputNecessidade" name="inputNecessidade">
                        <option>Motoboy</option>
                        <option>Motorista</option>
                        <option>Veículo</option>
                        <option>Outros</option>
                    </select>
                </div>

                <label for="inputDisponibilidade" class="col-md-1 control-label">Disponibilidade</label>
                <div class="col-md-3">
                    <select class="form-control" id="inputDisponibilidade" name="inputDisponibilidade">
                        <option>Integral</option>
                        <option>Turno - Manhã</option>
                        <option>Turno - Tarde</option>
                        <option>Eventual</option>
                    </select>
                </div>

            </div>

            <legend></legend>

            <div class="form-group">
                <label for="inputPerfil" class="col-md-1 control-label">Perfil</label>
                <div class="col-md-9">
                    <textarea class="form-control" rows="3" id="inputPerfil"></textarea>
                </div>
            </div>

            <legend></legend>

            <div class="form-group">
                <div class="col-md-4 col-md-offset-1">
                    <button type="button" class="btn btn-success" onclick="SalvarRegistro()" id="btSalvar">Solicitar</button>
                </div>
            </div>

        </fieldset>
    </form>

    <!-- Salvar Registro  -->
    <script type="text/javascript">
        function SalvarRegistro() {

            var v1 = document.getElementById("inputEmpresa").value
            var v2 = document.getElementById("inputContato").value
            var v3 = document.getElementById("inputEmail").value
            var v4 = document.getElementById("inputTelefone").value
            var v5 = document.getElementById("inputPerfil").value
            var v6 = document.getElementById("inputNecessidade").value
            var v7 = document.getElementById("inputDisponibilidade").value

            if (v1 == "") {
                alert("Informe Nome da Empresa");
                document.getElementById("inputEmpresa").focus();
                return;
            }

            $("body").css("cursor", "progress");
            document.getElementById("btSalvar").disabled = true;

            $.ajax({
                type: "POST",
                url: "wspainel.asmx/SalvarOrcamento",
                data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 + '", param6: "' + v6 + '", param7: "' + v7 + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    document.getElementById("btSalvar").style.cursor = "default";
                    var linkurl = response.d;
                    window.open(linkurl,"_self")
                },
                failure: function (response) {
                    alert(response.d);
                }
            });

            $("body").css("cursor", "default");
        }
    </script>
    <!-- Salvar Registro  -->

    <!-- Foco  -->
    <script type="text/javascript">
        document.getElementById("inputEmpresa").focus();
    </script>


</body>
</html>
