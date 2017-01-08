<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EntregadorNovo.aspx.cs" Inherits="EntregadorNovo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">

    <script src="~/vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="~/vendors/jquery/dist/jquery-3.1.1.min.js" type="text/javascript"></script>

    <style type="text/css">
        #results {
            float: right;
            margin: 5px;
            padding: 5px;
            border: 1px solid;
            background: #ccc;
        }
    </style>

    <script type = "text/javascript">
        function SalvarRegistro() {            

            var v1 = document.getElementById("inputNome").value
            var v2 = document.getElementById("selectVeiculo").value
            var v3 = document.getElementById("inputModelo").value
            var v4 = document.getElementById("inputPlaca").value
            var v5 = document.getElementById("inputIDCli").value
            var v6 = document.getElementById("inputCli").value
            var v7 = document.getElementById("Hidden1").value

            $.ajax({
                type: "POST",
                url: "WebServicePainelMaster.asmx/EntregadorSalvar",
                data: '{v1: "' + v1 + '", v2: "' + v2 + ', v3: "' + v3 + '", v4: "' + v4 + '", v5: "' + v5 + '", v6: "' + v6 + '", v7: "' + v7 + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        function OnSuccess(response) {
            alert(response.d);
            window.location.href = "Entregadores.aspx";
        }
    </script> 

</head>
<body>

    <form class="form-horizontal">
        <fieldset>
            <legend>Novo Entregador</legend>

            <div class="form-group">
                <label for="inputNome" class="col-md-1 control-label">Nome</label>
                <div class="col-md-8">
                    <input type="text" class="form-control" id="inputNome">
                </div>
            </div>

            <div class="form-group">
                <label for="selectVeiculo" class="col-md-1 control-label">Veiculo</label>
                <div class="col-md-2">
                    <select class="form-control" id="selectVeiculo">
                        <option>MOTO</option>
                        <option>CARRO</option>
                    </select>
                </div>
                <label for="inputModelo" class="col-md-1 control-label">Modelo</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputModelo">
                </div>
                <label for="inputPlaca" class="col-md-1 control-label">Placa</label>
                <div class="col-md-2">
                    <input type="text" class="form-control" id="inputPlaca">
                </div>
            </div>

            <div class="form-group">
                <label for="inputIDCli" class="col-md-1 control-label">Cliente</label>
                <div class="col-md-1">
                    <input type="text" class="form-control" id="inputIDCli">
                </div>
                <div class="col-md-7">
                    <input type="text" class="form-control" id="inputCli">
                </div>
            </div>

            <legend></legend>

            <!-- Camera - necessário https -->
            <br />
            <div id="results"></div>
            <div id="my_camera"></div>

            <br />
            <div class="row">
                <div class="col-md-5">
                    <label for="filePicker">Carregar Foto existente:</label><br>
                    <input type="file" id="filePicker">
                </div>
                <div class="col-md-5">
                    <label for="btwebcam">WebCam:</label><br>
                    <input id="btwebcam" type="button" value="Ativar WebCam" onclick="AtivarWebCam()">
                    <input type="button" value="Capturar imagem WebCam" onclick="take_snapshot()">
                </div>
            </div>
            <br />

            <legend></legend>
            <div class="form-group">
                <div class="col-md-4 col-md-offset-1">
                    <button type="reset" class="btn btn-default">Cancelar</button>
                    <input type="button" value="Salvar" onclick="SalvarRegistro()" class="btn btn-success" />
                </div>
            </div>
        </fieldset>
    </form>

    <input id="Hidden1" name="fotouri" type="hidden"/>

    <script type="text/javascript" src="Scripts/webcam.js"></script>

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


        function AtivarWebCam() {
            Webcam.set({
                width: 160,
                height: 120,
                image_format: 'png'
            });
            Webcam.attach('#my_camera');
            
        }

        function take_snapshot() {
            // take snapshot and get image data
            Webcam.snap(function (data_uri) {
                // display results in page
                document.getElementById('results').innerHTML = '<img src="' + data_uri + '"/>';
                document.getElementById("Hidden1").value = data_uri
            });

            Webcam.reset()
        }

    </script>


</body>

</html>
