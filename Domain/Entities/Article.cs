﻿namespace Domain.Entities;

public partial class Article
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Link { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
