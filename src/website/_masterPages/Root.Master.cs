using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bancdoor._masterPages
{
    public partial class Root : System.Web.UI.MasterPage
    {
        PageBuilder _pb;

        protected void Page_Load(object sender, EventArgs e)
        {
            _pb = new PageBuilder(Server.MapPath("~\\CONFIG\\Application.xml"));
//            litNavigation.Text = _pb.GetNavigation("");

            List<HyperLink> nav = _pb.GetNavigationLinks();

            foreach (HyperLink h in nav)
            {
                navigation.Controls.Add(h);
            }
        }

        public PageBuilder GetPageBuilder()
        {
            return _pb;
        }
    }
}