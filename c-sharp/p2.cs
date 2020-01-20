using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ***Project2
{
    public partial class Project2*** : Form
    {
        public Project2***()
        {
            InitializeComponent();
        }

        private void SavingsAtRetirementButton_Click(object sender, EventArgs e)
        {
            if (CurrentAgeTextBox.Text == String.Empty)
            {
                MessageBox.Show("Please enter a value in Current Age.");
                CurrentAgeTextBox.Text = String.Empty;
                CurrentAgeTextBox.Focus();
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(CurrentAgeTextBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers for Current Age.");
                CurrentAgeTextBox.Text = String.Empty;
                CurrentAgeTextBox.Focus();
            }
            else if (Convert.ToInt32(CurrentAgeTextBox.Text) < 18 || Convert.ToInt32(CurrentAgeTextBox.Text) > 75)
            {
                MessageBox.Show("Age entered must from 18 to 75 years of age.");
                CurrentAgeTextBox.Text = String.Empty;
                CurrentAgeTextBox.Focus();
            }
            else if (RetirementAgeTextBox.Text == String.Empty)
            {
                MessageBox.Show("Please enter a value in Retirement Age.");
                RetirementAgeTextBox.Text = String.Empty;
                RetirementAgeTextBox.Focus();
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(RetirementAgeTextBox.Text, "[^0-9]")) // I don't like tryparse.
            {
                MessageBox.Show("Please enter only numbers in Retirement Age.");
                RetirementAgeTextBox.Text = String.Empty;
                RetirementAgeTextBox.Focus();
            }
            else if (Convert.ToInt32(RetirementAgeTextBox.Text) < 62 || Convert.ToInt32(RetirementAgeTextBox.Text) > 76)
            {
                MessageBox.Show("Retirement age entered must be from 62 to 76 years of age.");
                RetirementAgeTextBox.Text = String.Empty;
                RetirementAgeTextBox.Focus();
            }
            else if ((Convert.ToDouble(RetirementAgeTextBox.Text) <= (Convert.ToDouble(CurrentAgeTextBox.Text))))
            {
                MessageBox.Show("Retirement age must be greater than current age.");
                RetirementAgeTextBox.Text = String.Empty;
                RetirementAgeTextBox.Focus();
            }
            else
            {
                double selectedAmount, selectedInt;
                double totalAmount = 0;
                selectedAmount = Convert.ToDouble(AmountSavedListBox.SelectedItem);
                selectedInt = Convert.ToDouble(InterestRateListBox.SelectedItem);
                int beginAge, endAge;
                beginAge = Convert.ToInt32(CurrentAgeTextBox.Text);
                endAge = Convert.ToInt32(RetirementAgeTextBox.Text);
                int loopCounter;

                for (loopCounter = beginAge; loopCounter < endAge; ++loopCounter)
                {
                    totalAmount = (totalAmount + selectedAmount) * (1 + selectedInt);
                }
                SavingsAtRetirementLabel.Text = "After " +(endAge - beginAge)+ " years, saving " +selectedAmount.ToString("C2")+ " per year at " +selectedInt+ "% you will have " +totalAmount.ToString("C2") + ".";
            }
        }

        private void ToRetirementTargetButton_Click(object sender, EventArgs e)
        {
            if (RetirementAmountTextBox.Text == String.Empty)
            {
                MessageBox.Show("Please enter a value desired for retirement.");
                RetirementAmountTextBox.Text = String.Empty;
                RetirementAmountTextBox.Focus();
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(RetirementAmountTextBox.Text, "[^0-9]")) // I don't like tryparse.
            {
                MessageBox.Show("Please enter only numbers for.");
                RetirementAmountTextBox.Text = String.Empty;
                RetirementAmountTextBox.Focus();
            }
            else
            {
                double selectedInt, selectedAmt;
                double totalAmount = 0;
                selectedAmt = Convert.ToDouble(AmountSavedListBox.SelectedItem);
                selectedInt = Convert.ToDouble(InterestRateListBox.SelectedItem);
                double targetAmount;
                targetAmount = Convert.ToDouble(RetirementAmountTextBox.Text);
                int yearsSave = 0;

                while (totalAmount < targetAmount)
                {
                    totalAmount = ((totalAmount + selectedAmt) * (1 + selectedInt));
                    yearsSave += 1;
                }
            
                RetrieveTargetLabel.Text = totalAmount.ToString("C2")+ " reached in " +yearsSave+ " years.";
            }
        }

        private void Project2***_Load(object sender, EventArgs e)
        {
            AmountSavedListBox.SelectedIndex = 1;
            InterestRateListBox.SelectedIndex = 4;
        }

        private void CurrentAgeTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
