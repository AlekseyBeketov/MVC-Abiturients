using System;
using System.Collections.Generic;

namespace MVCAbit.Models;

public partial class Faculty
{
    public int FacultyId { get; set; }

    public string FacultyName { get; set; } = null!;

    public string FacultyTelephone { get; set; } = null!;

    public virtual ICollection<Speciality> Specialities { get; set; } = new List<Speciality>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
