<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Funcionarios_Ficha.aspx.cs" Inherits="Funcionarios_Ficha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <style type="text/css">
        #results {
            float: left;
            margin: 5px;
            padding: 5px;
            border: 1px solid;
            background: #ccc;
        }
    </style>

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">

    <script type="text/javascript" src="Scripts/jquery-3.1.1.min.js"></script>
    <script type="text/javascript" src="Scripts/webcam.js"></script>

</head>
<body>

    <form class="form-horizontal">
        <fieldset>
            <legend>FICHA FUNCIONÁRIO</legend>

            <!-- Camera  -->
            <div id="results"></div>
            <div id="my_camera"></div>
            <br />
            <div class="row">
                <div class="col-sm-6">
                    <label for="filePicker">Carregar Foto:</label><br>
                    <input type="file" id="filePicker">
                </div>
            </div>
            <input id="Hidden1" name="fotouri" type="hidden" />
            <br />
            <!-- Camera  -->

            <legend></legend>

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
                    <input type="text" class="form-control" id="inputIDCli" readonly>
                </div>
                <div class="col-md-7">
                    <input type="text" class="form-control" id="inputCliente" readonly>
                </div>
            </div>   
            
            <div class="form-group">
                 <div class="col-md-1">
                     </div>
                <div class="col-md-8">
                    <select class="form-control" id="selectCliente" onclick="IdentificaCLiente()">
                        <asp:Literal ID="literal_clientes" runat="server"></asp:Literal>
                    </select>
                </div>
            </div>         

            <legend></legend>

            <input id="IDHidden" name="IDHidden" type="hidden" />

            <div class="form-group">
                <div class="col-md-4 col-md-offset-1">
                    <button id="btVoltar" type="reset" class="btn btn-primary" onclick="cancelar()"><i class="fa fa-undo"></i> VOLTAR</button>
                    <button id="btExcluir" type="button" class="btn btn-danger" onclick="ExcluirRegistro()"><i class="fa fa-trash"></i> EXCLUIR</button>
                    <button id="btSalvar" type="button" class="btn btn-success" onclick="AtualizarRegistro()"><i class="fa fa-save"></i> SALVAR</button>
                </div>
            </div>

        </fieldset>
    </form>

    <!-- preenche campos  -->
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <!-- preenche campos  -->

    <!-- Operações com Registro  -->
    <script type="text/javascript">

        function IdentificaCLiente() {
            var e = document.getElementById("selectCliente")
            document.getElementById("inputIDCli").value = e.options[e.selectedIndex].value
            document.getElementById("inputCliente").value = e.options[e.selectedIndex].text
        }

        function AtualizarRegistro() {

            document.getElementById("btSalvar").style.cursor = "progress";

            var v1 = document.getElementById("inputNome").value
            var v2 = document.getElementById("selectVeiculo").value
            var v3 = document.getElementById("inputModelo").value
            var v4 = document.getElementById("inputPlaca").value
            var v5 = document.getElementById("inputIDCli").value
            var v6 = document.getElementById("inputCliente").value
            var v7 = document.getElementById("Hidden1").value
            var v8 = document.getElementById("IDHidden").value

            $.ajax({
                type: "POST",
                url: "WebService.asmx/EditarEntregador",
                data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 + '", param6: "' + v6 + '", param7: "' + v7 + '", param8: "' + v8 + '"  }',
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

        function ExcluirRegistro() {

            var r = confirm("CONFIRMA EXCLUSÂO ?");
            if (r == false) {
                return;
            }

            document.getElementById("btExcluir").style.cursor = "progress";

            var v1 = document.getElementById("IDHidden").value

            $.ajax({
                type: "POST",
                url: "WebService.asmx/ExcluirEntregador",
                data: '{param1: "' + v1 + '" }',
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

        function cancelar() {
            var linkurl = "Funcionarios.aspx";
            window.location.href = linkurl;
        }
    </script>
    <!-- Operações com Registro  -->

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

</body>
</html>
