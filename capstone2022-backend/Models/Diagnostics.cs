using System;
namespace capstone2022_backend.Models
{
	public class Diagnostics
	{
		public Patient Patient { get; set; }

        public DateTime DataAcquisitionStartTime { get; set; }

		public List<int> AccelerationX { get; set; }

        public List<int> AccelerationY { get; set; }

        public List<int> AccelerationZ { get; set; }

        public List<int> AngularAccelerationX { get; set; }

        public List<int> AngularAccelerationY { get; set; }

        public List<int> AngularAccelerationZ { get; set; }

        public List<int> TimeInterval { get; set; }
    }
}

