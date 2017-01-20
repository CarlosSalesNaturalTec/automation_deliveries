<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DestinatarioFicha.aspx.cs" Inherits="PainelCliente_01.DestinatarioFicha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <script type="text/javascript" src="Scripts/jquery-3.1.1.min.js"></script>
    <script type="text/javascript" src="Scripts/webcam.js"></script>

    <br />
    <form class="form-horizontal">
        <fieldset>
            <br />
            <legend>Ficha Destinatário</legend>

            <div class="row">
                <label for="inputNome" class="col-md-1 control-label">Nome</label>
                <div class="col-md-8">
                    <input type="text" class="form-control" id="inputNome">
                </div>
            </div>

            <div class="row">
                <label for="inputFatasia" class="col-md-1 control-label">Fatasia</label>
                <div class="col-md-8">
                    <input type="text" class="form-control" id="inputFatasia">
                </div>
            </div>

            <div class="row">
                <label for="inputEndereco" class="col-md-1 control-label">Endereço</label>
                <div class="col-md-8">
                    <input type="text" class="form-control" id="inputEndereco">
                </div>
            </div>

            <div class="row">
                <label for="inputNumero" class="col-md-1 control-label">Numero</label>
                <div class="col-md-8">
                    <input type="text" class="form-control" id="inputNumero">
                </div>
            </div>

            <div class="row">
                <label for="inputBairro" class="col-md-1 control-label">Bairro</label>
                <div class="col-md-8">
                    <input type="text" class="form-control" id="inputBairro">
                </div>
            </div>

            <div class="row">
                <label for="inputCidade" class="col-md-1 control-label">Cidade</label>
                <div class="col-md-8">
                    <input type="text" class="form-control" id="inputCidade">
                </div>
            </div>

            <div class="row">
                <label for="inputUF" class="col-md-1 control-label">UF</label>
                <div class="col-md-8">
                    <input type="text" class="form-control" id="inputUF">
                </div>
            </div>

            <input id="IDHidden" name="IDHidden" type="hidden" />

            <br />
            <legend></legend>
            
            <input type ="button" class="btn btn-primary" value="Excluir"  />
            <input type ="reset" class="btn btn-danger" value="Cancelar" />
            <input type ="button" class="btn btn-success" value="Salvar" />
        </fieldset>
    </form>

    <!-- preenche campos  -->
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <!-- preenche campos  -->

</asp:Content>
