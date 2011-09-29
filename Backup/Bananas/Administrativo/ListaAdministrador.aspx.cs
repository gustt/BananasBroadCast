using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bananas.Administrativo
{
    public partial class ListaAdministrador : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Init(object sender, EventArgs e)
        {
            ucToolbar.Parent_New += new UserControls.ToolBar.OnNew(ucToolbar_Parent_New);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ucListaAdministrador.FillUserControl();
        }
        protected void ucToolbar_Parent_New()
        {
            Response.Redirect("~/Administrativo/CadastroAdministrador.aspx");
        }
        #endregion
    }
}