function NovoRegistro() {
    window.location.href = "Abastecimento_Local_Novo.aspx";  
}

function ExcluirRegistro() {

    var idRegistro = document.getElementById('HiddenID').value;

    $.ajax({
        type: "POST",
        url: "wspainel.asmx/AbastLocalExcluir",
        data: '{param1: "' + idRegistro + '" }',
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

function Excluir(IDExc) {
    document.getElementById('HiddenID').value = IDExc;
    document.getElementById('DivModal').style.display = "block";
}

function Excluir_cancel() {
    document.getElementById('DivModal').style.display = 'none';
}