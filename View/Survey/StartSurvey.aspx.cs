using AIT_Research.Controller;
using System;

namespace AIT_Research.View.Survey
{
    public partial class StartSurvey1 : System.Web.UI.Page
    {
        UserLogic logic = new UserLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            //check with page loading if User already finished survey
            var respondent = logic.RespondentExistWithIpAddress();
            if (respondent != null)
            {
                if (respondent.IsSurveyCompleted)
                    Response.Redirect("/View/Survey/SurveyEnded.aspx");
                else
                    Response.Redirect("/View/Survey/Survey.aspx");
            }
        }



        protected void ButtonNext_Click(object sender, EventArgs e)
        {
            

            if (RegisterPageYes.Checked)
            {
                Response.Redirect("/View/Respondent/RespondentRegister.aspx");
            }
            else
            {
                var respondent = logic.CheckRespondent();
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
}