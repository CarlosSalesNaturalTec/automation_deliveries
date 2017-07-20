using System;
using System.Text;

namespace delivcli
{
    public partial class Mapa1 : System.Web.UI.Page
    {
        StringBuilder str = new StringBuilder();
        StringBuilder coordenadas = new StringBuilder();
        StringBuilder coordenadasDados = new StringBuilder();

        StringBuilder cood_Markers = new StringBuilder();

        StringBuilder EmAbertoCoord = new StringBuilder();
        StringBuilder EmAbertoInfo = new StringBuilder();

        StringBuilder EmAndamentoCoord = new StringBuilder();
        StringBuilder EmAndamentoInfo = new StringBuilder();

        StringBuilder RealizadasCoord = new StringBuilder();
        StringBuilder RealizadasInfo = new StringBuilder();

        StringBuilder RetornoCoord = new StringBuilder();
        StringBuilder RetornoInfo = new StringBuilder();

        string centromapa = "{ lat: -12.9886458, lng: -38.4715624 }";
        int contagem = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // tenta identificar se houve login. caso contrário vai para página de erro
                string v_id_cli = Session["Cli_ID"].ToString();

                //obtemcoordenadas("On-Line");

                EntregasEmAberto();
                EntregasEmAndamento();
                EntregasRealizadas();
                Retornos();

