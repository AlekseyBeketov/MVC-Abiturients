using System;
using System.Collections.Generic;

namespace MVCAbit.Models;

public partial class Secondary
{
    public int SecondaryId { get; set; }

    public string SecondaryName { get; set; } = null!;

    public int SecondaryNumber { get; set; }

    public string SecondaryCity { get; set; } = null!;

    public virtual ICollection<Abiturient> Abiturients { get; set; } = new List<Abiturient>();
}
