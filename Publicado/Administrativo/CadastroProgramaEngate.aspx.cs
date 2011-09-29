using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bananas.Administrativo
{
    public partial class CadastroProgramaEngate : References.Web.UI.PageBase
    {
        #region Eventos
        protected void Page_Init(object sender, EventArgs e)
        {
            ucToolbar.Parent_Save += new UserControls.ToolBar.OnSave(ucToolbar_Parent_Save);
            ucToolbar.Parent_Delete += new UserControls.ToolBar.OnDelete(ucToolbar_Parent_Delete);
            ucToolbarComunicado.Parent_Save += new UserControls.ToolBar.OnSave(ucToolbarComunicado_Parent_Save);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ucCadastroProgramaEngate.FillUserControl();
        }
        protected void ucToolbarComunicado_Parent_Save()
        {
            ucCadastroComunicacao.Save();
        }
        protected void ucToolbar_Parent_Delete()
        {
            ucCadastroProgramaEngate.Delete();
        }
        protected void ucToolbar_Parent_Save()
        {
            ucCadastroProgramaEngate.Save();
        }
        #endregion
    }
}