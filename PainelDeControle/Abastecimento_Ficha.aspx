<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_Ficha.aspx.cs" Inherits="Abastecimento_Ficha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Ficha de Abastecimento</title>

    <!-- Jquery-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <!-- Styles: W3, BootsStrap, Font-Awesome -->
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />


</head>
<body>

    <form class="form-horizontal">
        <fieldset>
            <legend>Ficha de Abastecimento</legend>

            <input type="hidden" id="IDHidden" />

            <div class="form-group">
                <label for="inputData" class="col-md-1 control-label">Data</label>
                <div class="col-md-4">
                    <input type="text" class="form-control" id="inputData" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="inputNome" class="col-md-1 control-label">Nome</label>
                <div class="col-md-8">
                    <input type="text" class="form-control" id="inputNome" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="inputPlaca" class="col-md-1 control-label">Placa</label>
                <div class="col-md-4">
                    <input type="text" class="form-control" id="inputPlaca" readonly>
                </div>
                <label for="inputKm" class="col-md-1 control-label">Kilometragem</label>
                <div class="col-md-3">
                    <input type="number" class="form-control" id="inputKm" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="inputValor" class="col-md-1 control-label">Valor (R$)</label>
                <div class="col-md-3">
                    <input type="number" class="form-control" id="inputValor" readonly>
                </div>
            </div>

            <legend></legend>

            <div class="form-group">
                <div class="col-md-4 col-md-offset-1">
                    <button type="reset" class="btn btn-primary" onclick="cancelar()">Voltar</button>
                </div>
            </div>

        </fieldset>
    </form>

    <!-- preenche campos  -->
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <!-- preenche campos  -->

    <!-- Operações com Registro  -->
    <script type="text/javascript">

        function cancelar() {
            var linkurl = "../Abastecimento_Lista.aspx";
            window.location.href = linkurl;
        }
    </script>
    <!-- Operações com Registro  -->

</body>
</html>
