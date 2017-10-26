function Roteiros_Avançar() {

    var idaux_1 = document.getElementById("select_empresa");
    var idaux_2 = idaux_1.options[idaux_1.selectedIndex].value;     //ID do cliente
    var idaux_3 = idaux_1.options[idaux_1.selectedIndex].text;     //Nom do cliente

    //validacoes
    if (idaux_2 == "0") { alert("Selecione um Cliente"); return }

    $("body").css("cursor", "progress");
    document.getElementById("btnext").style.cursor = "progress";
    document.getElementById("btnext").disabled = true;

    var urlLink = "Roteiros_BarCode.aspx?p1=" + idaux_2 + "&p2=" + idaux_3;
    window.location.href = urlLink;
}

function Roteiros_Avançar_2() {

    var idaux_1 = document.getElementById("select_empresa2");
    var idaux_2 = idaux_1.options[idaux_1.selectedIndex].value;     //ID do cliente
    var idaux_3 = idaux_1.options[idaux_1.selectedIndex].text;     //Nom do cliente

    //validacoes
    if (idaux_2 == "0") { alert("Selecione um Cliente"); return }

    $("body").css("cursor", "progress");
    document.getElementById("btnext2").style.cursor = "progress";
    document.getElementById("btnext2").disabled = true;

    var urlLink = "Roteiros_Simplificado.aspx?p1=" + idaux_2 + "&p2=" + idaux_3;
    window.location.href = urlLink;
}

function Outras_Entregas() {
    var urlLink = "Roteiros_Clientes.aspx";
    window.location.href = urlLink;
}

function Roteiros_Status() {
    var urlLink = "Roteiros_Status.aspx";
    window.location.href = urlLink;
}

function Roteiros_Cancelar() {
    window.location.href = "Home.aspx";
}

function Roteiros_Setting() {
    window.location.href = "Roteiros_Setting.aspx";
}

function Roteiros_Bairro() {
    window.location.href = "Roteiros_Bairros.aspx";
}

function Roteiros_Listagem() {
    window.location.href = "Roteiros_Listagem.aspx";
}

function Roteiros_Pcontas() {
    window.location.href = "Roteiros_Pcontas.aspx";
}