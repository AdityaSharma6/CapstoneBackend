using System;
namespace capstone2022_backend.Models
{
	public class Doctor : Person
	{
		public string ClinicAddress { get; set; }

		public List<Guid> ListOfPatients { get; set; }
	}
}

