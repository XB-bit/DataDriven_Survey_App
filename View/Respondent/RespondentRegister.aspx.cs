using AIT_Research.Controller;
using System;

namespace AIT_Research.View.Respondent
{
    public partial class RespondentRegister1 : System.Web.UI.Page
    {
        UserLogic logic = new UserLogic();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //ButtonSubmit_Click = button 'submit and start survey'
        //check if respondent completed the survey or not
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string givenName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            DateTime dob = DateTime.Parse(txtDoB.Text);
            string phoneNumber = txtPhoneNumber.Text;

            
            var respondent = logic.RegisterNewRespondent(givenName, lastName, dob, phoneNumber);

            if (respondent != null)
            {
                if (respondent.IsSurveyCompleted)
                    Response.Redirect("/View/Survey/SurveyEnded.aspx");
                else
                    Response.Redirect("/View/Survey/Survey.aspx");
            }
        }
    }
}