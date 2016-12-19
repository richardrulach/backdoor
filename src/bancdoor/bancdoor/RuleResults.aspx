<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RuleResults.aspx.cs" Inherits="bancdoor.RuleResults" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rule results</title>
    <link rel="Stylesheet" type="text/css" href="_css/main.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Rule Results</h1>
        <div>
            Applicationid: <asp:TextBox ID="txtAppid" runat="server" />
        </div>
        <div>
            Ruleid: <asp:TextBox ID="txtRuleid" runat="server" />
        </div>
        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
        </div>        
        <div class="resultsContainer">
            <asp:Literal ID="LitInfo" runat="server" ></asp:Literal>
        </div>
    </div>
    </form>
</body>
</html>
