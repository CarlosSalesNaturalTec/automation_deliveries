<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClienteFicha.aspx.cs" Inherits="ClienteFicha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <title>Ficha de Cliente</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <script type="text/javascript" src="Scripts/jquery-3.1.1.min.js"></script>

</head>
<body>

    <br />
    <div class="w3-container w3-border w3-round w3-padding-16 w3-light-gray w3-small" style="margin-left: 2%; margin-right: 2%">
        <form class="form-horizontal">
            <fieldset>
                <legend>Ficha Cliente</legend>

                <div class="form-group">
                    <label for="inputNome" class="col-md-1 control-label">Nome</label>
                    <div class="col-md-8">
                        <input type="text" class="form-control" id="inputNome" />
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputResponsavel" class="col-md-1 control-label">Respons.</label>
                    <div class="col-md-8">
                        <input type="text" class="form-control" id="inputResponsavel">
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputEmail" class="col-md-1 control-label">E-mail</label>
                    <div class="col-md-8">
                        <input type="text" class="form-control" id="inputEmail" />
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputTelefone" class="col-md-1 control-label">Telefone</label>
                    <div class="col-md-8">
                        <input type="text" class="form-control" id="inputTelefone" />
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputUsuario" class="col-md-1 control-label">Usuario</label>
                    <div class="col-md-4">
                        <input type="text" class="form-control" id="inputUsuario" placeholder="Acesso ao Painel de Controle" />
                    </div>

                    <label for="inputSenha" class="col-md-1 control-label">Senha</label>
                    <div class="col-md-3">
                        <input type="password" class="form-control" id="inputSenha" />
                    </div>
                </div>

                <legend></legend>

                <input id="IDHidden" name="IDHidden" type="hidden" />

                <div class="form-group">
                    <div class="col-md-4 col-md-offset-1">
                        <button type="button" class="btn btn-danger" onclick="ExcluirRegistro()">Excluir</button>
                        <button type="reset" class="btn btn-primary" onclick="cancelar()">Cancelar</button>
                        <button type="button" class="btn btn-success" onclick="AtualizarRegistro()">Salvar</button>
                    </div>
                </div>

            </fieldset>
        </form>
    </div>

    <br />
    <div class="w3-container w3-border w3-round w3-padding-16 w3-light-gray w3-small" style="margin-left: 2%; margin-right: 2%">
        <h3><i class="fa fa-check-square-o" aria-hidden="true"></i>&nbsp;Custo dos Serviços</h3>
        <hr />
        <div class="w3-threequarter">
            <form class="form-horizontal">
                <fieldset>
                    <div class="form-group">
                        <label for="input_cidade" class="col-md-2 control-label">Cidade</label>
                        <div class="col-md-10">
                            <input type="text" id="input_cidade" class="w3-input w3-border w3-round" />
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="input_valor" class="col-md-2 control-label">Valor</label>
                        <div class="col-md-3">
                            <input type="number" id="input_valor" class="w3-input w3-border w3-round" />
                        </div>
                        <div class="col-md-2">
                            <button type="button" class="w3-btn w3-border w3-round w3-light-green w3-hover-green"
                                onclick="CidadeIncluir()">
                                <i class="fa fa-plus"></i>&nbsp;Adicionar</button>
                        </div>
                    </div>

                    <!-- GRID Custos de Serviços -->
                    <div class="form-group">
                        <div class="col-md-2"></div>
                        <div class="col-md-10 w3-border w3-padding w3-round w3-light-gray">
                            <table id="MyTable" class="w3-table-all w3-hoverable">
                                <thead>
                                    <tr class="w3-grey">
                                        <th>Cidade</th>
                                        <th>Valor</th>
                                    </tr>
                                </thead>
                                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                            </table>
                        </div>
                    </div>
                </fieldset>
            </form>
        </div>
    </div>

    <!-- preenche campos  -->
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <!-- Outros  -->
    <script type="text/javascript" src="Scripts/codeCliente_Ficha.js"></script>

</body>
</html>
