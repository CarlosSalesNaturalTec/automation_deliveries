<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_Novo.aspx.cs" Inherits="Abastecimento_Novo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Novo Abastecimento</title>

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <script type="text/javascript" src="Scripts/jquery-3.1.1.min.js"></script>
    
</head>
<body>

    <form class="form-horizontal">
        <fieldset>
            <legend>Novo abastecimento</legend>

            <div class="form-group">
                <label for="inputNome" class="col-md-1 control-label">Nome</label>
                <div class="col-md-8">
                    <input type="text" class="form-control" id="inputNome">
                </div>
            </div>

            <div class="form-group">
                <label for="inputModelo" class="col-md-1 control-label">Modelo</label>
                <div class="col-md-4">
                    <input type="text" class="form-control" id="inputModelo">
                </div>
                <label for="inputPlaca" class="col-md-1 control-label">Placa</label>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputPlaca">
                </div>
            </div>

            <div class="form-group">
                <label for="inputKm" class="col-md-1 control-label">Kilometragem</label>
                <div class="col-md-4">
                    <input type="number" class="form-control" id="inputKm">
                </div>
                <label for="inputValor" class="col-md-1 control-label">Valor (R$)</label>
                <div class="col-md-3">
                    <input type="number" class="form-control" id="inputValor">
                </div>
            </div>

            <legend></legend>

            <div class="form-group">
                <div class="col-md-4 col-md-offset-1">
                    <button type="reset" class="btn btn-primary" onclick="cancelar()">Cancelar</button>
                    <button type="button" class="btn btn-success" onclick="Salvar()" id="btsalvar">Salvar</button>
                </div>
            </div>

        </fieldset>
    </form>

    <!-- Operações com Registro  -->
    <script type="text/javascript">

        function Salvar() {

            var v1 = document.getElementById("inputModelo").value
            var v2 = document.getElementById("inputPlaca").value
            var v3 = document.getElementById("inputNome").value
            var v4 = document.getElementById("inputValor").value
            var v5 = document.getElementById("inputKm").value

            $("body").css("cursor", "progress");
            document.getElementById("btsalvar").disabled = true;
           
            $.ajax({
                type: "POST",
                url: "wspainel.asmx/AbastecimentoNovo",
                data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 + '"}',
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
            var linkurl = "../Abastecimento_Lista.aspx";
            window.location.href = linkurl;
        }
    </script>
    <!-- Operações com Registro  -->

    <!-- Foco  -->
    <script type="text/javascript">
        document.getElementById("inputPlaca").focus();
    </script>
    <!-- Foco  -->

</body>
</html>
