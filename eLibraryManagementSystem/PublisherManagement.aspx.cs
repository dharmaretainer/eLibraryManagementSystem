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
    public partial class PublisherManagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (CheckId())
            {
                Response.Write("<script>alert('Author ID already exists. Please try another one.');</script>");
                //TextBox6.Text = "";
                //TextBox6.Focus();

            }
            else
            {
                add();

            }
        }
        void add()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl(publisher_id ,publisher_name) values(@publisher_id,@publisher_name)", con);
                cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());

                ////cmd.Parameters.AddWithValue("@Full_Address", TextBox8.Text.Trim());
                //cmd.Parameters.AddWithValue("@member_id", TextBox6.Text.Trim());
                //cmd.Parameters.AddWithValue("@password", TextBox7.Text.Trim());
                //cmd.Parameters.AddWithValue("@account_status", "Pending");
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script type='text/javascript'>alert('Added Publisher Succesfully!');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM publisher_master_tbl WHERE publisher_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (CheckId())
            {
                update();

                //TextBox6.Text = "";
                //TextBox6.Focus();

            }
            else
            {
                Response.Write("<script>alert('Publisher does not exist. Please try again.');</script>");



            }
        }
        void update()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl SET publisher_name=@publisher_name WHERE publisher_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());

                ////cmd.Parameters.AddWithValue("@Full_Address", TextBox8.Text.Trim());
                //cmd.Parameters.AddWithValue("@member_id", TextBox6.Text.Trim());
                //cmd.Parameters.AddWithValue("@password", TextBox7.Text.Trim());
                //cmd.Parameters.AddWithValue("@account_status", "Pending");
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script type='text/javascript'>alert('Publisher Updated Succesfully!');</script>");
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            clearform();

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (CheckId())
            {
                delete();

                //TextBox6.Text = "";
                //TextBox6.Focus();

            }
            else
            {
                Response.Write("<script>alert('Publisher does not exist. Please try again.');</script>");



            }
        }
        void delete()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM publisher_master_tbl WHERE publisher_id='" + TextBox1.Text.Trim() + "'", con);

                //cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                ////cmd.Parameters.AddWithValue("@Full_Address", TextBox8.Text.Trim());
                //cmd.Parameters.AddWithValue("@member_id", TextBox6.Text.Trim());
                //cmd.Parameters.AddWithValue("@password", TextBox7.Text.Trim());
                //cmd.Parameters.AddWithValue("@account_status", "Pending");
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script type='text/javascript'>alert('Publisher Deleted Succesfully!');</script>");
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            clearform();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getpublisherbyid();
        }
        void getpublisherbyid()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("SELECT * FROM publisher_master_tbl WHERE publisher_id = @publisher_id", con);

                    int publisherId;
                    if (!int.TryParse(TextBox1.Text.Trim(), out publisherId))
                    {
                        Response.Write("<script>alert('Please enter valid numeric publisher ID');</script>");
                        return;
                    }

                    cmd.Parameters.AddWithValue("@publisher_id", publisherId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count >= 1)
                    {
                        TextBox2.Text = dt.Rows[0]["publisher_name"].ToString();
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid publisher ID');</script>");
                        TextBox2.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void clearform()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}