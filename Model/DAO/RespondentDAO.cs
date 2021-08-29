using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AIT_Research.Model.DAO
{
    public class RespondentDAO
    {
        SurveyDatabaseDAO db = new SurveyDatabaseDAO();

        public Respondent GetRespondent(string ipAddress)
        {
            // get respondent data from ip address
            Respondent respondent = null;
            db.connection.Open();
            string query = "SELECT * FROM Respondent WHERE respondent_ip_address = @ipAddress";
            //SqlCommand.ExecuteReader Method
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@ipAddress", ipAddress);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                respondent = new Respondent
                {
                    Id = (int)reader["respondent_id"],
                    IsSurveyCompleted = (bool)reader["is_completed"]
                };
            }
            db.connection.Close();

            return respondent;
        }

        public Respondent InsertNewRespondent(string ipAddress)
        { 
            //insert a new anonymous respondent
            Respondent respondent = null;
            db.connection.Open();
            string query = @"INSERT INTO Respondent (respondent_given_name,respondent_ip_address,respondent_record_date) VALUES (@givenName, @ipAddress,getdate());
                             SELECT CAST(scope_identity() AS int)";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@givenName", "Anonymous");
            command.Parameters.AddWithValue("@ipAddress", ipAddress);
            var newId = command.ExecuteScalar();
            respondent = new Respondent()
            {
                Id = (int)newId,
                IsSurveyCompleted = false
            };
            db.connection.Close();

            return respondent;
        }

        public Respondent InsertNewRegisteredRespondent(string givenName, string lastName, DateTime dob, string phoneNumber, string ipAddress)
        {
            //insert a new registred respondent
            Respondent respondent;
            db.connection.Open();
            string query = @"INSERT INTO Respondent (respondent_given_name,respondent_last_name,respondent_dob,respondent_phone,respondent_ip_address,respondent_record_date) 
                             VALUES (@givenName, @lastName, @dob, @phoneNumber, @ipAddress, getdate());
                             SELECT CAST(scope_identity() AS int)";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@givenName", givenName);
            command.Parameters.AddWithValue("@lastName", lastName);
            command.Parameters.AddWithValue("@dob", dob);
            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            command.Parameters.AddWithValue("@ipAddress", ipAddress);
            var newId = command.ExecuteScalar();
            respondent = new Respondent()
            {
                Id = (int)newId,
                GivenName = givenName,
                LastName = lastName,
                DateOfBirth = dob,
                PhoneNumber = phoneNumber,
                IsSurveyCompleted = false
            };
            db.connection.Close();

            return respondent;
        }

        public bool RespondentCompletedSurvey(int respondentId )
        {
            db.connection.Open();
            string query = @"UPDATE Respondent SET is_completed = 1 WHERE respondent_id = @respondentId";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@respondentId", respondentId);
            var rows = command.ExecuteNonQuery();
            db.connection.Close();

            return rows > 0;
        }

        public List<Respondent> GetAllRespondentsData()
        {
            List<Respondent> list = new List<Respondent>();
            db.connection.Open();
            string query = @"SELECT * FROM Respondent";
            SqlCommand command = new SqlCommand(query, db.connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var respondent = new Respondent();
                respondent.Id = (int)reader["respondent_ID"];
                respondent.GivenName = reader["respondent_given_name"].ToString();
                respondent.LastName = reader["respondent_last_name"].ToString();

                // avoid parsing null datetime
                if (!reader.IsDBNull(reader.GetOrdinal("respondent_dob")))
                    respondent.DateOfBirth = Convert.ToDateTime(reader["respondent_dob"]);

                respondent.PhoneNumber = reader["respondent_phone"].ToString();
                respondent.IsSurveyCompleted = (bool)reader["is_completed"];

                list.Add(respondent);
            }
            db.connection.Close();

            return list;
        }

        public string GetRespondentGender(int respondentId)
        {
            //get gender from gender question
            int genderQuestionId = 1;
            string answer = "";

            db.connection.Open();
            string query = @"SELECT SurveyAnswer.answer_description FROM RespondentAnswer LEFT JOIN SurveyAnswer ON RespondentAnswer.answer_ID = SurveyAnswer.answer_ID
                             WHERE RespondentAnswer.respondent_ID = @respondentId
                                AND RespondentAnswer.question_ID = @questionId";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@respondentId", respondentId);
            command.Parameters.AddWithValue("@questionId", genderQuestionId);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                answer = reader["answer_description"].ToString();
            }
            db.connection.Close();

            return answer;
        }

        public string GetRespondentAgeGroup(int respondentId)
        {
            int genderQuestionId = 2;
            string answer = "";
            //get ageGroup from age group question
            db.connection.Open();
            string query = @"SELECT SurveyAnswer.answer_description FROM RespondentAnswer LEFT JOIN SurveyAnswer ON RespondentAnswer.answer_ID = SurveyAnswer.answer_ID
                             WHERE RespondentAnswer.respondent_ID = @respondentId
                                AND RespondentAnswer.question_ID = @questionId";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@respondentId", respondentId);
            command.Parameters.AddWithValue("@questionId", genderQuestionId);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                answer = reader["answer_description"].ToString();
            }
            db.connection.Close();

            return answer;
        }

        public string GetRespondentEmail(int respondentId)
        {
            int questionId = 5;
            string answer = "";
            //get email from email question
            db.connection.Open();
            string query = @"SELECT RespondentAnswer.answer_description FROM RespondentAnswer LEFT JOIN SurveyAnswer ON RespondentAnswer.answer_ID = SurveyAnswer.answer_ID
                             WHERE RespondentAnswer.respondent_ID = @respondentId
                                AND RespondentAnswer.question_ID = @questionId";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@respondentId", respondentId);
            command.Parameters.AddWithValue("@questionId", questionId);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                answer = reader["answer_description"].ToString();
            }
            db.connection.Close();

            return answer;
        }

        public string GetRespondentState(int respondentId)
        {
            int questionId = 3;
            string answer = "";
            //get state from state question
            db.connection.Open();
            string query = @"SELECT SurveyAnswer.answer_description FROM RespondentAnswer LEFT JOIN SurveyAnswer ON RespondentAnswer.answer_ID = SurveyAnswer.answer_ID
                             WHERE RespondentAnswer.respondent_ID = @respondentId
                                AND RespondentAnswer.question_ID = @questionId";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@respondentId", respondentId);
            command.Parameters.AddWithValue("@questionId", questionId);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                answer = reader["answer_description"].ToString();
            }
            db.connection.Close();

            return answer;
        }

        public string GetRespondentPostCode(int respondentId)
        {
            int questionId = 4;
            string answer = "";
            //get postcode from postcode question
            db.connection.Open();
            string query = @"SELECT RespondentAnswer.answer_description FROM RespondentAnswer LEFT JOIN SurveyAnswer ON RespondentAnswer.answer_ID = SurveyAnswer.answer_ID
                             WHERE RespondentAnswer.respondent_ID = @respondentId
                                AND RespondentAnswer.question_ID = @questionId";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@respondentId", respondentId);
            command.Parameters.AddWithValue("@questionId", questionId);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                answer = reader["answer_description"].ToString();
            }
            db.connection.Close();

            return answer;
        }

        public List<string> GetRespondentBanks(int respondentId)
        {
            int questionId = 7;
            //return list of string because is multiple answer, so multiple strings
            List<string> answers = new List<string>();
            //get banks used from bank used question
            db.connection.Open();
            string query = @"SELECT SurveyAnswer.answer_description FROM RespondentAnswer JOIN SurveyAnswer ON RespondentAnswer.answer_ID = SurveyAnswer.answer_ID
                             WHERE RespondentAnswer.respondent_ID = @respondentId
                                AND RespondentAnswer.question_ID = @questionId";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@respondentId", respondentId);
            command.Parameters.AddWithValue("@questionId", questionId);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string answer = reader["answer_description"].ToString();
                answers.Add(answer);
            }
            db.connection.Close();

            return answers;
        }

        public List<string> GetRespondentBankServices(int respondentId)
        {
            int questionId = 8;
            //return list of string because is multiple answer, so multiple strings
            List<string> answers = new List<string>();
            //get bank services used from bank used question
            db.connection.Open();
            string query = @"SELECT SurveyAnswer.answer_description FROM RespondentAnswer JOIN SurveyAnswer ON 
                                     RespondentAnswer.answer_ID = SurveyAnswer.answer_ID
                                     WHERE RespondentAnswer.respondent_ID = @respondentId
                                     AND RespondentAnswer.question_ID = @questionId";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@respondentId", respondentId);
            command.Parameters.AddWithValue("@questionId", questionId);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string answer = reader["answer_description"].ToString();
                answers.Add(answer);
            }
            db.connection.Close();

            return answers;
        }

        public List<string> GetRespondentNewspapers(int respondentId)
        {
            int questionId = 9;
            //return list of string because is multiple answer, so multiple strings
            List<string> answers = new List<string>();
            //get newspaper read from newspaper read question
            db.connection.Open();
            string query = @"SELECT SurveyAnswer.answer_description FROM RespondentAnswer JOIN SurveyAnswer ON 
                                   RespondentAnswer.answer_ID = SurveyAnswer.answer_ID
                                    WHERE RespondentAnswer.respondent_ID = @respondentId
                                    AND RespondentAnswer.question_ID = @questionId";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@respondentId", respondentId);
            command.Parameters.AddWithValue("@questionId", questionId);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string answer = reader["answer_description"].ToString();
                answers.Add(answer);
            }
            db.connection.Close();

            return answers;
        }
    }
}