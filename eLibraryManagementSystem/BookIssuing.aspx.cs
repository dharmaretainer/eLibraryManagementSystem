using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLibraryManagementSystem
{
    public partial class BookIssuing : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GetBookById();


        }
        void GetBookById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id = '"+TextBox2.Text.Trim()+"'", con);

                //int bookId;
                //if (!int.TryParse(TextBox2.Text.Trim(), out bookId))
                //{
                //    Response.Write("<script>alert('Please enter valid numeric Book ID');</script>");
                //    return;
                //}

                //cmd.Parameters.AddWithValue("@book_id", bookId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox1.Text = dt.Rows[0]["book_name"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid BookId ID');</script>");
                    TextBox1.Text = "";
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void GetMemberById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);


                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id =@member_id", con);

                string memberID = TextBox4.Text.Trim();
                if (string.IsNullOrEmpty(memberID))
                {
                    Response.Write("<script>alert('Please enter a Member ID');</script>");
                    return;
                }
                cmd.Parameters.AddWithValue("@member_id", memberID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox3.Text = dt.Rows[0]["full_name"].ToString();


                }
                else
                {
                    Response.Write("<script>alert('Invalid Member ID');</script>");
                    TextBox3.Text = "";
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                GetMemberById();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }


        }
        //issue
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (CheckIfBookExist())
            {
                
                add();
                
                
                
            }
            else
            {
                Response.Write("<script>alert('No Stock');</script>");

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
                    SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl(member_id ,member_name, book_id, book_name, issue_date, due_date) values(@member_id,@member_name,@book_id,@book_name,@issue_date,@due_date)", con);
                    cmd.Parameters.AddWithValue("@member_id", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@member_name", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_id", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_name", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());

                    ////cmd.Parameters.AddWithValue("@Full_Address", TextBox8.Text.Trim());
                    //cmd.Parameters.AddWithValue("@member_id", TextBox6.Text.Trim());
                    //cmd.Parameters.AddWithValue("@password", TextBox7.Text.Trim());
                    //cmd.Parameters.AddWithValue("@account_status", "Pending");
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock = current_stock - 1 WHERE book_id = '"+TextBox2.Text.Trim()+"' AND current_stock>0", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script type='text/javascript'>alert('Issued Succesfully!');</script>");
                    GridView1.DataBind();

                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        
            
        }

        //Return
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (CheckIfIssuedBookExist())
            {
                delete();

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
              
                SqlCommand cmd = new SqlCommand("DELETE FROM book_issue_tbl WHERE book_id=@book_id AND member_id=@member_id", con);
                cmd.Parameters.AddWithValue("@book_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", TextBox4.Text.Trim());

                //cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                ////cmd.Parameters.AddWithValue("@Full_Address", TextBox8.Text.Trim());
                //cmd.Parameters.AddWithValue("@member_id", TextBox6.Text.Trim());
                //cmd.Parameters.AddWithValue("@password", TextBox7.Text.Trim());
                //cmd.Parameters.AddWithValue("@account_status", "Pending");
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock = current_stock + 1 WHERE book_id = '" + TextBox2.Text.Trim() + "'", con);
               

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script type='text/javascript'>alert('Book Returned Succesfully!');</script>");
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
       
        bool CheckIfBookExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    
                    SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id ='" + TextBox2.Text.Trim() + "' AND current_stock>0 ", con);
                   
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count >= 1)
                    {
                        // Use Convert.ToInt32 to handle DBNull and type safety
                        return true;
                    }
                    else
                    {
                        
                        return false;
                   }
                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        bool CheckIfIssuedBookExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_tbl WHERE book_id ='" + TextBox2.Text.Trim() + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    // Use Convert.ToInt32 to handle DBNull and type safety
                    return true;
                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                    TextBox1.Text = "";
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        

       

        //protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
        //            DateTime today = DateTime.Today;
        //            if (today > dt)
        //            {
        //                e.Row.BackColor = Color.PaleVioletRed;
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script>alert('" + ex.Message + "');</script>");
        //    }

        //}
        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    

                    int V = 5;
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[V].Text);
                    DateTime today=DateTime.Today;
                    if (today > dt)
                    {
                        foreach (TableCell cell in e.Row.Cells)
                        {
                            cell.Attributes["style"] = "background-color: DarkRed !important; color: white !important;";
                        }
                        //Response.Write("<script>alert('Due Date: " + e.Row.Cells[5].Text + "');</script>");

                    }
                   


                }
                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

    }
}
