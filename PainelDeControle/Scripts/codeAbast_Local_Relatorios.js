function verificar() {

    //p1 = período do relatorio (1 a 4) / p2=data ini  p3=data fim / p4=responsavel / p5=analítico ou sintético

    var v4 = document.getElementById('input1').value;
    if (v4 == "") {
        alert("Selecione o Responsável");
        return;
    }

    var v5 = document.getElementById('input_tipo').value;

    var linkurl = "Abastecimento_Local_Relatorios_PDF.aspx";
    var params = "";

    var selecao = document.getElementById('inputPeriodo').value;
    if (selecao == 'ESPECÍFICO') {
        var v2 = document.getElementById("inputData1").value;
        var v3 = document.getElementById("inputData2").value;
        params = "?p1=4&p2=" + v2 + "&p3=" + v3 + "&p4=" + v4 + "&p5=" + v5;
    } else {
        if (selecao == 'COMPLETO') { params = "?p1=1&p4=" + v4 + "&p5=" + v5; }
        if (selecao == 'ESTA SEMANA') { params = "?p1=2&p4=" + v4 + "&p5=" + v5; }
        if (selecao == 'ESTE MÊS') { params = "?p1=3&p4=" + v4 + "&p5=" + v5; }
    }
    var linkFinal = linkurl + params;
    window.open(linkFinal, '_blank');
}

function Selecao_Periodo(selecao) {

    if (selecao == 'ESPECÍFICO') {
        document.getElementById("divInput1").style.display = "block";
        document.getElementById("divInput2").style.display = "block";
        document.getElementById("inputData1").focus();
    } else {
        document.getElementById("divInput1").style.display = "none";
        document.getElementById("divInput2").style.display = "none";
    }

}

function cancelar() {
    var linkurl = "../Abastecimento_Local_Listagem.aspx";
    window.location.href = linkurl;
}