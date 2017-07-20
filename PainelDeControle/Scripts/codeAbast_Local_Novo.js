function SalvarRegistro() {

    //validações
    if (document.getElementById('input1').value == "") {
        alert("Informe Nome do Motorista");   
        openLink(event, 'grupo1')
        $('#bt1').addClass(' w3-blue');
        document.getElementById("input1").focus();  
        return;
    }

    //pega o valor de cada campo e constroi string com todos  
    var i, x, strLine = "";
    x = document.getElementsByClassName("form-control");
    for (i = 0; i < x.length; i++) {
        strLine = strLine + "param" + i + ":'" + x[i].value + "',";
    }

    // retira ultima virgula da string recem formada
    strLine = strLine.substring(0, strLine.length - 1);

    //UI - exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/InstituicaoSalvar",  //<!--*******Customização*******-->
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
        alert("Informe Nome da instituição");   //<!--*******Customização******-->
        openLink(event, 'grupo1')
        $('#bt1').addClass(' w3-blue');
        document.getElementById("input1").focus();  //<!--*******Customização******-->
        return;
    }

    //pega o valor de cada campo e constroi string com todos  
    var i, x, strLine = "";
    x = document.getElementsByClassName("form-control");
    for (i = 0; i < x.length; i++) {
        strLine = strLine + "param" + i + ":'" + x[i].value + "',";
    }

    var foto = document.getElementById('FotoHidden').value;
    strLine = strLine + "param" + i + ":'" + foto + "',";

    i++;
    var idAux = document.getElementById('IDAuxHidden').value;
    strLine = strLine + "param" + i + ":'" + idAux + "'";


    //UI - exibir animações - aguarde...
    UIAguardar();

    $.ajax({
        type: "POST",
        url: "WebService.asmx/InstituicaoAlterar",   //<!--*******Customização*******-->
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
    var linkurl = "Abastecimento_Local_Listagem.aspx";  
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