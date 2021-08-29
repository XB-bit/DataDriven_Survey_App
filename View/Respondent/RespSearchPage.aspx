<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site1.Master" AutoEventWireup="true" CodeBehind="RespSearchPage.aspx.cs" Inherits="AIT_Research.View.Respondent.RespSearchPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            color: #0033CC;
            text-align: center;
        }
        #Button1 {
            color: #FFFFFF;
            background-color: #000066;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="auto-style1">Respondent Search Page</h2>
    <br />
       <h3 style="color: #FFFFFF; background-color: #0066FF">Enter your search criterium</h3>
                    <p>First Name<br />
                        <asp:TextBox ID="txtFirstName" runat="server" /></p>
                    <p style="color: #FFFFFF; background-color: #0066FF">Surname<br />
                        <asp:TextBox ID="txtLastName" runat="server" /></p>
                    <p>Email<br />
                        <asp:TextBox ID="txtEmail" runat="server" />
                    </p>
                    <p style="color: #FFFFFF; background-color: #0066FF">Gender<br />
                        <asp:CheckBox ID="cbMale" Text="Male" runat="server" />
                        <asp:CheckBox ID="cbFemale" Text="Female" runat="server" />
                        <asp:CheckBox ID="cbOther" Text="Other" runat="server" />
                    </p>
                    <p>Age Group<br />
                        <asp:CheckBox ID="cbU16" Text="Under 16" runat="server" />
                        <asp:CheckBox ID="cb16to25" Text="16 to 25" runat="server" />
                        <asp:CheckBox ID="cb26to45" Text="26 to 45" runat="server" />
                        <asp:CheckBox ID="cb46to65" Text="46 to 65" runat="server" />
                        <asp:CheckBox ID="cbA65" Text="above 65" runat="server" />
                    </p>

                    <p style="color: #FFFFFF; background-color: #0066FF">Post Code<br />
                        <asp:TextBox ID="txtPostCode" runat="server" /></p>
                    <p>State<br />
                        <asp:TextBox ID="txtState" runat="server" /></p>

                    <p style="color: #FFFFFF; background-color: #0066FF">Bank Used<br />
                        <asp:TextBox ID="txtBanks" runat="server" /></p>
                    <p>Bank Services<br />
                        <asp:TextBox ID="txtBankService" runat="server" /></p>
                    <p style="color: #FFFFFF; background-color: #0066FF">Newspaper<br />
                        <asp:TextBox ID="txtNewspaper" runat="server" /></p>
                    <p></p>
                    <p style="background-color: #FFFFFF">
                        <asp:Button runat="server" Text="Search" OnClick="ButtonSearch_Click" style="color: #FFFFFF; background-color: #000066" />&nbsp;&nbsp;&nbsp;
                        <a href="../HomePage/HomePage.aspx"><input id="Button1" type="button" value="Home" /></p></a>




        <div class="searchResults">
        <asp:GridView ID="grvRespondent" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" Width="100%">
            <Columns>
                <asp:BoundField DataField="GivenName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                <asp:BoundField DataField="AgeGroup" HeaderText="Age Group" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="State" HeaderText="State" />
                <asp:BoundField DataField="PostCode" HeaderText="Post Code" />
                <asp:BoundField DataField="BankUsedString" HeaderText="Bank Used" />
                <asp:BoundField DataField="BankServiceString" HeaderText="Bank Service" />
                <asp:BoundField DataField="NewspaperString" HeaderText="Newspaper" />
            </Columns>
        </asp:GridView>
            </div>

</asp:Content>
