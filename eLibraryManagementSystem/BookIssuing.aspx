<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BookIssuing.aspx.cs" Inherits="eLibraryManagementSystem.BookIssuing" %>

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
        <div class="row">
            <div class="col-md-5">
                <div class="row">
                    <div class="col">
                        <center>
                            <img src="img/occupation.png" width="60px" />
                        </center>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <center>
                            <h4>Book Issue</h4>
                        </center>


                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 form-group">
                        <label>Book Name</label>
                        <asp:TextBox ID="TextBox1" runat="server" placeholder="Book Name" CssClass="form-control" ReadOnly="true" Style="background-color: lightgrey"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <label>Book Id</label>
                        <div class="input-group">
                            <asp:TextBox ID="TextBox2" runat="server" placeholder="Enter Book Id:" CssClass="form-control"></asp:TextBox>
                            <asp:Button ID="Button1" runat="server" Text="Go" CssClass="btn btn-outline-success form-control" OnClick="Button1_Click" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 form-group">
                        <label>Member Name</label>
                        <asp:TextBox ID="TextBox3" runat="server" placeholder="Member Name " CssClass="form-control" ReadOnly="true" Style="background-color: lightgrey"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <label>Member Id</label>
                        <div class="input-group">
                            <asp:TextBox ID="TextBox4" runat="server" placeholder="Enter Member Id:" CssClass="form-control"></asp:TextBox>
                            <asp:Button ID="Button4" runat="server" Text="Go" CssClass="btn btn-outline-success form-control" OnClick="Button4_Click" />
                        </div>

                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 form-group">
                        <label>Start Date</label>
                        <asp:TextBox ID="TextBox5" runat="server" placeholder="Enter Book Name: " TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <label>End Date</label>
                        <asp:TextBox ID="TextBox6" runat="server" placeholder="Enter Book Id:" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-md-6">
                        <asp:Button ID="Button2" runat="server" Text="Issue" CssClass="btn btn-lg btn-info w-100 " OnClick="Button2_Click" />
                    </div>
                    <div class="col-md-6">
                        <asp:Button ID="Button3" runat="server" Text="Return" CssClass="btn btn-lg btn-danger w-100 " OnClick="Button3_Click" />
                    </div>
                </div>
                <a href="homepage.aspx" style="text-align: center"><< Back to home..</a>
            </div>
            <div class="col-md-7">
                <div class="row">
                    <div class="col">
                        <center>
                            <h4>Issued Book List</h4>

                        </center>
                    </div>
                </div>
                <div class="row">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_issue_tbl]"></asp:SqlDataSource>
                    <div class="col">
                        <asp:GridView ID="GridView1" runat="server" class="table table-striped table-bordered" DataKeyNames="member_id" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound1">
                            <Columns>
                                <asp:BoundField DataField="member_id" HeaderText="Member ID" ReadOnly="True" SortExpression="member_id" />
                                <asp:BoundField DataField="member_name" HeaderText="Member Name" SortExpression="member_name" />
                                <asp:BoundField DataField="book_id" HeaderText="Book ID" SortExpression="book_id" />
                                <asp:BoundField DataField="book_name" HeaderText="Book Name" SortExpression="book_name" />
                                <asp:BoundField DataField="issue_date" HeaderText="Issue Date" SortExpression="issue_date" />
                                <asp:BoundField DataField="due_date" HeaderText="Due Date" SortExpression="due_date" />
                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
