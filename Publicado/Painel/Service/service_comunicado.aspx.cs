using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Text;

namespace Bananas.Painel.Service
{
    public partial class service_comunicado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["InicioAcesso"] == null)
                    Session.Add("InicioAcesso", DateTime.Now);

                DateTime timerequest;
                if(!DateTime.TryParse(Session["InicioAcesso"].ToString(), out timerequest))
                    throw new Exception("Não foi possivel recuperar a data de requisição do serviço!");

                DBLayers.BLL.Regras.StreamComunicados regras = new DBLayers.BLL.Regras.StreamComunicados();
                List<DBLayers.DAL.Entidades.StreamComunicados> retorno =
                    regras.List(Session.SessionID, timerequest);

                StringBuilder sb = new StringBuilder();
                sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                sb.Append("<configs>");

                foreach (DBLayers.DAL.Entidades.StreamComunicados msg in retorno)
                    sb.Append(
                        string.Format("<msg userid=\"{0}\" hora=\"{1}\" minuto=\"{2}\" segundo=\"{3}\">{4}</msg>", 
                                            msg.UserId,
                                            msg.DataPostagem.Hour,
                                            msg.DataPostagem.Minute,
                                            msg.DataPostagem.Second,
                                            msg.Mensagem));

                sb.Append("</configs>");

                Response.Write(sb.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
    }
}