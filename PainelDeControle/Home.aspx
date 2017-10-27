<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html>

<head runat="server">
    <title></title>
    <meta charset="utf-8" />
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

<body>

    <div class="w3-display-container w3-display-middle w3-opacity-max ">
        <img src="images/logologt.png" alt="Logomarca LOG Logística" />
    </div>

    <br>

    <div class="w3-row-padding">

        <div id="Bloco1" class="w3-col s6 m3 l3 w3-padding">
            <div class="panel panel-success">

                <div class="panel-heading text-center">
                    <h4 class="panel-title w3-small">Crédito de Combustível - Saldo</h4>
                </div>

                <div class="panel-body text-center">
                    <h1><i class="fa fa-car" aria-hidden="true"></i></h1>
                    <h1><asp:Literal ID="Bloco1_Info" runat="server"></asp:Literal></h1>
                </div>

            </div>
        </div>

        <div id="Bloco2" class="w3-col s6 m3 l3 w3-padding">
            <div class="panel panel-success">

                <div class="panel-heading text-center">
                    <h4 class="panel-title w3-small">Total de Combustível a Pagar</h4>
                </div>

                <div class="panel-body text-center">
                    <h1><i class="fa fa-credit-card" aria-hidden="true"></i></h1>
                    <h1><asp:Literal ID="Bloco2_Info" runat="server"></asp:Literal></h1>
                </div>

            </div>
        </div>

        <div id="Bloco3" class="w3-col s6 m3 l3 w3-padding">
            <div class="panel panel-success">

                <div class="panel-heading text-center">
                    <h4 class="panel-title w3-small">Roteiros</h4>
                </div>

                <div class="panel-body text-center w3-text-black">
                    <h1><i class="fa fa-map-signs" aria-hidden="true" onclick="window.location.href ='Roteiros_Clientes1.aspx'" ></i></h1>
                    <h1><asp:Literal ID="Bloco3_Info" runat="server"></asp:Literal></h1>
                </div>

            </div>
        </div>

    </div>

</body>

</html>
