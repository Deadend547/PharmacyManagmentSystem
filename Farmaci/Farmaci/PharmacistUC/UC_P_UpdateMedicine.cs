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
    public partial class UC_P_UpdateMedicine : UserControl
    {
        function fn = new function();
        String query;

        public UC_P_UpdateMedicine()
        {
            InitializeComponent();
        }

        private void clearAll()
        {
            txtMediId.Clear();
            txtMediName.Clear();
            txtMediDose.Clear();
            txtmDate.ResetText();
            txteDate.ResetText();
            txtAvailableQuantity.Clear();
            txtAddQuantity.Text = "0";
            txtPricePerUnit.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMediId.Text != "")
            {
                query = "Select * From medic where mid = '" + txtMediId.Text + "'";
                DataSet ds = fn.GetData(query);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtMediName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtMediDose.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtmDate.Text = ds.Tables[0].Rows[0][3].ToString();
                    txteDate.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtAvailableQuantity.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtPricePerUnit.Text = ds.Tables[0].Rows[0][6].ToString();
                }
                else
                {
                    MessageBox.Show("No Medecine with that id exists", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                clearAll();
            }
        }

        Int64 totalQuantity;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String mname = txtMediName.Text;
            String mdose = txtMediDose.Text;
            String mdate = txtmDate.Text;
            String edate = txteDate.Text;
            Int64 quantity = Int64.Parse(txtAvailableQuantity.Text);
            Int64 addQuantity = Int64.Parse(txtAddQuantity.Text);
            Int64 unitprice = Int64.Parse(txtPricePerUnit.Text);
            totalQuantity = quantity + addQuantity;

            query = "update medic set mname = '"+mname+"',mnumber = '"+mdose+"',mDate = '"+mdate+"',eDate = '"+edate+"', quantity = "+totalQuantity+", perUnit = "+unitprice+" where mid = '"+txtMediId.Text+"' ";
            fn.setData(query, "Successfuly Updated");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
