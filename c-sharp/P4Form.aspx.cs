using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project4
{
    public partial class Project4Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DisplayChosenMajorButton_Click(object sender, EventArgs e)
        {
            if (MajorListBox.SelectedIndex == -1)
            {
                MajorListBox.SelectedIndex = 0;
                OutPutLabel.Text = string.Empty;
            }
            string selectedMajor = MajorListBox.SelectedItem.Value;
            OutPutLabel.Text = string.Empty;
            for (int loopCounter = 0; loopCounter < AdvisingDatabaseGridView.Rows.Count; ++loopCounter)
            {
                if (AdvisingDatabaseGridView.Rows[loopCounter].Cells[1].Text == selectedMajor)
                {
                    OutPutLabel.Text +=
                        AdvisingDatabaseGridView.Rows[loopCounter].Cells[0].Text + " -- " +
                        AdvisingDatabaseGridView.Rows[loopCounter].Cells[1].Text + ", " +
                        AdvisingDatabaseGridView.Rows[loopCounter].Cells[2].Text + ", " +
                        AdvisingDatabaseGridView.Rows[loopCounter].Cells[3].Text + " " +
                        AdvisingDatabaseGridView.Rows[loopCounter].Cells[4].Text + "<br />";
                }
            }
        }

        protected void DisplayChosenAdvisorButton_Click(object sender, EventArgs e)
        {
            if (AdvisorListBox.SelectedIndex == -1)
            {
                AdvisorListBox.SelectedIndex = 0;
                OutPutLabel.Text = string.Empty;
            }
            string selectedAdvisor = AdvisorListBox.SelectedItem.Value;
            OutPutLabel.Text = string.Empty;
            for (int loopCounter = 0; loopCounter < AdvisingDatabaseGridView.Rows.Count; ++loopCounter)
            {
                if (AdvisingDatabaseGridView.Rows[loopCounter].Cells[4].Text == selectedAdvisor)
                {
                    OutPutLabel.Text +=
                        AdvisingDatabaseGridView.Rows[loopCounter].Cells[0].Text + " -- " +
                        AdvisingDatabaseGridView.Rows[loopCounter].Cells[1].Text + ", " +
                        AdvisingDatabaseGridView.Rows[loopCounter].Cells[2].Text + ", " +
                        AdvisingDatabaseGridView.Rows[loopCounter].Cells[3].Text + " " +
                        AdvisingDatabaseGridView.Rows[loopCounter].Cells[4].Text + "<br />";
                }
            }
        }
    }
}