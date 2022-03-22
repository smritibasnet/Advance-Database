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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            cmd.CommandText = @"SELECT * from module";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("module");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();



            modGridView.DataSource = dt;
            modGridView.DataBind();

        }

        [Obsolete]
        protected void Button1_Click1(object sender, EventArgs e)
        {
            string mod_code = modTxt.Text.ToString();
            string mod_name = nameTxt.Text.ToString();
            int cred_hours = int.Parse(chTxt.Text);
            string mod_leader = modLeaderTxt.Text.ToString();

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constr);

            if (btnSubmit.Text == "Submit")
            {
                OracleCommand cmd = new OracleCommand("Insert into module(Module_Code,Module_Name,Credit_Hours, Module_Leader)Values('" + mod_code + "','" + mod_name + "','" + cred_hours + "','" + mod_leader + "')");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }

            else if (btnSubmit.Text == "Update")
            {
                //get ID for the Update
                string ID = IDStore.Text.ToString();


                OracleCommand cmd = new OracleCommand("update module set Module_Code = '" + mod_code + "',Module_Name = '" + mod_name + "',Credit_Hours = '" + cred_hours + "',Module_Leader = '" + mod_leader + "' where Module_Code ='" + ID + "'");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();



                btnSubmit.Text = "Submit";
                modTxt.Enabled = true;
                modGridView.EditIndex = -1;

            }

            modTxt.Text = "";
            nameTxt.Text = "";
            chTxt.Text = "";
            modLeaderTxt.Text = "";


            this.BindGrid();
        }

            [Obsolete]
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {

            this.BindGrid();
            modGridView.EditIndex = -1;
        }

        [Obsolete]
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ID = (string)e.Values[0];
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM module WHERE Module_Code = + '" + ID + "'"))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindGrid();
            modGridView.EditIndex = -1;

        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != modGridView.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";


            }
            //this.BindGrid();
            modGridView.EditIndex = -1;

        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {

            // get id for data update
            IDStore.Text = this.modGridView.Rows[e.NewEditIndex].Cells[1].Text;
            modTxt.Text = this.modGridView.Rows[e.NewEditIndex].Cells[1].Text;
            nameTxt.Text = this.modGridView.Rows[e.NewEditIndex].Cells[2].Text; // (row.Cells[2].Controls[0] as TextBox).Text;
            chTxt.Text = this.modGridView.Rows[e.NewEditIndex].Cells[3].Text;
            modLeaderTxt.Text = this.modGridView.Rows[e.NewEditIndex].Cells[4].Text;
            btnSubmit.Text = "Update";




        }

       
    }
    }


