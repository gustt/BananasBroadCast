using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayers.BLL;

namespace Bananas.Administrativo.UserControls
{
    public partial class ColecaoListaCliente :
        References.Web.UI.UserControlBase
    {
        #region Eventos
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                grdLista.DataSource = 
                    DBLayers.BLL.Regras.Cliente.SelectNewInstance().List(txtNomeFantasia.Text, txtRazaoSocial.Text);

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
                string.Concat("~/Administrativo/CadatroCliente.aspx?Codigo=", grdLista.DataKeys[e.NewEditIndex].Value.ToString())
            );
        }
        #endregion
        #region Metodos
        public void FillUserControl()
        {
            if (!IsPostBack)
            {
                grdLista.DataSource = 
                    DBLayers.BLL.Regras.Cliente.SelectNewInstance().List(string.Empty, string.Empty);
                grdLista.DataBind();
            }
        }
        #endregion
    }
}