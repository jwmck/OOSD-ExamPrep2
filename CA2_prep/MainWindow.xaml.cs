using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA2_prep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> filteredList = new ObservableCollection<Employee>();

        //string[] EmployeeType = {"Employee", "PartTimer", "Contractor" };

        
        //public static int noOfEmployees;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetRandomEmployee()
        {
            string[] firstnames = { "MARY", "PATRICIA", "LINDA", "BARBARA", "ELIZABETH", "JENNIFER", "MARIA", "SUSAN", "MARGARET",
            "DOROTHY", "LISA", "JAMES", "JOHN", "ROBERT", "MICHAEL", "WILLIAM", "DAVID", "RICHARD", "CHARLES", "JOSEPH", "THOMAS", };

            string[] lastnames = { "SMITH", "JOHNSON", "WILLIAMS", "JONES", "BROWN", "DAVIS", "MILLER", "WILSON", "MOORE", "TAYLOR",
            "ANDERSON", "THOMAS", "JACKSON", "WHITE", "HARRIS", "MARTIN", "THOMPSON", "ROBINSON", "CLARK", "LEWIS", "LEE", };

            //Create randome object
            Random rf = new Random();

            //Loop to create 20 Employees
            for (int i=0; i<20; i++)
            {
                int randType = rf.Next(0, 3);

                string randomfirstname = firstnames[rf.Next(0, firstnames.Count())];

                string randomSurname = lastnames[rf.Next(0, lastnames.Count())];

                switch(randType)
                {
                    case 0:
                        Employee e = new Employee()
                        {
                            FirstName = randomfirstname,
                            LastName = randomSurname,
                            Salary = Convert.ToDecimal(rf.Next(20000, 40001))
                        };
                        employees.Add(e);
                        break;

                    case 1:
                        PartTimer p = new PartTimer()
                        {
                            FirstName = randomfirstname,
                            LastName = randomSurname,
                            HourlyRate = Convert.ToDecimal(rf.Next(10, 41)),
                            Hours = rf.Next(10, 21)
                        };
                        employees.Add(p);
                        break;

                    case 2:
                        Contractor c = new Contractor()
                        {
                            FirstName = randomfirstname,
                            LastName = randomSurname,
                            HourlyRate = Convert.ToDecimal(rf.Next(10, 41)),
                            Hours = rf.Next(10, 21),
                            StartDate = DateTime.Now.AddMonths(-rf.Next(13)),
                            EndDate = DateTime.Now.AddMonths(rf.Next(13))

                        };
                        employees.Add(c);
                        break;
                }

            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Random randomFactory = new Random();

            //Create employee pbjects
           GetRandomEmployee();
            SetEmployeeCount();




            //Set listbox source to employee list
            lbxEmployees.ItemsSource = employees;

            
        }

        private void SetEmployeeCount()
        {
           tblkCont.Text = Contractor.ContractorCount.ToString();
            tblkPart.Text = (PartTimer.PartTimerCount - Contractor.ContractorCount).ToString();
            tblkEmp.Text = (Employee.EmpCount - PartTimer.PartTimerCount).ToString();

            
        }

       

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //Clear the filtered list
            filteredList.Clear();

            //deteremine which radio button was selected
            RadioButton selectedButton = sender as RadioButton;
            string selected = selectedButton.Tag.ToString();

            //Ling method
            if (selected.Equals("All"))
                lbxEmployees.ItemsSource = employees;
            //else
            //    lbxEmployees.ItemsSource = employees.Where(emp => emp.GetType().Name.Equals(selected));
            else
            {
                if (selected.Equals("Employee"))
                {
                    foreach (Employee emp in employees)
                    {
                        if (emp is Employee && !(emp is PartTimer) && !(emp is Contractor))
                            filteredList.Add(emp);

                    }

                }
                else if (selected.Equals("PartTimer"))
                {
                    foreach (Employee emp in employees)
                    {
                        if (emp is PartTimer && !(emp is Contractor))
                            filteredList.Add(emp);

                    }
                    lbxEmployees.ItemsSource = filteredList;
                }
                else if (selected.Equals("Contractor"))
                {
                    foreach (Employee emp in employees)
                    {
                        if (emp is Contractor)
                            filteredList.Add(emp);

                    }
                    lbxEmployees.ItemsSource = filteredList;
                }
                lbxEmployees.ItemsSource = null;
                //update display
                lbxEmployees.ItemsSource = filteredList;
            }



        }

        //private void RadioButton_Checked(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
