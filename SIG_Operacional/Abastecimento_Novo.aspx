<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_Novo.aspx.cs" Inherits="Abastecimento_Novo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Novo Abastecimento</title>

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">

    <script type="text/javascript" src="Scripts/jquery-3.1.1.min.js"></script>
    
</head>
<body>

    <form class="form-horizontal">
        <fieldset>
            <legend>Nova Autorização de Abastecimento</legend>

            <div class="form-group">
                <label for="inputPosto" class="col-md-1 control-label">Posto</label>
                <div class="col-md-8">
                    <input type="text" class="form-control" id="inputPosto" value="POSTO TREVO" readonly>
                </div>
            </div>

            <!-- Colaboradores -->
            <asp:Literal ID="LIteral_Colaborador" runat="server"></asp:Literal>
            <!-- Colaboradores -->

            <!-- Veiculos -->
            <asp:Literal ID="LIteral_Veiculos" runat="server"></asp:Literal>
            <!-- Veiculos -->

            <div class="form-group">
                <label for="inputKm" class="col-md-1 control-label">Kilometragem</label>
                <div class="col-md-4">
                    <input type="number" class="form-control" id="inputKm" value="0">
                </div>

                <label for="inputValor" class="col-md-1 control-label">Valor (R$)</label>
                <div class="col-md-3">
                    <input type="number" class="form-control" id="inputValor">
                </div>

            </div>

            <legend></legend>

            <div class="form-group">
                <div class="col-md-4 col-md-offset-1">
                    <button type="reset" class="btn btn-block btn-primary" onclick="cancelar()"><i class="fa fa-ban" aria-hidden="true"></i> CANCELAR</button>
                    <button type="button" class="btn btn-block btn-success" onclick="Salvar()" id="btsalvar">
                        <span class="fa fa-floppy-o"></span> SALVAR</button>
                </div>
            </div>

        </fieldset>
    </form>

    <!-- Operações com Registro  -->
    <script type="text/javascript">

        function Salvar() {

            var v1 = document.getElementById("inputPlaca").value
            var v2 = document.getElementById("inputNome").value
            var v3 = document.getElementById("inputValor").value
            var v4 = document.getElementById("inputKm").value

            $("body").css("cursor", "progress");
            document.getElementById("btsalvar").disabled = true;
           
            $.ajax({
                type: "POST",
                url: "WebService.asmx/AbastecimentoNovo",
                data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '"}',
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
            var linkurl = "../Abastecimento_Planilha.aspx";
            window.location.href = linkurl;
        }
    </script>
    <!-- Operações com Registro  -->

    <!-- Foco  -->
    <script type="text/javascript">
        document.getElementById("inputNome").focus();
    </script>
    <!-- Foco  -->

</body>
</html>
