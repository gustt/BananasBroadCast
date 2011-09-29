using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bananas.Administrativo.UserControls
{
    public partial class ToolBar : System.Web.UI.UserControl
    {
        #region ..:: Delegates
        public delegate void OnSave();
        public delegate void OnDelete();
        public delegate void OnNew();

        public event OnNew Parent_New;
        public event OnSave Parent_Save;
        public event OnDelete Parent_Delete;
        #endregion

        #region ..:: Events
        protected void Page_PreRender(object sender, EventArgs e)
        {
            tdNovo.Visible = Parent_New != null;
            tdExcluir.Visible = Parent_Delete != null;
            tdSalvar.Visible = Parent_Save != null;
        }
        protected void lnkNovo_Click(object sender, EventArgs e)
        {
            if (Parent_New != null)
                Parent_New.Invoke();
        }
        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            if (Parent_Save != null)
                Parent_Save.Invoke();
        }
        protected void lnkDeletar_Click(object sender, EventArgs e)
        {
            if (Parent_Delete != null)
                Parent_Delete.Invoke();
        }
        #endregion
    }
}