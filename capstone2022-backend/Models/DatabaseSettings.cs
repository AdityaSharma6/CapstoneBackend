using System;
namespace capstone2022_backend.Models
{
	public class DatabaseSettings
	{
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string PatientCollectionName { get; set; } = null!;

        public string DoctorCollectionName { get; set; } = null!;

        public string EventCollectionName { get; set; } = null!;

        public string DiagnosticCollectionName { get; set; } = null!;
    }
}

