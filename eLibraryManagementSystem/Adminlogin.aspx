<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Adminlogin.aspx.cs" Inherits="eLibraryManagementSystem.Adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
        <br />
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    
                                    <img src="img/admin.png" width="100px"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                           <div class="col">
                                <center>
                                   <h3>Admin Login</h3>
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
                            <div class="col">
                                <div class="form-group">
                                   <label>Admin Id</label>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="AdminId"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                   <label>Password</label>
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                                <br />
                                 <div class="form-group">
                                     <asp:Button ID="Button1" runat="server" Text="Login" CssClass="btn btn-success w-100 btn-lg" OnClick="Button1_Click" />
                                 </div>
                                <br />
                                                              
                              
                             </div>
                              
                    </div>
                </div>

            </div>
        </div>
            <a href="#" style="text-align:center"><< Back to home..</a>
</div>

    </div>
        <div>
            <br />
            <br />
            <br />
            


        </div>

</asp:Content>
