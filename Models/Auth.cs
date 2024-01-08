using System;
using System.Collections.Generic;

namespace MVCAbit.Models;

public partial class Auth
{
    public int AuthStaffId { get; set; }

    public string AuthLogin { get; set; } = null!;

    public string AuthPass { get; set; } = null!;

    public virtual Staff AuthStaff { get; set; } = null!;
}
