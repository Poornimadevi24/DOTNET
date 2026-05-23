using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Assignemt
{
    public partial class Validator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void cvName_ServerValidate(object source,
           System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid =
                txtName.Text.Trim().ToLower() !=
                txtFamilyName.Text.Trim().ToLower();
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                lblMessage.CssClass = "success";
                lblMessage.Text = "All details are valid!";
            }
            else
            {
                lblMessage.CssClass = "error";
                lblMessage.Text = "Please fix errors!";
            }
        }
    }
}