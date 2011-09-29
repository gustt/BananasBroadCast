using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using References.Common;

namespace Bananas.Administrativo
{
    public partial class CadastroProgramacao : References.Web.UI.PageBase
    {
        #region Eventos
        protected void Page_Init(object sender, EventArgs e)
        {
            ucToolbar.Parent_Save += new UserControls.ToolBar.OnSave(ucToolbar_Parent_Save);
            ucToolbar.Parent_Delete += new UserControls.ToolBar.OnDelete(ucToolbar_Parent_Delete);

            ucCadastroProgramacao2.FillUserControl(Request.QueryString["Codigo"].ToInt());
            int _codigoprograma;
            if (Request.QueryString["CodigoPrograma"] != null &&
                int.TryParse(Request.QueryString["CodigoPrograma"], out _codigoprograma))
                ucCadastroProgramacao2.CodigoPrograma = _codigoprograma;
        }
        protected void ucToolbar_Parent_Delete()
        {
            ucCadastroProgramacao2.Delete();
            int _codigoprograma;
            if (Request.QueryString["CodigoPrograma"] != null &&
                int.TryParse(Request.QueryString["CodigoPrograma"], out _codigoprograma))
                Response.Redirect(string.Concat("~/Administrativo/CadastroPrograma.aspx?Codigo=", _codigoprograma));
        }
        protected void ucToolbar_Parent_Save()
        {
            ucCadastroProgramacao2.Save();
            int _codigoprograma;
            if (Request.QueryString["CodigoPrograma"] != null &&
                int.TryParse(Request.QueryString["CodigoPrograma"], out _codigoprograma))
                Response.Redirect(string.Concat("~/Administrativo/CadastroPrograma.aspx?Codigo=", _codigoprograma));
        }
        #endregion
    }
}