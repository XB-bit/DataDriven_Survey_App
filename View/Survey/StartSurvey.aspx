<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site1.Master" AutoEventWireup="true" CodeBehind="StartSurvey.aspx.cs" Inherits="AIT_Research.View.Survey.StartSurvey1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            font-weight: normal;
            color: #000099;
        }
        .auto-style3 {
            font-weight: normal;
            color: #000000;
        }
        #ButtonCancel {
            color: #FFFFFF;
            background-color: #0033CC;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="auto-style2"><strong style="text-align: center; color: #FFFFFF; background-color: #0033CC;">Welcome to the Start of the Survey</strong></h3>
    <p class="auto-style3"><strong>Do you want to quickly register before starting the survey? </strong></p>
    <p class="auto-style2">
        <asp:RadioButton ID="RegisterPageYes" runat="server" GroupName="RegisterRadioButton" Text="Yes" />
        <asp:RadioButton ID="RegisterPageNo" runat="server" GroupName="RegisterRadioButton" Text="No" />
    </p>
    <p class="auto-style2">
        <asp:Button ID="ButtonNext" runat="server" OnClick="ButtonNext_Click" style="color: #FFFFFF; text-align: center; background-color: #0033CC" Text="Next" />
&nbsp;&nbsp;&nbsp;
       <a href="../HomePage/HomePage.aspx"><input id="ButtonCancel" type="button" value="Cancel" /></a> </p>
    <p class="auto-style2">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/756-7564789_registration-icon-png-transparent-png.png" style="background-color: #FFFFFF" Width="300px" />
    </p>
        </asp:Content>