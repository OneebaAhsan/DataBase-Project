using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMS
{
    public partial class AddClass : System.Web.UI.Page
    {
        string ConStr = "datasource=localhost;port=3306;username=root;password=database123";
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "insert into school.semester(semestername) values('" + this.txtuserName.Text + "');";

                MySqlConnection MyConn2 = new MySqlConnection(ConStr);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MyConn2.Close();

                string script = "alert(\"SEMESTER INSERTED!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);

                this.txtuserName.Text ="";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}