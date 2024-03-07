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
    public partial class UC_AddUser : UserControl
    {

        function fn = new function();
        String query;


        public UC_AddUser()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            String role = txtUserRole.Text;
            String name = txtName.Text;
            String dob = txtDob.Text;
            Int64 mobile = Int64.Parse(txtMobileNo.Text);
            String email = txtEmail.Text;
            String username = txtUsername.Text;
            String password = txtPassword.Text;

            try
            {
                query = "Insert into users(userRole, name, dob, mobile, email, username, pass) Values('"+role+"', '"+name+"', '"+dob+"', "+mobile+", '"+email+"', '"+username+"', '"+password+"' )";
                fn.setData(query, "Sign Up Successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Username Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        public void clearAll()
        {
            txtName.Clear();
            txtDob.ResetText();
            txtMobileNo.Clear();
            txtEmail.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtUserRole.SelectedIndex = -1;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            query = "Select * From Users where username = '"+txtUsername.Text+"'";
            DataSet ds = fn.GetData(query);

            if (ds.Tables[0].Rows.Count == 0 )
            {
                pictureBox1.ImageLocation = @"C:\\Users\\User\\Desktop\\Pharmacy Management System in C#\yes.png";
            }
            else
            {
                pictureBox1.ImageLocation = @"C:\\Users\\User\\Desktop\\Pharmacy Management System in C#\no.png";
            }
        }
    }
}
