using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bananas.Administrativo
{
    public partial class CadastroProgramaEngate : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Init(object sender, EventArgs e)
        {
            ucToolbar.Parent_Save += new UserControls.ToolBar.OnSave(ucToolbar_Parent_Save);
            ucToolbar.Parent_Delete += new UserControls.ToolBar.OnDelete(ucToolbar_Parent_Delete);
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