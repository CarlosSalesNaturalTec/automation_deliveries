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

    <!-- Lançar Nova Entrega -->
    <div class="panel panel-success">
        <div class="panel-heading text-center">
            <h4 class="panel-title">Lançar Entregas</h4>
        </div>
        <div class="panel-body">
            <br />
            
            <!-- Coleta de Valores -->
            <div class="w3-card-4 col-md-3">
                <br />
                <div class="w3-container w3-center">
                    <p><i class="fa fa-5x fa-usd" aria-hidden="true"></i></p>
                </div>
                <footer class="w3-container w3-center">
                    <p>
                        <asp:Literal ID="Literal_Empresa" runat="server"></asp:Literal></p>
                    <button id="btnext" type="button" class="w3-btn w3-round w3-border w3-light-green w3-hover-green w3-block" onclick="Roteiros_Avançar()">Coleta de Valores</button>
                </footer>
                <br />
            </div>

            <!-- Entrega Simples-->
            <div class="col-md-1"></div>
            <div class="w3-card-4 col-md-3">
                <br />
                <div class="w3-container w3-center">
                    <p><i class="fa fa-5x fa-plus" aria-hidden="true"></i></p>
                </div>
                <footer class="w3-container w3-center">
                    <p>
                        <asp:Literal ID="Literal_Empresa1" runat="server"></asp:Literal></p>
                    <button id="btnext2" type="button" class="w3-btn w3-round w3-border w3-light-blue w3-hover-blue w3-block" onclick="Roteiros_Avançar_2()">Entrega Simples</button>
                </footer>
                <br />
            </div>
            

        </div>
    </div>

    <!-- Outras Operações -->
    <div class="panel panel-success">
        <div class="panel-heading text-center">
            <h4 class="panel-title">Outras Operações</h4>
        </div>

        <div class="panel-body">
            <br />

            <!-- Bairro -->
            <div class="w3-card-4 col-md-3">
                <br />
                <div class="w3-container w3-center">
                    <p><i class="fa fa-5x fa-map-signs" aria-hidden="true"></i>&nbsp;&nbsp;</p>
                    <p>
                        <asp:Literal ID="Literal_quadro1" runat="server"></asp:Literal></p>
                </div>
                <footer class="w3-container w3-center">
                    <button type="button" class="w3-btn w3-round w3-border w3-light-green w3-hover-green w3-block" onclick="Roteiros_Bairro()">Não Roteirizadas</button>
                </footer>
                <br />
            </div>

            <!-- Entregas a Realizar -->
            <div class="col-md-1"></div>
            <div class="w3-card-4 col-md-3">
                <br />
                <div class="w3-container w3-center">
                    <p><i class="fa fa-5x fa-calendar-o" aria-hidden="true"></i></p>
                    <p>
                        <asp:Literal ID="Literal_quadro2" runat="server"></asp:Literal></p>
                </div>
                <footer class="w3-container w3-center">
                    <button type="button" class="w3-btn w3-round w3-border w3-light-blue w3-hover-blue w3-block" onclick="Roteiros_Listagem()">Roteiro</button>
                </footer>
                <br />
            </div>

            <!-- Prestação de Contas -->
            <div class="w3-card-4 col-md-3">
                <br />
                <div class="w3-container w3-center">
                    <p><i class="fa fa-5x fa-calculator" aria-hidden="true"></i></p>
                    <p>
                        <asp:Literal ID="Literal_quadro3" runat="server"></asp:Literal></p>
                </div>
                <footer class="w3-container w3-center">
                    <button type="button" class="w3-btn w3-round w3-border w3-light-green w3-hover-green w3-block" onclick="Roteiros_Pcontas()">Prestação de Contas</button>
                </footer>
                <br />
            </div>
        </div>

    </div>

    <!-- Auxiliares -->
    <script type="text/javascript" src="Scripts/codeRoteiros_Clientes1.js"></script>

</body>
</html>