                montaScript();
                Literal1.Text = str.ToString();
            }
        }

        // ---------------------------------------------------------------------------------------------------------------------------
        // Motoboys e respectivas coordenadas de localização
        private void obtemcoordenadas(string escolha)
        {
            try
            {
                string stringselect = "";
                stringselect = @"select nome, GeoLatitude, GeoLongitude , format(GeoDataLoc,'dd-MM-yyyy') as UltimaData," +
                        " format(GeoDataLoc,'HH:mm:ss') as UltimaHora, DATEDIFF(MINUTE, GeoDataLoc, getdate()) AS Intervalo, ID_Motoboy  " +
                        " from Tbl_Motoboys where ID_Cliente = " + Session["Cli_ID"].ToString() +
                        " order by usuario";

                OperacaoBanco operacao = new OperacaoBanco();
                System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

                coordenadas.Clear();
                coordenadasDados.Clear();

                string coord = "";

                while (dados.Read())
                {

                    int min1 = Convert.ToInt32(dados[5]);  // diferença em minutos

                    if (escolha == "On-Line") { if (min1 > 185) { continue; } }
                    if (escolha == "Off-Line") { if (min1 < 185) { continue; } }

                    coord = Convert.ToString(dados[2]);
                    if (coord == "") { continue; }
                    else
                    {
                        // pega somente o primeiro valor para servir como centro do mapa
                        if (contagem == 1) { centromapa = "{ lat: " + Convert.ToString(dados[1]) + ", lng: " + Convert.ToString(dados[2]) + " }"; contagem++; }

                        //obtem dados da ultima leitura
                        coordenadas.Append("{ lat: " + Convert.ToString(dados[1]) + ", lng: " + Convert.ToString(dados[2]) + " },");

                        string dadosCoordenadas = Convert.ToString(dados[0]);

                        string tagIni = "", tagFim = "";
                        int minutos = Convert.ToInt16(dados[5]);

                        if (minutos > 185)
                        {
                            tagIni = "<a href=\"FichaEntregador.aspx?ID=" + Convert.ToString(dados[6]) + "\" target=\"_parent\" style=\"color: red;\">";  
                            tagFim = "</a>";
                        }
                        else
                        {
                            tagIni = "<a href=\"FichaEntregador.aspx?ID=" + Convert.ToString(dados[6]) + "\" target=\"_parent\" style=\"color: green;\">";
                            tagFim = "</a>";
                        }

                        coordenadasDados.Append("'" + tagIni + dadosCoordenadas + tagFim + "',");
                    }
                }
                ConexaoBancoSQL.fecharConexao();

                //remove ultimo caracter "," 
                if (coordenadas.Length == 0) { } else { coordenadas.Length--; }
                if (coordenadasDados.Length == 0) { } else { coordenadasDados.Length--; }

            }
            catch (Exception)
            {
                throw;
            }
        }
        

        // ---------------------------------------------------------------------------------------------------------------------------
        // Entregas em Aberto
        private void EntregasEmAberto()
        {
            EmAbertoCoord.Clear();
            EmAbertoInfo.Clear();
           
            string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
            string stringselect = @"select Tbl_Entregas.Latitude, Tbl_Entregas.Longitude, Tbl_Motoboys.Nome, Tbl_Entregas.Nome_Destinatario, Tbl_Entregas.ID_Entrega" +
                    " from Tbl_Entregas " +
                    " INNER JOIN Tbl_Motoboys ON Tbl_Entregas.ID_Motoboy = Tbl_Motoboys.ID_Motoboy " +
                    " where Tbl_Entregas.ID_Cliente = " + Session["Cli_ID"].ToString() +
                    " and format(Tbl_Entregas.Data_Encomenda,'yyyy-MM-dd') ='" + datastatus + "'" +
                    " and Tbl_Entregas.Status_Entrega ='EM ABERTO'" +
                    " and Tbl_Entregas.Partida_Iniciada =0";

            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
            while (dados.Read())
            {
                string linkUrl = "<a href=\"DetalhesEntrega.aspx" + "?IDEnt=" + Convert.ToString(dados[4]) + "\" target=\"_parent\">";

                string coord = Convert.ToString(dados[0]);
                if (coord == "0") { continue; }
                EmAbertoCoord.Append("{ lat: " + Convert.ToString(dados[0]) + ", lng: " + Convert.ToString(dados[1]) + " },");
                EmAbertoInfo.Append("'" + linkUrl + "Em Aberto: " + Convert.ToString(dados[3]) + " / " + Convert.ToString(dados[2]) + "</a>',");
            }
            ConexaoBancoSQL.fecharConexao();

            //remove ultimo caracter "," 
            if (EmAbertoCoord.Length == 0) { } else { EmAbertoCoord.Length--; }
            if (EmAbertoInfo.Length == 0) { } else { EmAbertoInfo.Length--; }

        }


        // ---------------------------------------------------------------------------------------------------------------------------
        // Entregas em Andamento
        private void EntregasEmAndamento()
        {
            EmAndamentoCoord.Clear();
            EmAndamentoInfo.Clear();
            string datastatus = DateTime.Now.ToString("yyyy-MM-dd");

            string stringselect = @"select Tbl_Entregas.Latitude, Tbl_Entregas.Longitude, Tbl_Motoboys.Nome, Tbl_Entregas.Nome_Destinatario, Tbl_Entregas.ID_Entrega" +
                    " from Tbl_Entregas " +
                    " INNER JOIN Tbl_Motoboys ON Tbl_Entregas.ID_Motoboy = Tbl_Motoboys.ID_Motoboy " +
                    " where Tbl_Entregas.ID_Cliente = " + Session["Cli_ID"].ToString() +
                    " and format(Tbl_Entregas.Data_Encomenda,'yyyy-MM-dd') ='" + datastatus + "'" +
                    " and Tbl_Entregas.Partida_Iniciada = 1" +
                    " and Tbl_Entregas.Entregue = 0";

            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
            while (dados.Read())
            {                
                string coord = Convert.ToString(dados[0]);
                if (coord == "0") { continue; }

                string linkUrl = "<a href=\"DetalhesEntrega.aspx" + "?IDEnt=" + Convert.ToString(dados[4]) + "\" target=\"_parent\">";

                EmAndamentoCoord.Append("{ lat: " + Convert.ToString(dados[0]) + ", lng: " + Convert.ToString(dados[1]) + " },");
                EmAndamentoInfo.Append("'" + linkUrl + "Em Andamento: " + Convert.ToString(dados[3]) + " / " + Convert.ToString(dados[2]) + "</a>',");
            }
            ConexaoBancoSQL.fecharConexao();

            //remove ultimo caracter "," 
            if (EmAndamentoCoord.Length == 0) { } else { EmAndamentoCoord.Length--; }
            if (EmAndamentoInfo.Length == 0) { } else { EmAndamentoInfo.Length--; }

        }


        // ---------------------------------------------------------------------------------------------------------------------------
        // Entregas Realizadas
        private void EntregasRealizadas()
        {
            RealizadasCoord.Clear();
            RealizadasInfo.Clear();

            string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
            string stringselect = @"select Tbl_Entregas.Latitude, Tbl_Entregas.Longitude, Tbl_Motoboys.Nome, Tbl_Entregas.Nome_Destinatario, Tbl_Entregas.ID_Entrega" +
                    " from Tbl_Entregas " +
                    " INNER JOIN Tbl_Motoboys ON Tbl_Entregas.ID_Motoboy = Tbl_Motoboys.ID_Motoboy " +
                    " where Tbl_Entregas.ID_Cliente = " + Session["Cli_ID"].ToString() +
                    " and Tbl_Entregas.Entregue = 1" +
                    " and format(Tbl_Entregas.Data_Encomenda,'yyyy-MM-dd') ='" + datastatus + "'" +
                    " and Tbl_Entregas.Status_Entrega='ENTREGA REALIZADA'";

            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
            while (dados.Read())
            {

                string coord = Convert.ToString(dados[0]);
                if (coord == "0") { continue; }

                string linkUrl = "<a href=\"DetalhesEntrega.aspx" + "?IDEnt=" + Convert.ToString(dados[4]) + "\" target=\"_parent\">";

                RealizadasCoord.Append("{ lat: " + Convert.ToString(dados[0]) + ", lng: " + Convert.ToString(dados[1]) + " },");
                RealizadasInfo.Append("'" + linkUrl + "Entregue: " + Convert.ToString(dados[3]) + " / " + Convert.ToString(dados[2]) + "</a>',");
            }
            ConexaoBancoSQL.fecharConexao();

            //remove ultimo caracter "," 
            if (RealizadasCoord.Length == 0) { } else { RealizadasCoord.Length--; }
            if (RealizadasInfo.Length == 0) { } else { RealizadasInfo.Length--; }

        }

        // ---------------------------------------------------------------------------------------------------------------------------
        // Retornos
        private void Retornos()
        {
            RetornoCoord.Clear();
            RetornoInfo.Clear();

            string datastatus = DateTime.Now.ToString("yyyy-MM-dd");
            string stringselect = @"select Tbl_Entregas.Latitude, Tbl_Entregas.Longitude, Tbl_Motoboys.Nome, Tbl_Entregas.Nome_Destinatario, Tbl_Entregas.ID_Entrega" +
                    " from Tbl_Entregas " +
                    " INNER JOIN Tbl_Motoboys ON Tbl_Entregas.ID_Motoboy = Tbl_Motoboys.ID_Motoboy " +
                    " where Tbl_Entregas.ID_Cliente = " + Session["Cli_ID"].ToString() +
                    " and format(Tbl_Entregas.Data_Encomenda,'yyyy-MM-dd') ='" + datastatus + "'" +
                    " and Tbl_Entregas.Entregue = 1" +
                    " and Tbl_Entregas.Status_Entrega<>'ENTREGA REALIZADA'";

            OperacaoBanco operacao = new OperacaoBanco();
            System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
            while (dados.Read())
            {
                string coord = Convert.ToString(dados[0]);
                if (coord == "0") { continue; }

                string linkUrl = "<a href=\"DetalhesEntrega.aspx" + "?IDEnt=" + Convert.ToString(dados[4]) + "\" target=\"_parent\">";

                RetornoCoord.Append("{ lat: " + Convert.ToString(dados[0]) + ", lng: " + Convert.ToString(dados[1]) + " },");
                RetornoInfo.Append("'" + linkUrl + "Retorno: " + Convert.ToString(dados[3]) + " / " + Convert.ToString(dados[2]) + "</a>',");
            }
            ConexaoBancoSQL.fecharConexao();

            //remove ultimo caracter "," 
            if (RetornoCoord.Length == 0) { } else { RetornoCoord.Length--; }
            if (RetornoInfo.Length == 0) { } else { RetornoInfo.Length--; }

        }

        // ---------------------------------------------------------------------------------------------------------------------------
        // Monta Mapa 
        private void montaScript()
        {
            str.Clear();
            str.Append(@"<script type='text/javascript'> 

            var coordEntregador = [");
            str.Append(coordenadas.ToString());
            str.Append(@"];

            var NomeEntregador = [");
            str.Append(coordenadasDados.ToString());
            str.Append(@"];

            var EntregasEmAberto = [");
            str.Append(EmAbertoCoord.ToString());
            str.Append(@"];

            var EntregasInfo = [");
            str.Append(EmAbertoInfo.ToString());
            str.Append(@"];

            var EmAndamentoCoord = [");
            str.Append(EmAndamentoCoord.ToString());
            str.Append(@"];

            var EmAndamentoInfo = [");
            str.Append(EmAndamentoInfo.ToString());
            str.Append(@"];

            var RealizadasCoord = [");
            str.Append(RealizadasCoord.ToString());
            str.Append(@"];

            var RealizadasInfo = [");
            str.Append(RealizadasInfo.ToString());
            str.Append(@"];

            var RetornosCoord = [");
            str.Append(RetornoCoord.ToString());
            str.Append(@"];

            var RetornosInfo = [");
            str.Append(RetornoInfo.ToString());
            str.Append(@"];

            var CentroDoMapa = ");
            str.Append(centromapa);
            str.Append(@";

        var markers = [];
        var markersEntregas = [];
        var markersEmAndamento = [];
        var markersRealizadas = [];
        var markersRetornos = [];

        var map;
        
        var image = 'images/motorbike24.png';
        var imageEmAberto = 'images/flagEmAberto.png';
        var imageEmAndamento = 'images/flagEmAndamento.png';
        var imageEntregue = 'images/flagOk.png';
        var imageRetorno = 'images/flagRetorno.png';

        function initMap() {
            map = new google.maps.Map(document.getElementById('map'), {
                zoom: 12,
                center: CentroDoMapa
            });

            entregadoresOnLine();

            entregasemAberto();
            entregasemAndamento();
            entregasRealizadas();
            entregasRetornos();
        }

        function entregadoresOnLine() {
            clearMarkers();
            for (var i = 0; i < coordEntregador.length; i++) {
                var contentString = NomeEntregador[i];
                MarcadorEntregador(coordEntregador[i],contentString);
            }
        }

        function entregasemAberto() {
            clearMarkersEntregas();
            for (var i = 0; i < EntregasEmAberto.length; i++) {
                MarcadorEntrega(EntregasEmAberto[i],EntregasInfo[i]);
            }
        }

        function entregasemAndamento() {
            clearEmAndamento();
            for (var i = 0; i < EmAndamentoCoord.length; i++) {
                MarcadorEmAndamento(EmAndamentoCoord[i],EmAndamentoInfo[i]);
            }
        }

        function entregasRealizadas() {
            clearRealizadas();
            for (var i = 0; i < RealizadasCoord.length; i++) {
                MarcadorRealizadas(RealizadasCoord[i],RealizadasInfo[i]);
            }
        }

        function entregasRetornos() {
            clearRetornos();
            for (var i = 0; i < RetornosCoord.length; i++) {
                MarcadorRetornos(RetornosCoord[i],RetornosInfo[i]);
            }
        }

        function MarcadorEntregador(position,dadosc) {
            var marker = new google.maps.Marker({
            position: position,
            icon: image,
            map: map
            });

            var infowindow = new google.maps.InfoWindow({
                content: dadosc
            });

            infowindow.open(map, marker);

            marker.addListener('click', function() {
                infowindow.open(marker.get('map'), marker);
            });
        }

        function MarcadorEntrega(position,info) {
            var markersEntregas = new google.maps.Marker({
            position: position,
            icon: imageEmAberto,
            map: map
            });

            var infowindow = new google.maps.InfoWindow({
                content: info
            });

            markersEntregas.addListener('click', function() {
                infowindow.open(markersEntregas.get('map'), markersEntregas);
            });
        }

        function MarcadorEmAndamento(position,info) {
            var markersEmAndamento = new google.maps.Marker({
            position: position,
            icon: imageEmAndamento,
            map: map
            });

            var infowindow = new google.maps.InfoWindow({
                content: info
            });

            markersEmAndamento.addListener('click', function() {
                infowindow.open(markersEmAndamento.get('map'), markersEmAndamento);
            });
        }

        function MarcadorRealizadas(position,info) {
            var markersRealizadas = new google.maps.Marker({
            position: position,
            icon: imageEntregue,
            map: map
            });

            var infowindow = new google.maps.InfoWindow({
                content: info
            });

            markersRealizadas.addListener('click', function() {
                infowindow.open(markersRealizadas.get('map'), markersRealizadas);
            });
        }

        function MarcadorRetornos(position,info) {
            var markersRetornos = new google.maps.Marker({
            position: position,
            icon: imageRetorno,
            map: map
            });

            var infowindow = new google.maps.InfoWindow({
                content: info
            });

            markersRetornos.addListener('click', function() {
                infowindow.open(markersRetornos.get('map'), markersRetornos);
            });
        }

        function clearMarkers() {
            for (var i = 0; i < markers.length; i++) {
                markers[i].setMap(null);
            }
            markers = [];
        }

        function clearMarkersEntregas() {
            for (var i = 0; i < markersEntregas.length; i++) {
                markersEntregas[i].setMap(null);
            }
            markersEntregas = [];
        }

        function clearEmAndamento() {
            for (var i = 0; i < markersEmAndamento.length; i++) {
                markersEmAndamento[i].setMap(null);
            }
            markersEmAndamento = [];
        }

        function clearRealizadas() {
            for (var i = 0; i < markersRealizadas.length; i++) {
                markersRealizadas[i].setMap(null);
            }
            markersRealizadas = [];
        }

        function clearRetornos() {
            for (var i = 0; i < markersRetornos.length; i++) {
                markersRetornos[i].setMap(null);
            }
            markersRetornos = [];
        }


        </script>");
        }
    }
}