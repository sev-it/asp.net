using System;
using System.Data;
using System.Configuration;
using System.Xml;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace EventRegistrationWeb
{
    public class RegistrationInformaion
    {
        public struct RI
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string SelectedEvent { get; set; }
        }
    }
}

