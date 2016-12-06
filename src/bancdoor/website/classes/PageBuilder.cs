using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Collections;
using System.IO;

namespace GetBanctecDebugInfo
{
    public struct page
    {
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

        public String GetNavigation(String format)
        {

            String sReturn = string.Empty;
            foreach (page p in _pages)
            {
                sReturn += "<a class=\"nav_page\" href=\"javascript:ChangePage(" + p.name + ")\">" + p.name + "</a>";
            }

            return sReturn;
        }

    }
}