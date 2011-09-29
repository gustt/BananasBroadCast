using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bananas.Administrativo
{
    public partial class CadastroComunicado : References.Web.UI.PageBase
    {
        #region Eventos
        protected void Page_Init(object sender, EventArgs e)
        {
            ucToolbar.Parent_Save += new UserControls.ToolBar.OnSave(ucToolbar_Parent_Save);
            ucToolbar.Parent_Delete += new UserControls.ToolBar.OnDelete(ucToolbar_Parent_Delete);

            int _codigocliente;
            if (Request.QueryString["Codigo"] != null &&
                int.TryParse(Request.QueryString["Codigo"], out _codigocliente))
                ucCadastroComunicado.FillUserControl(_codigocliente);
            else
                ucCadastroComunicado.FillUserControl();

        }
        protected void ucToolbar_Parent_Delete()
        {
            ucCadastroComunicado.Delete();
        }
        protected void ucToolbar_Parent_Save()
        {
            ucCadastroComunicado.Save();
        }
        #endregion
    }
}