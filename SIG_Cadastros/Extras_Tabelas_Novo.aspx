<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Extras_Tabelas_Novo.aspx.cs" Inherits="Extras_Tabelas_Novo" %>

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

    <link rel="stylesheet" href="custom/StyleTAB.css">

    <script type="text/javascript" src="Scripts/jquery-3.1.1.min.js"></script>
    <script type="text/javascript" src="Scripts/webcam.js"></script>

</head>
<body>

    <h3>NOVA TABELA</h3>
    <br />

    <input id="tab1" type="radio" name="tabs" checked>
    <label for="tab1">Semanal</label>

    <input id="tab2" type="radio" name="tabs">
    <label for="tab2">Domingos e Feriados</label>

    <input id="tab3" type="radio" name="tabs">
    <label for="tab3">Região Metropolitana</label>

    <input id="tab4" type="radio" name="tabs">
    <label for="tab4">Região Metropolitana - Dom.Fer.</label>

    <!-- Funcionário  -->
    <section id="content1">
        <form class="form-horizontal">
            <fieldset>
                <div class="form-group">
                    <label for="inputNome" class="col-md-1 control-label">Nome</label>
                    <div class="col-md-8">
                        <input type="text" class="form-control" id="inputNome">
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputadmissao" class="col-md-1 control-label">Data Admissão</label>
                    <div class="col-md-2">
                        <input type="date" class="form-control" id="inputadmissao">
                    </div>

                    <label for="selectCargo" class="col-md-1 control-label">Cargo</label>
                    <div class="col-md-2">
                        <select class="form-control" id="selectCargo">
                            <option>Motoboy</option>
                            <option>Motorista</option>
                        </select>
                    </div>

                    <label for="inputSalario" class="col-md-1 control-label">Salário</label>
                    <div class="col-md-2">
                        <input type="number" class="form-control" id="inputSalario">
                    </div>

                </div>


            </fieldset>
        </form>
    </section>
    <!-- Funcionário  -->

    <!-- Dados Pessoais  -->
    <section id="content2">
    </section>
    <!-- Dados Pessoais  -->

    <!-- Documentos  -->
    <section id="content3">
    </section>
    <!-- Documentos  -->


    <!-- Veículo -->
    <section id="content4">
    </section>
    <!-- Veículo  -->

    <!-- Ocorrências e Avalizações  -->
    <section id="content5">
    </section>
    <!-- Ocorrências e Avalizações  -->


    <div class="form-group">
        <div class="col-md-4 col-md-offset-1">
            <button type="reset" class="btn btn-primary" onclick="cancelar()"><i class="fa fa-undo"></i>VOLTAR</button>
            <button type="button" class="btn btn-success" onclick="SalvarRegistro()" id="btSalvar"><i class="fa fa-save"></i>SALVAR</button>
        </div>
    </div>


    <!-- Salvar Registro  -->
    <script type="text/javascript">

        function SalvarRegistro() {

            var v1 = document.getElementById("inputNome").value
            var v2 = document.getElementById("selectVeiculo").value
            var v3 = document.getElementById("inputModelo").value
            var v4 = document.getElementById("inputPlaca").value

            var e = document.getElementById("selectCliente")
            var v5 = e.options[e.selectedIndex].value
            var v6 = e.options[e.selectedIndex].text

            var v7 = document.getElementById("Hidden1").value

            if (v1 == "") {
                alert("ATENÇÃO! INFORME NOME DO FUNCIONÁRIO");
                document.getElementById("inputNome").focus();
                return;
            }

            if (v5 == "0") {
                alert("ATENÇÃO! SELECIONE UM CLIENTE DA LISTA");
                document.getElementById("selectCliente").focus();
                return;
            }

            document.getElementById("btSalvar").style.cursor = "progress";
            document.getElementById("btSalvar").disabled = true;

            $.ajax({
                type: "POST",
                url: "WebService.asmx/SalvarEntregador",
                data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 + '", param6: "' + v6 + '", param7: "' + v7 + '"  }',
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
            var linkurl = "Extras_Tabelas.aspx";
            window.location.href = linkurl;
        }
    </script>
    <!-- Salvar Registro  -->

    <!-- Foco  -->
    <script type="text/javascript">
        document.getElementById("inputNome").focus();
    </script>
</body>

</html>
