using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1
{
	public class ParentParameters
	{
		public List<Student> Students { get; set; }

		public ParentParameters()
		{
			Students = new List<Student>
			           {
				           new Student { Id = 1, Name = "A", FirstName = "AA", Age = 15 },
				           new Student { Id = 2, Name = "B", FirstName = "BB", Age = 14 },
				           new Student { Id = 3, Name = "C", FirstName = "CC", Age = 16 }
					   };

		}
	}

	public class Student
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string FirstName { get; set; }
		public int Age { get; set; }
	}
}
