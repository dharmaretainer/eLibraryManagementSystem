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
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getmemberbyid();

        }
        void getmemberbyid()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id = @member_id", con);
                    cmd.Parameters.AddWithValue("@member_id", TextBox1.Text.Trim());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count >= 1)
                    {
                        TextBox2.Text = dt.Rows[0]["full_name"].ToString();
                        TextBox3.Text = dt.Rows[0]["DOB"].ToString();
                        TextBox4.Text = dt.Rows[0]["contact_no"].ToString();
                        TextBox9.Text = dt.Rows[0]["Email"].ToString();
                        TextBox5.Text = dt.Rows[0]["Branch"].ToString();
                        TextBox6.Text = dt.Rows[0]["Year"].ToString();
                        TextBox10.Text = dt.Rows[0]["MIS"].ToString();

                        updateDot(dt.Rows[0]["account_status"].ToString());
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Member ID');</script>");
                        clearform();
                        updateDot("unknown");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updateDot(string status)
        {
            string statusLower = status.ToLower();

            switch (statusLower)
            {
                case "active":
                    lblStatusDot.CssClass = "status-dot dot-active";
                    lblStatusDot.ToolTip = "Account Status: Active";
                    break;
                case "pending":
                    lblStatusDot.CssClass = "status-dot dot-pending";
                    lblStatusDot.ToolTip = "Account Status: Pending";
                    break;
                case "deactivated":
                    lblStatusDot.CssClass = "status-dot dot-deactivated";
                    lblStatusDot.ToolTip = "Account Status: Defaulter";
                    break;
                default:
                    lblStatusDot.CssClass = "status-dot dot-unknown";
                    lblStatusDot.ToolTip = "Account Status: Unknown";
                    break;
            }
        }
        void updateStatus(string newStatus)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status=@status WHERE member_id=@member_id", con);
                    cmd.Parameters.AddWithValue("@status", newStatus);
                    cmd.Parameters.AddWithValue("@member_id", TextBox1.Text.Trim());
                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('Status updated to " + newStatus + "');</script>");
                    GridView1.DataBind();
                    updateDot(newStatus);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }



        //void dot()
        //{
        //    string status = dt.Rows[0]["account_status"].ToString().ToLower();

        //    switch (status)
        //    {
        //        case "active":
        //            lblStatusDot.CssClass = "status-dot dot-active";
        //            break;

        //        case "pending":
        //            lblStatusDot.CssClass = "status-dot dot-pending";
        //            break;

        //        case "deactivated":
        //            lblStatusDot.CssClass = "status-dot dot-deactivated";
        //            break;

        //        default:
        //            lblStatusDot.CssClass = "status-dot dot-unknown";
        //            break;
        //    }

        //}



        //    protected void Button4_Click(object sender, EventArgs e)
        //    {

        //        if (CheckId())
        //        {
        //            update();

        //            //TextBox6.Text = "";
        //            //TextBox6.Focus();

        //        }
        //        else
        //        {
        //            Response.Write("<script>alert('Member does not exist. Please try again.');</script>");



        //        }
        //    }
        //    void update()
        //    {
        //        try
        //        {
        //            SqlConnection con = new SqlConnection(strcon);
        //            if (con.State == System.Data.ConnectionState.Closed)
        //            {
        //                con.Open();
        //            }

        //            SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='active' WHERE member_id=@member_id", con);
        //            cmd.Parameters.AddWithValue("@member_id", TextBox1.Text.Trim());

        //            cmd.ExecuteNonQuery();
        //            con.Close();

        //            // ✅ Show success message
        //            Response.Write("<script type='text/javascript'>alert('Status Updated Successfully!');</script>");

        //            // ✅ Highlight input fields
        //            //TextBox8.CssClass += " highlight-green";
        //            //TextBox2.CssClass += " highlight-green";

        //            GridView1.DataBind();
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write("<script>alert('" + ex.Message + "');</script>");
        //        }

        //        clearform();
        //    }

        void clearform()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox9.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox10.Text = "";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (CheckId())
                updateStatus("active");
            else
                Response.Write("<script>alert('Member not found');</script>");
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='" + TextBox1.Text.Trim() + "';", con);
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

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (CheckId())
                updateStatus("pending");
            else
                Response.Write("<script>alert('Member not found');</script>");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (CheckId())
                updateStatus("deactivated");
            else
                Response.Write("<script>alert('Member not found');</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (CheckId())
            {
                delete();

                //TextBox6.Text = "";
                //TextBox6.Focus();

            }
            else
            {
                Response.Write("<script>alert('Member does not exist. Please try again.');</script>");



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
                SqlCommand cmd = new SqlCommand("DELETE FROM member_master_tbl WHERE member_id='" + TextBox1.Text.Trim() + "'", con);

                //cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                ////cmd.Parameters.AddWithValue("@Full_Address", TextBox8.Text.Trim());
                //cmd.Parameters.AddWithValue("@member_id", TextBox6.Text.Trim());
                //cmd.Parameters.AddWithValue("@password", TextBox7.Text.Trim());
                //cmd.Parameters.AddWithValue("@account_status", "Pending");
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script type='text/javascript'>alert('Member Deleted Succesfully!');</script>");
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            clearform();
        }

        //    protected void Button5_Click(object sender, EventArgs e)
        //    {
        //        if (CheckId())
        //        {
        //            update();

        //            //TextBox6.Text = "";
        //            //TextBox6.Focus();

        //        }
        //        else
        //        {
        //            Response.Write("<script>alert('Member does not exist. Please try again.');</script>");



        //        }

        //    }
    }
}