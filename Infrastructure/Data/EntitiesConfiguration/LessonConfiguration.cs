using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK__Lessons__3214EC0797457F0C");

        builder.ToTable(tb => tb.HasTrigger("D_U_Lessons"));

        builder.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
        builder.Property(e => e.Description).HasMaxLength(150);
        builder.Property(e => e.Title).HasMaxLength(150);
        builder.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetime())");

        builder.HasMany(d => d.Articles).WithMany(p => p.Lessons)
            .UsingEntity<Dictionary<string, object>>(
                "LessonArticle",
                r => r.HasOne<Article>().WithMany()
                    .HasForeignKey("ArticleId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LessonArt__Artic__08B54D69"),
                l => l.HasOne<Lesson>().WithMany()
                    .HasForeignKey("LessonId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LessonArt__Lesso__07C12930"),
                j =>
                {
                    j.HasKey("LessonId", "ArticleId").HasName("PK__LessonAr__29428BDE00EB3234");
                    j.ToTable("LessonArticle");
                });

        builder.HasMany(d => d.Ebooks).WithMany(p => p.Lessons)
            .UsingEntity<Dictionary<string, object>>(
                "LessonEbook",
                r => r.HasOne<Ebook>().WithMany()
                    .HasForeignKey("EbookId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LessonEBo__EBook__0A9D95DB"),
                l => l.HasOne<Lesson>().WithMany()
                    .HasForeignKey("LessonId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LessonEBo__Lesso__09A971A2"),
                j =>
                {
                    j.HasKey("LessonId", "EbookId").HasName("PK__LessonEB__47441B8FD5F2B363");
                    j.ToTable("LessonEBook");
                    j.IndexerProperty<int>("EbookId").HasColumnName("EBookId");
                });

        builder.HasMany(d => d.Rewards).WithMany(p => p.Lessons)
            .UsingEntity<Dictionary<string, object>>(
                "LessonReward",
                r => r.HasOne<Reward>().WithMany()
                    .HasForeignKey("RewardId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LessonRew__Rewar__0C85DE4D"),
                l => l.HasOne<Lesson>().WithMany()
                    .HasForeignKey("LessonId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LessonRew__Lesso__0B91BA14"),
                j =>
                {
                    j.HasKey("LessonId", "RewardId").HasName("PK__LessonRe__38A1AD8B59E27149");
                    j.ToTable("LessonReward");
                });

        builder.HasMany(d => d.Videos).WithMany(p => p.Lessons)
            .UsingEntity<Dictionary<string, object>>(
                "LessonVideo",
                r => r.HasOne<Video>().WithMany()
                    .HasForeignKey("VideoId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LessonVid__Video__0E6E26BF"),
                l => l.HasOne<Lesson>().WithMany()
                    .HasForeignKey("LessonId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LessonVid__Lesso__0D7A0286"),
                j =>
                {
                    j.HasKey("LessonId", "VideoId").HasName("PK__LessonVi__0B2AFDF6799ED9DF");
                    j.ToTable("LessonVideo");
                });
    }
}
