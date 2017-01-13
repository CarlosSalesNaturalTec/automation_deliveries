<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Curriculuns.aspx.cs" Inherits="Curriculuns" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <script src="~/vendors/jquery/dist/jquery.min.js"></script>
    <script src="~/vendors/bootstrap/dist/js/bootstrap.min.js"></script>

</head>

<body>

    <h3>Banco de Currículos</h3>

    <form class="form-horizontal">
        <fieldset>
            <div class="form-group">
                <div class="col-md-3">
                    <select class="form-control" id="selectFuncao">
                        <option disabled selected value>Função</option>
                        <option>MOTOBOY</option>
                        <option>MOTORISTA</option>
                        <option>ADMINISTRATIVO</option>
                        <option>LOGÍSTICA</option>
                        <option>AJUDANTE</option>
                    </select>
                </div>
                <div class="col-md-3">
                    <select class="form-control" id="selectcHabilitacao">
                        <option disabled selected value>Cat.Habilitação</option>
                        <option>A</option>
                        <option>B</option>
                        <option>C</option>
                        <option>D</option>
                        <option>E</option>
                    </select>
                </div>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputBairro" placeholder="Bairro">
                </div>
                <div class="col-md-3">
                    <input type="text" class="form-control" id="inputIndicacao" placeholder="Indicação">
                </div>
            </div>
        </fieldset>
    </form>
    <br />

    <asp:Literal ID="Literal1" runat="server"></asp:Literal>


</body>
</html>
