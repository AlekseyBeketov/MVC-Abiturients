using System;
using System.Collections.Generic;

namespace MVCAbit.Models;

public partial class Registration
{
    public int RegId { get; set; }

    public int RegAbiturientId { get; set; }

    public int RegStaffId { get; set; }

    public DateTime RegDate { get; set; }

    public virtual Abiturient RegAbiturient { get; set; } = null!;

    public virtual Staff RegStaff { get; set; } = null!;
}
