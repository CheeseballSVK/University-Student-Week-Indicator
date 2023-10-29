using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace UniWeekDisplay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int selectedInt;
        private String selectedMonth;
        private int selectedMonth_int;
        private int weeksPassed;
        private bool isblack;
        private readonly System.Windows.Forms.NotifyIcon _notifyIcon;

        public MainWindow()
        {
            InitializeComponent();
            
            _notifyIcon = new System.Windows.Forms.NotifyIcon();
            _notifyIcon.Click += NotifyIcon_Click;
            var contextMenu = new ContextMenuStrip();
            var exitMenuItem = new ToolStripMenuItem("Exit");
            exitMenuItem.Click += (sender, e) =>
            {
                // Handle the "Exit" action here
                // You can also perform any cleanup or save state here before exiting
                System.Windows.Application.Current.Shutdown();
            };
            _notifyIcon.ContextMenuStrip = contextMenu;

            contextMenu.Items.Add(exitMenuItem);
            ResizeMode = ResizeMode.NoResize;
            cb1.Items.Add(1);
            cb1.Items.Add(2);
            cb1.Items.Add(3);
            cb1.Items.Add(4);
            cb1.Items.Add(5);
            cb1.Items.Add(6);
            cb1.Items.Add(7);
            cb1.Items.Add(8);
            cb1.Items.Add(9);
            cb1.Items.Add(10);
            cb1.Items.Add(11);
            cb1.Items.Add(12);
            cb1.Items.Add(13);
            cb1.Items.Add(14);
            cb1.Items.Add(15);
            cb1.Items.Add(16);
            cb1.Items.Add(17);
            cb1.Items.Add(18);
            cb1.Items.Add(19);
            cb1.Items.Add(20);
            cb1.Items.Add(21);
            cb1.Items.Add(22);
            cb1.Items.Add(23);
            cb1.Items.Add(24);
            cb1.Items.Add(25);
            cb1.Items.Add(26);
            cb1.Items.Add(27);
            cb1.Items.Add(28);
            cb1.Items.Add(29);
            cb1.Items.Add(30);
            cb1.SelectedIndex = 0;
            cb2.Items.Add("January");
            cb2.Items.Add("February");
            cb2.Items.Add("March");
            cb2.Items.Add("April");
            cb2.Items.Add("May");
            cb2.Items.Add("June");
            cb2.Items.Add("July");
            cb2.Items.Add("August");
            cb2.Items.Add("September");
            cb2.Items.Add("October");
            cb2.Items.Add("November");
            cb2.Items.Add("December");
            cb2.SelectedIndex = 0;
            //String semester = "ZS";

            selectedInt = Properties.Settings.Default.SelectedInt;
            selectedMonth = Properties.Settings.Default.SelectedMonth;
            selectedMonth_int = Properties.Settings.Default.SelectedMonth_int;
            weeksPassed = Properties.Settings.Default.weeksPassed;
            isblack = Properties.Settings.Default.isblack;
            
            cb1.SelectedItem = selectedInt;
            cb2.SelectedItem = selectedMonth;

            error_box.Text = "";
            week.Text = "X";
            week.Text = weeksPassed.ToString();
            if (isblack == true)
            {
                black.IsChecked = true;
            }
            else
            {
                black.IsChecked = false;
            }

        }
        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            // Show the main window when the NotifyIcon is clicked
            this.Show();
            this.WindowState = WindowState.Normal;
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;  // Prevent the window from closing
            this.Hide();      // Hide the window instead
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Windows.Controls.ComboBox comboBox = (System.Windows.Controls.ComboBox)sender;

            // Check if an item is selected
            if (comboBox.SelectedItem != null)
            {
                // Convert the selected item to an integer
                if (int.TryParse(comboBox.SelectedItem.ToString(), out selectedInt))
                {
                    //week.Text = selectedInt.ToString();
                    // You now have the selected integer value in the selectedInt variable.
                    // You can use it as needed.
                    //System.Windows.MessageBox.Show($"Selected starting date of semester is: {selectedInt} of Sept");
                    
                    selectedMonth = Properties.Settings.Default.SelectedMonth;
                    selectedMonth_int = Properties.Settings.Default.SelectedMonth_int;
                    DateTime CurrentDate = DateTime.Now;
                    DateTime SelectedDate = new DateTime(CurrentDate.Year, selectedMonth_int, selectedInt);
                    TimeSpan timeDifference = CurrentDate-SelectedDate;
                    int weeksPassed = (int)Math.Floor((timeDifference.TotalDays / 7)+1);
                    if (weeksPassed > 12)
                    {
                        weeksPassed = 13;
                    }
                    week.Text = weeksPassed.ToString();
                    isblack = Properties.Settings.Default.isblack;
                    if (isblack == true && weeksPassed == 1)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/1.ico");
                    }
                    else if (isblack == true && weeksPassed == 2)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/2.ico");
                    }
                    else if (isblack == true && weeksPassed == 3)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/3.ico");
                    }
                    else if (isblack == true && weeksPassed == 4)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/4.ico");
                    }
                    else if (isblack == true && weeksPassed == 5)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/5.ico");
                    }
                    else if (isblack == true && weeksPassed == 6)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/6.ico");
                    }
                    else if (isblack == true && weeksPassed == 7)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/7.ico");
                    }
                    else if (isblack == true && weeksPassed == 8)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/8.ico");
                    }
                    else if (isblack == true && weeksPassed == 9)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/9.ico");
                    }
                    else if (isblack == true && weeksPassed == 10)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/10.ico");
                    }
                    else if (isblack == true && weeksPassed == 11)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/11.ico");
                    }
                    else if (isblack == true && weeksPassed == 12)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/12.ico");
                    }
                    else if (isblack == true && weeksPassed == 13)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/13.ico");
                    }
                    else if (isblack == false && weeksPassed == 1)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/1.ico");
                    }
                    else if (isblack == false && weeksPassed == 2)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/2.ico");
                    }
                    else if (isblack == false && weeksPassed == 3)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/3.ico");
                    }
                    else if (isblack == false && weeksPassed == 4)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/4.ico");
                    }
                    else if (isblack == false && weeksPassed == 5)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/5.ico");
                    }
                    else if (isblack == false && weeksPassed == 6)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/6.ico");
                    }
                    else if (isblack == false && weeksPassed == 7)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/7.ico");
                    }
                    else if (isblack == false && weeksPassed == 8)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/8.ico");
                    }
                    else if (isblack == false && weeksPassed == 9)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/9.ico");
                    }
                    else if (isblack == false && weeksPassed == 10)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/10.ico");
                    }
                    else if (isblack == false && weeksPassed == 11)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/11.ico");
                    }
                    else if (isblack == false && weeksPassed == 12)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/12.ico");
                    }
                    else if (isblack == false && weeksPassed == 13)
                    {
                        _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/13.ico");
                    }
                    _notifyIcon.Visible = true;
                    Properties.Settings.Default.weeksPassed = weeksPassed;
                    Properties.Settings.Default.SelectedInt = selectedInt;
                    Properties.Settings.Default.Save();
                }
            }

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            System.Windows.Controls.ComboBox comboBox = (System.Windows.Controls.ComboBox)sender;

            // Check if an item is selected
            if (comboBox.SelectedItem != null)
            {
                string selectedMonth = comboBox.SelectedItem.ToString();
                //week.Text = selectedInt.ToString();
                // You now have the selected integer value in the selectedInt variable.
                // You can use it as needed.
                //System.Windows.MessageBox.Show($"Selected starting date of semester is: {selectedInt} of Sept");
                int selectedMonth_int = 1;
                switch (selectedMonth)
                {
                    case "January":
                        selectedMonth_int = 1;
                        break;
                    case "February":
                        selectedMonth_int = 2;
                        break;
                    case "March":
                        selectedMonth_int = 3;
                        break;
                    case "April":
                        selectedMonth_int = 4;
                        break;
                    case "May":
                        selectedMonth_int = 5;
                        break;
                    case "June":
                        selectedMonth_int = 6;
                        break;
                    case "July":
                        selectedMonth_int = 7;
                        break;
                    case "August":
                        selectedMonth_int = 8;
                        break;
                    case "September":
                        selectedMonth_int = 9;
                        break;
                    case "October":
                        selectedMonth_int = 10;
                        break;
                    case "November":
                        selectedMonth_int = 11;
                        break;
                    case "December":
                        selectedMonth_int = 12;
                        break;
                
                }
                selectedInt = Properties.Settings.Default.SelectedInt;
                DateTime CurrentDate = DateTime.Now;
                DateTime SelectedDate = new DateTime(CurrentDate.Year, selectedMonth_int, selectedInt);
                TimeSpan timeDifference = CurrentDate - SelectedDate;
                int weeksPassed = (int)Math.Floor((timeDifference.TotalDays / 7) + 1);
                if (weeksPassed > 12)
                {
                    weeksPassed = 13;
                }
                week.Text = weeksPassed.ToString();

                isblack = Properties.Settings.Default.isblack;
                if (isblack == true && weeksPassed == 1)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/1.ico");
                }
                else if (isblack == true && weeksPassed == 2)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/2.ico");
                }
                else if (isblack == true && weeksPassed == 3)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/3.ico");
                }
                else if (isblack == true && weeksPassed == 4)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/4.ico");
                }
                else if (isblack == true && weeksPassed == 5)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/5.ico");
                }
                else if (isblack == true && weeksPassed == 6)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/6.ico");
                }
                else if (isblack == true && weeksPassed == 7)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/7.ico");
                }
                else if (isblack == true && weeksPassed == 8)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/8.ico");
                }
                else if (isblack == true && weeksPassed == 9)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/9.ico");
                }
                else if (isblack == true && weeksPassed == 10)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/10.ico");
                }
                else if (isblack == true && weeksPassed == 11)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/11.ico");
                }
                else if (isblack == true && weeksPassed == 12)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/12.ico");
                }
                else if (isblack == true && weeksPassed == 13)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/13.ico");
                }
                else if (isblack == false && weeksPassed == 1)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/1.ico");
                }
                else if (isblack == false && weeksPassed == 2)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/2.ico");
                }
                else if (isblack == false && weeksPassed == 3)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/3.ico");
                }
                else if (isblack == false && weeksPassed == 4)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/4.ico");
                }
                else if (isblack == false && weeksPassed == 5)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/5.ico");
                }
                else if (isblack == false && weeksPassed == 6)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/6.ico");
                }
                else if (isblack == false && weeksPassed == 7)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/7.ico");
                }
                else if (isblack == false && weeksPassed == 8)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/8.ico");
                }
                else if (isblack == false && weeksPassed == 9)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/9.ico");
                }
                else if (isblack == false && weeksPassed == 10)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/10.ico");
                }
                else if (isblack == false && weeksPassed == 11)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/11.ico");
                }
                else if (isblack == false && weeksPassed == 12)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/12.ico");
                }
                else if (isblack == false && weeksPassed == 13)
                {
                    _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/13.ico");
                }
                _notifyIcon.Visible = true;








                //error_box.Text = selectedMonth_int.ToString();
                Properties.Settings.Default.weeksPassed = weeksPassed;
                Properties.Settings.Default.SelectedMonth = selectedMonth;
                Properties.Settings.Default.SelectedMonth_int = selectedMonth_int;
                Properties.Settings.Default.Save();
                
            }
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            weeksPassed = Properties.Settings.Default.weeksPassed;
            isblack = true;
            if (isblack == true && weeksPassed == 1)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/1.ico");
            }
            else if (isblack == true && weeksPassed == 2)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/2.ico");
            }
            else if (isblack == true && weeksPassed == 3)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/3.ico");
            }
            else if (isblack == true && weeksPassed == 4)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/4.ico");
            }
            else if (isblack == true && weeksPassed == 5)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/5.ico");
            }
            else if (isblack == true && weeksPassed == 6)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/6.ico");
            }
            else if (isblack == true && weeksPassed == 7)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/7.ico");
            }
            else if (isblack == true && weeksPassed == 8)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/8.ico");
            }
            else if (isblack == true && weeksPassed == 9)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/9.ico");
            }
            else if (isblack == true && weeksPassed == 10)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/10.ico");
            }
            else if (isblack == true && weeksPassed == 11)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/11.ico");
            }
            else if (isblack == true && weeksPassed == 12)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/12.ico");
            }
            else if (isblack == true && weeksPassed == 13)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/13.ico");
            }
            else if (isblack == false && weeksPassed == 1)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/1.ico");
            }
            else if (isblack == false && weeksPassed == 2)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/2.ico");
            }
            else if (isblack == false && weeksPassed == 3)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/3.ico");
            }
            else if (isblack == false && weeksPassed == 4)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/4.ico");
            }
            else if (isblack == false && weeksPassed == 5)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/5.ico");
            }
            else if (isblack == false && weeksPassed == 6)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/6.ico");
            }
            else if (isblack == false && weeksPassed == 7)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/7.ico");
            }
            else if (isblack == false && weeksPassed == 8)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/8.ico");
            }
            else if (isblack == false && weeksPassed == 9)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/9.ico");
            }
            else if (isblack == false && weeksPassed == 10)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/10.ico");
            }
            else if (isblack == false && weeksPassed == 11)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/11.ico");
            }
            else if (isblack == false && weeksPassed == 12)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/12.ico");
            }
            else if (isblack == false && weeksPassed == 13)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/13.ico");
            }
            _notifyIcon.Visible = true;
            Properties.Settings.Default.isblack = isblack;
            Properties.Settings.Default.Save();
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            weeksPassed = Properties.Settings.Default.weeksPassed;
            isblack = false;
            if (isblack == true && weeksPassed == 1)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/1.ico");
            }
            else if (isblack == true && weeksPassed == 2)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/2.ico");
            }
            else if (isblack == true && weeksPassed == 3)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/3.ico");
            }
            else if (isblack == true && weeksPassed == 4)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/4.ico");
            }
            else if (isblack == true && weeksPassed == 5)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/5.ico");
            }
            else if (isblack == true && weeksPassed == 6)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/6.ico");
            }
            else if (isblack == true && weeksPassed == 7)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/7.ico");
            }
            else if (isblack == true && weeksPassed == 8)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/8.ico");
            }
            else if (isblack == true && weeksPassed == 9)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/9.ico");
            }
            else if (isblack == true && weeksPassed == 10)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/10.ico");
            }
            else if (isblack == true && weeksPassed == 11)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/11.ico");
            }
            else if (isblack == true && weeksPassed == 12)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/12.ico");
            }
            else if (isblack == true && weeksPassed == 13)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/Black/13.ico");
            }
            else if (isblack == false && weeksPassed == 1)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/1.ico");
            }
            else if (isblack == false && weeksPassed == 2)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/2.ico");
            }
            else if (isblack == false && weeksPassed == 3)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/3.ico");
            }
            else if (isblack == false && weeksPassed == 4)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/4.ico");
            }
            else if (isblack == false && weeksPassed == 5)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/5.ico");
            }
            else if (isblack == false && weeksPassed == 6)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/6.ico");
            }
            else if (isblack == false && weeksPassed == 7)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/7.ico");
            }
            else if (isblack == false && weeksPassed == 8)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/8.ico");
            }
            else if (isblack == false && weeksPassed == 9)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/9.ico");
            }
            else if (isblack == false && weeksPassed == 10)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/10.ico");
            }
            else if (isblack == false && weeksPassed == 11)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/11.ico");
            }
            else if (isblack == false && weeksPassed == 12)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/12.ico");
            }
            else if (isblack == false && weeksPassed == 13)
            {
                _notifyIcon.Icon = new System.Drawing.Icon("Resources/White/13.ico");
            }
            _notifyIcon.Visible = true;
            Properties.Settings.Default.isblack = isblack;
            Properties.Settings.Default.Save();
        }
    }
}
