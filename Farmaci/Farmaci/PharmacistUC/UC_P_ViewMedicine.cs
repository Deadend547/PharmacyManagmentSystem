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
    public partial class UC_P_ViewMedicine : UserControl
    {
        function fn = new function();
        String query;

        public UC_P_ViewMedicine()
        {
            InitializeComponent();
        }

        //Fills table with data when the usercontrol is loaded
        private void UC_P_ViewMedicine_Load(object sender, EventArgs e)
        {
            //Note:mnumber is the dose of the medicine
            query = "Select mid AS Barcode,mname AS Name,mnumber AS Dose,mDate AS Manufacture_Date,eDate AS Expire_Date,quantity AS Quantity,perUnit AS Price from medic;";
            setDataGridView(query);
        }

        //Updates table data when the user clicks refresh
        private void btnSync_Click(object sender, EventArgs e)
        {
            UC_P_ViewMedicine_Load(this, null);
        }

        //Updates table data when the user searches for something
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Note:mnumber is the dose of the medicine
            query = "Select mid AS Barcode,mname AS Name,mnumber AS Dose,mDate AS Manufacture_Date,eDate AS Expire_Date,quantity AS Quantity,perUnit AS Price from medic where mname like '" + txtSearch.Text+"%'";
            setDataGridView(query);
        }

        String medicineId;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                medicineId = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                query = "delete from medic where mid = '" + medicineId + "'";
                fn.setData(query, "Record Deleted");
                UC_P_ViewMedicine_Load(this, null);
            }
        }

        private void setDataGridView(String query)
        {
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
    }
}
