// Anita Martin
// amartin98@cnm.edu
// Title: WPF Dialogs Demo
// Objectives:
//      - Demonstrate how to use WPF Message Boxes.
//      - Demonstrate how to use WPF file dialogs.
//      - Demonstrate how to create a custom dialog.


// StudentWindows.xaml.cs

using System.Collections.Generic;
using System.Windows;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        private Student student;
        public Student Student
        {
            get { return student; }
            set { student = value; }
        }

        public StudentWindow() : this(new Student())
        {
        }

        public StudentWindow(Student st)
        {
            InitializeComponent();
            this.student = st;
        }


        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //Instantiate a class object
            //Student st = new Student();

            //Set the values from our controls into the class
            student.FirstName = txbFirstName.Text;
            student.LastName = txbLastName.Text;
            student.StudentNumber = txbStudentNum.Text;
            student.Major = txbMajor.Text;

            List<Assignment> scores = new List<Assignment>();
            foreach (Assignment score in lbScores.Items)
            {
                scores.Add(score);
            }
            student.Scores = scores;

            //Set the results from the class into a control on the form
            txbResults.Text = student.ToString();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Assignment assign = new Assignment();
            assign.Title = txbTitle.Text;
            assign.Score = int.Parse(txbScore.Text);
            lbScores.Items.Add(assign);
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
