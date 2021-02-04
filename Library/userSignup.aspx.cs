using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class userSignup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //sign up button is clickced
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkMemberExists())
            {
                Response.Write("<script> alert('This memberID already exists');</script>");
            }
            else
            {
                signUpNewMember();
            }
            
        }
        
        
        // user defined method
        
        bool checkMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //possible sql injection
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE " +
                    "member_id='" +TextBox8.Text.Trim()+"';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    con.Close();
                    return true;
                    
                }
                else
                {
                    con.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void signUpNewMember()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl(full_name, dob," +
                    "contact_no, email, state, city, pincode, full_address, member_id, password," +
                    "account_status) values" +
                    "(@fname, @dob," +
                    "@contact, @emailId, @state, @city, @pin, @faddress, @member, @pwd," +
                    "@acnt_status)", con);

                cmd.Parameters.AddWithValue("@fname", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@emailId", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@pin", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@faddress", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@member", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@pwd", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@acnt_status", "pending");

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script> alert('Sign Up Successful. Go to User Login to Login');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}