<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminBookInventory.aspx.cs" Inherits="eLibraryManagementSystem.AdminBookInventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
                .main-content{
    background-image: url('https://wallpaperbat.com/img/272832-wallpaper-movie-theater-wallpaper-on-wallpaperp-movie.png'); /* Replace with your image path */
    background-size: cover;
    background-repeat: no-repeat;
    background-attachment: fixed;
    background-position: center;
    font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif; /* Optional font */
}
    </style>

     <script type="text/javascript">
         $(document).ready(function () {
             var table = $('.table');

             // Check if thead exists
             if (table.find('thead').length === 0) {
                 var thead = $('<thead></thead>');
                 thead.append(table.find('tr:first'));
                 table.prepend(thead);
             }

             table.DataTable();
         });
         function readURL(input) {
             if (input.files && input.files[0]) {
                 var reader = new FileReader();
                 reader.onload = function (e) {
                     $('#imgview').attr('src', e.target.result);
                 };
                 reader.readAsDataURL(input.files[0]);
             }
         }

     </script>
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-content">
    <div class="container">
    <br />

        <div class="row">
    
        <div class="card">
        <center>
        <div class="col">
            <div class="row">
                <div class="col">
                    <center>
                        <img src="img/booksimg/inventory.png" width="70px" id="imgview" height="100px" />
                    </center>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <center>
                        <h4>Admin Book Inventory</h4>
                    </center>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col">
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" onchange="readURL(this);" />
                </div>
            </div>
            <div class="row p-2">
                <div class="col-md-4 form-group">
                    <label>Book Id</label>
                    <div class="input-group">
                    <asp:TextBox ID="TextBox1" runat="server" placeholder="Member Id" CssClass="form-control"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Go" CssClass="btn btn-outline-success form-control" OnClick="Button1_Click"  />
                        </div>
                </div>
                <div class="col-md-8 form-group">
                    <label>Book Name</label>
                    <asp:TextBox ID="TextBox2" runat="server" placeholder="Full Name" CssClass="form-control"></asp:TextBox>
                </div>
                
            </div>
            
            <div class="row p-2 ">
                <div class="col-md-4 form-group">
                    <label>Language</label>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" placeholder="select language">
                        <asp:ListItem Value="">--Select--</asp:ListItem>
                        <asp:ListItem >English</asp:ListItem>
                        <asp:ListItem >Marathi</asp:ListItem>
                        <asp:ListItem >Hindi</asp:ListItem>
                        <asp:ListItem >Spanish</asp:ListItem>
                        <asp:ListItem >French</asp:ListItem>
                        <asp:ListItem >Japanese</asp:ListItem>
                        <asp:ListItem >Sanskrit</asp:ListItem>
                    </asp:DropDownList>
                     
                    
                    <label>Publisher Name</label>
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" placeholder="Select Publisher">
                        <asp:ListItem Value="">--Select--</asp:ListItem>
                        <asp:ListItem >McGraw-Hill</asp:ListItem>
                        <asp:ListItem >Pearson</asp:ListItem>
                        <asp:ListItem >Cambridge University Press</asp:ListItem>
                        <asp:ListItem >Springer Naturei</asp:ListItem>
                        <asp:ListItem >Elsevier (ScienceDirect) </asp:ListItem>
                        <asp:ListItem >Artech House</asp:ListItem>
                        <asp:ListItem >John Wiley & Sons</asp:ListItem>

                    </asp:DropDownList>
                    
                </div>
                <div class="col-md-4 form-group">
                    <label>Author</label>
                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control" placeholder="Select Author" >
                        <asp:ListItem Value="">--Select--</asp:ListItem>
                            <asp:ListItem >J K Rowling</asp:ListItem>
                            <asp:ListItem >Dilip Prabhawalkar</asp:ListItem>
                            <asp:ListItem >Franklin Kuo</asp:ListItem>
                            <asp:ListItem >Mazidi</asp:ListItem>
                            <asp:ListItem >Rashid </asp:ListItem>
                            <asp:ListItem >Khanchandani</asp:ListItem>
                            <asp:ListItem >Vishwas Patil</asp:ListItem>
                    </asp:DropDownList>

                    <label>Publish date</label>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control " TextMode="Date" ></asp:TextBox>
                    
                </div>
                <div class="col-md-4 form-group">
                    <label>Genre</label>
                    <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" CssClass="form-control">
                        <asp:ListItem Text="Science Fiction" Value="ScienceFiction"></asp:ListItem>
                        <asp:ListItem Text="Romance" Value="Romance"></asp:ListItem>
                        <asp:ListItem Text="Thriller" Value="Thriller"></asp:ListItem>
                        <asp:ListItem Text="Biography" Value="Biography"></asp:ListItem>
                        <asp:ListItem Text="Technology" Value="Technology"></asp:ListItem>
                        <asp:ListItem Text="Fantasy" Value="Fantasy"></asp:ListItem>
                        <asp:ListItem Text="History" Value="History"></asp:ListItem>
                        <asp:ListItem Text="Drama" Value="Drama"></asp:ListItem>
                    </asp:ListBox>

                </div>
            </div>
            <div class="row p-2 ">
                <div class="col-md-4 form-group">
                    <label>Edition</label>
                    <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control " TextMode="Number" placeholder="edition"></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label>Book Cost</label>
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control " placeholder="bookcost" ></asp:TextBox>
        
                </div>
                <div class="col-md-4 form-group">
                    <label>Pages</label>
                    <asp:TextBox ID="TextBox8" runat="server" placeholder="Pages" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
              <div class="row p-2">
                  <div class="col-md-4 form-group">
                      <label>Actual Stock</label>
                      <asp:TextBox ID="TextBox5" runat="server" placeholder="Actual" CssClass="form-control" ReadOnly="false" ></asp:TextBox>
                  </div>
                  <div class="col-md-4 form-group">
                      <label>Current Stock</label>
                      <asp:TextBox ID="TextBox6" runat="server" placeholder="Current" CssClass="form-control" ReadOnly="false" style="background-color:lightgrey" ></asp:TextBox>
                  </div>
                  <div class="col-md-4 form-group">
                      <label>Issued Books</label>
                      <asp:TextBox ID="TextBox10" runat="server" placeholder="Issued" CssClass="form-control" ReadOnly="true" style="background-color:lightgrey"></asp:TextBox>
                  </div>
              </div>
            <div class="row p-2">
                <div class="col form-group">
                    <label>Book Description</label>
                    <asp:TextBox ID="TextArea" runat="server" TextMode="MultiLine" width="100%"/>


                </div>
            </div>
            <hr />
            <div class="row p-2">
                <div class="col-md-4">
                    <asp:Button ID="Button2" runat="server" Text="Add" CssClass="btn btn-lg btn-success w-100 " OnClick="Button2_Click" />
                </div>
                <div class="col-md-4">
                    <asp:Button ID="Button3" runat="server" Text="Update" CssClass="btn btn-lg btn-info w-100 " OnClick="Button3_Click" />
                </div>
                <div class="col-md-4">
                    <asp:Button ID="Button4" runat="server" Text="Delete" CssClass="btn btn-lg btn-danger w-100 " OnClick="Button4_Click" />
                </div>

                
            </div>
            <a href="homepage.aspx" style="text-align:center"><< Back to home..</a>
        </div>
          </center> 
            </div>
        <br />
        <hr />

        <div class="card">

        
        <div class="col">
            <div class="row">
                <div class="col">
                    <center>
                        <h4>Book Inventory List</h4>

                    </center>
                </div>
            </div>
            <hr />
                       <div class="row">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
    <div class="col">
        <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="book_id" HeaderText="ID" SortExpression="book_id" ReadOnly="True" />
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-lg-10">
                                    <div class="row">
                                        <div class="col-12">
                                            <asp:Label ID="Label1" Font-Bold="True"  runat="server" Text='<%# Eval("book_name") %>' Font-Size="X-Large" Font-Names="Georgia" ></asp:Label>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-12">


                                            Author-<asp:Label Font-Bold="true"  ID="Label2" runat="server" Text='<%# Eval("author_name") %>'></asp:Label>
                                            | Genre-<asp:Label Font-Bold="true" ID="Label3" runat="server" Text='<%# Eval("genre") %>'></asp:Label>
                                            | Language-<asp:Label Font-Bold="true" ID="Label4" runat="server" Text='<%# Eval("language") %>'></asp:Label>


                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-12">


                                            Publisher-<asp:Label Font-Bold="true" ID="Label5" runat="server" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                            &nbsp;| Publish Date-
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("publish_date") %>'></asp:Label>
                                            &nbsp;| Pages-<asp:Label Font-Bold="true" ID="Label7" runat="server" Text='<%# Eval("edition") %>'></asp:Label>
                                            &nbsp;| Edition-<asp:Label Font-Bold="true" ID="Label8" runat="server" Text='<%# Eval("edition") %>'></asp:Label>


                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-12">


                                            Cost-<asp:Label Font-Bold="true" ID="Label9" runat="server" Text='<%# Eval("book_cost") %>'></asp:Label>
                                            &nbsp;| Actual Stock-<asp:Label Font-Bold="true" ID="Label10" runat="server" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                            &nbsp;| Available-<asp:Label Font-Bold="true" ID="Label11" runat="server" Text='<%# Eval("current_stock") %>'></asp:Label>


                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-12">


                                            Description-<asp:Label ID="Label12" runat="server" Text='<%# Eval("book_description") %>'></asp:Label>


                                        </div>
                                    </div>

                                </div>
                                <div class="col-lg-2">
                                    <asp:Image CssClass="img-fluid" ID="Image1" Height="200px"   runat="server" ImageUrl='<%# Eval("book_img_link") %>' />


                                </div>

                            </div>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>

        </asp:GridView>
    </div>
</div>
        </div>
            </div>
    </div>
</div>
   </div>
</asp:Content>
