<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CurriculumFicha.aspx.cs" Inherits="CurriculumFicha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

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

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <script type="text/javascript" src="Scripts/jquery-3.1.1.min.js"></script>
    <script type="text/javascript" src="Scripts/webcam.js"></script>

</head>
<body>

    <form class="form-horizontal">
        <br />
        <fieldset>
            <legend>Dados Pessoais</legend>

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
                <div class="col-md-5">
                    <input type="text" class="form-control" id="inputEnd" readonly>
                </div>
                <label for="inputCEP" class="col-md-2 control-label">CEP</label>
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
                <label for="inputAnoModelo" class="col-md-1 control-label">Ano/Modelo</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputAnoModelo" readonly>
                </div>
                <label for="inputRenavam" class="col-md-2 control-label">Renavam</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputRenavam" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="selectArea" class="col-md-2 control-label">Area Desejada</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="selectArea" readonly>
                </div>
                <label for="inputDataCad" class="col-md-2 control-label">Data Cadastro</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputDataCad" readonly>
                </div>
            </div>

            <br />

            <legend>Experiências Profissionais</legend>

            <div class="form-group">
                <label for="inputExperiencia1" class="col-md-2 control-label">Empresa</label>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputExperiencia1" readonly>
                </div>
                <label for="inputPeriodo1" class="col-md-1 control-label">Periodo</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputPeriodo1" readonly>
                </div>
                <label for="inputCargo1" class="col-md-1 control-label">Cargo</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputCargo1" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="inputAtividades1" class="col-md-2 control-label">Atividades</label>
                <div class="col-lg-4">
                    <textarea class="form-control" rows="3" id="inputAtividades1" readonly></textarea>
                </div>
            </div>

            <div class="form-group">
                <label for="inputExperiencia2" class="col-md-2 control-label">Empresa</label>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputExperiencia2" readonly>
                </div>
                <label for="inputPeriodo2" class="col-md-1 control-label">Periodo</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputPeriodo2" readonly>
                </div>
                <label for="inputCargo2" class="col-md-1 control-label">Cargo</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputCargo2" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="inputAtividades2" class="col-md-2 control-label">Atividades</label>
                <div class="col-lg-8">
                    <textarea class="form-control" rows="3" id="inputAtividades2" readonly></textarea>
                </div>
            </div>

            <div class="form-group">
                <label for="inputExperiencia3" class="col-md-2 control-label">Empresa</label>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputExperiencia3" readonly>
                </div>
                <label for="inputPeriodo3" class="col-md-1 control-label">Periodo</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputPeriodo3" readonly>
                </div>
                <label for="inputCargo3" class="col-md-1 control-label">Cargo</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputCargo3" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="inputAtividades3" class="col-md-2 control-label">Atividades</label>
                <div class="col-lg-8">
                    <textarea class="form-control" rows="3" id="inputAtividades3" readonly></textarea>
                </div>
            </div>

            <legend>Escolaridade</legend>

            <div class="form-group">
                <label for="inputEscolaridade1" class="col-md-2 control-label">Segundo Grau</label>
                <div class="col-lg-7">
                    <input type="text" class="form-control" id="inputEscolaridade1" readonly>
                </div>
                <label for="inputConclusao1" class="col-md-1 control-label">Ano de Conclusão</label>
                <div class="col-lg-1">
                    <input type="text" class="form-control" id="inputConclusao1" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="inputEscolaridade2" class="col-md-2 control-label">Graduação</label>
                <div class="col-lg-7">
                    <input type="text" class="form-control" id="inputEscolaridade2" readonly>
                </div>
                <label for="inputConclusao2" class="col-md-1 control-label">Ano de Conclusão</label>
                <div class="col-lg-1">
                    <input type="text" class="form-control" id="inputConclusao2" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="inputEscolaridade3" class="col-md-2 control-label">Pós/Mestrado</label>
                <div class="col-lg-7">
                    <input type="text" class="form-control" id="inputEscolaridade3" readonly>
                </div>
                <label for="inputConclusao3" class="col-md-1 control-label">Ano de Conclusão</label>
                <div class="col-lg-1">
                    <input type="text" class="form-control" id="inputConclusao3" readonly>
                </div>
            </div>

            <legend>Outras Informações</legend>

            <div class="form-group">
                <label for="inputIndicacao" class="col-md-2 control-label">Indicação</label>
                <div class="col-lg-9">
                    <input type="text" class="form-control" id="inputIndicacao" readonly>
                </div>
            </div>

            <div class="form-group">
                <label for="inputComentarios" class="col-md-2 control-label">Objetivos</label>
                <div class="col-lg-9">
                    <textarea class="form-control" rows="3" id="inputComentarios" readonly></textarea>
                </div>
            </div>

        </fieldset>
    </form>

    <!-- Foco  -->
    <script type="text/javascript">
        document.getElementById("inputNome").focus();
    </script>

    <!-- preenche campos  -->
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <!-- preenche campos  -->

</body>

</html>
