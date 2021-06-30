using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
		public static void ShowActionErrorMessage(string errMsg)
		{
			Console.WriteLine( errMsg + " !!");
		}
		static public MainWindow mainWindow = new MainWindow();
		private void OK_Click(object sender, RoutedEventArgs e)
		{
			User newUser = new User(txtUsername.Text, txtPassword.Password.ToString(), "", 4);

			LoginValidation validation = new LoginValidation(txtUsername.Text, txtPassword.Password.ToString(), ShowActionErrorMessage);

			if (validation.ValidateUserInput(ref newUser))
			{
				Student student = StudentValidation.GetStudentDataByUser(newUser);
				MainWindowVM mainViewModel = new MainWindowVM(student, mainWindow);

				mainWindow.DataContext = mainViewModel;
				mainWindow.Show();
				this.Close();
			}
			else
			{
				ResetInputFields();
			}
		}
		private void ResetInputFields()
		{
			MessageBox.Show("Няма потребител с тези данни", "Внимание", MessageBoxButton.OK);
			TextBox usernameBox = txtUsername;
			usernameBox.Clear();
			PasswordBox passwordBox = txtPassword;
			passwordBox.Clear();
		}
	}
}
