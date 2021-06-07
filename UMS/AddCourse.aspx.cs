using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMS
{
    public partial class AddCourse : System.Web.UI.Page
    {
        string ConStr = "datasource=localhost;port=3306;username=root;password=database123";
        protected void Page_Load(object sender, EventArgs e)
        {
            //FillSemester();
            //FillTeachers();
        }

        //public void FillSemester()
        //{
        //    try
        //    {
        //        MySqlConnection con = new MySqlConnection(ConStr);

        //        MySqlCommand cmd = new MySqlCommand("SELECT ID,semestername FROM school.semester", con);

        //        MySqlDataAdapter da = new MySqlDataAdapter(cmd);

        //        DataTable dt = new DataTable();
        //        da.Fill(dt);

        //        txtSemster.DataTextField = "semestername";
        //        txtSemster.DataValueField = "ID";

        //        txtSemster.DataSource = dt;
        //        txtSemster.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //public void FillTeachers()
        //{
        //    try
        //    {

        //        MySqlConnection con = new MySqlConnection(ConStr);

        //        MySqlCommand cmd = new MySqlCommand("SELECT ID,Name FROM school.teacher", con);

        //        MySqlDataAdapter da = new MySqlDataAdapter(cmd);

        //        DataTable dt = new DataTable();
        //        da.Fill(dt);

        //        txtTeacher.DataTextField = "Name";
        //        txtTeacher.DataValueField = "ID";

        //        txtTeacher.DataSource = dt;
        //        txtTeacher.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "insert into school.course( Name, Code, Semester, Teacher) values('" + this.txtCourse.Text + "','" + this.txtCode.Text + "','" + this.txtSem.Text + "','" + this.txtT.Text + "');";

                MySqlConnection MyConn2 = new MySqlConnection(ConStr);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MyConn2.Close();

                string script = "alert(\"COURSE INSERTED!\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);

                txtCourse.Text = txtCode.Text = txtT.Text = txtSem.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}