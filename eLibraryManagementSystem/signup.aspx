<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="eLibraryManagementSystem.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mx-auto">
        <div class="row">
            <div class="col-md-8 mx-auto" >
                <div class="card p-4 shadow">
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
                             <h4 style="font-weight:bolder" >Student Registration</h4>

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
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Full name" required="true"></asp:TextBox>
                               
                                    <label  style="font-weight:bold">Date of Birth</label>
                    
                                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Date" CssClass="form-control" placeholder="Date of Birth" required="true"></asp:TextBox>
                                
                              </div>
                            <div class="form-group col-md-6">
                                
                                     <label  style="font-weight:bold">Contact Number</label>
                                     <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="Contact no." TextMode="Phone" required="true"></asp:TextBox>
                                     <label  style="font-weight:bold"> College EmailId</label>
     
                                     <asp:TextBox ID="TextBox4" runat="server" TextMode="Email" CssClass="form-control" placeholder="Email id" required="true"></asp:TextBox>
                                
                             </div>
                     

                    </div>
                    <div class="row">
                        <div class="col-md-4 form-group">
                           
                                <asp:Label  style="font-weight:bold" ID="LabelState" runat="server" Text="Select Branch:"></asp:Label>
                                <asp:DropDownList ID="DropDownListState" runat="server" CssClass="form-control" required="true" >
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
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" required="true">
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
                        <div class="col-md-6 form-group">
                            <label  style="font-weight:bold">UserID</label>
                            <asp:TextBox ID="TextBox6" runat="server" placeholder="Enter Your Id:" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-6 form-group">
                            <label  style="font-weight:bold">Password</label>
                            <asp:TextBox ID="TextBox7" runat="server" placeholder="Set Your Password:" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <hr />
                            <asp:Button ID="Button1" runat="server" Text="SignUp" class="btn btn-success w-100 btn-lg" OnClick="Button1_Click"/>
                            
                        </div>
                    </div>

        </div>
                

                
     </div>
            <a href="homepage.aspx" style="text-align:center"><< Back to home..</a>
            <br />
            <br />
    </div>
</asp:Content>
