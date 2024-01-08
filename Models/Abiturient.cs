using System;
using System.Collections.Generic;

namespace MVCAbit.Models;

public partial class Abiturient
{
    public int AbiturientId { get; set; }

    public int AbiturientSecId { get; set; }

    public string AbiturientSurname { get; set; } = null!;

    public string AbiturientName { get; set; } = null!;

    public string? AbiturientPoBatyushke { get; set; }

    public bool AbiturientGoldMedal { get; set; }

    public bool AbiturientSilverMedal { get; set; }

    public bool AbiturientTechDiplom { get; set; }

    public string AbiturientPhoto { get; set; } = null!;

    public int AbiturientSecYear { get; set; }

    public virtual Secondary AbiturientSec { get; set; } = null!;

    public virtual ICollection<Chosen> Chosens { get; set; } = new List<Chosen>();

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}
