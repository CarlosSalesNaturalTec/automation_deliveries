using System;
using System.Text;

namespace delivcli
{
    public partial class DetalhesEntrega : System.Web.UI.Page
    {
        StringBuilder str = new StringBuilder();
        string centromapa = "{ lat: -12.9886458, lng: -38.4715624 }";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // tenta identificar se houve login. caso contrário vai para página de erro
                string v_id_cli = Session["Cli_ID"].ToString();

                montaScript();
                Literal1.Text = str.ToString();
            }
        }

        // ---------------------------------------------------------------------------------------------------------------------------
        // Monta Mapa 
        private void montaScript()
        {
            str.Clear();
            str.Append(@"<script type='text/javascript'> 

            var CentroDoMapa = ");
            str.Append(centromapa);
            str.Append(@";

        var map;

        function initMap() {
            map = new google.maps.Map(document.getElementById('map'), {
                zoom: 12,
                center: CentroDoMapa
            });
        }
        </script>");
        }
    }
}