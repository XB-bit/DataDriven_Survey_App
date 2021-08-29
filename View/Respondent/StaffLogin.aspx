<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site1.Master" AutoEventWireup="true" CodeBehind="StaffLogin.aspx.cs" Inherits="AIT_Research.View.Respondent.StaffLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            color: #0033CC;
            text-align: center;
        }
        #Button2 {
            color: #FFFFFF;
            background-color: #0033CC;
        }
        .auto-style3 {
            font-size: x-small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="auto-style2">Staff Page</h2>
    <br />

     <p>
            <asp:Label runat="server" Text="Username" style="color: #0033CC"/>&nbsp;&nbsp; <span class="auto-style3">&nbsp;(staff or staff123)</span><br />
            <asp:TextBox ID="txtUsername" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName1" runat="server" ErrorMessage="Username cannot be empty" ControlToValidate="txtUsername" style="color: #FF0000"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label runat="server" Text="Password" style="color: #0033CC"/>&nbsp;<span class="auto-style3">(same as usernames)</span><br />
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Password cannot be empty" ControlToValidate="txtPassword" style="color: #FF0000"></asp:RequiredFieldValidator>

    <p>
            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
    <p>

    <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="Button1_Click" style="color: #FFFFFF; background-color: #0033CC" />
&nbsp;&nbsp;&nbsp;
   <a href="../HomePage/HomePage.aspx"><input id="Button2" type="button" value="Cancel" /></a> 
            </asp:Content>
