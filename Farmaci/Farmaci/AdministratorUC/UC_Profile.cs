﻿using System;
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
    public partial class UC_Profile : UserControl
    {
        function fn = new function();
        String query;

        public UC_Profile()
        {
            InitializeComponent();
        }

        public string ID 
        {
            set { userNameLabel.Text = value; }
        }

        private void UC_Profile_Enter(object sender, EventArgs e)
        {
            query = "Select * From users where username = '"+userNameLabel.Text+"'";
            DataSet ds = fn.GetData(query);
            txtUserRole.Text = ds.Tables[0].Rows[0][1].ToString();
            txtName.Text = ds.Tables[0].Rows[0][2].ToString();
            txtDob.Text = ds.Tables[0].Rows[0][3].ToString();
            txtMobile.Text = ds.Tables[0].Rows[0][4].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0][5].ToString();
            txtPassword.Text = ds.Tables[0].Rows[0][7].ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            UC_Profile_Enter(this, null);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String role = txtUserRole.Text;
            String name = txtName.Text;
            String dob = txtDob.Text;
            Int64 mobile = Int64.Parse(txtMobile.Text);
            String email = txtEmail.Text;
            String password = txtPassword.Text;
            String username = userNameLabel.Text;

            query = "Update users set userRole = '" + role + "', name = '" + name + "', dob = '" + dob + "', mobile = " + mobile + ", email = '" + email + "', pass = '" + password + "' where username = '"+username+"'";
            fn.setData(query, "Profile Update Successful");
        }
    }
}
