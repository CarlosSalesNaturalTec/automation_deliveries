<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_Credito.aspx.cs" Inherits="Abastecimento_Credito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Lançamento de Crédito - Pagamento antecipado</title>

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <script type="text/javascript" src="Scripts/jquery-3.1.1.min.js"></script>
    
</head>
<body>

    <form class="form-horizontal">
        <fieldset>
            <legend>Lançamento de Crédito</legend>


            <div class="form-group">
                <label for="inputPosto" class="col-md-1 control-label">Posto</label>
                <div class="col-md-8">
                    <input type="text" class="form-control" id="inputPosto" value="POSTO TREVO" readonly>
                </div>
            </div>

            <div class="form-group">
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

    <!-- Preenche Data  -->
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <!-- Preenche Data  -->

    <!-- Operações com Registro  -->
    <script type="text/javascript">

        function Salvar() {

            var v1 = document.getElementById("inputValor").value

            $("body").css("cursor", "progress");
            document.getElementById("btsalvar").disabled = true;
           
            $.ajax({
                type: "POST",
                url: "WebService.asmx/AbastecimentoCredito",
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

        function cancelar() {
            var linkurl = "../Abastecimento_Planilha.aspx";
            window.location.href = linkurl;
        }
    </script>
    <!-- Operações com Registro  -->

    <!-- Foco  -->
    <script type="text/javascript">
        document.getElementById("inputValor").focus();
    </script>
    <!-- Foco  -->

</body>
</html>
