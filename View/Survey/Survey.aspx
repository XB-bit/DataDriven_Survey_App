<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site1.Master" AutoEventWireup="true" CodeBehind="Survey.aspx.cs" Inherits="AIT_Research.View.Survey.Survey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            color: #0033CC;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="auto-style1">Online Survey</h2>
       <p>
                <asp:Label ID="lblQuestionContent" runat="server"></asp:Label>
            </p>
            <p>
                <asp:PlaceHolder ID="plhSurveyAnswer" runat="server"></asp:PlaceHolder>
            </p>            
            <p>
                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="NextBtnClick" style="color: #FFFFFF; background-color: #0033CC" />
                &nbsp;<asp:Button ID="btnSkip" runat="server" Text="Skip" OnClick="SkipButton_Click" Visible="false" style="color: #FFFFFF; background-color: #0033CC"/>
            </p>
            <p>
                <asp:Label ID="lblErrorMessage" runat="server" style="font-weight: 700"></asp:Label>
            </p>
</asp:Content>