﻿namespace TeacherApp.Models.ViewModels
{
	public class StudentListViewModel
	{
		public IEnumerable<Student> Students { get; set; }
			= Enumerable.Empty<Student>();
		public PagingInfo PagingInfo { get; set; } = new();

	}
}
