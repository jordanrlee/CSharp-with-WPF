/*******************************************************
 *  Assignment 3 - Assignment Scores                   *
 *  By: Jordan Lee                                     *
 *  Date: 2/10/2022                                    *
 *  CS-3280                                            *
 *******************************************************/



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3_JRL
{
    public partial class Form1 : Form
    {
        #region Attributes

        /// <summary>
        /// one dimension array of student names
        /// </summary>
        private string[] StudentArr;
        /// <summary>
        /// multi-deminsional array of studentScores
        /// </summary>
        private double[,] AssignmentArr;
        /// <summary>
        /// counter for student array
        /// </summary>
        private static int studentArrCounter = 1;
        /// <summary>
        /// counter for assignment array
        /// </summary>
        private static int assignmentArrCounter = 1;
        #endregion Attributes

        #region Methods
        public Form1()
        {
            InitializeComponent();
            // hide the display score button until Submit Count is clicked
            displayScoreBtn.Visible = false;
            // hide 
            firstStudentBtn.Visible = false;
            nextStudentBtn.Visible = false;
            prevStudentBtn.Visible = false;
            lastStudentBtn.Visible = false;
            saveNameBtn.Visible = false;
            saveScoreBtn.Visible = false;
            // display the hint label
            labelHint.Visible = true;
        }

        /// <summary>
        /// Error handing & validation for the number of students and/or assignments. Including the min/max.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitCountBtn_Click(object sender, EventArgs e)
        {
            // validate number entered from the user, if incorrect, display error label
            if (!Int32.TryParse(tBoxNStudents.Text, out int temp1) || temp1 < 1 || temp1 > 10)
            {
                // reveal the error label
                errLabel1.Visible = true;
            }
            // if the entry is valid
            else if (Int32.TryParse(tBoxNStudents.Text, out int temp2) && temp2 > 0 && temp2 < 11)
            {

                // create a single dimension array for student
                StudentArr = new string[temp2];
                // store names into the student array
                defaultNames(StudentArr);
                // change the label for the student number to reflect the student
                label3.Text = "Student #" + studentArrCounter;


                // next, validate the number entered from the user for number of assignments
                // if incorrect, display error label.
                if (!Int32.TryParse(tBoxNAssignments.Text, out int temp3) || temp3 < 1 || temp3 > 99)
                {
                    // reveal the error label
                    errLabel2.Visible = true;
                }
                // if the entry was valid
                else if (Int32.TryParse(tBoxNAssignments.Text, out int temp4) && temp4 > 0 && temp4 < 100)
                {
                    // reveal the display score button when Submit Count is clicked
                    displayScoreBtn.Visible = true;
                    // reveal the rest buttons on the GUI and hide the hint label
                    firstStudentBtn.Visible = true;
                    nextStudentBtn.Visible = true;
                    prevStudentBtn.Visible = true;
                    lastStudentBtn.Visible = true;
                    saveNameBtn.Visible = true;
                    saveScoreBtn.Visible = true;
                    labelHint.Visible = false;
                    // create the multi-dimentional array for assignments using the number of students
                    AssignmentArr = new double[temp2, temp4];
                    // store the default scores into the assignment array
                    defaultScores(AssignmentArr);
                    // change the label for assignments with the new amount entered by the user
                    // student number
                    label3.Text = "Student #" + studentArrCounter; 
                    // assignment number
                    label4.Text = "Enter Assignment Number (1-" + temp4 + ")"; 
                }
            }
        }
        /// <summary>
        /// create various default name for student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void defaultNames(string[] arr)
        {
            // use the element length
            for (int i = 0; i < arr.Length; i++)
            {
                // use this structure for the name assignment and increment
                arr[i] = "Student #" + (i + 1);
            }
        }
        /// <summary>
        /// set a default score inside the array using zero as the default value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void defaultScores(double[,] arr)
        {
            // rows
            for (int rows = 0; rows < arr.GetLength(0); rows++)
            {
                // columns
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    // assign zero
                    arr[rows, col] = 0;
                }
            }
        }

        /// <summary>
        /// hide the error label when the user clicks the text for Number of Students
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tBoxNStudents_MouseClick(object sender, MouseEventArgs e)
        {
            // hide the error label
            errLabel1.Visible = false;
        }
        /// <summary>
        /// hide the error label when the user clicks the text for Number of Assignments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tBoxNAssignments_TextChanged(object sender, EventArgs e)
        {
            // hide the error label
            errLabel2.Visible = false;
        }
        /// <summary>
        /// go to the very first student in the array
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void firstStudentBtn_Click(object sender, EventArgs e)
        {
            studentArrCounter = 1;
            label3.Text = "Student #" + studentArrCounter;
            tBoxStudentInfo.Text = StudentArr[studentArrCounter - 1];
        }
        /// <summary>
        /// go to the previous student in the array (based upon position in array)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prevStudentBtn_Click(object sender, EventArgs e)
        {
            if(studentArrCounter > 1)
            {
                --studentArrCounter;
                label3.Text = "Student #" + studentArrCounter;
                tBoxStudentInfo.Text = StudentArr[studentArrCounter - 1];
            }
        }
        /// <summary>
        /// go to the next student in the array (based upon position in the array)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextStudentBtn_Click(object sender, EventArgs e)
        {
            ++studentArrCounter;
            label3.Text = "Student #" + studentArrCounter;
            tBoxStudentInfo.Text = StudentArr[studentArrCounter - 1];
        }
        /// <summary>
        /// go to the very last student in the array
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lastStudentBtn_Click(object sender, EventArgs e)
        {
            studentArrCounter = StudentArr.Length;
            label3.Text = "Student #" + studentArrCounter;
            tBoxStudentInfo.Text = StudentArr[studentArrCounter - 1];
        }
        /// <summary>
        /// save the student name and put it into the Student Array
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveNameBtn_Click(object sender, EventArgs e)
        {
            // store the text box value entered
            StudentArr[studentArrCounter - 1] = tBoxStudentInfo.Text;
        }
        /// <summary>
        /// display the results of the student scores with error handling by using a stringbuilder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void displayScoreBtn_Click(object sender, EventArgs e)
        {


            // use the functionality of stringBuilder and create an object
            StringBuilder results = new StringBuilder();
            // reset the counters back to a default value
            studentArrCounter = 1;
            assignmentArrCounter = 1;
            // create some formatting the student name
            results.Append("Student Name\t\t"); // create the spacing
            // create some formatting for the assignment number
            // use a loop
            for (int i = 0; i < AssignmentArr.GetLength(1); i++)
            {
                
                results.Append("#" + assignmentArrCounter + "\t"); // create the spacing
                assignmentArrCounter++; // increment
            }
            // create some formatting for average grade
            results.Append("Average\tGrade");
            // next line matching formatting
            results.Append(Environment.NewLine);
            // student names and student score per assignment (rows) using a loop
            for (int i = 0; i < AssignmentArr.GetLength(0); i++)
            {
                results.Append(StudentArr[studentArrCounter - 1] + "\t\t");
                studentArrCounter++; // increment
                // create an average variable
                Double average = 0;
                for (int j = 0; j < AssignmentArr.GetLength(1); j++)
                {
                    results.Append(AssignmentArr[i, j] + "\t");
                    average += AssignmentArr[i, j]; // calculate sum
                }
                // calculate the average (SUM / total numbers)
                average = average / AssignmentArr.GetLength(1);

                // determine which grade is assigned based upon the average
                // create a string variable
                string grade;
                // if the average is 93 or above assign A
                if (average >= 93)
                {
                    grade = "A";
                }
                // if the grade is between 90 and 92.9 assign A-
                else if (average >= 90 && average < 92.9)
                {
                    grade = "A-";
                }
                // if the grade is between 87 and 89.9 assign B+
                else if (average >= 87 && average < 89.9)
                {
                    grade = "B+";
                }
                // if the grade is between 83 and 86.9 assign B
                else if (average >= 83 && average < 86.9)
                {
                    grade = "B";
                }
                // if the grade is between 80 and 82.9 assign B-
                else if (average >= 80 && average < 82.9)
                {
                    grade = "B-";
                }
                // if the grade is between 77 and 79.9 assign C+
                else if (average >= 77 && average < 79.9)
                {
                    grade = "C+";
                }
                // if the grade is between 73 and 76.9 assign C
                else if (average >= 73 && average < 76.9)
                {
                    grade = "C";
                }
                // if the grade is between 70 and 72.9 assign C-
                else if (average >= 70 && average < 72.9)
                {
                    grade = "C-";
                }
                // if the grade is between 67 and 69.9 assign D+
                else if (average >= 67 && average < 69.9)
                {
                    grade = "D+";
                }
                // if the grade is between 63 and 66.9 assign D
                else if (average >= 63 && average < 66.9)
                {
                    grade = "D";
                }
                // if the grade is between 60 and 62.9 assign D-
                else if (average >= 60 && average < 62.9)
                {
                    grade = "D-";
                }
                // else the grade must be E and below 60
                else
                    grade = "E";
                // display the finalized average and letter grade
                results.Append(average + "\t" + grade + "\t" + Environment.NewLine);
            }
            // place calculations into the rich Text Box
            richTextBox1.Text = results.ToString();
            // set values to student 1 after clicking the display score button
            studentArrCounter = 1;
            label3.Text = "Student #" + studentArrCounter;
            tBoxStudentInfo.Text = StudentArr[studentArrCounter - 1];
        }
        /// <summary>
        /// allow the user to save an entered score into the array
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveScoreBtn_Click(object sender, EventArgs e)
        {
            // if the entry is incorrect
            if (!Int32.TryParse(tBoxAssignmentNum.Text, out int temp1) || temp1 < 1 || temp1 > AssignmentArr.GetLength(1))
            {
                // error message with a variable length for array. (A number between 1 and ___)
                errLabel3.Visible = true;
                errLabel3.Text = "Please enter a valid Number (1-" + AssignmentArr.GetLength(1) + ")";
            }
            // if the entry is valid
            else if (Int32.TryParse(tBoxAssignmentNum.Text, out int temp2) && temp2 >= 1 && temp2 <= AssignmentArr.GetLength(1))
            {
                // validate the user entry for validity
                // if incorrect, display the error label
                if (!Double.TryParse(tBoxAssignmentScore.Text, out double temp3) || temp3 < 0 || temp3 > 100)
                {
                    errLabel4.Visible = true;
                }
                // if the value entered from the user is valid
                else if (Double.TryParse(tBoxAssignmentScore.Text, out double temp4) && temp4 >= 0 && temp3 <= 100)
                {
                    // hide the error label
                    errLabel4.Visible = false;
                    // convert the entered score from a string (text box) into the score type
                    //Int32.TryParse(tBoxAssignmentScore.Text, out int score);

                    // instructor advised code
                    Double.TryParse(tBoxAssignmentScore.Text, out double score);

                    // place score into the array at the appropriate position
                    AssignmentArr[studentArrCounter - 1, temp2 - 1] = score;
                }
            }
        }

        private void tBoxAssignmentScore_TextChanged(object sender, EventArgs e)
        {
            
            if (!Int32.TryParse(tBoxAssignmentScore.Text, out int temp4) || temp4 < 1 || temp4 > AssignmentArr.GetLength(1))
            {
                errLabel4.Visible = false;
            }
        }
        /// <summary>
        /// Reset the entire app and create a default version
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetScoreBtn_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Dispose(false);
        }

        private void tBoxAssignmentNum_TextChanged(object sender, EventArgs e)
        {
            errLabel3.Visible = false;
        }
    }
    #endregion Methods
}// end Assignment 3 code
