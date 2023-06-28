using System;
using System.Collections.Generic;

namespace MM_Roteiros.Models;

public partial class Language
{
    public byte LanguageId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime LastUpdate { get; set; }

    public virtual ICollection<Film> FilmLanguages { get; } = new List<Film>();

    public virtual ICollection<Film> FilmOriginalLanguages { get; } = new List<Film>();
}
