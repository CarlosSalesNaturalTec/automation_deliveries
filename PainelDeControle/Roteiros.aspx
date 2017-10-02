<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Roteiros.aspx.cs" Inherits="Roteiros" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Lançamento de Roteiro</title>

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
            <h4 class="panel-title">Lançar Roteiros</h4>
        </div>

        <div class="panel-body">
            <form class="form-horizontal">

                <fieldset>
                    <br />

                    <div class="form-group">
                        <label for="select_empresa" class="col-md-1 control-label">Empresa</label>
                        <div class="col-md-9">
                            <asp:Literal ID="Literal_Empresa" runat="server"></asp:Literal>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="input_end" class="col-md-1 control-label">Endereço</label>
                        <div class="col-md-6">
                            <input type="text" class="form-control" id="input_end">
                        </div>
                        <label for="input_num" class="col-md-1 control-label">Número</label>
                        <div class="col-md-2">
                            <input type="text" class="form-control" id="input_num">
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="input_bairro" class="col-md-1 control-label">Bairro</label>
                        <div class="col-md-4">
                            <input type="text" class="form-control" id="input_bairro">
                        </div>
                        <label for="select_Cidade" class="col-md-1 control-label">Cidade</label>
                        <div class="col-md-4">
                            <select class="form-control" id="select_Cidade">
                            </select>
                        </div>
                    </div>



                    <div class="form-group">
                        <label for="select_placa" class="col-md-1 control-label">Obs</label>
                        <div class="col-md-4">
                            <input type="text" class="form-control" id="input_obs">
                        </div>
                        <label for="select_motoboy" class="col-md-1 control-label">Motoboy</label>
                        <div class="col-md-4">
                            <asp:Literal ID="Literal_Motoboy" runat="server"></asp:Literal>
                        </div>
                    </div>

                    <legend></legend>

                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-1">
                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                                <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Fechar</button>

                            <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="SalvarRegistro()">
                                <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Adicionar&nbsp;&nbsp;
                            </button>

                            <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                        </div>
                    </div>

                </fieldset>
            </form>
        </div>

    </div>

    <!-- Auxiliares -->
    <script type="text/javascript" src="Scripts/codeRoteiros.js"></script>

</body>
</html>
