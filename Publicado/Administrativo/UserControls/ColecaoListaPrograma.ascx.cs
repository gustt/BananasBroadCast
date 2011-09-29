using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayers.BLL;

namespace Bananas.Administrativo.UserControls
{
    public partial class ColecaoListaPrograma :
        References.Web.UI.UserControlBase
    {
        #region Eventos
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                grdLista.DataSource = 
                    DBLayers.BLL.Regras.Programa.SelectNewInstance().List(txtPrograma.Text);
                grdLista.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void grdLista_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect(
                string.Concat("~/Administrativo/CadastroPrograma.aspx?Codigo=", grdLista.DataKeys[e.NewEditIndex].Value.ToString())
            );
        }
        #endregion
        #region Metodos
        public void FillUserControl()
        {
            if (!IsPostBack)
            {
                grdLista.DataSource =
                    DBLayers.BLL.Regras.Programa.SelectNewInstance().List(string.Empty);
                grdLista.DataBind();
            }

        }
        #endregion
    }
}