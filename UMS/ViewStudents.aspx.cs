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
    public partial class ViewStudents : System.Web.UI.Page
    {
        string ConStr = "datasource=localhost;port=3306;username=root;password=database123";
        protected void Page_Load(object sender, EventArgs e)
        {
            gvbind();
        }

        public void gvbind()
        {
            MySqlConnection con = new MySqlConnection(ConStr);
            MySqlCommand cmd = new MySqlCommand("Select s.id,Concat(s.Name,' ',s.LastName) as FullName,p.Pname,p.PNumber,p.PEmail,s.Sex,s.DOB,s.City,s.Semester,s.Section,s.StartDate FROM school.student s inner join  school.parent p ON s.Name = p.SName", con);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();


        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(ConStr);
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label lbldeleteid = (Label)row.FindControl("lblID");
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("delete FROM school.student where id='" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()) + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            string script = "alert(\"STUDENT DELETED!\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                                  "ServerControlScript", script, true);

            gvbind();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gvbind();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //MySqlConnection conn = new MySqlConnection(ConStr);
            //int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            //GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            //Label lblID = (Label)row.FindControl("lblID");
            //TextBox textName = (TextBox)row.Cells[0].Controls[0];
            //TextBox textEmail = (TextBox)row.Cells[1].Controls[0];
            //TextBox textphone = (TextBox)row.Cells[2].Controls[0];
            //TextBox textDOB = (TextBox)row.Cells[3].Controls[0];
            //TextBox textQ = (TextBox)row.Cells[4].Controls[0];
            //TextBox textSal = (TextBox)row.Cells[5].Controls[0];
            //GridView1.EditIndex = -1;
            //conn.Open();
            //MySqlCommand cmd = new MySqlCommand("update school.teacher set Name='" + textName.Text + "',Eamil='" + textEmail.Text + "',Phone='" + textphone.Text + "' DOB='" + textDOB.Text + "' Qualification='" + textQ.Text + "' Salary='" + textSal.Text + "' where id='" + userid + "'", conn);
            //cmd.ExecuteNonQuery();
            //conn.Close();
            //gvbind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            gvbind();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gvbind();
        }
    }
}
