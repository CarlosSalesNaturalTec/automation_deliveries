<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Veiculos_Ficha.aspx.cs" Inherits="Veiculos_Ficha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!-- Jquery-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <!-- Styles: W3, BootsStrap, Font-Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
   
    
</head>
<body>

    <form class="form-horizontal">
        <fieldset>
            <legend>Ficha de Veículo</legend>

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

            var v1 = document.getElementById("inputPlaca").value
            var v2 = document.getElementById("inputModelo").value
            var v3 = document.getElementById("IDHidden").value

            $.ajax({
                type: "POST",
                url: "wspainel.asmx/EditarVeiculo",
                data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '"}',
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

            var r = confirm("CONFIRMA EXCLUSÂO DE VEÍCULO?");
            if (r == false) {
                return;
            } 

            var v1 = document.getElementById("IDHidden").value

            $.ajax({
                type: "POST",
                url: "wspainel.asmx/ExcluirVeiculo",
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
            var linkurl = "../Veiculos_Lista.aspx";
            window.location.href = linkurl;
        }
    </script>
    <!-- Operações com Registro  -->

</body>
</html>
