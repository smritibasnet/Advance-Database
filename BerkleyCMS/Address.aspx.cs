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
    public partial class WebForm5 : System.Web.UI.Page
    {
        [Obsolete]
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
            cmd.CommandText = @"SELECT * from address";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("address");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();



            addressGridView.DataSource = dt;
            addressGridView.DataBind();

        }

        [Obsolete]
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {

            this.BindGrid();
            addressGridView.EditIndex = -1;
        }

        [Obsolete]
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ID = (string)e.Values[0];
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM address WHERE Address_ID = + '" + ID + "'"))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
            addressGridView.EditIndex = -1;

        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != addressGridView.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";


            }
            //this.BindGrid();
            addressGridView.EditIndex = -1;

        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {

            // get id for data update
            IDStore.Text = this.addressGridView.Rows[e.NewEditIndex].Cells[1].Text;
            idTxt.Text = this.addressGridView.Rows[e.NewEditIndex].Cells[1].Text;
            addTxt.Text = this.addressGridView.Rows[e.NewEditIndex].Cells[2].Text; // (row.Cells[2].Controls[0] as TextBox).Text;
            BtnSubmit.Text = "Update";




        }

        //[Obsolete]
        //protected void Button1_Click1(object sender, EventArgs e)
        //{
        //    string add_id = idTxt.Text.ToString();
        //    string add_name = addTxt.Text.ToString();


        //    string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //    OracleConnection con = new OracleConnection(constr);

        //    if (BtnSubmit.Text == "Submit")
        //    {
        //        OracleCommand cmd = new OracleCommand("Insert into address(Address_ID,Address)Values('" + add_id + "','" + add_name  );
        //        cmd.Connection = con;
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();

        //    }

        //    else if (BtnSubmit.Text == "Update")
        //    {
        //        //get ID for the Update
        //        string ID = IDStore.Text.ToString();


        //        OracleCommand cmd = new OracleCommand("update address set Address_ID = '" + add_id + "',Address = '" + add_name + "' where Address_ID ='" + ID + "'");
        //        cmd.Connection = con;
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();



        //        BtnSubmit.Text = "Submit";
        //        idTxt.Enabled = true;
        //        addressGridView.EditIndex = -1;

        //    }

        //    idTxt.Text = "";
        //    addTxt.Text = "";



        //    this.BindGrid();


        //}

        //[Obsolete]
        [Obsolete]
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string add_id = idTxt.Text.ToString();
            string add_name = addTxt.Text.ToString();


            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constr);

            if (BtnSubmit.Text == "Submit")
            {
                OracleCommand cmd = new OracleCommand("Insert into address(Address_ID,Address)Values('" + add_id + "','" + add_name + "')");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }

            else if (BtnSubmit.Text == "Update")
            {
                //get ID for the Update
                string ID = IDStore.Text.ToString();


                OracleCommand cmd = new OracleCommand("update address set Address_ID = '" + add_id + "',Address = '" + add_name + "' where Address_ID ='" + ID + "'");
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();



                BtnSubmit.Text = "Submit";
                idTxt.Enabled = true;
                addressGridView.EditIndex = -1;

            }

            idTxt.Text = "";
            addTxt.Text = "";



            this.BindGrid();


        }
    }
    
}