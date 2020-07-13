namespace P01_HospitalDatabase.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Visitation
    {
        [Key] 
        public int VisitationsId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required, MaxLength(250)]
        public string Comments { get; set; }

        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }
    }
}
