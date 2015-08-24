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
    public partial class ResultsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DropDownList dropDownListEvents =
                    (DropDownList)PreviousPage.FindControl("dropDownListEvents");
                string selectedEvent = dropDownListEvents.SelectedValue;
                string firstName = ((TextBox)PreviousPage.FindControl("textFirstName")).Text;
                string lastName = ((TextBox)PreviousPage.FindControl("textLastName")).Text;
                string email = ((TextBox)PreviousPage.FindControl("textEmail")).Text;
                labelResult.Text = string.Format(
                    "{0} {1} selected event {2}",
                    firstName,
                    lastName,
                    email
                );
            } catch
            {
                labelResult.Text = "The originating page must contain " + 
                    "textFirstName, textlastName, textEmail controls";
            }
        }
    }
}

