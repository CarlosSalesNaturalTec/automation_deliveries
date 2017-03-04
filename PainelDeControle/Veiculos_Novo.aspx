<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Veiculos_Novo.aspx.cs" Inherits="Veiculos_Novo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <script type="text/javascript" src="Scripts/jquery-3.1.1.min.js" ></script>

</head>
<body>

    <form class="form-horizontal">
        <fieldset>
            <legend>Novo Veículo</legend>

             <div class="form-group">
                <label for="inputPlaca" class="col-md-1 control-label">Placa</label>
                <div class="col-md-8">
                    <input type="text" class="form-control" id="inputPlaca">
                </div>
            </div>

            <div class="form-group">
                <label for="inputModelo" class="col-md-1 control-label">Modelo</label>
                <div class="col-md-8">
                    <input type="text" class="form-control" id="inputModelo">
                </div>
            </div>


            <legend></legend>

            <div class="form-group">
                <div class="col-md-4 col-md-offset-1">
                    <button type="reset" class="btn btn-primary" onclick="cancelar()">Cancelar</button>
                    <button type="button" class="btn btn-success" onclick="SalvarRegistro()" id="btSalvar">Salvar</button>
                </div>
            </div>

        </fieldset>
    </form>

    <!-- Salvar Registro  -->
    <script type="text/javascript">
        function SalvarRegistro() {

            document.getElementById("btSalvar").style.cursor = "progress";

            var v1 = document.getElementById("inputPlaca").value
            var v2 = document.getElementById("inputModelo").value

            if (v1 == "") {
                alert("Informe Placa do Veículo");
                document.getElementById("inputPlaca").focus();
                return;
            }

            $.ajax({
                type: "POST",
                url: "wspainel.asmx/SalvarVeiculo",
                data: '{param1: "' + v1 + '", param2: "' + v2 + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    document.getElementById("btSalvar").style.cursor = "default";
                    var linkurl = response.d;
                    window.location.href = linkurl;
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        function cancelar() {
            var linkurl = "../Veiculos_Lista.aspx";
            window.location.href = linkurl;
        }
    </script>
    <!-- Salvar Registro  -->

    <!-- Foco  -->
    <script type="text/javascript">
        document.getElementById("inputPlaca").focus();
    </script>
    
</body>

</html>
