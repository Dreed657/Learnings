﻿namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Medicament
    {
        [Key]
        public int MedicamentId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public ICollection<PatientMedicament> Prescriptions { get; set; } = new HashSet<PatientMedicament>();
    }
}
