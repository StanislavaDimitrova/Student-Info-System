using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentInfoSystem
{
    public class MainWindowVM : ObservableBase
	{
		MainWindow main;
		private Student _student;
		public Student Student
		{
			get { return _student; }
			set
			{
				_student = value;
				RaisePropertyChangedEvent("Student");
			}
		}
		private bool _canEdit = true;
		public bool CanEdit
		{
			get
			{
				return _canEdit;
			}
			set
			{
				_canEdit = value;
				RaisePropertyChangedEvent("CanEdit");
			}
		}
		public MainWindowVM(Student student, MainWindow mainW)
		{
			if (student == null)
			{
			    student = new Student();
				mainW = new MainWindow();
			}
			Student = student;
			main = mainW;
		}
		public ICommand ShowStudentDataCommand
		{
			get { return new RelayCommand(ShowStudentData); }
		}
		public void ShowStudentData()
		{
			main.txtName.Text = Student.name;
			main.txtMName.Text = Student.middleName;
			main.txtLName.Text = Student.lastName;
			main.txtFac.Text = Student.faculty;
			main.txtSpec.Text = Student.specialty;
			main.txtOKS.Text = Student.OKS;
			main.txtFNum.Text = Student.fakNum;
			main.txtCourse.Text = Student.course.ToString();
			main.txtPotok.Text = Student.flow.ToString();
			main.txtGroup.Text = Student.group.ToString();
		}
		public ICommand ClearAllDataCommand
		{
			get { return new RelayCommand(ClearAllData); }
		}
		public void ClearAllData()
		{
			main.txtName.Text = "";
			main.txtMName.Text = "";
			main.txtLName.Text = "";
			main.txtFac.Text = "";
			main.txtSpec.Text = "";
			main.txtOKS.Text = "";
			main.txtFNum.Text = "";
			main.txtCourse.Text = "";
			main.txtPotok.Text = "";
			main.txtGroup.Text = "";
		}
		public ICommand DisableEditingCommand
		{
			get { return new RelayCommand(DisableEditing); }
		}
		public void DisableEditing()
		{
			CanEdit = false;
		}
		public ICommand EnableEditingCommand
		{
			get { return new RelayCommand(EnableEditing); }
		}
		public void EnableEditing()
		{
			CanEdit = true;
		}
	}
}
