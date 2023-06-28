using System;
using System.Collections.Generic;

namespace MM_Roteiros.Models;

public partial class Customer
{
    public byte CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public bool? Active { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime LastUpdate { get; set; }
}
