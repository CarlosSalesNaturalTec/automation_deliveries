<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro_Simplif_Ficha.aspx.cs" Inherits="delivcli.Registro_Simplif_Ficha1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">

    <head>

        <title>Lançamento Simplificado de Entregas</title>

        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">

        <link href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css" rel="Stylesheet">
        <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>

    </head>
    <body>

        <br />

        <div class="panel panel-success">

            <div class="panel-heading text-center">
                <h4 class="panel-title">Nova Lançamento</h4>
            </div>

            <div class="panel-body">

                <div class="w3-row w3-padding">
                    <label for="input1" class="col-md-2 control-label">Motoboy</label>
                    <div class="col-md-8">
                        <input type="text" class="form-control" id="input1">
                    </div>
                </div>

                <div class="w3-row w3-padding">
                    <label for="input_data" class="col-md-2 control-label">Data</label>
                    <div class="col-md-3">
                        <input type="date" class="form-control" id="input_data">
                    </div>

                    <label for="input_quant" class="col-md-2 control-label">Quant.Entregas</label>
                    <div class="col-md-2">
                        <input type="number" class="form-control" id="input_quant" value="0" onClick="this.select();">
                    </div>
                    <div class="col-md-2">
                        &nbsp;
                    </div>
                </div>

                <div class="w3-row w3-padding">
                    <label for="input_realiz" class="col-md-2 control-label">Realizadas</label>
                    <div class="col-md-3">
                        <input type="number" class="form-control" id="input_realiz" value="0" onblur="calculo1();" onClick="this.select();" >
                    </div>

                    <label for="input_devolv" class="col-md-2 control-label">Devolvidas</label>
                    <div class="col-md-2">
                        <input type="number" class="form-control" id="input_devolv" value="0" onblur="calculo2();" onClick="this.select();" >
                    </div>
                </div>

                <div class="w3-row w3-padding">
                    <label for="select_placa" class="col-md-2 control-label">Obs</label>
                    <div class="col-md-8">
                        <input type="text" class="form-control" id="input_obs">
                    </div>
                </div>

                <div class="w3-row w3-padding">
                    <div class="col-md-4 col-md-offset-2">
                        <button type="button" class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar();">
                            <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

                        <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="AlterarRegistro()">
                            <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Salvar&nbsp;&nbsp;
                        </button>

                        <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                    </div>
                </div>
            </div>

        </div>


        <!-- auxiliares -->
        <input id="IDAuxHidden" type="hidden" />
        <asp:Literal ID="Literal_Aux" runat="server"></asp:Literal>
        <asp:Literal ID="Literal_AutoComplete" runat="server"></asp:Literal>

        <!-- Scripts Diversos  -->
        <script type="text/javascript" src="Scripts/codeRegistro_Simplif_Novo.js"></script>

    </body>
    </html>


</asp:Content>
