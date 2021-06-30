using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentInfoSystem
{
	public class RelayCommand : ICommand
	{
		private readonly Action _action;
		private Action<MainWindow> _showStudentData;

		public RelayCommand(Action action)
		{
			_action = action;
		}

		public RelayCommand(Action<MainWindow> showStudentData)
		{
			_showStudentData = showStudentData;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			_action();
		}

		public event EventHandler CanExecuteChanged { add { } remove { } }
	}
}
