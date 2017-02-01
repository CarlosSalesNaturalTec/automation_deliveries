<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cad_Entregas_Import.aspx.cs" Inherits="delivcli.Cad_Entregas_Import" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <meta charset="utf-8">

    <div id="page-wrapper">

        <h1>Importação Arquivo TXT</h1>
        <div>
            Selecione o Arquivo: 
		
            <input type="file" id="fileInput" accept='text/plain'>
        </div>
        <br />
        <input type="hidden" name="textContent" id="fileDisplayArea" />

        <asp:Button ID="Button1" runat="server" Text="Leitura" OnClick="Button1_Click" />
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>

    <script type="text/javascript">

        window.onload = function () {
            var fileInput = document.getElementById('fileInput');
            var fileDisplayArea = document.getElementById('fileDisplayArea');

            fileInput.addEventListener('change', function (e) {
                var file = fileInput.files[0];
                var textType = /text.*/;

                if (file.type.match(textType)) {
                    var reader = new FileReader();

                    reader.onload = function (e) {
                        fileDisplayArea.value = reader.result;
                    }

                    reader.readAsText(file);
                } else {
                    fileDisplayArea.innerText = "File not supported!";
                }
            });
        }
    </script>



</asp:Content>
