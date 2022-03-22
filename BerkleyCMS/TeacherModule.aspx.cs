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
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = idddl.SelectedValue.ToString();

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT p.person_id, p.name,  t.teacher_email, m.module_code, m.module_name, m.credit_hours
FROM person p
JOIN teacher t
ON t.teacher_id = p.person_id
JOIN teacher_module tm 
ON t.teacher_id = tm.teacher_id
JOIN module m
ON tm.module_code = m.module_code
 WHERE p.name ='" + name + "' ";

            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("teacher_module");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            tmGridView.DataSource = dt;
            tmGridView.DataBind();
        }

        
    }
}