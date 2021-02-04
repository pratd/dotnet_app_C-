using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] != null)
                {
                    if (Session["role"].Equals(""))
                    {
                        LinkButton1.Visible = true; // user login link button
                        LinkButton2.Visible = true; // signup link button
                        LinkButton3.Visible = false; // logout link button
                        LinkButton7.Visible = false; // hello user link button

                        LinkButton6.Visible = true; // admin login link button
                        LinkButton11.Visible = false; // authr mangmnt link button
                        LinkButton12.Visible = false; // publisher link button
                        LinkButton8.Visible = false; // book link button
                        LinkButton9.Visible = false; // book issue link button
                        LinkButton10.Visible = false; //member link button
                    }
                    else if (Session["role"].Equals("user"))
                    {
                        LinkButton6.Visible = true; // admin login link button
                        LinkButton11.Visible = false; // authr mangmnt link button
                        LinkButton12.Visible = false; // publisher link button
                        LinkButton8.Visible = false; // book link button
                        LinkButton9.Visible = false; // book issue link button
                        LinkButton10.Visible = false; //member link button

                        LinkButton1.Visible = false; // user login link button
                        LinkButton2.Visible = false; // signup link button
                        LinkButton3.Visible = true; // logout link button
                        LinkButton7.Visible = true; // hello user link button
                        LinkButton7.Text = "Hello " + Session["username"].ToString(); // hello user link button

                    }
                    else if (Session["role"].Equals("admin"))
                    {
                        LinkButton6.Visible = false; // admin login link button
                        LinkButton11.Visible = true; // authr mangmnt link button
                        LinkButton12.Visible = true; // publisher link button
                        LinkButton8.Visible = true; // book link button
                        LinkButton9.Visible = true; // book issue link button
                        LinkButton10.Visible = true; //member link button

                        LinkButton1.Visible = false; // user login link button
                        LinkButton2.Visible = false; // signup link button
                        LinkButton3.Visible = true; // logout link button
                        LinkButton7.Visible = true; // hello user link button
                        LinkButton7.Text = "Hello Admin"; // hello user link button

                    }
                }
               
            }
            catch(Exception ex)
            {

            }
            
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminAuthorManagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminPublisherManagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminBookInventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminBookissuing.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminMemberManagement.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewBooks.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userLogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("userSignup.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullanme"] = "";
            Session["role"] = "";
            Session["status"] = "";

            LinkButton1.Visible = true; // user login link button
            LinkButton2.Visible = true; // signup link button
            LinkButton3.Visible = false; // logout link button
            LinkButton7.Visible = false; // hello user link button

            LinkButton6.Visible = true; // admin login link button
            LinkButton11.Visible = false; // authr mangmnt link button
            LinkButton12.Visible = false; // publisher link button
            LinkButton8.Visible = false; // book link button
            LinkButton9.Visible = false; // book issue link button
            LinkButton10.Visible = false; //member link button
        }
    }
}