<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmembermanagement.aspx.cs" Inherits="eLibraryManagementSystem.adminmembermanagement" %>
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
    <style>
    .status-dot {
        height: 15px;
        width: 15px;
        border-radius: 50%;
        display: inline-block;
        margin-left: 10px;
    }

    .dot-active {
        background-color: #28a745;
    }

    .dot-pending {
        background-color: #ffc107;
    }

    .dot-deactivated {
        background-color: #dc3545;
    }

    .dot-unknown {
        background-color: #6c757d;
    }
</style>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
        <div class="row">

            <div class="col-md-4">
                <div class="row">
                    <div class="col">
                        <center>
                            <img src="img/team-management.png" width="60px"/>
                        </center>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <center>
                            <h4>Member Management</h4>
                        </center>
                        

                    </div>
                </div>
                <div class="row p-2">
                    <div class="col-md-3 form-group">
                        <label>Member Id</label>
                        <div class="input-group">
                        <asp:TextBox ID="TextBox1" runat="server" placeholder="Member Id" CssClass="form-control"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" Text="Go" CssClass="btn btn-outline-success form-control" OnClick="Button1_Click"  />
                            </div>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>Full Name</label>
                        <asp:TextBox ID="TextBox2" runat="server" placeholder="Full Name" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-md-5 form-group">
                        <label>Account Status</label>
                        <asp:Label ID="lblStatusDot" runat="server" CssClass="status-dot"></asp:Label>
                        <div class="input-group"> 
                        <asp:Button ID="Button4" runat="server" Text="✓ " CssClass="btn btn-success form-control  " OnClick="Button4_Click"  />
                        <asp:Button ID="Button5" runat="server" Text="⏸" CssClass="btn btn-warning form-control " OnClick="Button5_Click"  />
                        <asp:Button ID="Button6" runat="server" Text="⛔" CssClass="btn btn-danger form-control " OnClick="Button6_Click"  />
                             
                            </div>

                    </div>
                </div>
                
                <div class="row p-2 ">
                    <div class="col-md-3 form-group">
                        <label>DOB</label>
                        <asp:TextBox ID="TextBox3" runat="server" placeholder="Date of Birth:" CssClass="form-control" ReadOnly="true" style="background-color:lightgrey" TextMode="Date"></asp:TextBox>
                    </div>
                    <div class="col-md-4 form-group">
                        <label>Contact No.</label>
                        <asp:TextBox ID="TextBox4" runat="server" placeholder="Contact No:" CssClass="form-control" ReadOnly="true" style="background-color:lightgrey" TextMode="Phone" ></asp:TextBox>
                    </div>
                    <div class="col-md-5 form-group">
                        <label>college Email Id</label>
                        <asp:TextBox ID="TextBox9" runat="server" placeholder="Email Id:" CssClass="form-control" ReadOnly="true" style="background-color:lightgrey" TextMode="Email"></asp:TextBox>
                    </div>
                </div>
                  <div class="row p-2">
                      <div class="col-md-4 form-group">
                          <label>Branch</label>
                          <asp:TextBox ID="TextBox5" runat="server" placeholder="Branch" CssClass="form-control" ReadOnly="true" style="background-color:lightgrey"></asp:TextBox>
                      </div>
                      <div class="col-md-4 form-group">
                          <label>Year</label>
                          <asp:TextBox ID="TextBox6" runat="server" placeholder="Year" CssClass="form-control" ReadOnly="true" style="background-color:lightgrey" ></asp:TextBox>
                      </div>
                      <div class="col-md-4 form-group">
                          <label>MIS no.</label>
                          <asp:TextBox ID="TextBox10" runat="server" placeholder="MIS" CssClass="form-control" ReadOnly="true" style="background-color:lightgrey"></asp:TextBox>
                      </div>
                  </div>
                
                <hr />
                <div class="row p-2">
                    <div class="col">
                        <asp:Button ID="Button2" runat="server" Text="Delete User Permenantly" CssClass="btn btn-lg btn-danger w-100 " OnClick="Button2_Click" />
                    </div>
                    
                </div>
                <a href="#" style="text-align:center"><< Back to home..</a>
            </div>
            <div class="col-md-8">
                <div class="row">
                    <div class="col">
                        <center>
                            <h4>Member List</h4>

                        </center>
                    </div>
                </div>
                <hr />
               <div class="row">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                <div class="col">
                    <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                        <Columns>
                            <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status"  />
                            <asp:BoundField DataField="member_id" HeaderText="ID" SortExpression="member_id" ReadOnly="True"/>
                            <asp:BoundField DataField="full_name" HeaderText="Name"  SortExpression="full_name" />
                            <asp:BoundField DataField="contact_no" HeaderText="Contact" SortExpression="contact_no"  />
                            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                            <asp:BoundField DataField="Branch" HeaderText="Branch" SortExpression="Branch"  />
                            <asp:BoundField DataField="Year" HeaderText="Year" SortExpression="Year"  />
                            <asp:BoundField DataField="MIS" HeaderText="MIS" SortExpression="MIS" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
                        </div>
        </div>
    </div>
</asp:Content>
