using System;
using System.Windows;
using System.Windows.Forms;

namespace Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WPFLabEntities1 wpfLabEntities = new WPFLabEntities1();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            User user = new User();

            user.FName = FName.Text;
            user.LName = LName.Text;
            user.Gender = Gender.Text;
            user.Address = Address.Text;
            user.Phone = Phone.Text;
            user.Mobile = Mobile.Text;
            user.Email = Email.Text;
            user.JobTitle = JobTitle.Text;

            string message = $"Do you want to insert this User?\nName: {FName.Text} {LName.Text}";
            string title = "New User";
            MessageBoxButton buttons = MessageBoxButton.OKCancel;
            DialogResult result = System.Windows.Forms.MessageBox.Show(message, title, (MessageBoxButtons)buttons);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                wpfLabEntities.Users.Add(user);
                wpfLabEntities.SaveChanges();
            }
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            foreach (var con in mainGrid.Children)
            {
                if (con.GetType() == typeof(TextBox))
                    ((TextBox)con).Text = String.Empty;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
