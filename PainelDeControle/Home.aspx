<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <style>

        body {
            background-image: url("images/fundo.jpg"); 
            background-repeat:repeat;
        }

        .icones {
            height: 100px;
        }

    </style>

</head>

<body>

    <br>

    <div class="w3-row-padding">

        <div class="w3-col s3 m3 l3 w3-container w3-center w3-display-container w3-border w3-border-black w3-round w3-opacity w3-hover-opacity-off">
            <p>Solicitações Extras</p>
            <div class="icones">
                <i class="fa fa-4x fa-plus-square-o w3-padding" aria-hidden="true"></i>
            </div>
            <div>
                <button style="width:80px" class="w3-btn w3-round w3-border w3-black" onclick="">Lançar</button>
                <p></p>
            </div>
        </div>

        <div class="w3-col s1 m1 l1">
            <p></p>
        </div>

        <div class="w3-col s3 m3 l3 w3-container w3-center w3-display-container w3-border w3-border-black w3-round w3-opacity w3-hover-opacity-off">
            <p>Controle de Combustível</p>
            <div class="icones">
                <i class="fa fa-4x fa-battery-half w3-padding" aria-hidden="true"></i>
            </div>
            <div>
                <button style="width:80px; margin-right:20px" class="botoes w3-btn w3-round w3-border w3-black" onclick="window.location.href='Abastecimento_Planilha.aspx'">Polo</button>
                <button style="width:80px" class="botoes w3-btn w3-round w3-border w3-black" onclick="window.location.href='Abastecimento_Local_Listagem.aspx'">Local</button>
                <p></p>
            </div>
        </div>

        <div class="w3-col s1 m1 l1">
            <p></p>
        </div>

        <div class="w3-col s3 m3 l3 w3-container w3-center w3-display-container w3-border w3-border-black w3-round w3-opacity w3-hover-opacity-off" >
            <p>Controle de Faltas</p>
            <div class="icones">
                <i class="fa fa-4x fa-calendar-times-o w3-padding" aria-hidden="true"></i>
            </div>
            <div>
                <button style="width:80px" class="botoes w3-btn w3-round w3-black" onclick="">Lançar</button>
                <p></p>
            </div>
        </div>

    </div>

</body>

</html>