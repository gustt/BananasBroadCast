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
    public partial class service_programa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sXML = new StringBuilder();
                sXML.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");

                DBLayers.DAL.Entidades.Programa programa =
                    DBLayers.BLL.Regras.Programa.SelectNewInstance().ListProgramaEngatado();

                if (programa != null)
                {
                    string caminho = string.Empty;
                    string nomearquivo = string.Empty;
                    if (!string.IsNullOrEmpty(programa.NomeArquivo))
                    {
                        //string extencao =
                        //    programa.NomeArquivo.Remove(0, programa.NomeArquivo.Length - 3);

                        nomearquivo = programa.NomeArquivo.Replace(" ", "_");

                        caminho =
                            string.Concat(HttpContext.Current.Request.PhysicalApplicationPath, nomearquivo);

                        FileStream fs =
                            new FileStream(
                                caminho,
                                FileMode.Create, FileAccess.Write);
                        fs.Write(programa.Arquivo, 0, programa.Arquivo.Length);
                        fs.Flush();
                        fs.Close();
                    }

                    string url =
                        string.Concat(
                            HttpContext.Current.Request.Url.Scheme, "://",
                            HttpContext.Current.Request.Url.Authority, "/");

                    sXML.Append(
                        string.Format("<programa nome=\"{0}\" img=\"{1}\" >",
                        programa.NomePrograma, string.Concat(url, nomearquivo)));

                    List<DBLayers.DAL.Entidades.Programacao> rProgramacao =
                        DBLayers.BLL.Regras.Programacao.SelectNewInstance().List(programa.Codigo);

                    if (rProgramacao != null && rProgramacao.Count > 0)
                    {
                        string xmlChild = "<programacao titulo=\"{0}\" >{1}</programacao>";
                        foreach (DBLayers.DAL.Entidades.Programacao entidade in rProgramacao)
                            sXML.Append(
                                string.Format(xmlChild,
                                        entidade.Titulo,
                                        entidade.Descricao));
                    }
                    sXML.Append("</programa>");
                }

                Response.Write(sXML.ToString());
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