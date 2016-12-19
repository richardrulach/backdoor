using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Collections;
using System.IO;

using System.Web.UI;
using System.Web.UI.WebControls;

namespace bancdoor
{
    public struct page
    {
        public int id;
        public string name, url;
    }

    public class PageBuilder
    {
        private String _configUrl = String.Empty;
        private Hashtable _environments = new Hashtable();
        private ArrayList _pages = new ArrayList();

        public PageBuilder(String configUrl)
        {
            _configUrl = configUrl;
            LoadConfig();
        }

        public void LoadConfig()
        {
            // LOAD ENVIRONMENTS
            foreach (
                System.Configuration.ConnectionStringSettings css in
                System.Web.Configuration.WebConfigurationManager.ConnectionStrings)
            {
                _environments.Add(css.Name, css.ConnectionString);
            }

            // LOAD 
            
            if (File.Exists(_configUrl))
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(_configUrl);

                foreach (XmlNode xnode in xdoc.SelectNodes("//navigation/page"))
                {
                    page p = new page();
                    p.id = Int32.Parse(xnode.Attributes["pageid"].Value);
                    p.name = xnode.Attributes["name"].Value;
                    p.url = xnode.Attributes["path"].Value;

                    _pages.Add(p);
                }
            }

        }

        public String GetEvironments(String format)
        {
            String sReturn = string.Empty;
            foreach (String key in _environments.Keys)
            {
                sReturn += "<div>" + key + "</div>";
            }
            return sReturn;
        }

        public List<HyperLink> GetNavigationLinks()
        {

            List<HyperLink> lst = new List<HyperLink>();
            foreach (page p in _pages)
            {
                HyperLink h = new HyperLink();
                h.Text = p.name;
                h.NavigateUrl = "~/?pid=" + p.id.ToString();
                lst.Add(h);
            }

            return lst;
        }

    }
}