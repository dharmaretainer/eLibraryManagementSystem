<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AuthorManagement.aspx.cs" Inherits="eLibraryManagementSystem.AuthorManagement" %>
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

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container">
            <br />
            <br />
            <div class="row" >
                <div class="col-md-5 mx-auto">
                    
                    <div class="card shadow p-2">
                         <div class="row">
                             <div class="col">
                                 <center>
                                     <h4>Author Management</h4>
                                 </center>
                             </div>
                         </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="img/author.png" width="60px"  />
                                </center>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-4 form-group ">
                                <label style="font-weight:bold">UserId</label>
                                <div class="input-group">
                                
                                <asp:TextBox ID="TextBox1" runat="server" placeholder="ID" CssClass="form-control"></asp:TextBox>
                                    <asp:Button ID="Button1" runat="server" Text="Go" CssClass="btn btn-outline-success form-control" OnClick="Button1_Click"  />

                                
                                    </div>
                            </div>

                            <div class="col-md-7 from-group">
                                <label style="font-weight:bold">Author Name</label>
                                <asp:TextBox ID="TextBox2" runat="server" placeholder="Name"  CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row p-2">
                            <div class="col-md-4">
                                <asp:Button ID="Button2" runat="server" Text="Add" CssClass="btn btn-success btn-lg btn-block" OnClick="Button2_Click" />

                            </div>
                             <div class="col-md-4">
                                 <asp:Button ID="Button3" runat="server" Text="Update" CssClass="btn btn-info btn-lg btn-block" OnClick="Button3_Click" />

                             </div>
                             <div class="col-md-4">
                                 <asp:Button ID="Button4" runat="server" Text="Delete" CssClass="btn btn-danger btn-lg btn-block " OnClick="Button4_Click" />

                             </div>
                        </div>
                       <a href="#" style="text-align:center"><< Back to home..</a>
                    </div>
                    
                        
                </div>
                <div class="col-md-7 mx-auto">
    
    <div class="card shadow p-2">
         <div class="row">
             <div class="col">
                 <center>
                     <h4>Author List</h4>
                 </center>
             </div>
         </div>
        <hr />
        
        <div class="row">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" ProviderName="<%$ ConnectionStrings:elibraryDBConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [author_master_tbl]"></asp:SqlDataSource>
            <div class="col">
                <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1" UseAccessibleHeader="True">
                    <Columns>
                        <asp:BoundField DataField="author_id" HeaderText="author_id" ReadOnly="True" SortExpression="author_id" />
                        <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
         
      
    </div>
    
        
</div>
            </div>
         
        </div>
    

</asp:Content>
