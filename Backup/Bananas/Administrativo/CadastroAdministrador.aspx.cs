using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bananas.Administrativo
{
    public partial class CadastroAdministrador : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            ucToolbar.Parent_Save += new UserControls.ToolBar.OnSave(ucToolbar_Parent_Save);
            ucToolbar.Parent_Delete += new UserControls.ToolBar.OnDelete(ucToolbar_Parent_Delete);

            string _UserID = string.Empty;
            if (Request.QueryString["UserID"] != null)
            {
                _UserID = Request.QueryString["UserID"].ToString();
                ucCadastroAdministrador.FillUserControl(_UserID);
            }
            else
                ucCadastroAdministrador.FillUserControl();
        }

        protected void ucToolbar_Parent_Delete()
        {
            ucCadastroAdministrador.Delete();
        }

        protected void ucToolbar_Parent_Save()
        {
            ucCadastroAdministrador.Save();
        }
    }
}