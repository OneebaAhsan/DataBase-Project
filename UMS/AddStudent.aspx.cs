using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMS
{
    public partial class AddStudent : System.Web.UI.Page
    {
        string ConStr = "datasource=localhost;port=3306;username=root;password=database123";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "insert into school.student( Name, LastName, Sex, DOB, Number, City, Semester, Section, StartDate) values('" + this.txtName.Text + "','" + this.txtLName.Text + "','" + DropDownList3.SelectedItem.Text.ToString() + "','" + txtDOB.Text + "','" + txtNumber.Text + "','" + txtCity.Text + "','" + txtSem.Text + "','" + txtSection.Text + "','" + txtSDtae.Text + "');";

                MySqlConnection MyConn2 = new MySqlConnection(ConStr);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MyConn2.Close();



                string Query2 = "insert into school.parent( PName, SName, PNumber, PEmail) values('" + this.txtPName.Text + "','" + this.txtName.Text + "','" + txtPNumber.Text + "','" + txtPEmail.Text + "');";

                MySqlConnection MyConn = new MySqlConnection(ConStr);
                MySqlCommand MyCommand = new MySqlCommand(Query2, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();
                MyConn.Close();
                
                string script = "alert(\"STUDENT INSERTED!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);

                txtName.Text = txtLName.Text = txtCity.Text = txtDOB.Text = txtLName.Text = txtName.Text = txtNumber.Text = txtPEmail.Text = txtPName.Text = txtPNumber.Text = txtSDtae.Text = txtSection.Text = txtSem.Text = "";
                DropDownList3.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}