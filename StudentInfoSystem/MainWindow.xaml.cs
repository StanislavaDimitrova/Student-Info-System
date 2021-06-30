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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace StudentInfoSystem
{

	public partial class MainWindow : Window
	{
		private StudentInfoContext dbStudentsContext;
		public MainWindow()
		{
			InitializeComponent();

			FillStudStatusChoices();
			this.DataContext = this;
			dbStudentsContext = new StudentInfoContext();
		}
		public List<string> StudStatusChoices { get; set; }

		private void FillStudStatusChoices()
		{
			StudStatusChoices = new List<string>();
			using (IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnect))
			{
				string sqlquery = @"SELECT StatusDescr FROM StudStatus";
				IDbCommand command = new SqlCommand();
				command.Connection = connection;
				connection.Open();
				command.CommandText = sqlquery;
				IDataReader reader = command.ExecuteReader();

				bool notEndOfResult;
				notEndOfResult = reader.Read();
				while (notEndOfResult)
				{
					string s = reader.GetString(0);
					StudStatusChoices.Add(s);
					notEndOfResult = reader.Read();
				}
			}
			txtStatus.ItemsSource = StudStatusChoices;
		}

		public bool TestStudentsIfEmpty()
		{
			IEnumerable<Student> queryStudents = dbStudentsContext.Students;
			int countStudents = queryStudents.Count();

			return countStudents == 0;
		}
		private List<Student> getAllStudents()
		{
			return dbStudentsContext.Students.ToList();
		}
		public void CopyTestStudents()
		{
			foreach (Student st in StudentData.TestStudents)
			{
				dbStudentsContext.Students.Add(st);
			}
			//Промените се записват единствено при извикване на SaveChanges()
			dbStudentsContext.SaveChanges();
		}
		private void IsEmptySt_Click(object sender, RoutedEventArgs e)
		{
			CopyTestStudents();
			bool isEmpty = TestStudentsIfEmpty();
			if (isEmpty)
			{
				MessageBox.Show("Students added successfully");
			}
			else
			{
				MessageBox.Show(isEmpty.ToString());

			}
		}
		public static void DeleteUserByFacultyNumber(string facultyNumber)
		{
			StudentInfoContext dbStudContext = new StudentInfoContext();
			Student student = (from st in dbStudContext.Students
							   where st.faculty == facultyNumber
							   select st).First();
			dbStudContext.Students.Remove(student);
			dbStudContext.SaveChanges();
		}
	}
}