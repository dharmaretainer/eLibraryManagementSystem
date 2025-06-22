<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="eLibraryManagementSystem.WebForm2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card p-3 shadow">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="img/mobile-password-forgot.png" width="100px"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                           <div class="col">
                                <center>
                                   <h3>Member Login</h3>
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
                                   <label>Member ID</label>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="MemberId"></asp:TextBox>
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
                                                              
                                <div class="form-group">
                                    
                                    <a href="signup.aspx"><input id="Button1" type="button" value="Sign Up" class="btn btn-primary btn-lg w-100"  /></a>

                                </div>
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
            
            
            


        </div>

</asp:Content>
