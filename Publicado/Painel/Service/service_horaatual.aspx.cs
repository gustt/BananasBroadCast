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
    public partial class service_horaatual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                sb.Append("<configs>");
                sb.Append(
                    string.Format("<serverinfo hora=\"{0}\" minuto=\"{1}\" segundo=\"{2}\" />", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                );
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