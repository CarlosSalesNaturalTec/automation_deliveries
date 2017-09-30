document.getElementById("inputNome").focus();

function SalvarRegistro() {

    document.getElementById("btSalvar").style.cursor = "progress";

    var v1 = document.getElementById("inputNome").value
    var v2 = document.getElementById("inputResponsavel").value
    var v3 = document.getElementById("inputEmail").value
    var v4 = document.getElementById("inputTelefone").value
    var v5 = document.getElementById("inputUsuario").value
    var v6 = document.getElementById("inputSenha").value

    if (v1 == "") {
        alert("Informe Nome do Cliente");
        document.getElementById("inputNome").focus();
        return;
    }

    $.ajax({
        type: "POST",
        url: "wspainel.asmx/SalvarCliente",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 + '", param6: "' + v6 + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            document.getElementById("btSalvar").style.cursor = "default";
            var linkurl = response.d;
            window.location.href = linkurl;
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}
function cancelar() {
    var linkurl = "../Clientes.aspx";
    window.location.href = linkurl;
}