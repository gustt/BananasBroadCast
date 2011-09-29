using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bananas.Administrativo.UserControls
{
    public partial class ColecaoListaProgramacao : References.Web.UI.UserControlBase
    {
        #region Propriedade
        public int CodigoPrograma
        {
            get
            {
                if (ViewState["CodigoPrograma"] == null)
                    ViewState.Add("CodigoPrograma", 0);

                return int.Parse(ViewState["CodigoPrograma"].ToString());
            }
            set
            {
                if (ViewState["CodigoPrograma"] == null)
                    ViewState.Add("CodigoPrograma", value);
                else
                    ViewState["CodigoPrograma"] = value;
            }
        }
        
        #endregion
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            ucToolBar.Parent_New += new UserControls.ToolBar.OnNew(ucToolbar_Parent_New);
        }

        protected void grdListaProgramacao_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect(
                string.Concat("~/Administrativo/CadastroProgramacao.aspx?Codigo=", grdListaProgramacao.DataKeys[e.NewEditIndex].Value.ToString(), "&CodigoPrograma=", CodigoPrograma)
            );
        }
        #endregion
        #region Metodos
        public void FillUserControl(int CodigoPrograma)
        {
            this.CodigoPrograma = CodigoPrograma;

            grdListaProgramacao.DataSource =
                DBLayers.BLL.Regras.Programacao.SelectNewInstance().List(CodigoPrograma);
            grdListaProgramacao.DataBind();
        }
        #endregion
        
        
        protected void ucToolbar_Parent_New()
        {
            Response.Redirect(
                string.Format("~/Administrativo/CadastroProgramacao.aspx?CodigoPrograma={0}", CodigoPrograma));
        }
    }

}