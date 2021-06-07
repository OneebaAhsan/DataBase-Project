using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnnLogin_Click(object sender, EventArgs e)
        {
            if (txtuserName.Text == "Usama" && txtPassword.Text == "123456")
            {
                Response.Redirect("~/Deshboard.aspx");
            }
            else
            {
                string script = "alert(\"Invalid Email Or Password!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
        }
    }
}