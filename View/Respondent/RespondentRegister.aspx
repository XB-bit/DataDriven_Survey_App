<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site1.Master" AutoEventWireup="true" CodeBehind="RespondentRegister.aspx.cs" Inherits="AIT_Research.View.Respondent.RespondentRegister1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
        .auto-style1 {
            font-weight: normal;
            color: #FFFFFF;
        }
        .auto-style3 {
            color: #0033CC;
        }
        #Button1 {
            color: #FFFFFF;
            background-color: #0033CC;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <h2 class="auto-style3">Respondent Registration Page</h2>
     <h3 class="auto-style1"><strong style="color: #0033CC">Enter your data:</strong></h3>

        <p>
            <asp:Label runat="server" Text="First Name" style="color: #0033CC"/><br />
            <asp:TextBox ID="txtFirstName" runat="server"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ErrorMessage="First Name cannot be empty" ControlToValidate="txtFirstName" style="color: #FF0000"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label runat="server" Text="Last Name" style="color: #0033CC"/><br />
            <asp:TextBox ID="txtLastName" runat="server"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName0" runat="server" ErrorMessage="Last Name cannot be empty" ControlToValidate="txtLastName" style="color: #FF0000"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label runat="server" Text="Date of Birth" style="color: #0033CC"/><br />
            <asp:TextBox ID="txtDoB" TextMode="Date" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName1" runat="server" ErrorMessage="Date of Birth cannot be empty" ControlToValidate="txtDoB" style="color: #FF0000"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label runat="server" Text="Phone Number" style="color: #0033CC"/><br />
            <asp:TextBox ID="txtPhoneNumber" TextMode="Phone" runat="server"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName2" runat="server" ErrorMessage="Phone Number cannot be empty" ControlToValidate="txtPhoneNumber" style="color: #FF0000"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Button runat="server" Text="Submit And Start Your Survey" OnClick="ButtonSubmit_Click" style="color: #FFFFFF; background-color: #0033CC" Width="356px" />&nbsp;
            <a href="../Survey/StartSurvey.aspx"><input id="Button1" type="button" value="Cancel" /><br /></a>
        </p>
</asp:Content>
