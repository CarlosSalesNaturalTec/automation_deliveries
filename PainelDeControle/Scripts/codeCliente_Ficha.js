function AtualizarRegistro() {

    var v1 = document.getElementById("inputNome").value
    var v2 = document.getElementById("inputResponsavel").value
    var v3 = document.getElementById("inputEmail").value
    var v4 = document.getElementById("inputTelefone").value
    var v5 = document.getElementById("IDHidden").value
    var v6 = document.getElementById("inputUsuario").value
    var v7 = document.getElementById("inputSenha").value

    $.ajax({
        type: "POST",
        url: "wspainel.asmx/EditarCliente",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 + '", param6: "' + v6 + '", param7: "' + v7 + '" }',
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

    var v1 = document.getElementById("IDHidden").value

    $.ajax({
        type: "POST",
        url: "wspainel.asmx/ExcluirCliente",
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
    var linkurl = "../Clientes.aspx";
    window.location.href = linkurl;
}

function CidadeIncluir() {

    if (document.getElementById('input_cidade').value == "") {
        alert("Informe Cidade");
        document.getElementById("input_cidade").focus();
        return;
    }

    var v1 = document.getElementById('IDHidden').value;
    var v2 = document.getElementById("input_cidade").value;
    var v3 = document.getElementById("input_valor").value;

    $.ajax({
        type: "POST",
        url: "wspainel.asmx/ClienteNovaCidade",  
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            CidadeInsertLinha();
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

function CidadeExcluir(r, USerID) {

    var conf = confirm("Confirma Exclusão de Cidade?");
    if (conf == false) {
        return;
    }

    $.ajax({
        type: "POST",
        url: "wspainel.asmx/ClienteDELCidade",  
        data: '{param1: "' + USerID + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            // excluir linha do Table
            var i = r.parentNode.parentNode.rowIndex;
            document.getElementById("MyTable").deleteRow(i);
        },
        failure: function (response) {
            alert(response.d);
        }
    });


}

function CidadeInsertLinha() {

    var col1 = document.getElementById('input_cidade').value;
    var col2 = document.getElementById('input_valor').value;

    var table = document.getElementById("MyTable");

    var row = table.insertRow(-1);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);

    cell1.innerHTML = col1;
    cell2.innerHTML = col2;

    //apaga formulario
    document.getElementById('input_cidade').value = "";
    document.getElementById('input_valor').value = "";

}