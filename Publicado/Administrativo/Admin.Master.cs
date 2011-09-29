using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bananas;
using Bananas.Administrativo;

namespace Bananas
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void lnk_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(
                string.Format("~/Administrativo/{0}{1}.aspx", e.CommandName, e.CommandArgument));
        }
        protected void lnkRadio_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "_openRadio",
                                "window.open('./../Painel/Player.aspx', '_print', 'width=950,height=570,toolbar=no,dependent=yes,location=no,scrollbars=yes');", true);
        }
        protected void lnkLogOff_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Cookies.Clear();
            HttpContext.Current.Request.Cookies.Clear();
            HttpContext.Current.Session.Abandon();

            Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
        }
    }
}