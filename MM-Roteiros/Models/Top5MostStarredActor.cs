using System;
using System.Collections.Generic;

namespace MM_Roteiros.Models;

public partial class Top5MostStarredActor
{
    public int ActorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int? Total { get; set; }
}
