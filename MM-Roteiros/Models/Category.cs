﻿using System;
using System.Collections.Generic;

namespace MM_Roteiros.Models;

public partial class Category
{
    public byte CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime LastUpdate { get; set; }

    public virtual ICollection<FilmCategory> FilmCategories { get; } = new List<FilmCategory>();
}
