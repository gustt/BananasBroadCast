using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bananas.Administrativo
{
    public partial class CadastroProgramacao : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Init(object sender, EventArgs e)
        {
            ucToolbar.Parent_Save += new UserControls.ToolBar.OnSave(ucToolbar_Parent_Save);
            ucToolbar.Parent_Delete += new UserControls.ToolBar.OnDelete(ucToolbar_Parent_Delete);

            int _codigoprogramacao;
            if (Request.QueryString["Codigo"] != null &&
                int.TryParse(Request.QueryString["Codigo"], out _codigoprogramacao))
                ucCadastroProgramacao2.FillUserControl(_codigoprogramacao);
            else
                ucCadastroProgramacao2.FillUserControl();

        }
        protected void ucToolbar_Parent_Delete()
        {
            ucCadastroProgramacao2.Delete();
        }
        protected void ucToolbar_Parent_Save()
        {
            ucCadastroProgramacao2.Save();
        }
        #endregion
    }
}