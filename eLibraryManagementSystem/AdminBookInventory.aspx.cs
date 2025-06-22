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
    public partial class AdminBookInventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            fillAuthorPublisherValues();
            GridView1.DataBind();

        }
        //go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed) { con.Open(); }

                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id=@book_id", con);
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox2.Text = dr["book_name"].ToString();
                        TextBox3.Text = dr["publish_date"].ToString();
                        TextBox4.Text = dr["book_cost"].ToString();
                        TextBox5.Text = dr["actual_stock"].ToString();
                        TextBox6.Text = dr["current_stock"].ToString();
                        TextBox8.Text = dr["no_of_pages"].ToString();
                        TextBox11.Text = dr["edition"].ToString();
                        TextArea.Text = dr["book_description"].ToString();
                        DropDownList1.SelectedValue = dr["language"].ToString().Trim();
                        DropDownList2.SelectedValue = dr["publisher_name"].ToString().Trim();
                        DropDownList3.SelectedValue = dr["author_name"].ToString().Trim();

                        string[] genres = dr["genre"].ToString().Split(',');
                        foreach (ListItem item in ListBox1.Items)
                        {
                            if (genres.Contains(item.Text))
                            {
                                item.Selected = true;
                            }
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('Book ID not found');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
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
                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";

                }
                genres = genres.Remove(genres.Length - 1);

                string filepath = "~/img/booksimg/inventory.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("img/booksimg/" + filename));
                filepath = "~/img/booksimg/" + filename;

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl(book_id ,book_name,genre,author_name,publisher_name,publish_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link) values(@book_id ,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", con);
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextArea.Text.Trim()); 
                cmd.Parameters.AddWithValue("@actual_stock", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);
                

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
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id='" + TextBox1.Text.Trim() + "';", con);
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
        // update button
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
                Response.Write("<script>alert('Book does not exist. Please try again.');</script>");



            }
        }
        void update()
        {
            try
            {
                string genres = string.Join(",", ListBox1.GetSelectedIndices()
                                                .Select(i => ListBox1.Items[i].ToString()));

                string filepath = "~/img/booksimg/inventory.png"; // default

                if (FileUpload1.HasFile)
                {
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.SaveAs(Server.MapPath("img/booksimg/" + filename));
                    filepath = "~/img/booksimg/" + filename;
                }

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"UPDATE book_master_tbl 
                SET book_name=@book_name, genre=@genre, author_name=@author_name,
                    publisher_name=@publisher_name, publish_date=@publish_date, language=@language,
                    edition=@edition, book_cost=@book_cost, no_of_pages=@no_of_pages,
                    book_description=@book_description, actual_stock=@actual_stock,
                    current_stock=@current_stock, book_img_link=@book_img_link
                WHERE book_id=@book_id", con);

                    cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", TextBox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", TextArea.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@current_stock", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        Response.Write("<script>alert('Book Updated Successfully!');</script>");
                        GridView1.DataBind();
                    }
                    else
                    {
                        Response.Write("<script>alert('Update failed: No rows affected.');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }

            clearform();
        }

        void clearform()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
        // delete button
        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed) { con.Open(); }

                SqlCommand cmd = new SqlCommand("DELETE FROM book_master_tbl WHERE book_id=@book_id", con);
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());

                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    Response.Write("<script>alert('Book deleted successfully');</script>");
                    GridView1.DataBind();
                    clearform();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void fillAuthorPublisherValues()
        {
            try
            {
                SqlConnection con=new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT author_name FROM author_master_tbl;",con);
                SqlDataAdapter da=new SqlDataAdapter(cmd);
                DataTable dt =new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "author_name";
                DropDownList3.DataBind();

                cmd = new SqlCommand("SELECT publisher_name FROM publisher_master_tbl;", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                DropDownList2.DataSource = dt1;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();



            }
            catch (Exception ex) 
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");


            }
        }
        
        

       
    }
}