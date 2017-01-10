<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EntregasCadastro.aspx.cs" Inherits="EntregasCadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <script src="~/vendors/jquery/dist/jquery.min.js"></script>
    <script src="~/vendors/bootstrap/dist/js/bootstrap.min.js"></script>

</head>
<body>

    <legend>Cadastro de Entregas</legend>

    <div class="row">
        <div class="col-md-3">
            <p>Endereço</p>
        </div>
        <div class="col-md-1">
            <p>Numero</p>
        </div>
        <div class="col-md-2">
            <p>Bairro</p>
        </div>
        <div class="col-md-2">
            <p>Cidade</p>
        </div>
        <div class="col-md-1">
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
            <input type="text" class="form-control" id="txtEndereco">
        </div>
        <div class="col-md-1">
            <input type="text" class="form-control" id="txtNumero">
        </div>
        <div class="col-md-2">
            <input type="text" class="form-control" id="txtBairro">
        </div>
        <div class="col-md-2">
            <select class="form-control" id="txtCidade">
                <option>Salvador</option>
                <option>Lauro de Freitas</option>
                <option>Camaçari</option>
                <option>Feira de Santana</option>
            </select>
        </div>

        <div class="col-md-1">
            <button type="reset" class="btn btn-primary" onclick="cancelar()">Buscar</button>
        </div>
    </div>

    <br />
    <!-- MAPA -->
    <iframe height="400px" width="100%" frameborder="0" scrolling="no" src="/SituacaoMapa.aspx"></iframe>
    <!-- MAPA -->

    <div class="row">
        <div class="col-md-3">
            <p>Destinatário</p>
        </div>
        <div class="col-md-3">
            <p>P.Ref.</p>
        </div>
        <div class="col-md-2">
            <p>Telefone</p>
        </div>
        <div class="col-md-2">
            <p>Entregador</p>
        </div>
        <div class="col-md-1">
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
            <input type="text" class="form-control" id="txtDestinatario">
        </div>
        <div class="col-md-3">
            <input type="text" class="form-control" id="txtPref">
        </div>
        <div class="col-md-2">
            <input type="text" class="form-control" id="txtTelefone">
        </div>
        <div class="col-md-2">
            <select class="form-control" id="cmb_funcionario">
            </select>
        </div>
        <div class="col-md-1">
            <button type="button" class="btn btn-success" onclick="cancelar()">Salvar</button>
        </div>
    </div>

    <input id="lblLat" name="lblLat" type="hidden" />
    <input id="lblLong" name="lblLong" type="hidden" />

    <!-- Foco  -->
    <script type="text/javascript">
        document.getElementById("txtEndereco").focus();
    </script>

</body>
</html>
