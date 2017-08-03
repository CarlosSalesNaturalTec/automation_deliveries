<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html>

<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Styles: W3, BootsStrap, Font-Awesome -->
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <!-- Jquery-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <!-- Gráficos HighCharts -->
    <script src="https://code.highcharts.com/highcharts.js"></script>
    <script src="https://code.highcharts.com/modules/exporting.js"></script>

</head>

<body>

    <div class="w3-display-container w3-display-middle w3-opacity-max ">
        <img src="images/logologt.png" alt="Logomarca LOG Logística" />
    </div>

    <br>

    <div class="w3-row-padding">
        <div id="Bloco1" class="w3-col s3 m3 l3">
            <div class="panel panel-success">

                <div class="panel-heading text-center">
                    <h4 class="panel-title">Crédito de Combustível - Saldo</h4>
                </div>

                <div class="panel-body text-center">
                    <h1><asp:Literal ID="Bloco1_Info" runat="server"></asp:Literal></h1>
                </div>

                <div class="panel-footer text-center">
                    <asp:Literal ID="Bloco1_Link" runat="server"></asp:Literal>
                </div>

            </div>
        </div>
    </div>

</body>

</html>
