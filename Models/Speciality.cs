using System;
using System.Collections.Generic;

namespace MVCAbit.Models;

public partial class Speciality
{
    public int SpecId { get; set; }

    public int SpecFacId { get; set; }

    public string SpecName { get; set; } = null!;

    public string SpecFirstExam { get; set; } = null!;

    public string SpecSecondExam { get; set; } = null!;

    public string SpecThirdExam { get; set; } = null!;

    public virtual ICollection<Chosen> Chosens { get; set; } = new List<Chosen>();

    public virtual Faculty SpecFac { get; set; } = null!;
}
