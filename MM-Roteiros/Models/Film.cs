using System;
using System.Collections.Generic;

namespace MM_Roteiros.Models;

public partial class Film
{
    public int FilmId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? ReleaseYear { get; set; }

    public byte LanguageId { get; set; }

    public byte? OriginalLanguageId { get; set; }

    public short? Length { get; set; }

    public string? Rating { get; set; }

    public DateTime LastUpdate { get; set; }

    public virtual ICollection<FilmActor> FilmActors { get; } = new List<FilmActor>();

    public virtual ICollection<FilmCategory> FilmCategories { get; } = new List<FilmCategory>();

    public virtual Language Language { get; set; } = null!;

    public virtual Language? OriginalLanguage { get; set; }
}
