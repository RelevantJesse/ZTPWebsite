﻿using System;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using ZeroToProgrammer.Tables;

namespace ZeroToProgrammer
{
    public partial class AddNewUser : System.Web.UI.Page
    {
        private Site _masterPage;
        private Site MasterPage
        {
            get
            {
                if (_masterPage == null)
                    _masterPage = Page.Master as Site;

                return _masterPage;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ResetPage();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(!AreFieldsValid()) return;
            
            try
            {
               UsersTable.Add(txtUsername.Text, BCrypt.Net.BCrypt.HashPassword(txtPassword.Text),
               txtFirstName.Text, txtLastName.Text, txtEmail.Text);
            }
            catch (Exception ex)
            {
                MasterPage.SetError("Error saving to the database: " + ex.Message);
                return;
            }

            MasterPage.SetSuccess("User successfully added!");
        }
        
        private void ResetPage()
        {
            // Reset Colors
            lblUsername.ForeColor = System.Drawing.Color.Black;
            lblPassword.ForeColor = System.Drawing.Color.Black;
            lblEmail.ForeColor = System.Drawing.Color.Black;
            lblFirstName.ForeColor = System.Drawing.Color.Black;
            lblLastName.ForeColor = System.Drawing.Color.Black;
        }

        private bool AreFieldsValid()
        {

            // User Name
            Regex rgxUsrName = new Regex("[^A-Za-z0-9]");
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MasterPage.SetError("Please enter a User Name");
                lblUsername.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            if (txtUsername.Text.Length < 6)
            {
                MasterPage.SetError("User Name must be at least 6 characters");
                lblUsername.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            if (rgxUsrName.IsMatch(txtUsername.Text))
            {
                MasterPage.SetError("User Name must be alphanumeric");
                lblUsername.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            try
            {
                if (UsersTable.UserExists(txtUsername.Text))
                {
                    MasterPage.SetError("This Username or Email address already exists");
                    lblUsername.ForeColor = System.Drawing.Color.Red;
                    return false;
                }
            }
            catch (Exception ex)
            {
                MasterPage.SetError("Error loading from database: \n" + ex.Message);
                return false;
            }

            // Password
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MasterPage.SetError("Please enter a Password");
                lblPassword.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            if (txtPassword.Text.Length < 8)
            {
                MasterPage.SetError("Password must be at least 8 characters");
                lblPassword.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            if (!(txtPassword.Text.Any(char.IsLetter)
               && txtPassword.Text.Any(char.IsDigit)
               && (txtPassword.Text.Any(char.IsSymbol)
               || txtPassword.Text.Any(char.IsPunctuation))))
            {
                MasterPage.SetError("Password must contain at least one letter, one number, and one symbol");
                lblPassword.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            // Email
            try
            {
                var addr = new MailAddress(txtEmail.Text);
            }
            catch
            {
                MasterPage.SetError("Invalid Email Address");
                lblEmail.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            try
            {
                if (UsersTable.EmailExists(txtEmail.Text))
                {
                    MasterPage.SetError("This Username or Email address already exists");
                    lblUsername.ForeColor = System.Drawing.Color.Red;
                    return false;
                }
            }
            catch (Exception ex)
            {
                MasterPage.SetError("Error loading from database: \n" + ex.Message);
                return false;
            }

            // First Name
            Regex rgxNames = new Regex("[^A-Za-z]");
            if (!string.IsNullOrEmpty(txtFirstName.Text) && rgxNames.IsMatch(txtFirstName.Text))
            {
                MasterPage.SetError("First Name must contain only letters");
                lblFirstName.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            // Last Name
            if (!string.IsNullOrEmpty(txtLastName.Text) && rgxNames.IsMatch(txtLastName.Text))
            {
                MasterPage.SetError("Last Name must contain only letters");
                lblLastName.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            return true;

        }
    }
}