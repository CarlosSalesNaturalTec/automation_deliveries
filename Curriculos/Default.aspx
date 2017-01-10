<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <style type="text/css">
        #results {
            float: right;
            margin: 5px;
            padding: 5px;
            border: 1px solid;
            background: #ccc;
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

    <br />
    <form class="form-horizontal">
        <fieldset>
            <legend> LOG Transportes - Cadastro de Curriculum Vitae</legend>

            <div class="form-group">
                <label for="inputNome" class="col-md-1 control-label">Nome</label>
                <div class="col-md-9">
                    <input type="text" class="form-control" id="inputNome">
                </div>
            </div>

            <div class="form-group">
                <label for="inputRG" class="col-md-1 control-label">RG</label>
                <div class="col-md-4">
                    <input type="text" class="form-control" id="inputRG">
                </div>
                <label for="inputCPF" class="col-md-1 control-label">CPF</label>
                <div class="col-md-4">
                    <input type="email" class="form-control" id="inputCPF">
                </div>
            </div>

            <div class="form-group">
                <label for="inputEnd" class="col-md-1 control-label">Endereço</label>
                <div class="col-md-6">
                    <input type="text" class="form-control" id="inputEnd">
                </div>
                <label for="inputCEP" class="col-md-1 control-label">CEP</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputCEP">
                </div>
            </div>

            <div class="form-group">
                <label for="inputResid" class="col-md-1 control-label">Tel.Resid</label>
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
                <label for="selectEstCivil" class="col-md-1 control-label">Est.Civil</label>
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
                <label for="selecthabilita" class="col-md-1 control-label">Habilitação</label>
                <div class="col-md-1">
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

                <label for="habilitaEmiss" class="col-md-1 control-label">Emissão</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="habilitaEmiss">
                </div>
            </div>

            <div class="form-group">
                <label for="selectVeiculo" class="col-md-1 control-label">Veic.Propio</label>
                <div class="col-md-1">
                    <select class="form-control" id="selectVeiculo">
                        <option>SIM</option>
                        <option>NÃO</option>
                    </select>
                </div>
                <label for="inputAnoModelo" class="col-md-1 control-label">Ano/Modelo</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputAnoModelo">
                </div>
            </div>

            <div class="form-group">
                <label for="selectArea" class="col-md-1 control-label">Area Desejada</label>
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
                <label for="inputExperiencia1" class="col-md-1 control-label">Empresa</label>
                <div class="col-md-4">
                    <input type="text" class="form-control" id="inputExperiencia1">
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
                <label for="inputAtividades1" class="col-md-1 control-label">Atividades</label>
                <div class="col-md-10">
                    <input type="text" class="form-control" id="inputAtividades1" placeholder="Atividades desenvolvidas neste cargo">
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
                    <label for="filePicker">Carregar Foto:</label><br>
                    <input type="file" id="filePicker">
                </div>
            </div>
            <input id="Hidden1" name="fotouri" type="hidden" />
            <br />
            <!-- Camera  -->

            <legend></legend>

            <div class="form-group">
                <div class="col-md-4 col-md-offset-1">
                    <button type="button" class="btn btn-success" onclick="SalvarRegistro()">Salvar</button>
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

            if (v1 == "") {
                alert("Informe Nome");
                document.getElementById("inputNome").focus();
                return;
            }

            $.ajax({
                type: "POST",
                url: "wspainel.asmx/SalvarCurric",
                data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 + '", param6: "' + v6 + '", param7: "' + v7 + '" }',
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
        function cancelar() {
            var linkurl = "../Curriculuns.aspx";
            window.location.href = linkurl;
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
