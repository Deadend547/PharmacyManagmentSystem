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
    public partial class UC_P_Dashboard : UserControl
    {
        function fn = new function();
        DataSet ds = new DataSet();
        String query;
        Int64 count;

        public UC_P_Dashboard()
        {
            InitializeComponent();
        }

        private void UC_P_Dashboard_Load(object sender, EventArgs e)
        {
            loadChart();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            this.chart1.Series["Valid Medicine"].Points.Clear();
            this.chart1.Series["Expired Medicine"].Points.Clear();
            loadChart();
        }

        public void loadChart()
        {
            //Loads valid medicine into chart
            query = "Select count(mname) from medic where edate >= CONVERT(VARCHAR(250), GETDATE(), 21)";
            ds = fn.GetData(query);
            count = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            this.chart1.Series["Valid Medicine"].Points.AddY(count);

            //Loads expired medicine into chart
            query = "Select count(mname) from medic where edate < CONVERT(VARCHAR(250), GETDATE(), 21)";
            ds = fn.GetData(query);
            count = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            this.chart1.Series["Expired Medicine"].Points.AddY(count);
        }
    }
}
