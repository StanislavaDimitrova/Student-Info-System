using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class StudentData
    {
		public static List<Student> TestStudents
		{
			get
			{
				ResetStudentData();
				return _testStudents;
			}
			set { }
		}
		public static List<Student> _testStudents;
		private static void ResetStudentData()
		{
			_testStudents = new List<Student>();
			_testStudents.Add(new Student("Иван", "Петров", "Иванов", "ФКСТ", "КСИ","Бакалавър", "Заверил", "121217095", 3, 9, 38));
			_testStudents.Add(new Student("Петър", "Иванов", "Димитров", "ФКСТ", "КСИ", "Бакалавър", "Заверил", "121217135", 3, 9, 38));
			_testStudents.Add(new Student("Анджела", "Огнянова", "Ефтимова", "ФКСТ", "КСИ", "Бакалавър", "Заверил", "121217125", 3, 5, 61));
		}
		public static Student IsThereStudent(string facNum)
		{
			StudentInfoContext context = new StudentInfoContext();
			return (from st in context.Students
					where st.fakNum == facNum
					select st).First();
		}
	}
}
