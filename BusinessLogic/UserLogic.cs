using AIT_Research.Model;
using AIT_Research.Model.DAO;
using System;
using System.Collections.Generic;
using System.Web;

namespace AIT_Research.Controller
{
    public class UserLogic
    {

        RespondentDAO respondentDAO = new RespondentDAO();
        StaffDAO staffDAO = new StaffDAO();

        public bool StaffLogin(string username, string password)
        {
            var staff = staffDAO.StaffLogin(username, password);
            if (staff != null)
            {
                HttpContext.Current.Session["staff_id"] = staff.Id;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Respondent RespondentExistWithIpAddress()
        {

            var ipAddress = GetUserIPAddress();
            var respondent = respondentDAO.GetRespondent(ipAddress);


            if (respondent != null)
                HttpContext.Current.Session["respondent_id"] = respondent.Id;

            return respondent;
        }


        //check respondent ip address
        public Respondent CheckRespondent()
        {
            var ipAddress = GetUserIPAddress();
            var respondent = respondentDAO.GetRespondent(ipAddress);

            if (respondent == null)
                respondent = respondentDAO.InsertNewRespondent(ipAddress);

            if (respondent != null)
                HttpContext.Current.Session["respondent_id"] = respondent.Id;

            return respondent;
        }

        //register new respondent
        public Respondent RegisterNewRespondent(string givenName, string lastName, DateTime dob, string phoneNumber)
        {
            var ipAddress = GetUserIPAddress();
            var respondent = respondentDAO.InsertNewRegisteredRespondent(givenName, lastName, dob, phoneNumber, ipAddress);

            if (respondent != null)
                HttpContext.Current.Session["respondent_id"] = respondent.Id;

            return respondent;
        }

        //get all respondent data
        public List<Respondent> GetAllRespondents()
        {
            //return list of respondents with basic data
            List<Respondent> respondents = respondentDAO.GetAllRespondentsData();
            
            //for loop to manually get the rest of data from the user answers
            foreach (var res in respondents)
            {
                
                res.AgeGroup = respondentDAO.GetRespondentAgeGroup(res.Id);
                res.Gender = respondentDAO.GetRespondentGender(res.Id);
                res.Email = respondentDAO.GetRespondentEmail(res.Id);
                res.State = respondentDAO.GetRespondentState(res.Id);
                res.PostCode = respondentDAO.GetRespondentPostCode(res.Id);
                res.BankUsed = respondentDAO.GetRespondentBanks(res.Id);
                res.BankService = respondentDAO.GetRespondentBankServices(res.Id);
                res.Newspaper = respondentDAO.GetRespondentNewspapers(res.Id);

                //joing multiple strings
                res.BankUsedString = String.Join(", ", res.BankUsed);
                res.BankServiceString = String.Join(", ", res.BankService);
                res.NewspaperString = String.Join(", ", res.Newspaper);
            }

            return respondents;
        }

        public void RespondentCompletedSurvey()
        {
            //*ignore comment* session = state that is used to store and retrieve values of a user. 
            int respondentId = (int)HttpContext.Current.Session["respondent_id"];
            respondentDAO.RespondentCompletedSurvey(respondentId);
        }


        // retrivied from stackoverflow https://stackoverflow.com/a/740431/13447077
        protected string GetUserIPAddress()
        {
            /* //Please, use this dummy variables code for more than 1 testing, because once the ip address will get recorded
                //It will send you to the surveyEnded Page, code below line 112/113 instead of 116/125
         var random = new Random();
         return $"{random.Next(1, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}";
              */
            //get Ip address

            string ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

         if (!string.IsNullOrEmpty(ipAddress))
        {
             string[] addresses = ipAddress.Split(',');
             if (addresses.Length != 0)
             {
                return addresses[0];
            }
         }

        return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
       
        }
    }
}