function Roteiros_Avançar() {

    $("body").css("cursor", "progress");

    document.getElementById("btnext").style.cursor = "progress";
    document.getElementById("btnext").disabled = true;

    var idaux_1 = document.getElementById("select_empresa");
    var idaux_2 = idaux_1.options[idaux_1.selectedIndex].value;     //ID do cliente
    var idaux_3 = idaux_1.options[idaux_1.selectedIndex].text;     //Nom do cliente

    //validacoes
    if (idaux_2 == "0") { alert("Selecione um Cliente"); return }

    var urlLink = "Roteiro_BarCode.aspx?p1=" + idaux_2 + "&p2=" + idaux_3;
    window.location.href = urlLink;
}

function Roteiros_Cancelar() {
    window.location.href = "Home.aspx";
}
