using System;
using System.Text;

namespace delivcli
{
    public partial class Mapa2 : System.Web.UI.Page
    {

        StringBuilder str = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                montaScript();
                Literal1.Text = str.ToString();
            }
        }

        private void montaScript()
        {
            str.Clear();
            str.Append(@"<script type='text/javascript'> 

                var map;

                function initMap() {
                    map = new google.maps.Map(document.getElementById('map'), {
                        zoom: 14,
                        center: { lat: -12.9886458, lng: -38.4715624 }
                    });
                }

                </script>");
        }


    }
}