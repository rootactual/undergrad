using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // never put C# code in the page load method
            //   if you are creating a web-based applications
        }
        protected void ClearEntriesButton_Click(object sender, EventArgs e)
        {
            PointsScoredTextBox.Text = String.Empty;
            PossiblePointsTextBox.Text = String.Empty;
            PointsScoredTextBox.Focus();
        }

        protected void AddScoresToListBoxesButton_Click(object sender, EventArgs e)
        {
            if (PointsScoredTextBox.Text == String.Empty)
            {
                PointsScoredTextBox.Focus();
                return;
            }

            if (PossiblePointsTextBox.Text == String.Empty)
            {
                PossiblePointsTextBox.Focus();
                return;
            }

            double score, posP;

            if (!double.TryParse(PointsScoredTextBox.Text, out score))
            {
                PointsScoredTextBox.Text = String.Empty;
                PointsScoredTextBox.Focus();
                return;
            }

            if (!double.TryParse(PossiblePointsTextBox.Text, out posP))
            {
                PossiblePointsTextBox.Text = String.Empty;
                PossiblePointsTextBox.Focus();
                return;
            }

            score = Convert.ToDouble(PointsScoredTextBox.Text);
            posP = Convert.ToDouble(PossiblePointsTextBox.Text);

            if (score < 0 || score > 100)
            {
                PointsScoredTextBox.Text = String.Empty;
                PointsScoredTextBox.Focus();
                return;
            }
            if (posP < 0 || posP > 100)
            {
                PossiblePointsTextBox.Text = String.Empty;
                PossiblePointsTextBox.Focus();
                return;
            }
            if (score > posP)
            {
                PossiblePointsTextBox.Text = String.Empty;
                PointsScoredTextBox.Text = String.Empty;
                PointsScoredTextBox.Focus();
                return;
            }

            else
            {
                ScoreListBox.Items.Insert(0, PointsScoredTextBox.Text);
                PointsListBox.Items.Insert(0, PossiblePointsTextBox.Text);
                string lG;
                double perc;
                perc = ((score / posP) * 100);

                lG = GetLetterGrade(perc);
                GradeListBox.Items.Insert(0, lG);
                PointsScoredTextBox.Text = String.Empty;
                PossiblePointsTextBox.Text = String.Empty;
                PointsScoredTextBox.Focus();
            }
        }
        string GetLetterGrade(double perc)
        {
            if (perc < 59)
            {
                return "F";
            }
            else if (perc >= 60 && perc < 70)
            {
                return "D";
            }
            else if (perc >= 70 && perc < 80)
            {
                return "C";
            }
            else if (perc >= 80 && perc < 90)
            {
                return "B";
            }
            else
            {
                return "A";
            }
        }
        

        protected void CalculateGradeButton_Click(object sender, EventArgs e)
        {
            if (PointsListBox.Items.Count == 0)
            {
                CalculateGradeLabel.Text = ("No grades to calculate");
            }
            else
            {
                double tot;
                string letterGrade;
                tot = CalculateRatio();
                tot = Math.Round(tot, 1);
                letterGrade = GetLetterGrade(tot);
                CalculateGradeLabel.Text = ("Average of " + tot.ToString() + "% for a letter grade of " + letterGrade);
            }
        }

        double CalculateRatio()
        {
            double sco = 0;
            double poss = 0;
            double totPer;
            int ind;
            ind = PointsListBox.Items.Count;
            for (int counter = 0; counter < ind; ++counter)
            {
                ScoreListBox.SelectedIndex = counter;
                PointsListBox.SelectedIndex = counter;
                sco += Convert.ToDouble(ScoreListBox.SelectedItem.ToString());
                poss += Convert.ToDouble(PointsListBox.SelectedItem.ToString());
            }
            totPer = ((sco / poss) * 100);
            return totPer;
        }

        protected void CalculateGradeDroppingLowScoreButton_Click(object sender, EventArgs e)
        {
            if (ScoreListBox.Items.Count <= 1)
            {
                CalculateGradeDroppingLowScoreLabel.Text = ("Not enough entries to drop lowest grade");
            }
            else
            {
                //DID NOT WORK, out of time.

                //double percent, minScore;
                //double lowScore = ScoreListBox.Items.Cast<object>().Select(obj => Convert.ToInt32(obj));
                //double lowPoss = PointsListBox.Items.Cast<object>().Select(obj => Convert.ToInt32(obj));
                //double min = lowScore.Min();

                //double sumScore = 0;
                //double sumPoss = 0;
                //for (int i=0;i<ScoreListBox.Items.Count;++i)
                //{
                //	sumScore += Convert.ToDouble(ScoreListBox.Items[i])
                //}
                //for (int i=0;i<PointsListBox.Items.Count;++i)
                //{
                //	sumPoss += Convert.ToDouble(ScoreListBox.Items[i] - 1)
                //}
                //percent = (((sumScore - minScore)/(sumPoss - lowPoss)) * 100)
                //CalculateGradeDroppingLowScoreLabel.Text = ("Average of " +percent+ "% for a letter grade of " +GetLetterGrade(percent)+ " ");

            }
        }

        protected void ResetFormValuesButton_Click(object sender, EventArgs e)
        {
            FormReset();

        }
        private void FormReset()
        {
            PointsScoredTextBox.Text = String.Empty;
            PossiblePointsTextBox.Text = String.Empty;
            CalculateGradeDroppingLowScoreLabel.Text = String.Empty;
            CalculateGradeLabel.Text = String.Empty;
            ScoreListBox.Items.Clear();
            PointsListBox.Items.Clear();
            GradeListBox.Items.Clear();
            PointsScoredTextBox.Focus();
        }
    }
}