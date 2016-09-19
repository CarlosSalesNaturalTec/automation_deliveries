using System;
using System.Text;
using System.Web.UI;

namespace automation_deliveries_client
{
    public partial class _Default : Page
    {
        // Variáveis de apoio
        string ID_Cli = "0";  // ID do cliente
        string periodo = "";
        string serie_entregues = "";
        string serie_nao_entregues = "";
        StringBuilder str = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl_data.Text = DateTime.Today.ToString("dd/MM/yyyy");

                Id_Cliente();
                entregasdia();

                // monta e carrega script responsável pelo gráfico : % funcionários em campo
                funcionariosemcampo();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptgraf1", str.ToString(),true);

                // monta e carrega script responsável pelo gráfico : % entregas efetuadas
                entregasefetuadas();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptgraf2", str.ToString(), true);

                // monta e carrega script responsável pelo gráfico : entregas no período
                entregasnoperiodo();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptgraf3", str.ToString(), true);
            }
        }

        private void Id_Cliente()
        {
            try
            {
                //email utilizado no login
                string str1 = Context.User.Identity.Name;
                string str2 = str1.Substring(9);
                string str3 = "";

                //Busca ID do cliente em banco de dados
                OperacaoBanco operacao = new OperacaoBanco();
                System.Data.SqlClient.SqlDataReader dados = operacao.Select("select ID_Cliente from tbl_clientes where email = '" + str2 + "'");
                while (dados.Read()) { str3 = Convert.ToString(dados[0]); }
                ID_Cli = str3;
            }
            catch (Exception)
            {
                lbl_msg.Text = "NÃO FOI POSSÍVEL CARREGAR ID DO CLIENTE";
                throw;
            }
            
        }

        public void entregasdia()
        {
            try
            {
                // string data formatada
                IFormatProvider culture = new System.Globalization.CultureInfo("pt-BR", true);
                DateTime dt2 = DateTime.Parse(lbl_data.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                string date_formated = dt2.ToString("yyyy-MM-dd");

                // total de entregas no dia
                string stringselect = "select count(*) as totalregistros from tbl_entregas where id_cliente = " + ID_Cli + " and Data_Encomenda = '" + date_formated + "'";
                OperacaoBanco operacao = new OperacaoBanco();
                System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);

                while (dados.Read())
                {
                    lbl_total_entregas_dia.Text = Convert.ToString(dados[0]);
                }
                ConexaoBancoSQL.fecharConexao();
            }
            catch (Exception)
            {
                lbl_total_entregas_dia.Text = "9999";
                lbl_msg.Text = lbl_msg.Text + " - ERRO AO CALCULAR TOTAL DE ENTREGAS NO DIA";
                throw;
            }
        }

        private void funcionariosemcampo()
        {
            // variáveis de apoio
            string t1 = "0";
            decimal t2 = 0;
            decimal  t3 = 0;
            int t4 = 0;
            int contador = 0;
            int faltantes = 0;

            // total de funcionários
            try
            {
                string stringselect = "select count(*) as totalregistros from tbl_motoboys where id_cliente = " + ID_Cli ;
                OperacaoBanco operacao = new OperacaoBanco();
                System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
                while (dados.Read())
                {
                    t1 = Convert.ToString(dados[0]);
                }
                ConexaoBancoSQL.fecharConexao();
            }
            catch (Exception)
            {
                lbl_msg.Text = lbl_msg.Text + " - ERRO AO CALCULAR QUANT TOTAL DE FUNCIONARIOS!";
                throw;
            }

            // total de funcionários que já realizaram entregas no dia
            try
            {
                // string data formatada
                IFormatProvider culture = new System.Globalization.CultureInfo("pt-BR", true);
                DateTime dt2 = DateTime.Parse(lbl_data.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                string date_formated = dt2.ToString("yyyy-MM-dd");

                // string lista de funcionários que já efetuaram entregas no dia
                string stringselect = "select ID_Motoboy from tbl_entregas " +
                        " where id_cliente = " + ID_Cli + " and Entregue = 1 and Data_Entrega = '" + date_formated + "' group by ID_Motoboy";

                OperacaoBanco operacao = new OperacaoBanco();
                System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
                while (dados.Read())
                {
                    contador = contador + 1;
                }
                ConexaoBancoSQL.fecharConexao();

                //% total de funcionários em campo
                t2 = Convert.ToDecimal(t1);
                t3 = (contador / t2) * 100;
                t4 = Convert.ToInt16(t3);

                // % total de faltantes = funcionários que ainda não realizaram entregas
                faltantes = 100 - t4;

                montagrafico1(t4,faltantes);

            }
            catch (Exception)
            {
                lbl_msg.Text = lbl_msg.Text + " - ERRO AO CALCULAR QUANT TOTAL DE FUNCIONARIOS QUE EFETUARAM ENTREGA!";
                throw;
            }
        }

        private void montagrafico1(int  v1, int v2)
        {
            str.Append(@"$(function() {
            $('#container_painel2').highcharts({
                    chart:
                    {
                        renderTo: 'load',
                    margin: [0, 0, 0, 0],
                    backgroundColor: null,
                    plotBackgroundColor: 'none',

                },

                title:
                    {
                        text: null
                },

                tooltip:
                    {
                        formatter: function() {
                            return this.point.name + ': ' + this.y + ' %';

                        }
                    },
                series: [
                    {
                        borderWidth: 2,
                        borderColor: '#F1F3EB',
                        shadow: false,
                        type: 'pie',
                        name: 'Income',
                        innerSize: '65%',
                        data: [
                            { name: 'Funcionarios em campo', y: " + v1.ToString());

            str.Append(@", color: '#b2c831' },
                            { name: 'Func.sem entregas realiz.', y: " + v2.ToString());

            str.Append(@", color: '#3d3d3d' }
                        ],
                        dataLabels:
                        {
                            enabled: false,
                            color: '#000000',
                            connectorColor: '#000000'
                        }
                    }]
            });
            });");

        }

        private void entregasefetuadas()
        {
            // variáveis de apoio            
            int v1 = 0;
            int v2 = 0;
            decimal v3 = 0;
            decimal v4 = 0;
            int v5 = 0;
            int v6 = 0;

            // string data formatada
            IFormatProvider culture = new System.Globalization.CultureInfo("pt-BR", true);
            DateTime dt2 = DateTime.Parse(lbl_data.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            string date_formated = dt2.ToString("yyyy-MM-dd");

            try
            {
                // total de entregas no dia = v1
                string stringselect = "select count(*) as totalregistros from tbl_entregas where id_cliente = " + ID_Cli + " and Data_Encomenda = '" + date_formated + "'";
                OperacaoBanco operacao = new OperacaoBanco();
                System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
                while (dados.Read()) { v1 = Convert.ToInt16(dados[0]);}
                ConexaoBancoSQL.fecharConexao();
            }
            catch (Exception)
            {
                lbl_msg.Text = lbl_msg.Text + " - ERRO:TOTAL DE ENTREGAS NO DIA!"; 
                throw;
            }

            try
            {
                // total de entregas realizadas no dia
                string stringselect = "select count(*) as totalregistros from tbl_entregas where " +
                    "id_cliente = " + ID_Cli + " and Data_Encomenda = '" + date_formated + "' " +
                    "and Entregue=1";
                OperacaoBanco operacao = new OperacaoBanco();
                System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
                while (dados.Read()) { v2 = Convert.ToInt16(dados[0]); }
                ConexaoBancoSQL.fecharConexao();

                v4 = Convert.ToDecimal(v1);
                v3 = (v2 / v4) * 100;
                v5 = Convert.ToInt16(v3);
                v6 = 100 - v5;

                montagrafico2(v5, v6);
            }
            catch (Exception)
            {
                lbl_msg.Text = lbl_msg.Text + " - ERRO: TOTAL DE ENTREGAS EFETUADAS NO DIA!";
                throw;
            }
        }

        private void montagrafico2(int entregues, int aentregar)
        {
            str.Clear();
            str.Append(@"$(function () {
	    $('#container_painel1').highcharts({
	        chart: {
	            renderTo: 'load',
	            margin: [0, 0, 0, 0],
	            backgroundColor: null,
	            plotBackgroundColor: 'none'
	        },

	        title: {
	            text: null
	        },

	        tooltip: {
	            formatter: function () {
	                return this.point.name + ': ' + this.y + ' %';

	            }
	        },
	        series: [
				{
				    borderWidth: 2,
				    borderColor: '#F1F3EB',
				    shadow: false,
				    type: 'pie',
				    name: 'Income',
				    innerSize: '65%',
				    data: [
                        { name: 'Total de Encomendas Entregues', y: " + entregues.ToString());

            str.Append(@", color: '#fa1d2d' },
                        { name: 'A Entregar', y: " + aentregar.ToString());

            str.Append(@", color: '#3d3d3d' }
				    ],
				    dataLabels: {
				        enabled: false,
				        color: '#000000',
				        connectorColor: '#000000'
				    }
	        }]
	    });
	});");

        }

        private void entregasnoperiodo()
        {
            // variáveis de apoio
            string per = "";
            string per1 = "";
            string per2 = "";
            int contador = 0;
            int len = 0;

            // string data formatada
            IFormatProvider culture = new System.Globalization.CultureInfo("pt-BR", true);
            DateTime dt2 = DateTime.Parse(lbl_data.Text, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            string date_formated = dt2.ToString("yyyy-MM-dd");

            try
            {             
                // entregas no periodo ultimas 5 datas
                string stringselect = "select Data_Encomenda, FORMAT(Data_Encomenda,'dd/MM') AS PerDate, " +
                    "FORMAT(Data_Encomenda,'yyyy-MM-dd') AS PerDate1  from tbl_entregas " +
                    "where id_cliente = " + ID_Cli + " group by Data_Encomenda";
                OperacaoBanco operacao = new OperacaoBanco();
                System.Data.SqlClient.SqlDataReader dados = operacao.Select(stringselect);
                while (dados.Read())
                {
                    per1 = Convert.ToString(dados[1]);
                    per2 = "'" + per1 + "',";
                    per = per + per2;

                    //monta serie entregues e não entregues
                    entregasperiododia(Convert.ToString(dados[2]));

                    contador = contador + 1;
                    if (contador == 5) { break; }
                }
                ConexaoBancoSQL.fecharConexao();

                len = per.Length - 1;
                periodo = per.Substring(0, len);

                len = serie_entregues.Length - 1;
                serie_entregues = serie_entregues.Substring(0, len);

                len = serie_nao_entregues.Length - 1;
                serie_nao_entregues = serie_nao_entregues.Substring(0, len);
                
                // monta script
                montagrafico3(periodo, serie_entregues, serie_nao_entregues);
            }
            catch (Exception)
            {
                lbl_msg.Text = lbl_msg.Text + " - ERRO AO LEVANTAR ULTIMO PERIODO DE ENTREGAS";
                throw;
            }
        }

        private void entregasperiododia(string date_formated)
        {
            // variáveis de apoio      
            int v1 = 0;
            int v2 = 0;
            
            try
            {
                // total de entregas realizadas no dia = v1
                string stringselect = "select count(*) as totalregistros from tbl_entregas where " +
                    "id_cliente = " + ID_Cli + " and Data_Encomenda = '" + date_formated + "' " +
                    "and Entregue=1";
                OperacaoBanco operacao2 = new OperacaoBanco();
                System.Data.SqlClient.SqlDataReader dados = operacao2.Select(stringselect);
                while (dados.Read()) { v1 = Convert.ToInt16(dados[0]); }
                ConexaoBancoSQL.fecharConexao();
                serie_entregues = serie_entregues + Convert.ToString(v1) + ",";
            }
            catch (Exception)
            {
                lbl_msg.Text = lbl_msg.Text + " - ERRO:TOTAL DE ENTREGAS NO DIA - series!";
                throw;
            }

            try
            {
                // total de entregas não realizadas no dia = v2
                string stringselect = "select count(*) as totalregistros from tbl_entregas where " +
                    "id_cliente = " + ID_Cli + " and Data_Encomenda = '" + date_formated + "' " +
                    "and Entregue<>1";
                OperacaoBanco operacao3 = new OperacaoBanco();
                System.Data.SqlClient.SqlDataReader dados = operacao3.Select(stringselect);
                while (dados.Read()) { v2 = Convert.ToInt16(dados[0]); }
                ConexaoBancoSQL.fecharConexao();
                serie_nao_entregues = serie_nao_entregues + Convert.ToString(v2) + ",";
            }
            catch (Exception)
            {
                lbl_msg.Text = lbl_msg.Text + " - ERRO: TOTAL DE ENTREGAS NÃO EFETUADAS NO DIA! - series";
                throw;
            }
        }

        private void montagrafico3(string periodog, string serieentregues, string serienaoentregues)
        {
            str.Clear();
            str.Append(@"$(function () {
            $('#container_painel3').highcharts({
                chart: {
                    type: 'column',
                    backgroundColor: null,
                    plotBackgroundColor: 'none'
                },
                title: {
                    text: null
                },
                xAxis: {
                    categories: [" + periodog + "]");

            str.Append(@"},
                yAxis: {
                    min: 0,
                    title: {
                        text: 'Total de Entregas'
                    }
                },
                tooltip: {
                    pointFormat: '<span>{series.name}</span>: <b>{point.y}</b> ({point.percentage:.0f}%)<br/>',
                    shared: true
                },
                plotOptions: {
                    column: {
                        stacking: 'percent'
                    }
                },
                series: [
                    {
                        name: 'Nao Entregues',
                        data: [" + serienaoentregues + "],");

            str.Append(@"color: '#b2c831'
                    },
                    {
                        name: 'Entregues',
                        data: [" + serieentregues + "]");

            str.Append(@"}]
            });
        });");

        }
    }
}