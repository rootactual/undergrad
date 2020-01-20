using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlsonProject1
{
    public partial class Project1Form : Form
    {
        public Project1Form()
        {
            InitializeComponent();
        }

        private void HasAValueBeenEnteredButton_Click(object sender, EventArgs e)
        {
            if (EnterAValueTextBox.Text == String.Empty)
            {
                MessageBox.Show("Go back and enter a value...");
                EnterAValueTextBox.Text = String.Empty;
                EnterAValueTextBox.Focus();
                return;
            }
            else
            {
                HasAValueBeenEnteredLabel.Text = "Yes!";
            }
        }

        private void IsTheValueTheLetterAButton_Click(object sender, EventArgs e)
        {
            if (EnterAValueTextBox.Text == String.Empty)
            {
                MessageBox.Show("Go back and enter a value...");
                EnterAValueTextBox.Text = "";
                EnterAValueTextBox.Focus();
                return;
            }
            else if (EnterAValueTextBox.Text == "A" || EnterAValueTextBox.Text == "a")
            {
                IsTheValueTheLetterALabel.Text = "Yes.";
            }
            else
            {
                IsTheValueTheLetterALabel.Text = "No.";
            }
        }

        private void IsTheValueANumberButton_Click(object sender, EventArgs e)
        {
            double isDouble;
            if (EnterAValueTextBox.Text == String.Empty)
            {
                MessageBox.Show("Go back and enter a value...");
                EnterAValueTextBox.Text = "";
                EnterAValueTextBox.Focus();
                return;
            }
            else if (Double.TryParse(EnterAValueTextBox.Text, out isDouble))
            {
                IsTheValueANumberLabel.Text = "Yes.";
            }
            else
            {
                IsTheValueANumberLabel.Text = "No.";

            }
        }

        private void IsTheValueANumberAndBetweenButton_Click(object sender, EventArgs e)
        {
            double isDouble2;
            if (Double.TryParse(EnterAValueTextBox.Text, out isDouble2))
            {
                if (isDouble2 >= 1 && isDouble2 <= 10)
                    IsTheValueANumberAndBetweenLabel.Text = "Yes.";
                else
                    IsTheValueANumberAndBetweenLabel.Text = "No.";
            }
        }
    }
}
