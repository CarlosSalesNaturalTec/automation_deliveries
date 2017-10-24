<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Roteiros_Simplificado.aspx.cs" Inherits="Roteiros_Simplificado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Lançamento de Entrega Simples</title>

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

     <!-- Autocomplete -->
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <!-- Paginação sem Jquery-->
    <script src="https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.15/js/dataTables.bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.15/css/dataTables.bootstrap.min.css" />

</head>

<body style="margin-left: 2%; margin-right: 2%">

    <br />

    <div class="panel panel-success">

        <div class="panel-heading text-center">
            <h4 class="panel-title">Lançamento de Entrega Simples</h4>
        </div>

        <div class="panel-body">
            <form class="form-horizontal">
                <fieldset>
                    <div class="form-group">
                        <label for="input_end" class="col-md-1 control-label">Endereço</label>
                        <div class="col-md-3">
                            <input type="text" class="form-control" id="input_end" />
                        </div>

                        <label for="input_bairro" class="col-md-1 control-label">Bairro</label>
                        <div class="col-md-3">
                            <input type="text" class="form-control" id="input_bairro" />
                        </div>

                        <div class="col-md-2">
                            <button id="btSalvar" type="button" class="w3-btn w3-round w3-border w3-light-gray w3-hover-gray w3-block" onclick="voltar()">
                                Voltar&nbsp;&nbsp;<i class="fa fa-undo" aria-hidden="true"></i></button>
                        </div>

                    </div>

                    <div class="form-group">
                        <label for="select_Cidade" class="col-md-1 control-label">Cidade</label>
                        <div class="col-md-3">
                            <asp:Literal ID="Literal_Cidade" runat="server"></asp:Literal>
                        </div>

                        <label for="input_cli" class="col-md-1 control-label">Cliente</label>
                        <div class="col-md-3">
                            <input type="text" class="form-control" id="input_cli" disabled />
                        </div>

                        <div class="col-md-2">
                            <button id="btvoltar" type="button" class="w3-btn w3-round w3-border w3-light-green w3-hover-green w3-block" onclick="Adicionar()">
                                Adicionar&nbsp;&nbsp;<i class="fa fa-arrow-circle-right" aria-hidden="true"></i></button>
                        </div>

                    </div>

                </fieldset>
            </form>
        </div>
    </div>

    <div class="panel panel-success">
        <div class="panel-heading text-center">
            <h4 class="panel-title">Roteiro Lançado</h4>
        </div>
    </div>

    <!-- GRID Roteiros Lançados -->
    <div class="form-group">
        <div class="col-md-12 w3-border w3-padding w3-round w3-light-gray">
            <table id="MyTable" class="w3-table-all w3-hoverable">
                <thead>
                    <tr class="w3-grey">
                        <th>Endereço</th>
                        <th>Bairro</th>
                        <th>Cidade</th>
                        <th>ID Motoboy</th>
                    </tr>
                </thead>
                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
            </table>
        </div>
    </div>

    <!-- Auxiliares -->
    <input type="hidden" id="ID_Cli_Hidden" />
    <asp:Literal ID="Literal_aux" runat="server"></asp:Literal>

    <!-- Autocomplete -->
    <asp:Literal ID="Literal_AutoComplete" runat="server"></asp:Literal>

    <!-- Script Paginação  -->
    <script type="text/javascript" src="Scripts/codePaginacaoX.js"></script>
    <script type="text/javascript" src="Scripts/codeRoteiros_Simplificado.js"></script>

</body>
</html>
