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
    public partial class service_engate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DBLayers.DAL.Entidades.ProgramaEngate pe = DBLayers.BLL.Regras.ProgramaEngate.SelectNewInstance().SelectLast(1);

                StringBuilder sb = new StringBuilder();
                sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                sb.Append("<configs>");

                string tipo = pe.TipoEngate == 0 ? "engate" : "desengate";
                bool isEnabled = true; //DateTime.Now < pe.Data;

                if (DateTime.Now > pe.Data)
                    pe.Data = DateTime.Now.AddSeconds(5);

                //if (isEnabled)
                    sb.Append(string.Format(" <config type=\"{0}\" enabled=\"{1}\" h='{2}' m='{3}' s=\"{4}\" />", tipo, isEnabled.ToString(), pe.Data.Hour, pe.Data.Minute, pe.Data.Second));
                //else
                //    sb.Append(string.Format(" <config type=\"{0}\" enabled=\"{1}\" />", tipo, isEnabled.ToString()));

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