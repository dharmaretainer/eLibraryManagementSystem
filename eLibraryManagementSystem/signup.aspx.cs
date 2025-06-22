using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLibraryManagementSystem
{
    public partial class WebForm3 : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CheckId())
            {
                Response.Write("<script>alert('Member ID already exists. Please try another one.');</script>");
                //TextBox6.Text = "";
                //TextBox6.Focus();

            }
            else
            {
                SignupNew();

            }

                
        }

        bool CheckId()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='"+TextBox6.Text.Trim()+"';", con);
                SqlDataAdapter da=  new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                    con.Close();
             


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }

            
        }
        void SignupNew()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl(full_name , DOB, contact_no, Email, Branch, Year,MIS,member_id,password,account_status) values(@full_name , @DOB, @contact_no, @Email, @Branch, @Year,@MIS,@member_id,@password,@account_status)", con);
                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@DOB", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@Branch", DropDownListState.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Year", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@MIS", TextBox5.Text.Trim());
                //cmd.Parameters.AddWithValue("@Full_Address", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "Pending");
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script type='text/javascript'>alert('SignUp Successful ! Please go to login page .');</script>");


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}