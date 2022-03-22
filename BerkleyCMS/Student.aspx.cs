using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BerkleyCMS
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }
        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"Select s.student_id, p.name, p.date_of_birth, s.student_email, p.age, s.academic_year from student s join person p on s.student_id=p.person_id";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("student");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();


            studentGridView.DataSource = dt;
            studentGridView.DataBind();

        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {

            this.BindGrid();
            studentGridView.EditIndex = -1;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string person_id = idTxt.Text.ToString();
            string name = nameTxt.Text.ToString();
            string email = emailTxt.Text.ToString();
            string dob = dobTxt.Text.ToString();
            int age = int.Parse(ageTxt.Text);
            int academic_year = int.Parse(yearTxt.Text);
        

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constr);

            if (btnSubmit.Text == "Submit")
            {
                OracleCommand cmd1 = new OracleCommand("Insert into person(Person_ID,Name, Date_of_Birth, Age)Values('" + person_id + "','" + name + "','" + dob + "','" + age + "')");
                cmd1.Connection = con;
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();

                OracleCommand cmd2 = new OracleCommand("Insert into student(Student_ID,Student_Email, Academic_Year )Values('" + person_id + "','" + email + "','" + academic_year + "')");
                cmd2.Connection = con;
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();

            }
            else if (btnSubmit.Text == "Update")
            {
                //get ID for the Update
                string ID = IDStore.Text.ToString();


                OracleCommand cmd2 = new OracleCommand("update person set Person_ID = '" + person_id + "',Name = '" + name + "',Date_of_Birth = '" + dob + "' , Age='" + age + "'   where Person_ID ='" + ID + "'");
                cmd2.Connection = con;
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();


                OracleCommand cmd1 = new OracleCommand("update student set Student_ID = '" + person_id + "',Student_Email = '" + email + "' , Academic_Year = '" + academic_year + "' where Student_ID  ='" + ID + "'");
                cmd1.Connection = con;
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();



                btnSubmit.Text = "Submit";
                idTxt.Enabled = true;
                studentGridView.EditIndex = -1;

            }
            idTxt.Text = "";
            nameTxt.Text = "";
            dobTxt.Text = "";
            emailTxt.Text = "";
            ageTxt.Text = "";
            yearTxt.Text = "";
           

            this.BindGrid();
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int ID = Convert.ToInt32(studentGridView.DataKeys[e.RowIndex].Values[0]);
            string ID = (string)e.Values[0];
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand("DELETE FROM student WHERE Student_ID =   + '" + ID + "'"))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                using (OracleCommand cmd = new OracleCommand("DELETE FROM person WHERE Person_ID  = + '" + ID + "'"))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindGrid();
            studentGridView.EditIndex = -1;

        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != studentGridView.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";


            }
            //this.BindGrid();
            studentGridView.EditIndex = -1;

        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            //disable ID textbox
            IDStore.Enabled = false;
            // get id for data update
            IDStore.Text = this.studentGridView.Rows[e.NewEditIndex].Cells[1].Text;
            idTxt.Text = this.studentGridView.Rows[e.NewEditIndex].Cells[1].Text;
            nameTxt.Text = this.studentGridView.Rows[e.NewEditIndex].Cells[2].Text;
            dobTxt.Text = this.studentGridView.Rows[e.NewEditIndex].Cells[3].Text;
            emailTxt.Text = this.studentGridView.Rows[e.NewEditIndex].Cells[4].Text;
            ageTxt.Text = this.studentGridView.Rows[e.NewEditIndex].Cells[5].Text;
            yearTxt.Text = this.studentGridView.Rows[e.NewEditIndex].Cells[6].Text;
            btnSubmit.Text = "Update";


        }

    }
 }
