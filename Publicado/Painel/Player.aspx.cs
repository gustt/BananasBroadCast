using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bananas.Painel
{
    public partial class Player : References.Web.UI.PageBase
    {
        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Cookies.Clear();
            HttpContext.Current.Request.Cookies.Clear();
            HttpContext.Current.Session.Abandon();

            Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
        }
    }
}