using AIT_Research.Controller;
using System;
using System.Collections.Generic;

namespace AIT_Research.View.Respondent
{
    public partial class RespSearchPage : System.Web.UI.Page
    {
        UserLogic logic = new UserLogic();
        List<Model.Respondent> respondentList;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if is loading for the first time
            if (!IsPostBack)
            {
                //get all respondents in DB
                respondentList = logic.GetAllRespondents();
                //grid view 
                grvRespondent.DataSource = respondentList;
                //refresh the list with the new data source
                grvRespondent.DataBind();
            }
        }

        //ButtonSearch_Click = Search Button
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            //return all respondent data
            respondentList = logic.GetAllRespondents();
            //put in filteredRespondent list
            List<Model.Respondent> filteredRespondent = new List<Model.Respondent>();

            foreach (var res in respondentList)
            {
                // Continue loop if one criteria doesn't match
                if (!res.GivenName.ToLower().Contains(txtFirstName.Text.ToLower())) continue;
                if (!res.LastName.ToLower().Contains(txtLastName.Text.ToLower())) continue;
                if (!res.Email.ToLower().Contains(txtEmail.Text.ToLower())) continue;
                if (!res.PostCode.ToLower().Contains(txtPostCode.Text.ToLower())) continue;
                if (!res.State.ToLower().Contains(txtState.Text.ToLower())) continue;
                if (!res.BankUsedString.ToLower().Contains(txtBanks.Text.ToLower())) continue;
                if (!res.BankServiceString.ToLower().Contains(txtBankService.Text.ToLower())) continue;
                if (!res.NewspaperString.ToLower().Contains(txtNewspaper.Text.ToLower())) continue;

                // Check if gender matched with selection
                bool matchGender = false;
                if (!cbMale.Checked && !cbFemale.Checked && !cbOther.Checked)
                    matchGender = true;
                else if (cbMale.Checked && res.Gender.ToLower() == cbMale.Text.ToLower())
                    matchGender = true;
                else if (cbFemale.Checked && res.Gender.ToLower() == cbFemale.Text.ToLower())
                    matchGender = true;
                else if (cbOther.Checked && res.Gender.ToLower() == cbOther.Text.ToLower())
                    matchGender = true;

                if (!matchGender) continue;


                // Check if age group matched with selection
                bool matchAgeGroup = false;
                if (!cbU16.Checked && !cb16to25.Checked && !cb26to45.Checked && !cb46to65.Checked && !cbA65.Checked)
                    matchAgeGroup = true;
                else if (cbU16.Checked && res.AgeGroup.ToLower() == cbU16.Text.ToLower())
                    matchAgeGroup = true;
                else if (cb16to25.Checked && res.AgeGroup.ToLower() == cb16to25.Text.ToLower())
                    matchAgeGroup = true;
                else if (cb26to45.Checked && res.AgeGroup.ToLower() == cb26to45.Text.ToLower())
                    matchAgeGroup = true;
                else if (cb46to65.Checked && res.AgeGroup.ToLower() == cb46to65.Text.ToLower())
                    matchAgeGroup = true;
                else if (cbA65.Checked && res.AgeGroup.ToLower() == cbA65.Text.ToLower())
                    matchAgeGroup = true;

                if (!matchAgeGroup) continue;

                // If pass all conditions, respondent will be added to the list to display to the user
                filteredRespondent.Add(res);
            }

            //populate grid view with the filteredRespondent
            grvRespondent.DataSource = filteredRespondent;
            //refresh the list with the new data source
            grvRespondent.DataBind();
        }
    }
}