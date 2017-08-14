<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Painel.aspx.cs" Inherits="Painel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOG Logística - Painel de Controle</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

</head>
<body>

    <!-- Menu -->
    <div>
        <div class="w3-bar w3-black">

            <a href="#" class="w3-bar-item w3-btn w3-hover-green w3-right" onclick="sair()">Sair <i class="fa fa-sign-out"></i></a>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-cog"></i>&nbsp;Cofigurações</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="parametros.aspx" target="iframe" class="w3-bar-item w3-button">Parâmetros</a>
                </div>
            </div>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-truck"></i>&nbsp;Operacional</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="Abastecimento_Planilha.aspx" target="iframe" class="w3-bar-item w3-button">Abastecimento Polo</a>
                    <a href="Abastecimento_Local_Listagem.aspx" target="iframe" class="w3-bar-item w3-button">Abastecimento Local</a>
                    <a href="Home.aspx" target="iframe" class="w3-bar-item w3-button">Solicitações Extras</a>
                    <a href="Registro_Simplif_Listagem.aspx" target="iframe" class="w3-bar-item w3-button">Registro Simplificado de Entregas</a>
                </div>
            </div>

            <div class="w3-dropdown-hover w3-right">
                <button class="w3-btn w3-hover-green"><i class="fa fa-list"></i>&nbsp;Cadastros</button>
                <div class="w3-dropdown-content w3-bar-block w3-card-4">
                    <a href="Clientes.aspx" target="iframe" class="w3-bar-item w3-button">Clientes</a>
                    <a href="Entregadores.aspx" target="iframe" class="w3-bar-item w3-button">Motoboys</a>
                    <a href="Veiculos_Lista.aspx" target="iframe" class="w3-bar-item w3-button">Veículos</a>
                    <a href="Curriculuns.aspx" target="iframe" class="w3-bar-item w3-button">Banco de Currículos</a>
                    <a href="Orcamento_lista.aspx" target="iframe" class="w3-bar-item w3-button">Orçamentos</a>
                </div>
            </div>

            <a href="Home.aspx" target="iframe" class="w3-bar-item w3-btn w3-hover-green w3-right"><i class="fa fa-home"></i>&nbsp;Home</a>

        </div>
    </div>


    <!-- page content -->
    <div >
        <iframe src="Home.aspx" width="100%" height="1000px" frameborder="0" name="iframe">Atualize seu Navegador!</iframe>
    </div>


    <!-- Modal LogOff -->
    <div id="DivLogOut" class="w3-modal">
        <div class="w3-modal-content w3-card-4 w3-animate-left" style="max-width: 400px">

            <form class="w3-container">
                <div class="w3-section w3-center">
                    <header class="w3-container w3-blue w3-center">
                        <h4><strong>Atenção</strong></h4>
                    </header>
                    <br />
                    <i class="fa fa-3x fa-exclamation-triangle" aria-hidden="true"></i>
                    <br />
                    <h3><strong>Confirma Saida?</strong> </h3>
                    <br />
                    <p>
                        <button type="button" class="w3-button w3-round w3-border w3-light-blue w3-hover-blue" onclick="sair_cancel()">Não</button>&nbsp;&nbsp;&nbsp;
                        <button type="button" class="w3-button w3-round w3-border w3-light-blue w3-hover-red" onclick="sair_exit()">Sim</button>
                    </p>
                    <br />
                </div>
            </form>
        </div>
    </div>
    <!-- Modal LogOff -->

    <!-- Scripts Diversos -->
    <script type="text/javascript" src="Scripts/codePainel.js"></script>

</body>
</html>