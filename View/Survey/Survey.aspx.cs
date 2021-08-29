using AIT_Research.Controller;
using AIT_Research.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace AIT_Research.View.Survey
{
    public partial class Survey : System.Web.UI.Page
    {
        SurveyLogic logic = new SurveyLogic();
        Question question;
        List<Answer> answers;
        TextBox txtAnswer;
        CheckBoxList checkboxes;
        RadioButtonList radioButtons;
        DropDownList dropdowns;

        protected void Page_Load(object sender, EventArgs e)
        {
            question = logic.GetQuestion();

            if (question == null)
            {
                Response.Redirect("/View/Survey/SurveyEnded.aspx");
                return;
            }


            btnSkip.Visible = question.IsAdditionalQuestion;
            lblQuestionContent.Text = question.Content;

            answers = logic.GetAnswers(question.Id);

            // check question type
            switch (question.GetAnswerKind())
            {
                case "text":
                    // set up textbox answer 
                    txtAnswer = new TextBox();
                    plhSurveyAnswer.Controls.Add(txtAnswer);
                    break;

                case "checkbox":
                    // set up checkbox answer 
                    checkboxes = new CheckBoxList();
                    foreach (var answer in answers)
                    {
                        var checkBox = new ListItem(answer.Content, answer.Id.ToString());
                        checkboxes.Items.Add(checkBox);
                    }
                    plhSurveyAnswer.Controls.Add(checkboxes);
                    break;

                case "radioButton":
                    radioButtons = new RadioButtonList();
                    foreach (var answer in answers)
                    {
                        var radioBtn = new ListItem(answer.Content, answer.Id.ToString());
                        radioButtons.Items.Add(radioBtn);
                    }
                    plhSurveyAnswer.Controls.Add(radioButtons);
                    break;

                case "dropDown":
                    dropdowns = new DropDownList();
                    foreach (var answer in answers)
                    {
                        var item = new ListItem(answer.Content, answer.Id.ToString());
                        dropdowns.Items.Add(item);
                    }
                    plhSurveyAnswer.Controls.Add(dropdowns);
                    break;
            }
        }

        protected void NextBtnClick(object sender, EventArgs e)
        {
            switch (question.GetAnswerKind())
            {
                case "text":
                    var answerText = txtAnswer.Text;
                    logic.InsertTextAnswer(answerText);
                    break;

                case "checkbox":
                    var checkboxAnswerIds = checkboxes.Items.Cast<ListItem>()
                                                              .Where(li => li.Selected)
                                                              .Select(li => int.Parse(li.Value))
                                                              .ToList();
                    logic.InsertMultipleAnswers(checkboxAnswerIds);
                    break;

                case "radioButton":
                    int radioAnswerId = int.Parse(radioButtons.SelectedValue);
                    logic.InsertAnswer(radioAnswerId);
                    break;

                case "dropDown":
                    var dropDownAnswerId = int.Parse(dropdowns.SelectedValue);
                    logic.InsertAnswer(dropDownAnswerId);
                    break;
            }

            Response.Redirect("/View/Survey/Survey.aspx");
        }

        protected void SkipButton_Click(object sender, EventArgs e)
        {
            logic.InsertSkippedAnswer();
            Response.Redirect("/View/Survey/Survey.aspx");
        }
    }
}