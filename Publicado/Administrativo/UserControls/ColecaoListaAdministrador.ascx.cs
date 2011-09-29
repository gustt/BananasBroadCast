using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayers.BLL;

namespace Bananas.Administrativo.UserControls
{
    public partial class ColecaoListaAdministrador : References.Web.UI.UserControlBase
    {
        #region Eventos
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {

            try
            {
                grdLista.DataSource =
                    DBLayers.BLL.Regras.Usuario.SelectNewInstance().List(txtAdministrador.Text);
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
                string.Concat("~/Administrativo/CadastroAdministrador.aspx?UserID=", grdLista.DataKeys[e.NewEditIndex].Value.ToString())
            );
        }
        protected void grdLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdLista.PageIndex = e.NewPageIndex;
            FillUserControl();
        }
        #endregion
        #region Metodos
        public void FillUserControl()
        {
            grdLista.DataSource =
                DBLayers.BLL.Regras.Usuario.SelectNewInstance().List(string.Empty);
            grdLista.DataBind();
        }
        #endregion
    }
}