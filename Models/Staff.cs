using System;
using System.Collections.Generic;

namespace MVCAbit.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public int StaffFacId { get; set; }

    public string StaffSurname { get; set; } = null!;

    public string StaffName { get; set; } = null!;

    public string? StaffPoBatyushke { get; set; }

    public string StaffPart { get; set; } = null!;

    public virtual Auth? Auth { get; set; }

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();

    public virtual Faculty StaffFac { get; set; } = null!;
}
