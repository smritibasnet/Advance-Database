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
    public partial class WebForm6 : System.Web.UI.Page
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
            cmd.CommandText = @"Select s.student_id, p.name, f.status,f.amount,f.semester
                                from student s 
                                inner join person p on s.student_id=p.person_id
                                inner join fee f on f.student_id=s.student_id
                                WHERE p.name ='" + name + "' ";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("student_fee");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            studentfeeGridView.DataSource = dt;
            studentfeeGridView.DataBind();
        }
    }
}