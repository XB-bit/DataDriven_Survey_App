<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site1.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="AIT_Research.View.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            color: #000099;
            text-align: center;
        }
        #Button1 {
            color: #FFFFFF;
            background-color: #000099;
            width: 295px;
        }
        #Button2 {
            color: #FFFFFF;
            background-color: #000099;
            font-size: medium;
            width: 556px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <h3 class="auto-style1">Welcome to the AITR Survey Home Page</h3>
        <p style="text-align: center">
            <a href="../Respondent/StaffLogin.aspx">
                <input id="Button1" type="button" value="Tap here if you are a Staff User" /></p>
        </a> 

    <h5 style="text-align: center"> &nbsp;This is a quick survey from AITResearch (AITR).This is a great way to earn some extra money.
    You will have the option of either registring or not. Thank you!<br /></h5> 
    <h4 style="text-align: center">
        <a href="../Survey/StartSurvey.aspx" style="text-align: center"> 
            <input id="Button2" type="button" value="Start Survey" /></a></h4>
    <h4 style="text-align: left">
        
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/download.png" Width="300px" />
       
            <br /></h4>
    </a>
</asp:Content>
