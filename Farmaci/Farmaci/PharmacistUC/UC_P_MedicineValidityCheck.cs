using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmaci.PharmacistUC
{
    public partial class UC_P_MedicineValidityCheck : UserControl
    {
        function fn = new function();
        String query;

        public UC_P_MedicineValidityCheck()
        {
            InitializeComponent();
        }

        private void txtCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtCheck.SelectedIndex == 0)
            {
                query = "Select mid AS Barcode,mname AS Name,mnumber AS Dose,mDate AS Manufacture_Date,eDate AS Expire_Date,quantity AS Quantity,perUnit AS Price from medic;";
                DataSet ds = fn.GetData(query);
                guna2DataGridView1.DataSource = ds.Tables[0];
                setLabel.Text = "All Medicine";
                setLabel.ForeColor = Color.Black;
            }
            else if (txtCheck.SelectedIndex == 1)
            {
                query = "Select mid AS Barcode,mname AS Name,mnumber AS Dose,mDate AS Manufacture_Date,eDate AS Expire_Date,quantity AS Quantity,perUnit AS Price from medic where eDate <= CONVERT(VARCHAR(250), GETDATE(), 21);";
                DataSet ds = fn.GetData(query);
                guna2DataGridView1.DataSource = ds.Tables[0];
                setLabel.Text = "Expired Medicine";
                setLabel.ForeColor = Color.Red;
            }else if (txtCheck.SelectedIndex == 2)
            {
                query = "Select mid AS Barcode,mname AS Name,mnumber AS Dose,mDate AS Manufacture_Date,eDate AS Expire_Date,quantity AS Quantity,perUnit AS Price from medic where eDate >= CONVERT(VARCHAR(250), GETDATE(), 21);";
                DataSet ds = fn.GetData(query);
                guna2DataGridView1.DataSource = ds.Tables[0];
                setLabel.Text = "Valid Medicine";
                setLabel.ForeColor = Color.Green;
            }
        }

        private void UC_P_MedicineValidityCheck_Load(object sender, EventArgs e)
        {
            setLabel.Text = "";
        }
    }
}
