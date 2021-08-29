using System.Collections.Generic;
using System.Data.SqlClient;

namespace AIT_Research.Model.DAO
{
    public class SurveyDAO
    {
        SurveyDatabaseDAO db = new SurveyDatabaseDAO();

        public Question GetAdditionalQuestion(int respondentId)
        {
            Question question = null;
            db.connection.Open();
            //get next additonal question that haven't been answered by the respondent
            string query = @"select TOP 1 survQ.* FROM SurveyQuestion AS survQ
                                 JOIN SurveyAnswer AS survAns ON survQ.question_ID = survAns.next_question_ID
                                 JOIN RespondentAnswer AS respAns ON respAns.answer_ID = survAns.answer_ID
                                 LEFT JOIN RespondentAnswer resQ ON survQ.question_ID = survQ.question_ID
                                 WHERE respAns.respondent_ID = @respondentId AND survQ.question_ID NOT IN
                                (SELECT question_ID FROM RespondentAnswer WHERE respondent_ID = @respondentId)
                                 ORDER BY survQ.question_ID";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@respondentId", respondentId);
            SqlDataReader reader = command.ExecuteReader(); 
            if (reader.Read())
            {
                question = new Question();
                question.Id = (int)reader["question_ID"];
                question.Id = (int)reader["question_ID"];
                question.Content = reader["question_description"].ToString();
                question.IsAdditionalQuestion = (bool)reader["additional_question"];
                question.AnswerKindID = (int)reader["question_type_ID"];

            }
            db.connection.Close();

            return question;
        }

        public Question GetMainQuestion(int respondentId)
        {
            Question question = null;
            db.connection.Open();
            // Get first main question that haven't been answered by the respondent
            string query = @"select TOP 1 * FROM SurveyQuestion survQ
                                LEFT JOIN RespondentAnswer respA ON survQ.question_ID = respA .question_ID
                                 WHERE additional_question = 0 AND survQ.question_ID NOT IN 
                                (SELECT question_ID FROM RespondentAnswer WHERE respondent_ID = @respondentId)
                                 ORDER BY survQ.question_ID";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@respondentId", respondentId);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                question = new Question();
                question.Id = (int)reader["question_ID"];
                question.Content = reader["question_description"].ToString();
                question. IsAdditionalQuestion = (bool)reader["additional_question"];
                question.AnswerKindID = (int)reader["question_type_ID"];
                
            }
            db.connection.Close();

            return question;
        }

        public List<Answer> GetAnswers(int questionId)
        {
            db.connection.Open();
            //Get answers for question ID
            List<Answer> answers = new List<Answer>();
            string query = "select * FROM SurveyAnswer WHERE question_ID = @questionId";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@questionId", questionId);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var answer = new Answer();
                answer.Id = (int)reader["answer_ID"];
                answer.Content = reader["answer_description"].ToString();
                answers.Add(answer);
            }
            db.connection.Close();

            return answers;
        }

        public bool InsertTextAnswer(int respondentId, int questionId, string answerText)
        {
            db.connection.Open();
            //Insert Text answer for respondent ID
            string query = @"INSERT INTO RespondentAnswer (respondent_ID, question_ID, answer_description)
                             VALUES (@respondentId, @questionId, @answerText)";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@respondentId", respondentId);
            command.Parameters.AddWithValue("@questionId", questionId);
            command.Parameters.AddWithValue("@answerText", answerText);
            var rows = command.ExecuteNonQuery();
            db.connection.Close();

            return rows > 0;
        }

        public bool InsertAnswer(int respondentId, int questionId, int answerId)
        {
            db.connection.Open();
            //Insert single answer for respondend ID
            string query = @"INSERT INTO RespondentAnswer (respondent_ID, question_ID, answer_ID)
                             VALUES (@respondentId, @questionId, @answerId)";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@respondentId", respondentId);
            command.Parameters.AddWithValue("@questionId", questionId);
            command.Parameters.AddWithValue("@answerId", answerId);
            var rows = command.ExecuteNonQuery();
            db.connection.Close();

            return rows > 0;
        }

        public bool InsertMultipleAnswers(int respondentId, int questionId, List<int> answerIds)
        {
            db.connection.Open();
            //Insert multiple answer for respondend ID
            var rows = 0;
            foreach (var answerId in answerIds)
            {
                string query = @"INSERT INTO RespondentAnswer (respondent_ID, question_ID, answer_ID)
                                 VALUES (@respondentId, @questionId, @answerId)";
                SqlCommand command = new SqlCommand(query, db.connection);
                command.Parameters.AddWithValue("@respondentId", respondentId);
                command.Parameters.AddWithValue("@questionId", questionId);
                command.Parameters.AddWithValue("@answerId", answerId);
                rows += command.ExecuteNonQuery();
            }
            db.connection.Close();

            return rows > 0;
        }

        public bool InsertSkippedAnswer(int respondentId, int questionId)
        {
            db.connection.Open();
            //Turn on the  skip flag to 'true'
            string query = @"INSERT INTO RespondentAnswer (respondent_ID, question_ID, skipped)
                             VALUES (@respondentId, @questionId, @isSkipped)";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@respondentId", respondentId);
            command.Parameters.AddWithValue("@questionId", questionId);
            command.Parameters.AddWithValue("@isSkipped", true);
            var rows = command.ExecuteNonQuery();
            db.connection.Close();

            return rows > 0;
        }
    }
}