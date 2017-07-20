<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_Local_Ficha.aspx.cs" Inherits="Abastecimento_Local_Ficha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--*******Customização*******-->
    <title>Ficha de Instituição</title>

    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <style>
        body {
            background-image: url("Images/fundo.jpg");
        }

        #results {
            float: right;
            margin: 5px;
            padding: 5px;
            border: 1px solid;
            background: #ccc;
        }
    </style>

</head>
<body>
  <!--*******MENU LATERAL - Customização*******-->
    <div class="w3-sidebar w3-bar-block w3-green w3-card-2" style="width: 180px">
        <hr />
        <button id="bt1" class="w3-bar-item w3-button tablink w3-hover-light-blue w3-blue" onclick="openLink(event, 'grupo1')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados P.Jurídica</button>
        <button id="bt2" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo2')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Diretoria</button>
        <button id="bt3" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo3')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Estrutura</button>
        <button id="bt4" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo4')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Imagens</button>
        <button id="bt5" class="w3-bar-item w3-button tablink w3-hover-light-blue" onclick="openLink(event, 'grupo5')"><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Usuários</button>
        <hr />
    </div>

    <div style="margin-left: 180px">

        <!-- GRUPO 1 -->
        <div id="grupo1" class="w3-container grupo w3-animate-left" style="display: block">
            <br />
            <div class="col-md-9 w3-border w3-round w3-light-gray">
                <!--*******Customização*******-->
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Dados Pessoa Jurídica - Nova Instituição</h3>
            </div>

            <div class="w3-threequarter w3-border w3-light-gray" style="margin-top: 20px">
                <form class="form-horizontal">
                    <!--*******Customização*******-->
                    <fieldset>
                        <br />
                        <div class="form-group">
                            <label for="input1" class="col-md-2 control-label">Nome Fantasia</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input1">
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="input1" class="col-md-2 control-label">Razão Social</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="input2">
                            </div>
                        </div>

                    </fieldset>
                </form>
            </div>

            <!-- FOTO -->
            <div class="w3-quarter">
                <div id="results"></div>
                <div id="my_camera"></div>
                <!--*******Customização - somente se necessitar de foto ******* 
                <div class="row">
                    <label for="filePicker">Foto ( 200x300pixels - Tam.Máx.:75Kb )</label><br>
                    <input type="file" id="filePicker">
                    
                </div>
                <input id="FotoHidden" name="fotouri" type="hidden" />
                -->
            </div>
            <!-- FOTO -->

            <!-- Botões Controle -->
            <div class="col-md-9 w3-border w3-round w3-light-gray w3-padding" style="margin-top: 10px">
                <br />
                <div class="col-md-2"></div>
                <p>
                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="cancelar()">
                        <i class="fa fa-undo" aria-hidden="true"></i>&nbsp;Cancelar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt2()">
                        <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

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
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp; Diretoria - Nova Instituição</h3>
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
                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar1()">
                        <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt3()">
                        <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="AlterarRegistro()">
                        <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;&nbsp;
                    </button>

                    <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                </p>
            </div>
            <!-- Botões Controle -->
        </div>

        <!-- GRUPO 3 -->
        <div id="grupo3" class="w3-container grupo w3-animate-left" style="display: none">
            <br />
            <div class="col-md-9 w3-border w3-round w3-light-gray">
                <!--*******Customização*******-->
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp; Estrutura - Nova Instituição</h3>
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
                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar2()">
                        <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt4()">
                        <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="AlterarRegistro()">
                        <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;&nbsp;
                    </button>

                    <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                </p>
            </div>
            <!-- Botões Controle -->
        </div>

        <!-- GRUPO 4 -->
        <div id="grupo4" class="w3-container grupo w3-animate-left" style="display: none">
            <br />
            <div class="col-md-9 w3-border w3-round w3-light-gray">
                <!--*******Customização*******-->
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp; Imagens - Nova Instituição</h3>
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
                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar3()">
                        <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="classeBt5()">
                        <i class="fa fa-forward" aria-hidden="true"></i>&nbsp;Avançar</button>

                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="AlterarRegistro()">
                        <i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Finalizar&nbsp;&nbsp;
                    </button>

                    <i style="display: none" class="aguarde fa-2x fa fa-cog fa-spin fa-fw w3-text-green w3-right"></i>
                </p>
            </div>
            <!-- Botões Controle -->
        </div>

        <!-- GRUPO 5 -->
        <div id="grupo5" class="w3-container grupo w3-animate-left" style="display: none">
            <br />
            <div class="col-md-9 w3-border w3-round w3-light-gray">
                <!--*******Customização*******-->
                <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp; Usuários - Nova Instituição</h3>
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
                    <button class="w3-btn w3-round w3-border w3-light-green w3-hover-green btcontroles" onclick="btvoltar4()">
                        <i class="fa fa-backward" aria-hidden="true"></i>&nbsp;Voltar</button>

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
    <script type="text/javascript" src="Scripts/codeInstituicao_Novo.js"></script>

    <!--*******Customização somente se for usar mapa*******
    <script type="text/javascript" src="Scripts/codeInstituicao_Mapa.js"></script> 
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCOmedP-f3N7W7CPxaRoCZJ5mTMm6g0Ycc&libraries=places&callback=initMap" async defer></script>
    -->

    <!--*******Customização somente se for usar webcam *******
    <script type="text/javascript" src="Scripts/webcam.js"></script>
    -->

</body>

</html>
