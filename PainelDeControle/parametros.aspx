<%@ Page Language="C#" AutoEventWireup="true" CodeFile="parametros.aspx.cs" Inherits="parametros" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--*******Customização*******-->
    <title>Parâmetros do Sistema</title>

    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

</head>
<body>
  <!--*******MENU LATERAL - Customização*******-->
    <div class="w3-sidebar w3-bar-block w3-green w3-card-2" style="width: 180px">
        <hr />
        <button id="bt1" class="w3-bar-item w3-button tablink w3-hover-light-blue w3-blue" onclick="openLink(event, 'grupo1')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Abastecimento</button>
        <button id="bt2" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo2')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Outros</button>
        <hr />
    </div>

    <div style="margin-left: 180px">

        <!-- GRUPO 1 -->
        <div id="grupo1" class="w3-container grupo w3-animate-left" style="display: block">
            <br />
            <div class="col-md-9 w3-border w3-round w3-light-gray">
                <!--*******Customização*******-->
                <h3><i class="fa fa-cog" aria-hidden="true"></i>&nbsp;Configurações - Abastecimento</h3>
            </div>

            <div class="w3-threequarter w3-border w3-light-gray" style="margin-top: 20px">
                <form class="form-horizontal">
                    <!--*******Customização*******-->
                    <fieldset>
                        <br />
                        <div class="form-group">
                            <label for="input1" class="col-md-2 control-label">Sequência Talão</label>
                            <div class="col-md-9">
                                <input type="number" class="form-control" id="input1">
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
                   
                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="AlterarRegistro()">
                        <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;&nbsp;
                    </button>

                    <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                </p>
            </div>
            <!-- Botões Controle -->


        </div>

        <!-- GRUPO 2 -->
        <div id="grupo2" class="w3-container grupo w3-animate-left" style="display: none">
            <br />
            <div class="col-md-9 w3-border w3-round w3-light-gray">
                <!--*******Customização*******-->
                <h3><i class="fa fa-cog" aria-hidden="true"></i>&nbsp;Configurações - Outros</h3>
            </div>

            <div class="w3-threequarter w3-border w3-light-gray" style="margin-top: 20px">
                <form class="form-horizontal">
                    <!--*******Customização*******-->
                    <fieldset>
                        <br />

                    </fieldset>
                </form>
            </div>

            <!-- Botões Controle -->
            <div class="col-md-9 w3-border w3-round w3-light-gray w3-padding" style="margin-top: 10px">
                <br />
                <div class="col-md-2"></div>
                <p>
                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                        <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Sair</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="AlterarRegistro()">
                        <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;&nbsp;
                    </button>

                    <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                </p>
            </div>
            <!-- Botões Controle -->
        </div>

      
    <!-- auxiliares -->
    <input id="IDAuxHidden" type="hidden" />
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <!-- Scripts Diversos  -->
    <script type="text/javascript" src="Scripts/codeParametros.js"></script>

</body>

</html>
