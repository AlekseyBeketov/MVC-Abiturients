using System;
using System.Collections.Generic;

namespace MVCAbit.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public string AddressCity { get; set; } = null!;

    public string AddressStreet { get; set; } = null!;

    public int AddressHomeNum { get; set; }
}
