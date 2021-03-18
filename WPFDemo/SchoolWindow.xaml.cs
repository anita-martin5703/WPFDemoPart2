// Anita Martin
// amartin98@cnm.edu
// Title: WPF Dialogs Demo

// SchoolWindow.xamal.cs

using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for SchoolWindow.xaml
    /// </summary>
    public partial class SchoolWindow : Window
    {
        School school = new School();
        public SchoolWindow()
        {
            InitializeComponent();
            lbCampuses.ItemsSource = school.Campuses;
            lbCourses.ItemsSource = school.Courses;
            lbMajor.ItemsSource = school.Majors;
            lbStudents.ItemsSource = school.Students;

        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            Student newStudent = new Student();
            StudentWindow studentWindow = new StudentWindow(newStudent);
            studentWindow.ShowDialog();

            if (studentWindow.DialogResult == true)
            {
                MessageBox.Show("Student " + newStudent.StudentNumber + " Added!");
                school.Students.Add(newStudent);
                lbStudents.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Dialog Cancelled!");
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == true)
            {
                using (StreamWriter file = new StreamWriter(saveFile.OpenFile()))
                {
                    foreach (var student in school.Students)
                    {
                        file.WriteLine(student.ToString());
                    }
                }
            }

        }
    }
}
