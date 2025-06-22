<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="eLibraryManagementSystem.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .form-control {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5">
                        <div class="card p-2 shadow">
            <div class="row">
                <div class="col">
                    <center>
                    <img src="img/interface.png" width="50px" />

                    </center>
                    
                </div>
            </div>
            <div class="row">
                <div class="col">
                     <center>
                     <h4 style="font-weight:bolder" >Your Profile</h4>
                         <span>Account Status-</span>
                         <asp:Label ID="Label2" runat="server" Text="Your Status" Class="badge rounded-pill text-bg-info"></asp:Label>
                     </center>
 
                 </div>
             </div>
            <div class="row">
                <div class="col">
                    <center>
                       <hr />
                    </center>
                </div>

            </div>
            <div class="row">
                
                    <div class="form-group col-md-6">
                        
                            <label style="font-weight:bold">Full Name</label>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Full name" ReadOnly="true"></asp:TextBox>
                            <label  style="font-weight:bold">Date of Birth</label>
            
                            <asp:TextBox ID="TextBox2" runat="server" TextMode="Date" CssClass="form-control" placeholder="Date of Birth" ReadOnly="true"></asp:TextBox>
                        
                      </div>
                    <div class="form-group col-md-6">
                        
                             <label  style="font-weight:bold">Contact Number</label>
                             <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="Contact no." TextMode="Phone" ReadOnly="true"></asp:TextBox>
                             <label  style="font-weight:bold"> College EmailId</label>
     
                             <asp:TextBox ID="TextBox4" runat="server" TextMode="Email" CssClass="form-control" placeholder="Email id" ReadOnly="true" ></asp:TextBox>
                        
                     </div>
             

            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                   
                        <asp:Label  style="font-weight:bold" ID="LabelState" runat="server" Text="Select Branch:"></asp:Label>
                        <asp:DropDownList ID="DropDownListState" runat="server" CssClass="form-control"  >
                            <asp:ListItem Value="">--Select Branch--</asp:ListItem>
                            <asp:ListItem>Electronics and Telecommunication Engeneering</asp:ListItem>
                            <asp:ListItem>Electrical Engeneering</asp:ListItem>
                            <asp:ListItem>Computer Engineering</asp:ListItem>
                            <asp:ListItem>Instrumentation and Control Engineering</asp:ListItem>
                            <asp:ListItem>Mechanical Engineering</asp:ListItem>
                            <asp:ListItem>Civil Engineering</asp:ListItem>
                            <asp:ListItem>Manufacturing Science Engineering</asp:ListItem>
                            <asp:ListItem>Metallurgical Engineering</asp:ListItem>
                            <asp:ListItem>BPlanning</asp:ListItem>
                            <asp:ListItem>Mtech</asp:ListItem>
                            <asp:ListItem>Mplan</asp:ListItem>
                            <asp:ListItem>MBA</asp:ListItem>
                            
                            
       
                        </asp:DropDownList>



                </div>
                <div class="col-md-4 form-group">
   
                    <asp:Label ID="Label1" runat="server" Text="Select Year:"  style="font-weight:bold"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                        <asp:ListItem Value="">--Select Year--</asp:ListItem>
                        <asp:ListItem>FY</asp:ListItem>
                        <asp:ListItem>SY</asp:ListItem>
                        <asp:ListItem>TY</asp:ListItem>
                        <asp:ListItem>Btech</asp:ListItem>
                        <asp:ListItem>FY MBA</asp:ListItem>
                        <asp:ListItem>FY Mtech</asp:ListItem>
                        <asp:ListItem>FY Mplan</asp:ListItem>
                        <asp:ListItem>SY MBA</asp:ListItem>
                        <asp:ListItem>SY Mtech</asp:ListItem>
                        <asp:ListItem>SY Mplan</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group col-md-4">
                    <label  style="font-weight:bold">MIS Number:</label>
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" placeholder="Enter Your MIS:" TextMode="Number"></asp:TextBox>
                </div>
            

                
            </div>
            <div class="row">
                <div class="col-md-12">
                    <center>
                        <hr />
                    <h6 style="color: black; 
                     Background: cornflowerblue ">Login Credentials</h6>
                     </center>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 form-group">
                    <label  style="font-weight:bold">UserID</label>
                    <asp:TextBox ID="TextBox6" runat="server" placeholder="Enter Your Id:" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-md-4 form-group">
                    <label  style="font-weight:bold">Old Password</label>
                    <asp:TextBox ID="TextBox7" runat="server" placeholder="Old Password" CssClass="form-control" TextMode="SingleLine" ReadOnly="true" Width="168px" ></asp:TextBox>
                    


                </div>

                <div class="col-md-4 form-group">
    <label  style="font-weight:bold">New Password</label>
    <asp:TextBox ID="TextBox8" runat="server" placeholder="Set New Password" CssClass="form-control" TextMode="Password"></asp:TextBox>
</div>
            </div>
                            <center>
            <div class="row">
                <div class="col">
                    <hr />
                    <asp:Button ID="Button1" runat="server" Text="Update" class="btn btn-info  btn-lg" OnClick="Button1_Click"/>
                    
                </div>
            </div>
                                </center>

</div>
            </div>
            <div class="col-md-7">
                <div class="card p-4 shadow">
                    <div class="row">
                        <div class="col">
                            <center>
                            <img src="img/booksimg/inventory.png" width="50px" />
                                </center>
                        </div>
                    </div>
                     <div class="row">
                         <div class="col">
                             <center>
                             <h4>Your Issued Books</h4>
                                 </center>
                         </div>
                    </div>
                         <hr />
                    <div class="row">
                            
                        <div class="col">
                           <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="member_id" HeaderText="member_id" ReadOnly="True" />
                                    <asp:BoundField DataField="member_name" HeaderText="member_name" />
                                    <asp:BoundField DataField="book_id" HeaderText="book_id" />
                                    <asp:BoundField DataField="book_name" HeaderText="book_name" />
                                    <asp:BoundField DataField="issue_date" HeaderText="issue_date" />
                                    <asp:BoundField DataField="due_date" HeaderText="due_date" />
                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>
                </div>

            </div>
        </div>
        <br />
        <br />
    </div>

</asp:Content>
