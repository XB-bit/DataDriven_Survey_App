using AIT_Research.Model;
using AIT_Research.Model.DAO;
using System.Collections.Generic;
using System.Web;

namespace AIT_Research.Controller
{
    public class SurveyLogic
    {
        SurveyDAO surveyDAO = new SurveyDAO();

        //get questions 
        public Question GetQuestion()
        {
            int respondentId = (int)HttpContext.Current.Session["respondent_id"];
            var question = surveyDAO.GetAdditionalQuestion(respondentId);

            if (question == null)
            {
                question = surveyDAO.GetMainQuestion(respondentId);
            }

            if (question != null)
                HttpContext.Current.Session["current_question_id"] = question.Id;
            else
                HttpContext.Current.Session["current_question_id"] = null;

            return question;
        }

        //get answers 
        public List<Answer> GetAnswers(int questionId)
        {
            return surveyDAO.GetAnswers(questionId);
        }

        //insert data in sessions
        public void InsertTextAnswer(string answerText)
        {
            int respondentId = (int)HttpContext.Current.Session["respondent_id"];
            int questionId = (int)HttpContext.Current.Session["current_question_id"];

            surveyDAO.InsertTextAnswer(respondentId, questionId, answerText);
        }

        public void InsertAnswer(int answerId)
        {
            int respondentId = (int)HttpContext.Current.Session["respondent_id"];
            int questionId = (int)HttpContext.Current.Session["current_question_id"];

            surveyDAO.InsertAnswer(respondentId, questionId, answerId);
        }

        public void InsertMultipleAnswers(List<int> answerIds)
        {
            int respondentId = (int)HttpContext.Current.Session["respondent_id"];
            int questionId = (int)HttpContext.Current.Session["current_question_id"];

            surveyDAO.InsertMultipleAnswers(respondentId, questionId, answerIds);
        }

        public void InsertSkippedAnswer()
        {
            int respondentId = (int)HttpContext.Current.Session["respondent_id"];
            int questionId = (int)HttpContext.Current.Session["current_question_id"];

            surveyDAO.InsertSkippedAnswer(respondentId, questionId);
        }
    }
}