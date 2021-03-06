using System;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int,
        IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        // public DbSet<UserLike> Likes { get; set; }
        public DbSet<Post> Posts {get;set;}
        public DbSet<Message> Messages { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Result> Results { get; set; }

        public DbSet<PostLike> PostLikes  { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Formation> Formations { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Group>()
                .HasMany(x => x.Connections)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();


            builder.Entity<PostLike>()
                    .HasKey(keyExpression=> new { keyExpression.SourceUserId,keyExpression.LikedPostId});
            builder.Entity<PostLike>()
                    .HasOne(s =>s.SourceUser)
                    .WithMany(l =>l.LikedPosts)
                    .HasForeignKey(s =>s.SourceUserId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PostLike>()
                    .HasOne(s =>s.LikedPost)
                    .WithMany(l => l.Postlikes)
                    .HasForeignKey(s => s.LikedPostId)
                    .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<PostComment>()
                    .HasKey(keyExpression => new { keyExpression.SourceUserId, keyExpression.CommentedPostId ,keyExpression.content});
            builder.Entity<PostComment>()
                    .HasOne(s => s.SourceUser)
                    .WithMany(l => l.PostComments)
                    .HasForeignKey(s => s.SourceUserId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PostComment>()
                    .HasOne(s => s.CommentedPost)
                    .WithMany(l => l.PostComments)
                    .HasForeignKey(s => s.CommentedPostId)
                    .OnDelete(DeleteBehavior.Cascade);

            
            builder.Entity<Post>()
                .HasOne(s=>s.Poster)
                .WithMany(s=>s.PostedPosts)
                .HasForeignKey(s=>s.PosterId)
                    .OnDelete(DeleteBehavior.Cascade);

            // builder.Entity<Tag>()
            //     .HasOne(s=>s.)
            //     .WithMany(s=>s.PostTags)
            //     .HasForeignKey(s=>s.Id)
            //         .OnDelete(DeleteBehavior.Cascade);
//    builder.Entity<Post>()
//                 .HasOne(s=>s.Photos)
//                 .WithMany(s=>s.)
//                 .HasForeignKey(s=>s.PosterId)
//                     .OnDelete(DeleteBehavior.Cascade);
                  

            builder.Entity<Message>()
                .HasOne(u => u.Recipient)
                .WithMany(m => m.MessagesReceived)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict);

           builder.Entity<Question>()
               .HasOne(e => e.questionnaire)
               .WithMany(c => c.questions);

            //builder.Entity<Result>()
            //    .HasOne(e => e.userId)
            //    .WithMany(c => c.results);
            builder.Entity<Result>()
       .HasKey(c => new { c.userId, c.domaine , c.creationDate});
            builder.ApplyUtcDateTimeConverter();
        }
    }

    public static class UtcDateAnnotation
    {
        private const String IsUtcAnnotation = "IsUtc";
        private static readonly ValueConverter<DateTime, DateTime> UtcConverter =
          new ValueConverter<DateTime, DateTime>(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        private static readonly ValueConverter<DateTime?, DateTime?> UtcNullableConverter =
          new ValueConverter<DateTime?, DateTime?>(v => v, v => v == null ? v : DateTime.SpecifyKind(v.Value, DateTimeKind.Utc));

        public static PropertyBuilder<TProperty> IsUtc<TProperty>(this PropertyBuilder<TProperty> builder, Boolean isUtc = true) =>
          builder.HasAnnotation(IsUtcAnnotation, isUtc);

        public static Boolean IsUtc(this IMutableProperty property) =>
          ((Boolean?)property.FindAnnotation(IsUtcAnnotation)?.Value) ?? true;

        /// <summary>
        /// Make sure this is called after configuring all your entities.
        /// </summary>
        public static void ApplyUtcDateTimeConverter(this ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (!property.IsUtc())
                    {
                        continue;
                    }

                    if (property.ClrType == typeof(DateTime))
                    {
                        property.SetValueConverter(UtcConverter);
                    }

                    if (property.ClrType == typeof(DateTime?))
                    {
                        property.SetValueConverter(UtcNullableConverter);
                    }
                }
            }
        }
    }
}