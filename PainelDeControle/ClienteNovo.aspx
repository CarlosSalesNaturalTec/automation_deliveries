<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClienteNovo.aspx.cs" Inherits="ClienteNovo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <title>Novo Cliente</title>

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script type="text/javascript" src="Scripts/jquery-3.1.1.min.js"></script>

</head>
<body>

    <br />
    <div class="w3-container w3-border w3-round w3-padding-16 w3-light-gray w3-small" style="margin-left: 2%; margin-right: 2%">

        <form class="form-horizontal">
            <fieldset>
                <legend>Novo Cliente</legend>

                <div class="form-group">
                    <label for="inputNome" class="col-md-1 control-label">Nome</label>
                    <div class="col-md-9">
                        <input type="text" class="form-control" id="inputNome">
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputResponsavel" class="col-md-1 control-label">Respons.</label>
                    <div class="col-md-9">
                        <input type="text" class="form-control" id="inputResponsavel">
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputEmail" class="col-md-1 control-label">E-mail</label>
                    <div class="col-md-9">
                        <input type="email" class="form-control" id="inputEmail">
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputTelefone" class="col-md-1 control-label">Telefone</label>
                    <div class="col-md-9">
                        <input type="text" class="form-control" id="inputTelefone">
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputUsuario" class="col-md-1 control-label">Usuario</label>
                    <div class="col-md-4">
                        <input type="text" class="form-control" id="inputUsuario" placeholder="Acesso ao Painel de Controle">
                    </div>

                    <label for="inputSenha" class="col-md-1 control-label">Senha</label>
                    <div class="col-md-4">
                        <input type="password" class="form-control" id="inputSenha">
                    </div>
                </div>

                <div class="form-group">
                </div>


                <legend></legend>

                <div class="form-group">
                    <div class="col-md-4 col-md-offset-1">
                        <button type="reset" class="btn btn-primary" onclick="cancelar()">Cancelar</button>
                        <button type="button" class="btn btn-success" onclick="SalvarRegistro()" id="btSalvar">Salvar</button>
                    </div>
                </div>

            </fieldset>
        </form>

    </div>

    <!-- Auxiliar -->
    <script type="text/javascript" src="Scripts/codeCliente_Novo.js"></script>

</body>

</html>
