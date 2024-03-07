using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmaci.AdministratorUC
{
    public partial class UC_Dashboard : UserControl
    {
        function fn = new function();
        String query;
        DataSet ds;

        public UC_Dashboard()
        {
            InitializeComponent();
        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            //Sets number of Admin Users when Dashboard is loaded
            query = "Select Count(userRole) from users where userRole = 'Administrator'";
            ds = fn.GetData(query);
            setLabel(ds, AdminLabel);

            //Sets number of Pharmacists when Dashboard is loaded
            query = "Select Count(userRole) from users where userRole = 'Pharmacist'";
            ds = fn.GetData(query);
            setLabel(ds, PharLabel);

            //Sets number of Patients when Dashboard is loaded
            query = "Select Count(userRole) from users where userRole = 'Patient'";
            ds = fn.GetData(query);
            setLabel(ds, PatientLabel);
        }

        private void setLabel(DataSet ds, Label lbl)
        {
            if (ds.Tables[0].Rows.Count != 0)
            {
                lbl.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                lbl.Text = "0";
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            UC_Dashboard_Load(this, null);
        }
    }
}
