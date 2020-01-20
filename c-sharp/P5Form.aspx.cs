using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Project5
{
    public partial class Project5Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // stateless webpages, avoid reload
        }

        protected void BeginButton_Click(object sender, EventArgs e)
        {
            
            DateTime currentDateTime = new DateTime();
            currentDateTime = DateTime.Now;
            DateTimeLabel.Text = currentDateTime.ToShortDateString() + " at " + currentDateTime.ToShortTimeString();

            AdvisorsListBox.Items.Clear(); //clear the listbox out
            string readOneLine;
            FileStream inFile = new FileStream(@"C:\Users\jlo5956\Desktop\Advisors.txt", FileMode.Open, FileAccess.Read);
            StreamReader recordsInFile = new StreamReader(inFile);
            readOneLine = recordsInFile.ReadLine();
            while (readOneLine != null)
            {
                AdvisorsListBox.Items.Add(readOneLine);
                readOneLine = recordsInFile.ReadLine();
            }
            recordsInFile.Close();
            inFile.Close();
            CoursesListBox.Items.Clear();
            string course;
            bool found;
            for (int loopCounter = 0; loopCounter < CoursesGridView.Rows.Count; ++loopCounter)
            {
                course = CoursesGridView.Rows[loopCounter].Cells[0].Text.Substring(0, 7);
                found = false;
                for (int innerLoop = 0; innerLoop < CoursesListBox.Items.Count; ++innerLoop)
                {
                    CoursesListBox.SelectedIndex = innerLoop;
                    if (CoursesListBox.SelectedItem.Value == course)
                    { found = true; }
                }
                if (found == false)
                {
                    CoursesListBox.Items.Add(course);
                }
            }
        }
        protected void RegistrarLinkButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.uncw.edu/reg");
        }
        protected void CoursesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdvisorsListBox.SelectedIndex = -1;
            if (CoursesListBox.SelectedIndex != -1)
            {
                OutputLabel.Text = String.Empty;
                for (int loopCounter = 0; loopCounter < CoursesGridView.Rows.Count; ++loopCounter)
                {
                    if (CoursesListBox.SelectedValue == CoursesGridView.Rows[loopCounter].Cells[0].Text.Substring(0, 7))
                    {
                        OutputLabel.Text += CoursesGridView.Rows[loopCounter].Cells[0].Text + " -- " + CoursesGridView.Rows[loopCounter].Cells[1].Text + " -- " +
                            CoursesGridView.Rows[loopCounter].Cells[2].Text + " -- " +
                            CoursesGridView.Rows[loopCounter].Cells[3].Text + " -- " +
                            CoursesGridView.Rows[loopCounter].Cells[4].Text + " -- " +
                            CoursesGridView.Rows[loopCounter].Cells[5].Text + " -- " +
                            CoursesGridView.Rows[loopCounter].Cells[6].Text + "<br />";
                    }
                }
            }
        }


    }
}