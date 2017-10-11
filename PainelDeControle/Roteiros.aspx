<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Roteiros.aspx.cs" Inherits="Roteiros" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Lançamento de Roteiro</title>

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

    <style>
        #map {
            height: 500px;
            width: 100%;
        }
    </style>

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

                    <div class="form-group">

                        <label for="lbl_cliente" class="col-md-1 control-label">Cliente</label>
                        <div class="col-md-4">
                            <input type="text" id="lbl_cliente" class="form-control" disabled />
                        </div>

                        <label for="lbl_motoboy" class="col-md-1 control-label">Motoboy</label>
                        <div class="col-md-4">
                            <input type="text" id="lbl_motoboy" class="form-control" disabled />
                        </div>

                    </div>

                    <div class="form-group">

                        <label for="input_end" class="col-md-1 control-label">Endereço</label>
                        <div class="col-md-4">
                            <input type="text" class="form-control" id="input_end" />
                        </div>

                        <label for="input_bairro" class="col-md-1 control-label">Bairro</label>
                        <div class="col-md-4">
                            <input type="text" class="form-control" id="input_bairro" />
                        </div>

                    </div>

                    <div class="form-group">

                        <label for="select_Cidade" class="col-md-1 control-label">Cidade</label>
                        <div class="col-md-4">
                            <asp:Literal ID="Literal_Cidade" runat="server"></asp:Literal>
                        </div>

                        <label for="input_dest" class="col-md-1 control-label">Destinatário</label>
                        <div class="col-md-4">
                            <input type="text" class="form-control" id="input_dest" />
                        </div>

                    </div>

                    <div class="form-group">

                        <label for="input_pref" class="col-md-1 control-label">P.Ref.:</label>
                        <div class="col-md-4">
                            <input type="text" class="form-control" id="input_pref" />
                        </div>

                        <label for="input_tel" class="col-md-1 control-label">Telefone</label>
                        <div class="col-md-2">
                            <input id="input_tel" class="form-control" type="text" />
                        </div>

                        <div class="col-md-4">
                            <button type="button" class="w3-btn w3-round w3-border w3-light-blue w3-hover-blue btcontroles" onclick="Roteiros_cancelar()">
                                <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Voltar</button>
                            <button type="button" id="btsalvar" class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="Roteiros_Salvar()">
                                Adicionar&nbsp;<i class="fa fa-check-square-o" aria-hidden="true"></i></button>
                            <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                        </div>
                    </div>

                </fieldset>
            </form>
        </div>

    </div>

    <div id="map"></div>
    <br />

    <div class="panel panel-success">
        <div class="panel-heading text-center">
            <h4 class="panel-title">Entregas do Motoboy</h4>
        </div>
    </div>

    <!-- GRID Roteiros Lançados -->
    <div class="form-group">
        <div class="col-md-12 w3-border w3-padding w3-round w3-light-gray">
            <table id="MyTable" class="w3-table-all w3-hoverable">
                <thead>
                    <tr class="w3-grey">
                        <th>Destinatário</th>
                        <th>Endereço</th>
                        <th>Bairro</th>
                        <th>Cidade</th>
                    </tr>
                </thead>
                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
            </table>
        </div>
    </div>

    <input type="hidden" id="ID_Cli_Hidden" />
    <input type="hidden" id="ID_Mot_Hidden" />

    <!-- Script -->
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB2PC8H2Mi0TZsYN-j17OtXsNb8DktSH64&libraries=places&callback=initMap" async defer></script>
    <script type="text/javascript" src="Scripts/codeRoteiros.js"></script>

    <!-- Auxiliares -->
    <asp:Literal ID="Literal_aux" runat="server"></asp:Literal>
    <asp:Literal ID="Literal_mapa" runat="server"></asp:Literal>

</body>
</html>
