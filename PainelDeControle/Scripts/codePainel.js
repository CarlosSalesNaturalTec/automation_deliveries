function sair() {
    document.getElementById('DivLogOut').style.display = "block";
}

function sair_cancel() {
    document.getElementById('DivLogOut').style.display = 'none';
}

function sair_exit() {
    window.open('LogOut.aspx', '_parent');
}