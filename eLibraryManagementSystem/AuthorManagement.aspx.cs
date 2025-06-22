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
    public partial class AuthorManagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();

        }
        //add button
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
                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl(author_id ,author_name) values(@author_id,@author_name)", con);
                cmd.Parameters.AddWithValue("@author_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                ////cmd.Parameters.AddWithValue("@Full_Address", TextBox8.Text.Trim());
                //cmd.Parameters.AddWithValue("@member_id", TextBox6.Text.Trim());
                //cmd.Parameters.AddWithValue("@password", TextBox7.Text.Trim());
                //cmd.Parameters.AddWithValue("@account_status", "Pending");
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script type='text/javascript'>alert('Added Author Succesfully!');</script>");
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE author_id='" + TextBox1.Text.Trim() + "';", con);
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
        //update button
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
                Response.Write("<script>alert('Author does not exist. Please try again.');</script>");



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
                SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name=@author_name WHERE author_id='"+TextBox1.Text.Trim()+"'", con);
               
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                ////cmd.Parameters.AddWithValue("@Full_Address", TextBox8.Text.Trim());
                //cmd.Parameters.AddWithValue("@member_id", TextBox6.Text.Trim());
                //cmd.Parameters.AddWithValue("@password", TextBox7.Text.Trim());
                //cmd.Parameters.AddWithValue("@account_status", "Pending");
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script type='text/javascript'>alert('Author Updated Succesfully!');</script>");
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            clearform();

        }
        //delete button
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
                Response.Write("<script>alert('Author does not exist. Please try again.');</script>");



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
                SqlCommand cmd = new SqlCommand("DELETE FROM author_master_tbl WHERE author_id='" + TextBox1.Text.Trim() + "'", con);

                //cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                ////cmd.Parameters.AddWithValue("@Full_Address", TextBox8.Text.Trim());
                //cmd.Parameters.AddWithValue("@member_id", TextBox6.Text.Trim());
                //cmd.Parameters.AddWithValue("@password", TextBox7.Text.Trim());
                //cmd.Parameters.AddWithValue("@account_status", "Pending");
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script type='text/javascript'>alert('Author Deleted Succesfully!');</script>");
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            clearform();
        }
        //go button 
        protected void Button1_Click(object sender, EventArgs e)
        {
            getauthorbyid();

        }
        void getauthorbyid()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE author_id = @author_id", con);

                    int authorId;
                    if (!int.TryParse(TextBox1.Text.Trim(), out authorId))
                    {
                        Response.Write("<script>alert('Please enter valid numeric Author ID');</script>");
                        return;
                    }

                    cmd.Parameters.AddWithValue("@author_id", authorId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count >= 1)
                    {
                        TextBox2.Text = dt.Rows[0]["author_name"].ToString();
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Author ID');</script>");
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

        //protected void Button1_Click1(object sender, EventArgs e)
        //{
        //    getauthorbyid();

        //}
        //void getauthorbyid()
        //{
        //    try
        //    {
        //        SqlConnection con = new SqlConnection(strcon);
        //        if (con.State == System.Data.ConnectionState.Closed)
        //        {
        //            con.Open();
        //        }
        //        SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE author_id=@id", con);
        //        cmd.Parameters.AddWithValue("@id", TextBox1.Text.Trim());

        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        if (dt.Rows.Count >= 1)
        //        {
        //            TextBox2.Text = dt.Rows[0]["author_name"].ToString();

        //        }
        //        else
        //        {
        //            Response.Write("<script type='text/javascript'>alert('Enter Valid ID');</script>");

        //        }

        //        //cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

        //        ////cmd.Parameters.AddWithValue("@Full_Address", TextBox8.Text.Trim());
        //        //cmd.Parameters.AddWithValue("@member_id", TextBox6.Text.Trim());
        //        //cmd.Parameters.AddWithValue("@password", TextBox7.Text.Trim());
        //        //cmd.Parameters.AddWithValue("@account_status", "Pending");
        //        //cmd.ExecuteNonQuery();
        //        //con.Close();
        //        //Response.Write("<script type='text/javascript'>alert('Author Deleted Succesfully!');</script>");
        //        //GridView1.DataBind();


        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script>alert('" + ex.Message + "');</script>");
        //    }
        //    clearform();

        
    }
}