<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_Novo.aspx.cs" Inherits="Abastecimento_Novo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Novo Abastecimento</title>

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Jquery-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <!-- Styles: W3, BootsStrap, Font-Awesome -->
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <!-- Paginação -->
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.15/js/dataTables.bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.15/css/dataTables.bootstrap.min.css" />

</head>

<body style="margin-left: 2%; margin-right: 2%">

    <br />

    <div class="panel panel-success">

        <div class="panel-heading text-center">
            <h4 class="panel-title">Nova Autorização de Abastecimento</h4>
        </div>

        <div class="panel-body">
            <form class="form-horizontal">
                <fieldset>

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
                            <button type="reset" class="btn btn-primary" onclick="cancelar()">Voltar</button>
                            <button type="button" class="btn btn-success" onclick="Salvar()" id="btsalvar">Salvar</button>
                        </div>
                    </div>

                </fieldset>
            </form>
        </div>

    </div>

    <div class="w3-row-padding ">
        <p>&nbsp;</p>
    </div>

    <!-- Planilha  -->
    <div class="w3-container w3-border w3-round w3-padding-16 w3-light-gray w3-small">
        <asp:Literal ID="Literal_Tabela" runat="server"></asp:Literal>
    </div>

    <!-- Script Paginação  -->
    <script type="text/javascript" src="Scripts/codePaginacao.js"></script>

    <!-- Scripts diversas -->
    <script type="text/javascript" src="Scripts/codeAbast_Novo.js"></script>

</body>
</html>
