using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BerkleyCMS
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        [Obsolete]
        protected void Page_Load(object sender, EventArgs e)
        {
            // default load data
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        [Obsolete]
        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT * from department";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("department");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();



            departmentGridView.DataSource = dt;
            departmentGridView.DataBind();

        }


        

        [Obsolete]
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {

            this.BindGrid();
            departmentGridView.EditIndex = -1;
        }

        [Obsolete]
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ID = (string)e.Values[0];
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM department WHERE Department_ID = + '"+ ID +"'"))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindGrid();
            departmentGridView.EditIndex = -1;

        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != departmentGridView.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";


            }
            //this.BindGrid();
            departmentGridView.EditIndex = -1;

        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {

            // get id for data update
            IDStore.Text = this.departmentGridView.Rows[e.NewEditIndex].Cells[1].Text;
            idTxt.Text = this.departmentGridView.Rows[e.NewEditIndex].Cells[1].Text;
            nameTxt.Text = this.departmentGridView.Rows[e.NewEditIndex].Cells[2].Text; // (row.Cells[2].Controls[0] as TextBox).Text;
            hodTxt.Text = this.departmentGridView.Rows[e.NewEditIndex].Cells[3].Text;
            btnSubmit.Text = "Update";




        }

        [Obsolete]
        protected void Button1_Click1(object sender, EventArgs e)
        {
            string dep_id = idTxt.Text.ToString();
            string depname = nameTxt.Text.ToString();
            string hod = hodTxt.Text.ToString();

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constr);

            if (btnSubmit.Text == "Submit")
            {
                OracleCommand cmd = new OracleCommand("Insert into department(Department_ID,Department_Name,Head_of_Department)Values('" + dep_id + "','" + depname + "','" + hod + "')");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }

            else if (btnSubmit.Text == "Update")
            {
                //get ID for the Update
                string ID = IDStore.Text.ToString();


                OracleCommand cmd = new OracleCommand("update department set Department_ID = '" + dep_id + "',Department_Name = '" + depname + "',Head_of_Department = '" + hod + "' where Department_ID ='" + ID + "'");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();



               btnSubmit.Text = "Submit";
                idTxt.Enabled = true;
                departmentGridView.EditIndex = -1;

            }

            idTxt.Text = "";
            nameTxt.Text = "";
            hodTxt.Text = "";


            this.BindGrid();

        }
    }
}