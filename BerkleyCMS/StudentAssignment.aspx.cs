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
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = nameddl.SelectedValue.ToString();

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT p.name, s.academic_year, r.module_code, r.grade, r.status,  a.assignment_id, a.assignment_type
                                FROM student s
                                JOIN person p
                                ON  p.person_id = s.student_id
                                JOIN result r
                                ON s.student_id = r.student_id
                                JOIN assignment a
                                ON a.assignment_id = r.assignment_id
                                WHERE p.name ='" + name + "' ";

            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("teacher_module");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            studentassignmentGridView.DataSource = dt;
            studentassignmentGridView.DataBind();
        }
    }
}