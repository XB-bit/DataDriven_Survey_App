<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site1.Master" AutoEventWireup="true" CodeBehind="SurveyEnded.aspx.cs" Inherits="AIT_Research.View.Survey.SurveyEnded1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
        .auto-style1 {
            text-align: center;
            color: #FFFFFF;
            background-color: #0033CC;
        }
        .auto-style2 {
            color: #0033CC;
        }
        #Button1 {
            color: #FFFFFF;
            background-color: #0033CC;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <h1 class="auto-style1">Survey Completed</h1>
        <p class="auto-style2" style="text-align: center">
            <strong>Thank you for partecipating!</strong></p>
    <p class="auto-style2" style="text-align: center">
        <a href="../HomePage/HomePage.aspx"><input id="Button1" type="button" value="Home" /></a> </p>
</asp:Content>

