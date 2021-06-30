using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
	public class StudentValidation
	{
		public static Student GetStudentDataByUser(User user)
		{
			foreach (Student student in StudentData.TestStudents)
			{
				if (user.fNum == student.fakNum)
				{
					return student;
				}
			}
			return null;
		}
	}
}
