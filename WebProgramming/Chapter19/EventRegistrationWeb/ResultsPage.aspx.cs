using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _ResultsPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            RegistrationInformation ri = PreviousPage.RegistrationInformation;
            labelResult.Text = String.Format("{0} {1} selected the event {2}", 
                               ri.FirstName, ri.LastName, ri.SelectedEvent);
        }

        catch
        {
            labelResult.Text = "The originating page must containt" +
                               "textFirstName, textLastName, textEmail controls";
        }

    }
}