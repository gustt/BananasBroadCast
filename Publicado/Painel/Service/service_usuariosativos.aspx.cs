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
    public partial class service_usuariosativos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                sb.Append("<usuarios>");

                if (Application["UsuariosAtivos"] != null)
                {
                    Dictionary<string, References.Security.UserContext> UsuarioAtivos =
                             Application["UsuariosAtivos"] as Dictionary<string, References.Security.UserContext>;

                    foreach (References.Security.UserContext usuario in UsuarioAtivos.Values)
                    {
                        string xml = "<usuario userid=\"{0}\" nomeusuario=\"{1}\" tipoperfil=\"{2}\" />";
                        sb.Append(string.Format(xml, usuario.UserID, usuario.NomeUsuario, usuario.TipoPerfil));
                    }
                }

                sb.Append("</usuarios>");

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