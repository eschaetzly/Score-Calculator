using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ScoreCalculator
{
    public partial class frmScoreCalculator : Form
    {
        //Creates Array of 20 integers
        int[] intSCarray = new int[20];
        int scoreCount = 0;


        public frmScoreCalculator()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Sets to zero
            int intScore = 0;

            //Takes user input and stores it into an integer
            Int32.TryParse(txtScore.Text, out intScore);

            //stores user input into the array
            intSCarray[scoreCount] = intScore;

            scoreCount++;

            //Displays all
            txtScoreTotal.ToString();
            txtScoreCount.Text = scoreCount.ToString();
            txtScore.Focus();
            txtScore.SelectAll();
            txtAverage.Text = intSCarray.Where(v => v > 0).Average(v => v).ToString();
            txtScoreTotal.Text = intSCarray.Where(v => v > 0).Sum(v => v).ToString();

        }

        //clears all fields when "clear" is pressed
        private void btnClearScores_Click(object sender, EventArgs e)
        {
            this.txtScore.Clear();
            this.txtScoreCount.Clear();
            this.txtAverage.Clear();
            this.txtScoreTotal.Clear();
            this.scoreCount = 0;
            this.intSCarray = new int[20];


            txtScore.Focus();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Creates the "sorted scores" dialog box and displays the array
        private void btnDisplayScores_Click(object sender, EventArgs e)
        {
            /*Had an issue that would display the remaining spaces in the array as zero
            this fixes it
            */

            int[] nonZeroData = intSCarray.Where(v => v > 0).ToArray();

            Array.Sort(nonZeroData);

            string numbersString = "";

            for (int i = 0; i < nonZeroData.Length; i++)
            {
                numbersString += nonZeroData[i] + "\n";
            }

            MessageBox.Show(numbersString, "Sorted Scores");
        }
    }
}
