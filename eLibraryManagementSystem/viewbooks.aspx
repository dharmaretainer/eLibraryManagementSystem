<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewbooks.aspx.cs" Inherits="eLibraryManagementSystem.viewbooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        <style>
                .main-content{
    background-image: url('https://m.media-amazon.com/images/S/pv-target-images/5836208596e4702385af95d32f5b636c9151bf29ba787d321a3716b2a749a658.jpg'); /* Replace with your image path */
    background-size: cover;
    background-repeat: no-repeat;
    background-attachment: fixed;
    background-position: center;
    font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif; /* Optional font */
}
/*                .col-md-8 {
    margin-right: 2000px;
}*/
.card {
    margin-left: 0 !important;
    padding-left: 15px;
}

.col-lg-8 {
    max-width: 100%;
}

             
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-content">
        <br />
   <div class="container-fluid">
        <div class="row">
            
            <div class="col-lg-8 offset-lg-0 ms-0 ">
                
                    
                               <div class="card">

        
        <div class="col">
            <div class="row">
                <div class="col">
                    <center>
                        <h4>Books List</h4>

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
        </div>
</asp:Content>
