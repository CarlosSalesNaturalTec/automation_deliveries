using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using DAL;
using System.Web.Script.Serialization;
using System.Web.Script.Services;

namespace WebSiteWS
{
    /// <summary>
    /// Summary description for wsProduto
    /// </summary>
    [WebService(Namespace = "webserviceEntrega")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class wsEntrega : System.Web.Services.WebService
    {

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ConsultarEntrega()
        {
            try
            {
                NegEntregas negEntrega = new NegEntregas();
                List<Tbl_Entregas> colecao = new List<Tbl_Entregas>();
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();

                string json = string.Empty;

                colecao.AddRange(negEntrega.ConsultarEntrega(null));
                json = jsSerializer.Serialize(colecao);

                return json;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
