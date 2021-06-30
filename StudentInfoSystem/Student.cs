using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
		public string name { get; set; }
		public string middleName { get; set; }
		public string lastName { get; set; }
		public string faculty { get; set; }
		public string specialty { get; set; }
		public string OKS { get; set; }
		public string status { get; set; } //заверил, прекъснал, семестриално завършил..
		public string fakNum { get; set; }
		public int course { get; set; }
		public int flow { get; set; }
		public int group { get; set; }
		public int StudentId { get; set; }
		public Student(string fname, string mName, string lName, string fac, string spec, string lvl,
			string status, string fNum, int course, int flow, int group)
		{
			this.name = fname;
			this.middleName = mName;
			this.lastName = lName;
			this.faculty = fac;
			this.specialty = spec;
			this.OKS = lvl;
			this.status = status;
			this.fakNum = fNum;
			this.course = course;
			this.flow = flow;
			this.group = group;
		}
		public Student() { }
	}
}
