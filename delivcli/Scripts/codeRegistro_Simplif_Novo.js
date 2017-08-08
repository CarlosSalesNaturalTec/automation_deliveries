document.getElementById('input1').focus();

function SalvarRegistro() {

    //validações
    if (document.getElementById('input1').value == "") {
        alert("Informe Nome do Motoboy");   
        document.getElementById("input1").focus();  
        return;
    }

    //pega o valor de cada campo e constroi string com todos  
    var i, x, strLine = "";
    x = document.getElementsByClassName("form-control");
    for (i = 0; i < x.length; i++) {
        strLine = strLine + "param" + i + ":'" + x[i].value + "',";
    }

    var talao = document.getElementById('IDAuxHidden').value;
    strLine = strLine + "param" + i + ":'" + talao + "'";

    //UI - exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService1.asmx/Registro_Simplif_Novo",
        data: '{' + strLine + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            window.location.href = response.d;
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

function AlterarRegistro() {

    //validações
    if (document.getElementById('input1').value == "") {
        alert("Informe Nome do Motoboy");
        document.getElementById("input1").focus();  
        return;
    }

    //pega o valor de cada campo e constroi string com todos  
    var i, x, strLine = "";
    x = document.getElementsByClassName("form-control");
    for (i = 0; i < x.length; i++) {
        strLine = strLine + "param" + i + ":'" + x[i].value + "',";
    }

    var idAux = document.getElementById('IDAuxHidden').value;
    strLine = strLine + "param" + i + ":'" + idAux + "'";

    //UI - exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService1.asmx/Registro_Simplif_Alterar",
        data: '{' + strLine + '}',
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
    var linkurl = "../Registro_Simplif_Listagem.aspx";
    window.location.href = linkurl;
}

function UIAguardar() {
    var i, x;

    x = document.getElementsByClassName("btcontroles");
    for (i = 0; i < x.length; i++) {
        x[i].disabled = true;
    }

    x = document.getElementsByClassName("aguarde");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "block";
    }
}

