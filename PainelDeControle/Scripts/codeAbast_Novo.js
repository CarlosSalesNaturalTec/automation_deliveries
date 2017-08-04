document.getElementById("inputNome").focus();

function Salvar() {

    var v1 = document.getElementById("inputPlaca").value
    var v2 = document.getElementById("inputNome").value
    var v3 = document.getElementById("inputValor").value
    var v4 = document.getElementById("inputKm").value

    $("body").css("cursor", "progress");
    document.getElementById("btsalvar").disabled = true;

    $.ajax({
        type: "POST",
        url: "wspainel.asmx/AbastecimentoNovo",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '"}',
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
    var linkurl = "../Abastecimento_Planilha.aspx";
    window.location.href = linkurl;
}