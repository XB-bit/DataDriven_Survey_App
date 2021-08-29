using AIT_Research.Controller;
using System;

namespace AIT_Research.View.Respondent
{
    public partial class StaffLogin : System.Web.UI.Page
    {
        UserLogic logic = new UserLogic();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //validation authentication
            var loginSuccess = logic.StaffLogin(txtUsername.Text, txtPassword.Text);
            if (loginSuccess)
                Response.Redirect("/View/Respondent/RespSearchPage.aspx");
            else
                Label1.Text = "Incorrect username or password";
        }
    }
}