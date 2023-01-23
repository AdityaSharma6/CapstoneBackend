using System;
namespace capstone2022_backend.Models
{
	public class Event
	{
		public Guid Guid { get; set; }

		public Patient Patient { get; set; }

		public Doctor Doctor { get; set; }

		public string DoctorNotes { get; set; }

		public string PatientNotes { get; set; }

		public List<Diagnostics> ListOfDiagnostics { get; set; }

	}
}

