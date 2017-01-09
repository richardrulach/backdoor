using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

using System.Xml;

namespace bancdoor
{
    public partial class RuleResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                LitInfo.Text = "";

                String conn = "Database=Origin_ClientArea;Server=192.168.145.5\\UAT;User ID=sa;Password=G10uc35tEr]!;";
                String connMain = "Database=Origin_Main;Server=192.168.145.5\\UAT;User ID=sa;Password=G10uc35tEr]!;";

                SqlConnection sqlconnection = new SqlConnection(conn);
                sqlconnection.Open();

                SqlCommand deleteCmd = new SqlCommand();

                deleteCmd.Connection = sqlconnection;
                deleteCmd.CommandType = CommandType.Text;
                deleteCmd.CommandText = "delete from devonly.debug_ruleresults";
                deleteCmd.ExecuteNonQuery();
                deleteCmd.Dispose();

                sqlconnection.Close();
                sqlconnection.Dispose();

                sqlconnection = new SqlConnection(connMain);
                sqlconnection.Open();

                SqlCommand runRulesCmd = new SqlCommand();
                runRulesCmd.Connection = sqlconnection;
                runRulesCmd.CommandType = CommandType.StoredProcedure;
                runRulesCmd.CommandText = "sp_CheckProductRulesForApplication";

                runRulesCmd.Parameters.Add(new SqlParameter("@ApplicationId", SqlDbType.Int, 50)).Value = txtAppid.Text;
                runRulesCmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int, 50)).Value = 7765;
                runRulesCmd.ExecuteNonQuery();
                runRulesCmd.Dispose();

                sqlconnection.Close();
                sqlconnection.Dispose();

                sqlconnection = new SqlConnection(conn);
                sqlconnection.Open();

                String sSQL = "SELECT * FROM devonly.debug_ruleresults";

                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = sqlconnection;

                sqlcommand.CommandText = sSQL;
                SqlDataReader dr = sqlcommand.ExecuteReader();

                while (dr.Read())
                {
                    String s = dr.GetValue(0).ToString();
                    String sXML = dr.GetValue(1).ToString();

                    XmlDocument xdoc = new XmlDocument();
                    xdoc.LoadXml("<root>" + sXML + "</root>");

                    XmlNodeList xList = xdoc.SelectNodes("/root/*");

                    String newlines = string.Empty;
                    String newline = string.Empty;
                    String header = string.Empty;

                    foreach (XmlElement elem in xList){
                        header = String.Empty;
                        newline = String.Empty;

                        foreach (XmlElement att in elem.ChildNodes)
                        {
                            header += "<th>" + att.Name + "</th>";
                            newline += "<td>" + att.InnerText + "</td>";
                        }

                        newlines += "<tr>" + newline + "</tr>";
                    }

                    LitInfo.Text = LitInfo.Text + 
                        "<div class=\"timestamp\">" + s + "</div>" +
                        "<table>" + header + newlines + "</table>";
                }
                dr.Close();
                sqlcommand.Dispose();

            }

        }
    }
}