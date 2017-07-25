﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_Local_Novo.aspx.cs" Inherits="Abastecimento_Local_Novo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Cadastro de Abastecimento Posto Local</title>

    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <style>
        body {
            background-image: url("images/fundo.jpg");
        }
    </style>

</head>
<body>

    <!-- GRUPO 1 -->
    <div class="w3-container w3-animate-left" style="margin-left: 2%; margin-right: 2%">
        <br />
        <div class="col-md-9 w3-border w3-round w3-light-gray">
            <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Novo Abastecimento - Posto Local</h3>
        </div>

        <div class="w3-threequarter w3-border w3-light-gray" style="margin-top: 20px">
            <form class="form-horizontal">

                <fieldset>
                    <br />
                    <div class="form-group">
                        <label for="input1" class="col-md-2 control-label">Nome</label>
                        <div class="col-md-9">
                            <asp:Literal ID="literal_Nome" runat="server" />
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="select_placa" class="col-md-2 control-label">Placa</label>
                        <div class="col-md-3">
                            <asp:Literal ID="literal_Placa" runat="server" />
                        </div>

                        <label for="input_data" class="col-md-2 control-label">Data</label>
                        <div class="col-md-3">
                            <input type="date" class="form-control" id="input_data">
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="input_talao" class="col-md-2 control-label">Talão</label>
                        <div class="col-md-3">
                            <asp:Literal ID="Literal_Talao" runat="server" />
                        </div>

                        <label for="input_valor" class="col-md-2 control-label">Valor</label>
                        <div class="col-md-3">
                            <input type="number" class="form-control" id="input_valor">
                        </div>
                    </div>
                </fieldset>
            </form>
        </div>

        <div class="w3-quarter">
        </div>

        <!-- Botões Controle -->
        <div class="col-md-9 w3-border w3-round w3-light-gray w3-padding" style="margin-top: 10px">
            <br />
            <div class="col-md-2"></div>
            <p>
                <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                    <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

                <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="SalvarRegistro()">
                    <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;&nbsp;
                </button>

                <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
            </p>
        </div>
        <!-- Botões Controle -->


    </div>

    <!-- auxiliares -->
    <input id="IDAuxHidden" type="hidden" />

    <!-- Scripts Diversos  -->
    <script type="text/javascript" src="Scripts/codeAbast_Local_Novo.js"></script>

</body>
</html>