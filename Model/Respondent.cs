using System;
using System.Collections.Generic;

namespace AIT_Research.Model
{
    public class Respondent
    {      
        //getters and setters
        public int Id { get; set; }
        public string GivenName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string AgeGroup { get; set; }
        public bool IsSurveyCompleted { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public List<string> BankUsed { get; set; }
        public List<string> BankService { get; set; }
        public List<string> Newspaper { get; set; }
        public string BankUsedString { get; set; }
        public string BankServiceString { get; set; }
        public string NewspaperString { get; set; }

    }
}