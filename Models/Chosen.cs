using System;
using System.Collections.Generic;

namespace MVCAbit.Models;

public partial class Chosen
{
    public int ChosenId { get; set; }

    public int ChosenAbId { get; set; }

    public int ChosenSpecId { get; set; }

    public int ChosenFirstExam { get; set; }

    public int ChosenSecondExam { get; set; }

    public int ChosenThirdExam { get; set; }

    public virtual Abiturient ChosenAb { get; set; } = null!;

    public virtual Speciality ChosenSpec { get; set; } = null!;
}
