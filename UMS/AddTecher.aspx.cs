using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMS
{
    public partial class AddTecher : System.Web.UI.Page
    {
        string ConStr = "datasource=localhost;port=3306;username=root;password=database123";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "insert into school.teacher( Name, Email, Phone, DOB, Qualification, Salary, IsActive) values('" + this.txtuserName.Text + "','" + this.txtyEmail.Text + "','" + this.txtPhone.Text + "','" + this.txtDOB.Text + "','" + this.txtQuali.Text + "','" + this.txtSalary.Text + "','" + "1" + "');";

                MySqlConnection MyConn2 = new MySqlConnection(ConStr);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MyConn2.Close();

                string script = "alert(\"TEACHER INSERTED!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);

                txtuserName.Text = txtDOB.Text = txtPhone.Text = txtQuali.Text = txtSalary.Text = txtyEmail.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}