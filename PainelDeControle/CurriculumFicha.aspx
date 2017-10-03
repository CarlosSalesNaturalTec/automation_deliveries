<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CurriculumFicha.aspx.cs" Inherits="CurriculumFicha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Curriculum</title>

    <style type="text/css">
        #results {
            float: left;
            margin: 15px;
            padding: 5px;
            border: 1px solid;
            background: #ccc;
        }

        form {
            background: #ccc;
            margin-top: 2%;
            margin-right: 2%;
            margin-left: 2%;
        }
    </style>

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
    
    <script type="text/javascript" src="Scripts/webcam.js"></script>

</head>
<body>

    <form class="form-horizontal">
        <br />
        <fieldset>
            <legend>Dados Pessoais</legend>

            <input type="hidden" id="IDHidden" />

            <!-- Foto  -->
            <div id="results"></div>
            <!-- Foto  -->

            <legend></legend>

            <div class="form-group">
                <label for="inputNome" class="col-md-2 control-label">Nome</label>
                <div class="col-md-9">
                    <input type="text" class="form-control" id="inputNome" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="inputRG" class="col-md-2 control-label">RG</label>
                <div class="col-md-4">
                    <input type="text" class="form-control" id="inputRG" readonly>
                </div>
                <label for="inputCPF" class="col-md-1 control-label">CPF</label>
                <div class="col-md-4">
                    <input type="email" class="form-control" id="inputCPF" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="inputEnd" class="col-md-2 control-label">Endereço</label>
                <div class="col-md-4">
                    <input type="text" class="form-control" id="inputEnd" readonly>
                </div>
                <label for="inputBairro" class="col-md-1 control-label">Bairro/CEP</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputBairro" readonly>
                </div>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputCEP" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="inputResid" class="col-md-2 control-label">Tel.Resid</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputResid" readonly>
                </div>

                <label for="inputCel" class="col-md-1 control-label">Tel.Celular</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputCel" readonly>
                </div>

                <label for="inputemail" class="col-md-1 control-label">E-mail</label>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputemail" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="inputPai" class="col-md-2 control-label">Filiação</label>
                <div class="col-md-4">
                    <input type="text" class="form-control" id="inputPai" readonly>
                </div>
                <div class="col-md-5">
                    <input type="text" class="form-control" id="inputMae" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="selectEstCivil" class="col-md-2 control-label">Est.Civil</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="selectEstCivil" readonly>
                </div>
                <label for="selectFilhos" class="col-md-1 control-label">Filhos</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="selectFilhos" readonly>
                </div>
                <label for="inputNascimento" class="col-md-2 control-label">Ano de Nascimento</label>
                <div class="col-md-2">
                    <input class="form-control" id="inputNascimento" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="selecthabilita" class="col-md-2 control-label">Habilitação</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="selecthabilita" readonly>
                </div>

                <label for="habilitaNum" class="col-md-1 control-label">Número</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="habilitaNum" readonly>
                </div>

                <label for="habilitaEmiss" class="col-md-2 control-label">Emissão</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="habilitaEmiss" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="selectVeiculo" class="col-md-2 control-label">Veic.Propio</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="selectVeiculo" readonly>
                </div>
                <label for="inputAnoModelo" class="col-md-1 control-label">Ano / Modelo</label>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputAnoModelo" readonly>
                </div>
                <label for="inputRenavam" class="col-md-1 control-label">Renavam</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputRenavam" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="selectArea" class="col-md-2 control-label">Função Desejada</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="selectArea" readonly>
                </div>
                <label for="inputDataCad" class="col-md-1 control-label">Data Cadastro</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputDataCad" readonly>
                </div>
                <label for="inputSalario" class="col-md-2 control-label">Pretensão Salarial</label>
                <div class="col-md-2">
                    <input type="number" class="form-control" id="inputSalario" value="0">
                </div>
            </div>

            <br />

            <legend>Experiências Profissionais</legend>

            <div class="form-group">
                <label for="inputExperiencia1" class="col-md-2 control-label">Empresa / Cargo / Periodo</label>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputExperiencia1" readonly>
                </div>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputCargo1" readonly>
                </div>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputPeriodo1" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="inputAtividades1" class="col-md-2 control-label">Atividades</label>
                <div class="col-md-9">
                    <textarea class="form-control" rows="4" id="inputAtividades1" readonly></textarea>
                </div>
            </div>

            <div class="form-group">
                <label for="inputExperiencia2" class="col-md-2 control-label">Empresa / Cargo / Periodo</label>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputExperiencia2" readonly>
                </div>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputCargo2" readonly>
                </div>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputPeriodo2" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="inputAtividades2" class="col-md-2 control-label">Atividades</label>
                <div class="col-md-9">
                    <textarea class="form-control" rows="4" id="inputAtividades2" readonly></textarea>
                </div>
            </div>

            <div class="form-group">
                <label for="inputExperiencia3" class="col-md-2 control-label">Empresa / Cargo / Periodo</label>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputExperiencia3" readonly>
                </div>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputCargo3" readonly>
                </div>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputPeriodo3" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="inputAtividades3" class="col-md-2 control-label">Atividades</label>
                <div class="col-md-9">
                    <textarea class="form-control" rows="4" id="inputAtividades3" readonly></textarea>
                </div>
            </div>

            <legend>Escolaridade</legend>

            <div class="form-group">
                <label for="inputEscolaridade1" class="col-md-2 control-label">Segundo Grau</label>
                <div class="col-md-6">
                    <input type="text" class="form-control" id="inputEscolaridade1" readonly>
                </div>
                <label for="inputConclusao1" class="col-md-1 control-label">Ano de Conclusão</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputConclusao1" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="inputEscolaridade2" class="col-md-2 control-label">Graduação</label>
                <div class="col-md-6">
                    <input type="text" class="form-control" id="inputEscolaridade2" readonly>
                </div>
                <label for="inputConclusao2" class="col-md-1 control-label">Ano de Conclusão</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputConclusao2" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="inputEscolaridade3" class="col-md-2 control-label">Pós/Mestrado</label>
                <div class="col-md-6">
                    <input type="text" class="form-control" id="inputEscolaridade3" readonly>
                </div>
                <label for="inputConclusao3" class="col-md-1 control-label">Ano de Conclusão</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputConclusao3" readonly>
                </div>
            </div>

            <legend>Outras Informações</legend>

            <div class="form-group">
                <label for="inputIndicacao" class="col-md-2 control-label">Indicação</label>
                <div class="col-md-9">
                    <input type="text" class="form-control" id="inputIndicacao" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="inputComentarios" class="col-md-2 control-label">Objetivos</label>
                <div class="col-md-9">
                    <textarea class="form-control" rows="4" id="inputComentarios" readonly></textarea>
                </div>
            </div>

            <legend></legend>

            <div class="form-group">
                <div class="col-md-4 col-md-offset-1">
                    <button id="BotaoExcluir" type="button" class="btn btn-danger" onclick="ExcluirRegistro()">Excluir</button>
                </div>
            </div>

        </fieldset>
    </form>

    <!-- Excluir Registro  -->
    <script type="text/javascript">
        function ExcluirRegistro() {

            var r = confirm("CONFIRMA EXCLUSÂO DE CURRICULUM?");
            if (r == false) {
                return;
            }

            var v1 = document.getElementById("IDHidden").value
            
            document.getElementById("BotaoExcluir").disabled = true;

            $.ajax({
                type: "POST",
                url: "wspainel.asmx/ExcluirCurric",
                data: '{param1: "' + v1 + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var linkurl = response.d;
                    window.location.href = linkurl;
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
    </script>
    <!-- Excluir Registro  -->


    <!-- preenche campos  -->
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <!-- preenche campos  -->

    <!-- Foco  -->
    <script type="text/javascript">
        document.getElementById("inputNome").focus();
    </script>


</body>

</html>
