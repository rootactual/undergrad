using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraCredit
{
    public partial class ExtraCreditForm : Form
    {
        public ExtraCreditForm()
        {
            InitializeComponent();
        }

        private void ExtraCreditForm_Load(object sender, EventArgs e)
        {
            // use the object named Ramdom to create random integers
            Random randomNumber = new Random();
            int numberOfItems, itemValue, loopCounter;
            // 1st parameter is the lowest integer value, 2nd parameter is the highest integer value plus 1
            numberOfItems = randomNumber.Next(100, 1001);
            // 1st loop parameter is a starting value for iterations
            // 2nd loop parameter is to continue looping until a stopping condition is met
            // 3rd loop parameter is to change the increment so that the new value can be tested against
            //      the stopping condition
            for (loopCounter = 1; loopCounter <= numberOfItems; ++loopCounter)
            {
                itemValue = randomNumber.Next(1, 1001);
                // add radomly generated numbers to the listbox
                ListOfNumbersListBox.Items.Add(itemValue.ToString());
            }
        }

        private void CalculateAverageButton_Click(object sender, EventArgs e)
        {
            decimal sum, averageJoe;
            sum = ListOfNumbersListBox.Items.OfType<object>().Sum(x => Convert.ToDecimal(x));
            averageJoe = sum / Convert.ToDecimal(ListOfNumbersListBox.Items.Count);
            CalculateAverageLabel.Text = averageJoe.ToString("F2");
            //The 'for' loop was good while it lasted.  All hail, LINQ!
        }
        private void RollDiceUntilAMatchIsFoundButton_Click(object sender, EventArgs e)
        {
            Random diOne = new Random();
            int itemValue1, itemValue2;
            itemValue1 = diOne.Next(1, 7);
            
            itemValue2 = diOne.Next(1, 7);
            double totalAmount = 0;
            int numberOfRolls = 0;
            while (itemValue1 != itemValue2)
            {
                itemValue1 = diOne.Next(1, 7);
                itemValue2 = diOne.Next(1, 7);
                numberOfRolls += 1;
                totalAmount = (totalAmount + numberOfRolls);
                //Verbatim code does not equate to 100% accuracy of itemValue1 and itemValue2 on return.
                //How? System time for Random()? LoA just over .5 for return of same/same values
                //Research Random() with Next parameters through terminal results.
            }
            TwoLabel.Text = itemValue2.ToString();
            OneLabel.Text = itemValue1.ToString();
            RollDiceUntilAMatchIsFoundLabel.Text = totalAmount.ToString("N0");

        }
    }
}
