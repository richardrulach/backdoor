using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetBanctecDebugInfo._masterPages
{
    public partial class Root : System.Web.UI.MasterPage
    {
        PageBuilder _pb;

        protected void Page_Load(object sender, EventArgs e)
        {
            _pb = new PageBuilder(Server.MapPath("~\\CONFIG\\Application.xml"));
            litNavigation.Text = _pb.GetNavigation("");
        }

        public PageBuilder GetPageBuilder()
        {
            return _pb;
        }
    }
}