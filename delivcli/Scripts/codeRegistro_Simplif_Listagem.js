function NovoRegistro() {
    window.location.href = "Registro_Simplif_Novo.aspx";
}

function ExcluirRegistro() {

    var idRegistro = document.getElementById('HiddenID').value;

    $.ajax({
        type: "POST",
        url: "WebService1.asmx/Registro_Simplif_Excluir",
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

function Relatorios() {
    var linkurl = "../Registro_Simplif_Relatorios.aspx";
    //window.location.href = linkurl;
}