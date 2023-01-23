using System;
using MongoDB.Bson.Serialization.Attributes;

namespace capstone2022_backend.Models
{
	public class Doctor : Person
	{
        [BsonElement("clinicAddress")]
        public string ClinicAddress { get; set; }

        [BsonElement("ListOfPatients")]
        public List<string> ListOfPatients { get; set; }
	}
}

