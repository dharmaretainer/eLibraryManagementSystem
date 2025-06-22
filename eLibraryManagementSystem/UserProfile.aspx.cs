using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLibraryManagementSystem
{
    public partial class UserProfile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"] == null || Session["username"].ToString() == "")
                {
                    Response.Write("<script>alert('Session Expired , Login Again!');</script>");
                    Response.Write("userlogin.aspx");

                }
                else
                {
                    getUserData();
                    if (!Page.IsPostBack)
                    {
                        getUserDetails();

                    }
                    




                }
            }
            catch (Exception ex) 
            {

            }

        }
        //updateData
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"].ToString() == "")
            {
                Response.Write("<script>alert('Session Expired , Login Again!');</script>");
                Response.Write("userlogin.aspx");

            }
            else
            {  
                    updateUserDetails();

            }

        }
        void updateUserDetails()
        {
            string password = "";
            if (TextBox8.Text.Trim() == "")
            {
                password = TextBox7.Text.Trim();

            }
            else
            { 
            password = TextBox8.Text;
            }
            try
            {
               

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"UPDATE member_master_tbl SET full_name=@full_name, DOB=@DOB, contact_no=@contact_no,Email=@Email, Branch=@Branch, Year=@Year,MIS=@MIS, password=@password, account_status=@account_status WHERE member_id=@member_id", con);

                    cmd.Parameters.AddWithValue("@member_id", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@DOB", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@Branch", DropDownListState.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Year", DropDownList1.SelectedItem.Value);

                    cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBox8.Text.Trim());
                    
                    cmd.Parameters.AddWithValue("@MIS", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@account_status", "pending");


                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        Response.Write("<script>alert('Profile Updated Successfully!');</script>");
                        getUserData();
                        getUserDetails();
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Entry');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }
        //User defined function
        void getUserData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_tbl WHERE member_id = '" + Session["username"] + "'", con);

                   

                    

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }

        void getUserDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed) { con.Open(); }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='"+ Session["username"] + "'", con);
                


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                

                TextBox1.Text = dt.Rows[0]["full_name"].ToString();
                TextBox2.Text = dt.Rows[0]["DOB"].ToString();
                TextBox3.Text = dt.Rows[0]["contact_no"].ToString();
                TextBox4.Text = dt.Rows[0]["Email"].ToString();
                DropDownListState.SelectedValue = dt.Rows[0]["Branch"].ToString().Trim();
                DropDownList1.SelectedValue = dt.Rows[0]["Year"].ToString().Trim();
                TextBox5.Text = dt.Rows[0]["MIS"].ToString();
                TextBox6.Text = dt.Rows[0]["member_id"].ToString();
                TextBox7.Text = dt.Rows[0]["password"].ToString();

                Label2.Text = dt.Rows[0]["account_status"].ToString().Trim();
                if (dt.Rows[0]["account_status"].ToString().Trim() == "active")
                {
                    Label2.Attributes.Add("class", "badge rounded-pill text-bg-success");
                }
                else if(dt.Rows[0]["account_status"].ToString().Trim() == "pending")
                {
                    Label2.Attributes.Add("class", "badge rounded-pill text-bg-info");

                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "deactivated")
                {
                    Label2.Attributes.Add("class", "badge rounded-pill text-bg-danger");

                }
                else
                {
                    Label2.Attributes.Add("class", "badge rounded-pill text-bg-secondary ");
                }



            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        
           

    }
}
