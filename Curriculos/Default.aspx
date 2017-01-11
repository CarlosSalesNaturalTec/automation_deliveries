<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <style type="text/css">
        #results {
            float: right;
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

    <h3>LOG Transportes - Cadastro de Curriculum Vitae</h3>

    <form class="form-horizontal">
        <br />
        <fieldset>
            <legend>Dados Pessoais</legend>

            <div class="form-group">
                <label for="inputNome" class="col-md-2 control-label">Nome</label>
                <div class="col-md-9">
                    <input type="text" class="form-control" id="inputNome">
                </div>
            </div>

            <div class="form-group">
                <label for="inputRG" class="col-md-2 control-label">RG</label>
                <div class="col-md-4">
                    <input type="text" class="form-control" id="inputRG">
                </div>
                <label for="inputCPF" class="col-md-1 control-label">CPF</label>
                <div class="col-md-4">
                    <input type="email" class="form-control" id="inputCPF">
                </div>
            </div>

            <div class="form-group">
                <label for="inputEnd" class="col-md-2 control-label">Endereço</label>
                <div class="col-md-5">
                    <input type="text" class="form-control" id="inputEnd">
                </div>
                <label for="inputCEP" class="col-md-2 control-label">CEP</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputCEP">
                </div>
            </div>

            <div class="form-group">
                <label for="inputResid" class="col-md-2 control-label">Tel.Resid</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputResid">
                </div>

                <label for="inputCel" class="col-md-1 control-label">Tel.Celular</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputCel">
                </div>

                <label for="inputemail" class="col-md-1 control-label">E-mail</label>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputemail">
                </div>
            </div>

            <div class="form-group">
                <label for="inputPai" class="col-md-2 control-label">Filiação</label>
                <div class="col-md-4">
                    <input type="text" class="form-control" id="inputPai" placeholder="Nome do Pai">
                </div>
                <div class="col-md-5">
                    <input type="text" class="form-control" id="inputMae" placeholder="Nome da Mãe">
                </div>
            </div>

            <div class="form-group">
                <label for="selectEstCivil" class="col-md-2 control-label">Est.Civil</label>
                <div class="col-md-2">
                    <select class="form-control" id="selectEstCivil">
                        <option>CASADO(A)</option>
                        <option>SOLTEIRO(A)</option>
                        <option>DIVORCIADO(A)</option>
                        <option>OUTRO(A)</option>
                    </select>
                </div>
                <label for="selectFilhos" class="col-md-1 control-label">Filhos</label>
                <div class="col-md-2">
                    <select class="form-control" id="selectFilhos">
                        <option>SIM</option>
                        <option>NÃO</option>
                    </select>
                </div>
            </div>

            <div class="form-group">
                <label for="selecthabilita" class="col-md-2 control-label">Habilitação</label>
                <div class="col-md-2">
                    <select class="form-control" id="selecthabilita">
                        <option>A</option>
                        <option>B</option>
                        <option>C</option>
                        <option>D</option>
                        <option>E</option>
                    </select>
                </div>

                <label for="habilitaNum" class="col-md-1 control-label">Número</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="habilitaNum">
                </div>

                <label for="habilitaEmiss" class="col-md-2 control-label">Emissão</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="habilitaEmiss">
                </div>
            </div>

            <div class="form-group">
                <label for="selectVeiculo" class="col-md-2 control-label">Veic.Propio</label>
                <div class="col-md-2">
                    <select class="form-control" id="selectVeiculo">
                        <option>SIM</option>
                        <option>NÃO</option>
                    </select>
                </div>
                <label for="inputAnoModelo" class="col-md-1 control-label">Ano/Modelo</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputAnoModelo">
                </div>
                <label for="inputRenavam" class="col-md-2 control-label">Renavam</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputRenavam">
                </div>
            </div>

            <div class="form-group">
                <label for="selectArea" class="col-md-2 control-label">Area Desejada</label>
                <div class="col-md-2">
                    <select class="form-control" id="selectArea">
                        <option>LOGISTICA</option>
                        <option>OPERACIONAL</option>
                        <option>ADMINISTRATIVO</option>
                        <option>COMERCIAL</option>
                        <option>FINANCEIRO</option>
                        <option>REC.HUMANOS</option>
                    </select>
                </div>
            </div>

            <br />

            <legend>Experiências Profissionais</legend>

            <div class="form-group">
                <label for="inputExperiencia1" class="col-md-2 control-label">Empresa</label>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputExperiencia1" placeholder="Última Experiência">
                </div>
                <label for="inputPeriodo1" class="col-md-1 control-label">Periodo</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputPeriodo1">
                </div>
                <label for="inputCargo1" class="col-md-1 control-label">Cargo</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputCargo1">
                </div>
            </div>

            <div class="form-group">
                <label for="inputAtividades1" class="col-md-2 control-label">Atividades</label>
                <div class="col-lg-9">
                    <textarea class="form-control" rows="3" id="inputAtividades1" placeholder="Atividades desenvolvidas neste cargo"></textarea>
                </div>
            </div>

            <div class="form-group">
                <label for="inputExperiencia2" class="col-md-2 control-label">Empresa</label>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputExperiencia2" placeholder="Penúltima Experiência">
                </div>
                <label for="inputPeriodo2" class="col-md-1 control-label">Periodo</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputPeriodo2">
                </div>
                <label for="inputCargo2" class="col-md-1 control-label">Cargo</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputCargo2">
                </div>
            </div>

            <div class="form-group">
                <label for="inputAtividades2" class="col-md-2 control-label">Atividades</label>
                <div class="col-lg-9">
                    <textarea class="form-control" rows="3" id="inputAtividades2" placeholder="Atividades desenvolvidas neste cargo"></textarea>
                </div>
            </div>

            <div class="form-group">
                <label for="inputExperiencia3" class="col-md-2 control-label">Empresa</label>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputExperiencia3" placeholder="Outras experiências na área de interesse">
                </div>
                <label for="inputPeriodo3" class="col-md-1 control-label">Periodo</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputPeriodo3">
                </div>
                <label for="inputCargo3" class="col-md-1 control-label">Cargo</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputCargo3">
                </div>
            </div>

            <div class="form-group">
                <label for="inputAtividades3" class="col-md-2 control-label">Atividades</label>
                <div class="col-lg-9">
                    <textarea class="form-control" rows="3" id="inputAtividades3" placeholder="Atividades desenvolvidas neste cargo"></textarea>
                </div>
            </div>

            <legend>Escolaridade</legend>

            <div class="form-group">
                <label for="inputEscolaridade1" class="col-md-2 control-label">Segundo Grau</label>
                <div class="col-lg-7">
                    <input type="text" class="form-control" id="inputEscolaridade1" placeholder="Nome da instituição de ensino">
                </div>
                <label for="inputConclusao1" class="col-md-1 control-label">Ano de Conclusão</label>
                <div class="col-lg-1">
                    <input type="text" class="form-control" id="inputConclusao1">
                </div>
            </div>

            <div class="form-group">
                <label for="inputEscolaridade2" class="col-md-2 control-label">Graduação</label>
                <div class="col-lg-7">
                    <input type="text" class="form-control" id="inputEscolaridade2" placeholder="Nome da instituição de ensino">
                </div>
                <label for="inputConclusao2" class="col-md-1 control-label">Ano de Conclusão</label>
                <div class="col-lg-1">
                    <input type="text" class="form-control" id="inputConclusao2">
                </div>
            </div>

            <div class="form-group">
                <label for="inputEscolaridade3" class="col-md-2 control-label">Pós/Mestrado</label>
                <div class="col-lg-7">
                    <input type="text" class="form-control" id="inputEscolaridade3" placeholder="Nome da instituição de ensino">
                </div>
                <label for="inputConclusao3" class="col-md-1 control-label">Ano de Conclusão</label>
                <div class="col-lg-1">
                    <input type="text" class="form-control" id="inputConclusao3">
                </div>
            </div>

            <legend>Outras Informações</legend>

            <div class="form-group">
                <label for="inputIndicacao" class="col-md-2 control-label">Indicação</label>
                <div class="col-lg-9">
                    <input type="text" class="form-control" id="inputIndicacao" placeholder="Caso conheça algum colaborador da LOG, citar nome.">
                </div>
            </div>

            <div class="form-group">
                <label for="inputComentarios" class="col-md-2 control-label">Objetivos</label>
                <div class="col-lg-9">
                    <textarea class="form-control" rows="3" id="inputComentarios" placeholder="Porquê você gostaria de entrar para o time da LOG?"></textarea>
                </div>
            </div>

            <legend></legend>
            <!-- Camera  -->
            <div id="results"></div>
            <div id="my_camera"></div>
            <br />
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-6">
                    <label for="filePicker">Foto (Opcional)</label><br>
                    <input type="file" id="filePicker">
                </div>
            </div>
            <input id="Hidden1" type="hidden" />
            <br />
            <!-- Camera  -->

            <legend></legend>

            <div class="form-group">
                <div class="col-md-4 col-md-offset-1">
                    <button type="button" class="btn btn-success" onclick="SalvarRegistro()">Enviar</button>
                </div>
            </div>

        </fieldset>
    </form>

    <!-- Salvar Registro  -->
    <script type="text/javascript">
        function SalvarRegistro() {

            var v1 = document.getElementById("inputNome").value
            var v2 = document.getElementById("inputRG").value
            var v3 = document.getElementById("inputCPF").value
            var v4 = document.getElementById("inputEnd").value
            var v5 = document.getElementById("inputCEP").value
            var v6 = document.getElementById("inputResid").value
            var v7 = document.getElementById("inputCel").value
            var v8 = document.getElementById("inputemail").value
            var v9 = document.getElementById("inputPai").value
            var v10 = document.getElementById("inputMae").value
            var v11 = document.getElementById("selectEstCivil").value
            var v12 = document.getElementById("selectFilhos").value
            var v13 = document.getElementById("selecthabilita").value
            var v14 = document.getElementById("habilitaNum").value
            var v15 = document.getElementById("habilitaEmiss").value
            var v16 = document.getElementById("selectVeiculo").value
            var v17 = document.getElementById("inputAnoModelo").value
            var v18 = document.getElementById("inputRenavam").value
            var v19 = document.getElementById("selectArea").value
            var v20 = document.getElementById("inputExperiencia1").value
            var v21 = document.getElementById("inputPeriodo1").value
            var v22 = document.getElementById("inputCargo1").value
            var v23 = document.getElementById("inputAtividades1").value
            var v24 = document.getElementById("inputExperiencia2").value
            var v25 = document.getElementById("inputPeriodo2").value
            var v26 = document.getElementById("inputCargo2").value
            var v27 = document.getElementById("inputAtividades2").value
            var v28 = document.getElementById("inputExperiencia3").value
            var v29 = document.getElementById("inputPeriodo3").value
            var v30 = document.getElementById("inputCargo3").value
            var v31 = document.getElementById("inputAtividades3").value
            var v32 = document.getElementById("inputEscolaridade1").value
            var v33 = document.getElementById("inputConclusao1").value
            var v34 = document.getElementById("inputEscolaridade2").value
            var v35 = document.getElementById("inputConclusao2").value
            var v36 = document.getElementById("inputEscolaridade3").value
            var v37 = document.getElementById("inputConclusao3").value
            var v38 = document.getElementById("inputIndicacao").value
            var v39 = document.getElementById("inputComentarios").value
            var v40 = document.getElementById("Hidden1").value

            if (v1 == "") {
                alert("Informe Nome");
                document.getElementById("inputNome").focus();
                return;
            }

            $.ajax({
                type: "POST",
                url: "wspainel.asmx/SalvarCurric",
                data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 +
                    '", param6: "' + v6 + '", param7: "' + v7 + '", param8: "' + v8 + '", param9: "' + v9 + '", param10: "' + v10 +
                    '", param11: "' + v11 + '", param12: "' + v12 + '", param13: "' + v13 + '", param14: "' + v14 + '", param15: "' + v15 +
                    '", param16: "' + v16 + '", param17: "' + v17 + '", param18: "' + v18 + '", param19: "' + v19 + '", param20: "' + v20 +
                    '", param21: "' + v21 + '", param22: "' + v22 + '", param23: "' + v23 + '", param24: "' + v24 + '", param25: "' + v25 +
                    '", param26: "' + v26 + '", param27: "' + v27 + '", param28: "' + v28 + '", param29: "' + v29 + '", param30: "' + v30 +
                    '", param31: "' + v31 + '", param32: "' + v32 + '", param33: "' + v33 + '", param34: "' + v34 + '", param35: "' + v35 +
                    '", param36: "' + v36 + '", param37: "' + v37 + '", param38: "' + v38 + '", param39: "' + v39 + '", param40: "' + v40 +
                    '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    alert("Ok");
                    var linkurl = response.d;
                    window.location.href = linkurl;
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
    </script>
    <!-- Salvar Registro  -->

    <!-- Foto  -->
    <script language="JavaScript">

        var handleFileSelect = function (evt) {
            var files = evt.target.files;
            var file = files[0];

            if (files && file) {
                var reader = new FileReader();

                reader.onload = function (readerEvt) {
                    var binaryString = readerEvt.target.result;
                    var data_uri = "data:image/png;base64," + btoa(binaryString);

                    document.getElementById('results').innerHTML = '<img src="' + data_uri + '"/>';
                    document.getElementById("Hidden1").value = data_uri

                };

                reader.readAsBinaryString(file);
            }
        };

        if (window.File && window.FileReader && window.FileList && window.Blob) {
            document.getElementById('filePicker').addEventListener('change', handleFileSelect, false);
        } else {
            alert('The File APIs are not fully supported in this browser.');
        }
    </script>
    <!-- Foto  -->

    <!-- Foco  -->
    <script type="text/javascript">
        document.getElementById("inputNome").focus();
    </script>

</body>

</html>
