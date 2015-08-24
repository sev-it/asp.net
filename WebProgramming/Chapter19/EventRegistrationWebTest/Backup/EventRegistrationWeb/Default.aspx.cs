using System;
using System.Data;
using System.Configuration;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


namespace EventRegistrationWeb
{
	public partial class Default : System.Web.UI.Page
	{
        protected string java;
        void Page_Load(object sender, EventArgs e)
        {
            java = "";
            java += "function PageReload()";
            java += "\n{\n\tdate = new Date();";
            java += "\n\tdocument.write(123);";
            java += "\n\tif ((date.getSeconds() == 0 || date.getSeconds() == 15 || date.getSeconds() == 30 || date.getSeconds() == 45) && document.readyState == \"complete\")";
            java += "\n\t{\n\t\tdocument.form1.submit();\n\t}\n}";

            Page.ClientScript.RegisterClientScriptBlock(
                this.GetType(),
                "myScript",
                java,
                true
                );
        }
	}
}

