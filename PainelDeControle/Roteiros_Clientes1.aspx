<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Roteiros_Clientes1.aspx.cs" Inherits="Roteiros_Clientes1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Lançamento de Roteiros - Selecione Cliente</title>

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

</head>

<body style="margin-left: 2%; margin-right: 2%">

    <br />

    <div class="panel panel-success">

        <div class="panel-heading text-center">
            <h4 class="panel-title">Lançar Entregas</h4>
        </div>

        <div class="panel-body">
            <br />
            <form class="form-horizontal">
                <fieldset>

                    <div class="form-group">
                        <label for="select_empresa" class="col-md-1 control-label">Cliente</label>
                        <div class="col-md-3">
                            <asp:Literal ID="Literal_Empresa" runat="server"></asp:Literal>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-3">
                            <button id="btnext" type="button" class="w3-btn w3-round w3-border w3-light-green w3-hover-green w3-block" onclick="Roteiros_Avançar()">
                                Lançar Entregas&nbsp;<i class="fa fa-arrow-circle-right" aria-hidden="true"></i></button>
                        </div>
                    </div>

                </fieldset>
            </form>
        </div>
    </div>

    <div class="panel panel-success">
        <div class="panel-heading text-center">
            <h4 class="panel-title">Outras Operações</h4>
        </div>
        <div class="panel-body">
            <br />
            <form class="form-horizontal">
                <fieldset>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-3">
                            <button type="button" class="w3-btn w3-round w3-border w3-light-green w3-hover-green w3-block" onclick="Roteiros_Bairro()">
                                Roteirizar por Bairro&nbsp;&nbsp;<i class="fa fa-map-signs" aria-hidden="true"></i></button>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-3">
                            <button type="button" class="w3-btn w3-round w3-border w3-light-green w3-hover-green w3-block" onclick="Roteiros_Listagem()">Entregas a Realizar&nbsp;&nbsp;<i class="fa fa-check-square-o" aria-hidden="true"></i></button>
                        </div>
                    </div>
                </fieldset>
            </form>
        </div>
    </div>

    <!-- Auxiliares -->
    <script type="text/javascript" src="Scripts/codeRoteiros_Clientes1.js"></script>

</body>
</html>
