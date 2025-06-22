//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace eLibraryManagementSystem
//{
//    public partial class Site1 : System.Web.UI.MasterPage
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            try
//            {
//                if (Session["role"].Equals(""))
//                {
//                    LinkButton1.Visible = true;
//                    LinkButton2.Visible = true;
//                    LinkButton3.Visible = false;
//                    LinkButton7.Visible = false;
//                    LinkButton6.Visible = true;
//                    LinkButton8.Visible = false;
//                    LinkButton9.Visible = false;
//                    LinkButton10.Visible = false;
//                    LinkButton11.Visible = false;

//                }
//                else if (Session["role"].Equals("user")){
//                    LinkButton1.Visible = false;
//                    LinkButton2.Visible = false;
//                    LinkButton3.Visible=true;
//                    LinkButton7.Visible=true;
//                    LinkButton6.Visible = true;
//                    LinkButton8.Visible = false;
//                    LinkButton9.Visible = false;
//                    LinkButton10.Visible = false;
//                    LinkButton11.Visible = false;
//                    LinkButton7.Text = "Hello " + Session["username"].ToString();
//                }
//                else if (Session["role"].Equals("admin"))
//                {
//                    LinkButton1.Visible = false;
//                    LinkButton2.Visible = false;
//                    LinkButton3.Visible = true;
//                    LinkButton7.Visible = true;
//                    LinkButton6.Visible = false;
//                    LinkButton8.Visible = true;
//                    LinkButton9.Visible = true;
//                    LinkButton10.Visible = true;
//                    LinkButton11.Visible = true;
//                    LinkButton7.Text = "Hello Admin";
//                }

//            }
//            catch (Exception ex) {
//                Response.Write("<script>alert('" + ex.Message + "');</script>");

//            }
            
            

//        }

//        protected void LinkButton6_Click(object sender, EventArgs e)
//        {
//            Response.Redirect("Adminlogin.aspx");
//        }

//        protected void LinkButton5_Click(object sender, EventArgs e)
//        {
//            Response.Redirect("AuthorManagement.aspx");
//        }

//        protected void LinkButton8_Click(object sender, EventArgs e)
//        {
//            Response.Redirect("PublisherManagement.aspx");
//        }

//        protected void LinkButton9_Click(object sender, EventArgs e)
//        {
//            Response.Redirect("AdminBookInventory.aspx");
//        }

//        protected void LinkButton10_Click(object sender, EventArgs e)
//        {
//            Response.Redirect("BookIssuing.aspx");  
//        }

//        protected void LinkButton11_Click(object sender, EventArgs e)
//        {
//            Response.Redirect("adminmembermanagement.aspx");
//        }

//        protected void LinkButton4_Click(object sender, EventArgs e)
//        {
//            Response.Redirect("viewbooks.aspx");
//        }

//        protected void LinkButton20_Click(object sender, EventArgs e)
//        {
//            Response.Redirect("login.aspx");
//        }

//        protected void LinkButton21_Click(object sender, EventArgs e)
//        {
//            Response.Redirect("signup.aspx");
//        }
//    }
//}





using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLibraryManagementSystem
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string role = Session["role"] as string;

                if (string.IsNullOrEmpty(role))
                {
                    // Guest User (not logged in)
                    LinkButton1.Visible = true;
                    LinkButton2.Visible = true;
                    LinkButton3.Visible = false;
                    LinkButton7.Visible = false;
                    LinkButton6.Visible = true;
                    LinkButton8.Visible = false;
                    LinkButton9.Visible = false;
                    LinkButton10.Visible = false;
                    LinkButton11.Visible = false;
                }
                else if (string.Equals(role, "user"))
                {
                    LinkButton1.Visible = false;
                    LinkButton2.Visible = false;
                    LinkButton3.Visible = true;
                    LinkButton7.Visible = true;
                    LinkButton6.Visible = true;
                    LinkButton8.Visible = false;
                    LinkButton9.Visible = false;
                    LinkButton10.Visible = false;
                    LinkButton11.Visible = false;
                    LinkButton7.Text = "Hello " + (Session["fullname"] ?? "").ToString();
                }
                else if (string.Equals(role, "admin"))
                {
                    LinkButton1.Visible = false;
                    LinkButton2.Visible = false;
                    LinkButton3.Visible = true;
                    LinkButton7.Visible = true;
                    LinkButton6.Visible = false;
                    LinkButton5.Visible = true;
                    LinkButton8.Visible = true;
                    LinkButton9.Visible = true;
                    LinkButton10.Visible = true;
                    LinkButton11.Visible = true;
                    LinkButton7.Text = "Hello Admin";
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }


        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Adminlogin.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("AuthorManagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("PublisherManagement.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminBookInventory.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookIssuing.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");
        }

        protected void LinkButton20_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void LinkButton21_Click(object sender, EventArgs e)
        {
            Response.Redirect("signup.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = false;
            LinkButton7.Visible = false;
            LinkButton6.Visible = true;
            LinkButton8.Visible = false;
            LinkButton9.Visible = false;
            LinkButton10.Visible = false;
            LinkButton11.Visible = false;
            Response.Redirect("homepage.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");

        }
    }
}
